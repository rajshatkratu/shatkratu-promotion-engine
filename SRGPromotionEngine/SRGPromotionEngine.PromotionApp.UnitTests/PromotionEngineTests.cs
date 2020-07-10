using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRGPromotionEngine.PromotionApp.UnitTests
{
    [TestFixture]
    public class PromotionEngineTests
    {
        private Dictionary<string, int> _productPricePairs;
        [SetUp]
        public void SetUp()
        {
            this._productPricePairs = new Dictionary<string, int>();

            _productPricePairs.Add("A", 50);
            _productPricePairs.Add("B", 30);
            _productPricePairs.Add("C", 20);
            _productPricePairs.Add("D", 15);
        }
    }
}
