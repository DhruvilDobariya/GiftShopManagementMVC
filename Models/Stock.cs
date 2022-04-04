using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiftShopManagement.Models
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }

        [Required(ErrorMessage = "Please Enter Gift Name")]
        [ForeignKey("Gift")]
        public int GiftId { get; set; }

        [Required(ErrorMessage = "Please Enter Quantity Gift")]
        public int Quantity { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ModificationDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        public Gift? Gift { get; set; }
    }
}
