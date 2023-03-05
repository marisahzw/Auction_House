using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auction_House.Models
{
    public enum ItemCategory
    {
        Electronics,
        Books,
        Clothing,
        HomeGoods,
        Other,
        Stationery,
        Furniture
    }

    public enum ItemCondition
    {
        BrandNew,
        Old,
        Refurbished
    }

    public class Item
    {
        [Key]
        public int  Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Minimum bid is required")]
        public double MinimumBid { get; set; }

     
        [DisplayName("Upload File")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Auction start date is required")]
        public DateTime AuctionStart { get; set; }

        [Required(ErrorMessage = "Auction end date is required")]
        public DateTime AuctionEnd { get; set; }

        [Required(ErrorMessage = "ItemController category is required")]
        public ItemCondition ItemCondition { get; set; }

        [Required(ErrorMessage = "ItemController category is required")]
        public ItemCategory ItemCategory { get; set; }

        // Relationships

        public ICollection<Seller_Item> Seller_Items { get; set; } = new List<Seller_Item>();

       }

    
}
