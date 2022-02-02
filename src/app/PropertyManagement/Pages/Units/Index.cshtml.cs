using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using data.context;
using data.models;
using Microsoft.AspNetCore.Authorization;

namespace PropertyManagement.Pages.Units
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly data.context.FSPropertyManagementContext _context;

        public IndexModel(data.context.FSPropertyManagementContext context)
        {
            _context = context;
        }

        public IList<Unit> Unit { get; set; }

        public async Task OnGetAsync()
        {
            Unit = await _context.Units
                .Include(u => u.Property)
                .Include(u => u.UnitType).ToListAsync();
        }
    }
}
