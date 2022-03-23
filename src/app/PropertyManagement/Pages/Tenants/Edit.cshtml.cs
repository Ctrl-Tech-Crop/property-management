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
using data.models.POCO;

namespace PropertyManagement.Pages.Tenants
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
            ViewData["Units"] = new SelectList(GetUnitsListAsync(), "Id", "DisplayText", Tenant.UnitId);
            ViewData["Provinces"] = new SelectList(StaticDataHelper.GetCanadianProvinces(), "Abbreviation", "Name");
            ViewData["Status"] = new SelectList(StaticDataHelper.GetStatus(), "StatusType", "StatusType", Tenant.Status);
            ViewData["Standing"] = new SelectList(StaticDataHelper.GetStandings(), "StandingType", "StandingType", Tenant.Standing);

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

            _context.Attach(Tenant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenantExists(Tenant.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TenantExists(Guid id)
        {
            return _context.Tenants.Any(e => e.Id == id);
        }
        private List<UnitSelectItem> GetUnitsListAsync()
        {
            List<UnitSelectItem> unitSelectItems = new List<UnitSelectItem>();
            foreach (Unit unit in _context.Units.Include(x => x.Property))
            {
                UnitSelectItem unitSelectItem = new UnitSelectItem()
                {
                    Id = unit.Id,
                    DisplayText = string.Format("#{0} {1} {2}, {3}, {4}, {5}", unit.Number, unit.Property.AddressLine1, unit.Property.AddressLine2, unit.Property.City, unit.Property.Province, unit.Property.PostalCode)
                };
                unitSelectItems.Add(unitSelectItem);
            }
            return unitSelectItems;
        }
    }
}
