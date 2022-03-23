using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.models
{
    public class ApplicationUser : IdentityUser
    {
        public Guid CompanyID { get; set; }
        public virtual Company Company { get; set; }
    }
}
