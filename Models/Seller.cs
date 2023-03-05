
using System.ComponentModel.DataAnnotations;

namespace Auction_House.Models
{
    public class Seller
    { 
        [Key]
        public int Id { get; set; }

      
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }

        //Relationships
        public List<Seller_Item> Seller_Items { get; set; }
    }
}
