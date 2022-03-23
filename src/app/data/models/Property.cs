using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace data.models
{
    public partial class Property
    {
        public Property()
        {
            Units = new HashSet<Unit>();
        }

        public Guid Id { get; set; }


        [DisplayName("Property Description")]
        public string PropertyDescription { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Province { get; set; }
        [Required, MaxLength(6)]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$", ErrorMessage = "Follow C#C#C# format.")]
        public string PostalCode { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, Range(0, 2000, ErrorMessage = "Total Units must be a positive value")]
        [DisplayName("Total units")]
        public int TotalUnits { get; set; }
        [Required, Range(0, 2000, ErrorMessage = "Total Vacant Units must be a positive value")]
        [DisplayName("Vacant units")]
        public int? TotalVacantUnits { get; set; }
        [Required]
        public bool Parking { get; set; }
        [Required]
        public bool Pets { get; set; }
        [Required]
        public bool Smoking { get; set; }


        public virtual ICollection<Unit> Units { get; set; }


        //public Guid CompanyID { get; set; }
        //public virtual Company Company { get; set; }
    }
}
