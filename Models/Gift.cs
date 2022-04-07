using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiftShopManagement.Models
{
    [Index(nameof(GiftName), IsUnique = true)]
    public class Gift
    {
        [Key]
        public int GiftId { get; set; }


        [Required(ErrorMessage = "Please Enter Gift Name")]
        [MaxLength(250, ErrorMessage = "Gift Name Max length must less then or equal to 250 character")]
        [MinLength(1, ErrorMessage = "Gift Name must at least one character")]
        public string GiftName { get; set; } = null!;


        [Required(ErrorMessage = "Please Enter Gift Type Name")]
        [ForeignKey("GiftType")]
        public int GiftTypeId { get; set; }


        [Required(ErrorMessage = "Please Enter Company Name")]
        [ForeignKey("Company")]
        public int CompanyID { get; set; }


        [DataType(DataType.Currency)]
        [Display(Name = "Price Per Pice")]
        public decimal PricePerPice { get; set; }


        public int Quantity { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime ModificationDate { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }


        public GiftType? GiftType { get; set; }

        public Company? Company { get; set; }
    }
}
