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
    public class DetailsModel : PageModel
    {
        private readonly data.context.FSPropertyManagementContext _context;

        public DetailsModel(data.context.FSPropertyManagementContext context)
        {
            _context = context;
        }

        public Unit Unit { get; set; }
        public List<Tenant> Tenant { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Unit = await _context.Units
                .Include(u => u.Property)
                .Include(u => u.UnitType).FirstOrDefaultAsync(m => m.Id == id);

            Tenant = await _context.Tenants
                .Include(t => t.Unit)
                .Where(t => t.UnitId == id).ToListAsync();


            if (Unit == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
