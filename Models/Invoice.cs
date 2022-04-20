using System.ComponentModel.DataAnnotations;

namespace GiftShopManagement.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [Required(ErrorMessage = "Please Customer Name")]
        [MaxLength(250, ErrorMessage = "Customer Name Max length must less then or equal to 250 character")]
        [MinLength(1, ErrorMessage = "Customer Name must at least one character")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = null!;

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

        [DataType(DataType.Currency)]
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }

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
