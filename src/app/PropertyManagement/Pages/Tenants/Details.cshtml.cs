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

namespace PropertyManagement.Pages.Tenants
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly data.context.FSPropertyManagementContext _context;

        public DetailsModel(data.context.FSPropertyManagementContext context)
        {
            _context = context;
        }

        public Tenant Tenant { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tenant = await _context.Tenants
                .Include(t => t.Unit).FirstOrDefaultAsync(m => m.Id == id);

            if (Tenant == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
