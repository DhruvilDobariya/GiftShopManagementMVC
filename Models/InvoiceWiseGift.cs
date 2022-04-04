using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiftShopManagement.Models
{
    public class InvoiceWiseGift
    {
        [Key]
        public int InvoiceWiseId { get; set; }

        [Required(ErrorMessage = "Please Enter Invoice Id")]
        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }

        [Required(ErrorMessage = "Please Enter Gift Name")]
        [ForeignKey("Gift")]
        public int GiftId { get; set; }

        [Required(ErrorMessage = "Please Enter Quantity")]
        public int Quantity { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ModificationDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        public Invoice? Invoice { get; set; }
        public Gift? Gift { get; set; }

    }
}
