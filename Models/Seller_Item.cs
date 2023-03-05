using Auction_House.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction_House.Models
{

    public class Seller_Item
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }

}