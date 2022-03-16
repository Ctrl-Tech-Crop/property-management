using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace data.models
{
    public partial class Unit
    {
        public Unit()
        {
            Tenants = new HashSet<Tenant>();
        }

        public Guid Id { get; set; }
        public Guid PropertyId { get; set; }
        [Required]
        public string Number { get; set; }
        public string Name { get; set; }
        public Guid UnitTypeId { get; set; }
        [Required]
        public decimal Area { get; set; }
        [Required]
        public int NumberofRooms { get; set; }
        [Required]
        public decimal RentAmount { get; set; }
        [Required]
        public decimal DepositAmount { get; set; }
        public bool Furnished { get; set; }
        public bool Laundry { get; set; } // 3 options not bool

        public virtual Property Property { get; set; }
        public virtual PropertyType UnitType { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }
    }
}
