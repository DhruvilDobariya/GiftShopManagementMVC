using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GiftShopManagement.Models
{
    [Index(nameof(CompanyName), IsUnique = true)]
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Please Enter Company Name")]
        [MaxLength(250, ErrorMessage = "Company Name Max length must less then or equal to 50 character")]
        [MinLength(1, ErrorMessage = "Company Name must at least one character")]
        public string CompanyName { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter Email")]
        [MaxLength(250, ErrorMessage = "Email Max length must less then or equal to 50 character")]
        [MinLength(1, ErrorMessage = "Email must at least one character")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter MobileNo")]
        [MaxLength(50, ErrorMessage = "MobileNo Max length must less then or equal to 50 character")]
        [MinLength(1, ErrorMessage = "MobileNo must at least one character")]
        [DataType(DataType.PhoneNumber)]
        public string MobileNo { get; set; } = null!;

        [MaxLength(500, ErrorMessage = "Address Max length must less then or equal to 50 character")]
        [MinLength(1, ErrorMessage = "Address must at least one character")]
        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ModificationDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
    }
}
