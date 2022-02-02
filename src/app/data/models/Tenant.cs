using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace data.models
{
    public partial class Tenant
    {
        public Guid Id { get; set; }
        public Guid UnitId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public DateTime TenancyStartDate { get; set; }
        public string Status { get; set; }
        public string Standing { get; set; }
        public string EmergencyContactName { get; set; }
        public int EmergencyContactPhone { get; set; }
        public string EmergencyContactEmail { get; set; }
        public bool ParkingStall { get; set; }
        public string MailingAddressLine1 { get; set; }
        public string MailingAddressLine2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public virtual Unit Unit { get; set; }
    }
}
