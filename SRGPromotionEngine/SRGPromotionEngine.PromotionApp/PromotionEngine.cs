using System;
using System.Collections.Generic;
using System.Text;

namespace SRGPromotionEngine.PromotionApp
{
    public class PromotionEngine
    {
        /// <summary>
        /// Apply Promotion To Get TotalSum
        /// </summary>
        /// <param name="orders">orders containing order item</param>
        /// <param name="promotions">promotion rules</param>
        /// <param name="productPricePairs">price for a product as key value pairs</param>
        /// <returns>total sum price of the orders after applying promotion</returns>
        public static decimal ApplyPromotionToGetTotalSum(List<Order> orders, List<Promotion> promotions, Dictionary<string, int> productPricePairs)
        {
            return 0m;
        }
    }
}
