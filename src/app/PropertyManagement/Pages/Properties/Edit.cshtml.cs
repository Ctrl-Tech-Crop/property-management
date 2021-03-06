using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using data.context;
using data.models;
using Microsoft.AspNetCore.Authorization;
using PropertyManagement.Helpers;

namespace PropertyManagement.Pages.Properties
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly data.context.FSPropertyManagementContext _context;

        public EditModel(data.context.FSPropertyManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Property Property { get; set; }

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
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "Id", "Name");
            ViewData["Provinces"] = new SelectList(StaticDataHelper.GetCanadianProvinces(), "Abbreviation", "Name", Property.Province);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Property.TotalVacantUnits > Property.TotalUnits)
            {
                ModelState.AddModelError("Property.TotalVacantUnits", "Value can't be greater than Total Units");
                ViewData["Provinces"] = new SelectList(StaticDataHelper.GetCanadianProvinces(), "Abbreviation", "Name");
                return Page();
            }
            _context.Attach(Property).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(Property.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Details", new { id = Property.Id });
        }

        private bool PropertyExists(Guid id)
        {
            return _context.Properties.Any(e => e.Id == id);
        }
    }
}
