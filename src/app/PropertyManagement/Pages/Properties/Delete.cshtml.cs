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
using Microsoft.AspNetCore.Html;

namespace PropertyManagement.Pages.Properties
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly data.context.FSPropertyManagementContext _context;

        public DeleteModel(data.context.FSPropertyManagementContext context)
        {
            _context = context;
        }
        public Property Property { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Property name is required")]
        public string PropertyName { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Property = await _context.Properties
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Property == null)
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
            Property = await _context.Properties.Where(x => x.Id == id)
                                                .Include(x => x.Units)
                                                .ThenInclude(y => y.Tenants).FirstOrDefaultAsync();

            if (Property == null)
                return NotFound();

            if (string.IsNullOrEmpty(PropertyName))
            {

                return Page();
            }
            if (PropertyName != Property.Name)
            {
                ModelState.AddModelError("PropertyName", "Property name does not match");
                return Page();
            }
            foreach (Unit unit in Property.Units)
                _context.Tenants.RemoveRange(unit.Tenants);

            _context.Units.RemoveRange(Property.Units);
            _context.Properties.Remove(Property);
            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }
    }
}
