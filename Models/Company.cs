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
        [MaxLength(250, ErrorMessage = "Company Name Max length must less then or equal to 250 character")]
        [MinLength(1, ErrorMessage = "Company Name must at least one character")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter Authorized Person Name")]
        [MaxLength(250, ErrorMessage = "Authorized Person Name Max length must less then or equal to 250 character")]
        [MinLength(1, ErrorMessage = "Authorized Person Name must at least one character")]
        [Display(Name = "Authorized Person Name")]
        public string AuthorizedPersonName { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter Email")]
        [MaxLength(250, ErrorMessage = "Email Max length must less then or equal to 250 character")]
        [MinLength(1, ErrorMessage = "Email must at least one character")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter Mobile No")]
        [MaxLength(50, ErrorMessage = "Mobile No Max length must less then or equal to 50 character")]
        [MinLength(1, ErrorMessage = "Mobile No must at least one character")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; } = null!;

        [MaxLength(500, ErrorMessage = "Address Max length must less then or equal to 500 character")]
        [MinLength(1, ErrorMessage = "Address must at least one character")]
        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ModificationDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }
    }
}
