using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using data.context;
using data.models;
using Microsoft.AspNetCore.Authorization;

namespace PropertyManagement.Pages.Tenants
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly data.context.FSPropertyManagementContext _context;

        public CreateModel(data.context.FSPropertyManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Number");
            return Page();
        }

        [BindProperty]
        public Tenant Tenant { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tenants.Add(Tenant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
