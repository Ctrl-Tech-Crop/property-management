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

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Property = await _context.Properties
                .Include(x => x.PropertyType).FirstOrDefaultAsync(m => m.Id == id);

            if (Property == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
