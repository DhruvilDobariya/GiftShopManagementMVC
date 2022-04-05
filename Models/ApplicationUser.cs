using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GiftShopManagement.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Please Enter FirstName")]
        [MaxLength(250, ErrorMessage = "FirstName Max length must less then or equal to 50 character")]
        [MinLength(1, ErrorMessage = "FirstName must at least one character")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter LastName")]
        [MaxLength(250, ErrorMessage = "LastName Max length must less then or equal to 50 character")]
        [MinLength(1, ErrorMessage = "LastName must at least one character")]
        public string LastName { get; set; } = null!;

        public string? Address { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ModificationDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
    }
}
