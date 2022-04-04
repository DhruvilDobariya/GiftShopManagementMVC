using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GiftShopManagement.Models
{
    [Index(nameof(UserName), IsUnique = true)]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please Enter Username")]
        [MaxLength(250, ErrorMessage = "Username Max length must less then or equal to 250 character")]
        [MinLength(1, ErrorMessage = "Username must at least one character")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter Password")]
        [MaxLength(50, ErrorMessage = "Password Max length must less then or equal to 50 character")]
        [MinLength(1, ErrorMessage = "Password must at least one character")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter Name")]
        [MaxLength(250, ErrorMessage = "Name Max length must less then or equal to 50 character")]
        [MinLength(1, ErrorMessage = "Name must at least one character")]
        public string Name { get; set; } = null!;

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
