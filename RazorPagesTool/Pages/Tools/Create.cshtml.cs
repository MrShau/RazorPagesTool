using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesTool.Data;
using RazorPagesTool.Models;

namespace RazorPagesTool.Pages.Tools
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesTool.Data.RazorPagesToolContext _context;

        public CreateModel(RazorPagesTool.Data.RazorPagesToolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Tool Tool { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Tools == null || Tool == null)
            {
                return Page();
            }

            _context.Tools.Add(Tool);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
