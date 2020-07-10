using System;
using System.Collections.Generic;
using System.Text;

namespace SRGPromotionEngine.PromotionApp
{
    public class Promotion
    {
        public int PromotionID { get; set; }
        public Dictionary<string, double> ProductsInfo { get; set; }
        public decimal PromoPrice { get; set; }
        public bool IsCalculatedPriceGiven { get; set; }

        public Promotion(int promotionID, Dictionary<string, double> productsInfo, decimal promoPrice, bool isCalculatedPriceGiven = true)
        {
            PromotionID = promotionID;
            ProductsInfo = productsInfo ?? throw new ArgumentNullException(nameof(productsInfo));
            PromoPrice = promoPrice;
            IsCalculatedPriceGiven = isCalculatedPriceGiven;
        }
    }
}
