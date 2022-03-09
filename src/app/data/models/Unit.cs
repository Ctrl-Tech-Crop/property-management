﻿using System;
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
        public string Number { get; set; }
        public string Name { get; set; }
        public Guid UnitTypeId { get; set; }
        public decimal Area { get; set; }
        public int NumberofRooms { get; set; }
        public decimal RentAmount { get; set; }
        public decimal DepositAmount { get; set; }
        public bool Furnished { get; set; }
        public bool Laundry { get; set; }

        public virtual Property Property { get; set; }
        public virtual PropertyType UnitType { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }
    }
}
