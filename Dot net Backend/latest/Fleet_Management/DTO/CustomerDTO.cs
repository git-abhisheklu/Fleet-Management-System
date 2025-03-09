using System;

namespace Fleet_Management.DTO
{
    public class CustomerDTO
    {
        public long CustomerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string AddressLine1 { get; set; } = string.Empty;
        public string AddressLine2 { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Pincode { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string CreditCardType { get; set; } = string.Empty;
        public string CreditCardNumber { get; set; } = string.Empty;
        public string DrivingLicenseNumber { get; set; } = string.Empty;
        public string IdpNumber { get; set; } = string.Empty;
        public string IssuedByDL { get; set; } = string.Empty;
        public DateOnly? ValidThroughDL { get; set; }
        public string PassportNumber { get; set; } = string.Empty;
        public DateOnly? PassportValidThrough { get; set; }
        public string PassportIssuedBy { get; set; } = string.Empty;
        public DateOnly? PassportValidFrom { get; set; }
        public DateOnly? PassportIssueDate { get; set; }
        public DateOnly? DateOfBirth { get; set; }
    }
}
