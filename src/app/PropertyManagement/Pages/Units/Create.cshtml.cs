using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using data.context;
using data.models;
using Microsoft.AspNetCore.Authorization;

namespace PropertyManagement.Pages.Units
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly data.context.FSPropertyManagementContext _context;

        public CreateModel(data.context.FSPropertyManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var property = _context.Properties.Find(id);
            if (property == null)
                Redirect("/Error");
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "AddressLine1", id);
            ViewData["UnitTypeId"] = new SelectList(_context.PropertyTypes, "Id", "Name");
            Property = property;
            return Page();
        }

        [BindProperty]
        public Unit Unit { get; set; }
        public Property Property { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (!ModelState.IsValid && id == null)
            {
                return Page();
            }

            // Unit.PropertyId = (Guid)id;
            Unit.PropertyId = (Guid)id;
            _context.Units.Add(Unit);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Properties/Details", new { id = Unit.PropertyId });
        }
    }
}
