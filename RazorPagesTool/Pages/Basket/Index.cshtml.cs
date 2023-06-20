using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesTool.Models;

namespace RazorPagesTool.Pages.Basket
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesTool.Data.RazorPagesToolContext _context;

        public IndexModel(RazorPagesTool.Data.RazorPagesToolContext context)
        {
            _context = context;
        }
        public IList<Tool> Tool { get; set; } = default!;
        public SelectList? Title { get; set; }
        public decimal TotalPrice { get; set; } = 0m;
        public async Task<IActionResult> OnGetAsync()
        {
            var tools = _context.Baskets.Include(b => b.Tools).First().Tools;

            if (tools == null)
            {
                return NotFound();
            }
            else
            {
                Tool = tools;
            }

            foreach (var tool in tools)
                TotalPrice += tool.Price;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string delete)
        {
            var basket = await _context.Baskets.Include(b => b.Tools).FirstAsync();
            if (id != null && delete.ToLower() == "true")
            {
                if (basket != null)
                {
                    basket.Tools.Remove(basket.Tools.First(t => t.Id == id));
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                foreach(var tool in basket.Tools)
                {
                    tool.Count -= 1;
                }
                await _context.SaveChangesAsync();

                basket.Tools.Clear();
                await _context.SaveChangesAsync();
            }


            return Redirect("/Basket/Index");
        }
    }
}
