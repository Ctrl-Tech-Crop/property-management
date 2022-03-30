using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace data.models
{
    public partial class Tenant
    {
        public Guid Id { get; set; }
        public Guid UnitId { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Preferred Name")]
        public string PreferredName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$", ErrorMessage = "Follow (###)-###-#### format. ")]
        public string Phone { get; set; }
        [DisplayName("Tenancy Start Date")]
        public DateTime TenancyStartDate { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Standing { get; set; }
        [DisplayName("Parking Stall")]
        public bool ParkingStall { get; set; }
        [Required]
        [DisplayName("Emergency Contact Name")]
        public string EmergencyContactName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$", ErrorMessage = "Please enter valid Email ")]
        [DisplayName("Emergency Contact Phone")]
        public string EmergencyContactPhone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Emergency Contact Email")]
        public string EmergencyContactEmail { get; set; }
        [Required]
        [DisplayName("Mailing Address Line 1")]
        public string MailingAddressLine1 { get; set; }
        [DisplayName("Mailing Address Line 2")]
        public string MailingAddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$", ErrorMessage = "Follow C#C-#C# format.")]
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }
        public virtual Unit Unit { get; set; }


        //public Guid CompanyID { get; set; }
        //public virtual Company Company { get; set; }
    }
}
