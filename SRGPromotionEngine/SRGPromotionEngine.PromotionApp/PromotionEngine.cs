using System;
using System.Collections.Generic;
using System.Linq;
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
            decimal sum = 0m;

            if (orders == null || orders.Count <= 0)
            {
                return sum;
            }


            if (productPricePairs == null || productPricePairs.Count <= 0)
            {
                throw new ArgumentNullException();
            }

            var dict = orders.SelectMany(x => x.Products).GroupBy(x => x.Id).Select(x => new
            {
                Id = x.Key,
                Count = x.Count()
            }).ToDictionary(x => x.Id, y => y.Count);

            foreach (var item in dict)
            {
                if (item.Value > 0)
                {
                    sum += (item.Value * productPricePairs[item.Key]);
                }
            }

            return sum;
        }
    }
}
