using System.ComponentModel.DataAnnotations;

namespace GiftShopManagement.ViewModels
{
    public class Login
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

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
