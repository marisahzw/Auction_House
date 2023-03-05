using Auction_House.Models;
using Auction_House.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction_House.Data.ViewModels
{
    public class NewItemsDropdownsVM
    {
        public NewItemsDropdownsVM()
        {
           
            ItemCondition = new List<ItemCondition>();
            Seller = new List<Seller>();
        }

        
        public List<ItemCondition> ItemCondition { get; set; }
        public List<ItemCategory> ItemCategorY { get; set; }
        public List<Seller> Seller { get; set; }
    }
}
