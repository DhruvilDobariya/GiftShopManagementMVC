using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GiftShopManagement.Models.ViewModels
{
    [Index(nameof(UserName), IsUnique = true)]
    public class SignUp
    {
        [Required(ErrorMessage = "Please Enter Username")]
        [MaxLength(250, ErrorMessage = "Username Max length must less then or equal to 250 character")]
        [MinLength(1, ErrorMessage = "Username must at least one character")]
        [Display(Name = "Username")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter Password")]
        [MaxLength(50, ErrorMessage = "Password Max length must less then or equal to 50 character")]
        [MinLength(1, ErrorMessage = "Password must at least one character")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [MaxLength(50, ErrorMessage = "Confirm Password Max length must less then or equal to 50 character")]
        [MinLength(1, ErrorMessage = "Confirm Password must at least one character")]
        [Compare("Password", ErrorMessage = "Possword and Confirm Password dosen't match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ComfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = "Please Select User Role")]
        [Display(Name = "User Role")]
        public int UserRole { get; set; }

        [Required(ErrorMessage = "Please Enter First Name")]
        [MaxLength(250, ErrorMessage = "First Name Max length must less then or equal to 50 character")]
        [MinLength(1, ErrorMessage = "First Name must at least one character")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter Last Name")]
        [MaxLength(250, ErrorMessage = "Last Name Max length must less then or equal to 50 character")]
        [MinLength(1, ErrorMessage = "Last Name must at least one character")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter Email")]
        [MaxLength(250, ErrorMessage = "Email Max length must less then or equal to 50 character")]
        [MinLength(1, ErrorMessage = "Email must at least one character")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter Mobile No")]
        [MaxLength(50, ErrorMessage = "Mobile No Max length must less then or equal to 50 character")]
        [MinLength(1, ErrorMessage = "Mobile No must at least one character")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "MobileNo")]
        public string MobileNo { get; set; } = null!;

        [MaxLength(500, ErrorMessage = "Address Max length must less then or equal to 50 character")]
        [MinLength(1, ErrorMessage = "Address must at least one character")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Address")]
        public string? Address { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ModificationDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

    }
}
