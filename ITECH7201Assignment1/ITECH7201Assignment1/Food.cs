using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITECH7201Assignment1
{
    class Food  // Parent classs
    {
        public int countOrder { get; set; }
        public double totalAmount { get; set; }
        protected int countOfferGarlicBread { get; set; }
        protected int countSoftDrink { get; set; }
        
        protected double Price { get; set; }
        protected string ItemName { get; set; }
        public string OfferName { get; set; }
    }
}
