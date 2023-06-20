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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesTool.Data.RazorPagesToolContext _context;

        public DetailsModel(RazorPagesTool.Data.RazorPagesToolContext context)
        {
            _context = context;
        }

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
    }
}
