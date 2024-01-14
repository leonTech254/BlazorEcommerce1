using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceFronted.models
{
    public class CartItem
    {
        public int Id { get; set; }
		public string productId { get; set; }
		public DateTime dateAdded { get; set; }
		public String userId {  get; set; }
		public int quantity { get; set; }
		public int pricePerItem { get; set; }
		public int totalprice { get; set; }
		public  Products productCart;
    }
}