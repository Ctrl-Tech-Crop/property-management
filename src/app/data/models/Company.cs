using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.models
{
    public partial class Company
    {
        public Company()
        {
            Tenants = new HashSet<Tenant>();
            Properties = new HashSet<Property>();
            ApplicationUsers = new HashSet<ApplicationUser>();
        }

        public Guid Id { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<Tenant> Tenants { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
