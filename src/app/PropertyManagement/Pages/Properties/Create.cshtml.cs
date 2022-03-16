using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using data.models;
using System;
using PropertyManagement.Helpers;
using System.Linq;

namespace PropertyManagement.Pages.Properties
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
            ViewData["Provinces"] = new SelectList(StaticDataHelper.GetCanadianProvinces(), "Abbreviation", "Name");
            return Page();
        }

        [BindProperty]
        public Property Property { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Property.Id = Guid.NewGuid();
            //Property.CompanyID = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "FlamingSoft").Value);

            _context.Properties.Add(Property);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Details", new { id = Property.Id });
        }
    }
}
