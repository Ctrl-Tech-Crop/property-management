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
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public DateTime TenancyStartDate { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Standing { get; set; }
        public bool ParkingStall { get; set; }
        [Required]
        public string EmergencyContactName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string EmergencyContactPhone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmergencyContactEmail { get; set; }
        [Required]
        public string MailingAddressLine1 { get; set; }
        public string MailingAddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$", ErrorMessage = "Follow C#C-#C# format.")]
        public string PostalCode { get; set; }
        public virtual Unit Unit { get; set; }


        //public Guid CompanyID { get; set; }
        //public virtual Company Company { get; set; }
    }
}
