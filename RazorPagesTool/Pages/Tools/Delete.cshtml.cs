using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTool.Data;
using RazorPagesTool.Models;

namespace RazorPagesTool.Pages.Tools
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesTool.Data.RazorPagesToolContext _context;

        public DeleteModel(RazorPagesTool.Data.RazorPagesToolContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Tool Tool { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tools == null)
            {
                return NotFound();
            }

            var tool = await _context.Tools.FirstOrDefaultAsync(m => m.Id == id);

            if (tool == null)
            {
                return NotFound();
            }
            else 
            {
                Tool = tool;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Tools == null)
            {
                return NotFound();
            }
            var tool = await _context.Tools.FindAsync(id);

            if (tool != null)
            {
                Tool = tool;
                if (Tool.Count > 0)
                {
                    var basket = await _context.Baskets.FirstAsync();

                    if (basket != null)
                    {
                        basket.Tools.Add(tool);
                        await  _context.SaveChangesAsync();
                    }
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
