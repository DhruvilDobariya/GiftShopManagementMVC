using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiftShopManagement.Models
{
    public class Sell
    {
        [Key]
        public int SellId { get; set; }

        [Required(ErrorMessage = "Please Enter Gift Name")]
        [ForeignKey("Gift")]
        public int GiftId { get; set; }

        [Required(ErrorMessage = "Please Enter Invoice Id")]
        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }

        [Required(ErrorMessage = "Please Enter Quantity Gift")]
        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Price Per Pice")]
        public decimal PricePerPice { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ModificationDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        public Gift? Gift { get; set; }
        public Invoice? Invoice { get; set; }
    }
}
