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
        [Required, Range(1, Int32.MaxValue, ErrorMessage = "Value should be greater than or equal to 1. Please enter positive numbers.")]
        public decimal Area { get; set; }
        [Required, Range(1, Int32.MaxValue, ErrorMessage = "Value should be greater than or equal to 1. Please enter positive numbers.")]
        [DisplayName("# of Rooms")]
        public int NumberofRooms { get; set; }
        [Required, Range(1, Int32.MaxValue, ErrorMessage = "Value should be greater than or equal to 1. Please enter positive numbers.")]
        [DisplayName("Rent Amount")]
        public decimal RentAmount { get; set; }
        [Required, Range(1, Int32.MaxValue, ErrorMessage = "Value should be greater than or equal to 1. Please enter positive numbers.")]
        [DisplayName("Deposit Amount")]
        public decimal DepositAmount { get; set; }
        public bool Furnished { get; set; }

        public string Laundry { get; set; } // 3 options not bool

        public virtual Property Property { get; set; }
        [DisplayName("Unit Type")]
        public virtual PropertyType UnitType { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }
    }
}
