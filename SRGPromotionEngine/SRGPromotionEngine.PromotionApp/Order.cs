using System;
using System.Collections.Generic;
using System.Text;

namespace SRGPromotionEngine.PromotionApp
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<Product> Products { get; set; }
    }
}
