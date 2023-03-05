using Auction_House.Models;
using System.ComponentModel.DataAnnotations;

namespace Auction_House.Models
{
    public class NewItemsVM
    {
        public int Id { get; set; }

        [Display(Name = "Items name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Items description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "MinimumBid in $")]
        [Required(ErrorMessage = "MinimumBid is required")]
        public double MinimumBid { get; set; }

        [Display(Name = "Items poster URL")]
        [Required(ErrorMessage = "Items poster URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Items start date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime AuctionStart { get; set; }

        [Display(Name = "Items end date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime AuctionEnd { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Items category is required")]
        public ItemCategory ItemCategory { get; set; }

        [Display(Name = "Select a condition")]
        [Required(ErrorMessage = "Items category is required")]
        public ItemCondition ItemCondition { get; set; }

        //Relationships
        [Display(Name = "Select Seller(s)")]
        [Required(ErrorMessage = "Items Seller(s) is required")]
        public List<int> SellerIds { get; set; }

  

    }
}
