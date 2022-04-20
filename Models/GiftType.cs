using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GiftShopManagement.Models
{
    [Index(nameof(GiftTypeName), IsUnique = true)]
    public class GiftType
    {
        [Key]
        public int GiftTypeID { get; set; }

        [Required(ErrorMessage = "Please Enter Gift Type Name")]
        [MaxLength(250, ErrorMessage = "Gift Type Name Max length must less then or equal to 250 character")]
        [MinLength(1, ErrorMessage = "Gift Type Name must at least one character")]
        [Display(Name = "Gift Type Name")]
        public string GiftTypeName { get; set; } = null!;

        [DataType(DataType.DateTime)]
        public DateTime ModificationDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }
    }
}
