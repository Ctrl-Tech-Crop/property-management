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
        [Required]
        public Guid PropertyTypeId { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string PostalCode { get; set; }
        public string Name { get; set; }
        [Required]
        [DisplayName("Total units")]
        public int TotalUnits { get; set; }
        [Required]
        [DisplayName("Vacant units")]
        public int? TotalVacantUnits { get; set; }
        [Required]
        public bool Parking { get; set; }
        [Required]
        public bool Pets { get; set; }
        [Required]
        public bool Smoking { get; set; }

        [DisplayName("Property type")]

        public virtual PropertyType PropertyType { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
    }
}
