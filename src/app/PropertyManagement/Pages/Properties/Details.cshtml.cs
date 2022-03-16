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

namespace PropertyManagement.Pages.Properties
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly data.context.FSPropertyManagementContext _context;

        public DetailsModel(data.context.FSPropertyManagementContext context)
        {
            _context = context;

        }

        public Property Property { get; set; }
        public IList<Unit> Unit { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Property = await _context.Properties
                .FirstOrDefaultAsync(m => m.Id == id);

            Unit = await _context.Units
                .Include(u => u.Property)
                .Include(u => u.UnitType)
                .Where(u => u.PropertyId == id)
                .ToListAsync();

            if (Property == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
