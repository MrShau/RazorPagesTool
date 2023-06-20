using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesTool.Data;
using RazorPagesTool.Models;

namespace RazorPagesTool.Pages.Tools
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesTool.Data.RazorPagesToolContext _context;

        public IndexModel(RazorPagesTool.Data.RazorPagesToolContext context)
        {
            _context = context;
        }

        public IList<Tool> Tool { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Title { get; set; }
        public async Task OnGetAsync()
        {
            var tools = from m in _context.Tools
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                tools = tools.Where(s => s.Title.Contains(SearchString));
            }

            Tool = await tools.ToListAsync();   
        }
    }
}
