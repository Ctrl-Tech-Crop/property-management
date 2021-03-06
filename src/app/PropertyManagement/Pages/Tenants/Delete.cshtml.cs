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

namespace PropertyManagement.Pages.Tenants
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
        public Tenant Tenant { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Tenants email is required")]
        [DataType(DataType.EmailAddress)]
        public string TenantEmail { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tenant = await _context.Tenants
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Tenant == null)
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

            Tenant = await _context.Tenants.FindAsync(id);

            if (Tenant == null)
                return NotFound();

            if (string.IsNullOrEmpty(TenantEmail))
            {
                return Page();
            }
            if(TenantEmail != Tenant.Email)
            {
                ModelState.AddModelError("TenantEmail", "Tenant email does not match");
                return Page();
            }
            
                _context.Tenants.Remove(Tenant);
                await _context.SaveChangesAsync();
            

            return RedirectToPage("./Index");
        }
    }
}
