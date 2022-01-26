using System;
using System.Collections.Generic;

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
        public Guid PropertyTypeId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Name { get; set; }
        public int TotalUnits { get; set; }
        public int? TotalVacantUnits { get; set; }
        public bool Parking { get; set; }
        public bool Pets { get; set; }
        public bool Smoking { get; set; }

        public virtual PropertyType PropertyType { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
    }
}
