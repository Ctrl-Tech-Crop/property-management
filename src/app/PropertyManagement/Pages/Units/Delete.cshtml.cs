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
using System.ComponentModel.DataAnnotations;

namespace PropertyManagement.Pages.Units
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly data.context.FSPropertyManagementContext _context;

        public DeleteModel(data.context.FSPropertyManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Unit Unit { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Unit number is required")]
        public string Number { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Unit = await _context.Units
                .Include(u => u.Property)
                .Include(u => u.UnitType).FirstOrDefaultAsync(m => m.Id == id);

            if (Unit == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            Unit = await _context.Units.Where(x => x.Id == id)
                                       .Include(t => t.Tenants).FirstOrDefaultAsync();

            if (Unit == null)
                return NotFound();

            if (Number != Unit.Number)
            {
                ModelState.AddModelError("Number", "Number does not match");
                return Page();
            }

            if (Unit != null)
            {
                foreach (Tenant tenant in Unit.Tenants)
                    _context.Tenants.Remove(tenant);

                _context.Units.Remove(Unit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
