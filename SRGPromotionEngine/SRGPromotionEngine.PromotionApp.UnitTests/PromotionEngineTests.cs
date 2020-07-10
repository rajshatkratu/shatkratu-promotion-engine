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

        [Test]
        public void ApplyPromotionToGetTotalSum_OrdersArgumentIsNull_ReturnZero()
        {

            // Arrange
            Dictionary<string, double> pinfo1 = new Dictionary<string, double>();
            pinfo1.Add("A", 3);
            Dictionary<string, double> pinfo2 = new Dictionary<string, double>();
            pinfo2.Add("B", 2);
            Dictionary<string, double> pinfo3 = new Dictionary<string, double>();
            pinfo3.Add("C", 2);

            List<Promotion> promotions = new List<Promotion>()
            {
                new Promotion(1, pinfo1, 130),
                new Promotion(2, pinfo2, 45),
                new Promotion(3, pinfo3, 30)
            };


            // Act
            decimal result = PromotionEngine.ApplyPromotionToGetTotalSum(null, promotions, _productPricePairs);

            // Assert

            Assert.That(result, Is.EqualTo(0));

        }

        [Test]
        public void ApplyPromotionToGetTotalSum_OrdersArgumentIsEmpty_ReturnZero()
        {

            // Arrange
            Dictionary<string, double> pinfo1 = new Dictionary<string, double>();
            pinfo1.Add("A", 3);
            Dictionary<string, double> pinfo2 = new Dictionary<string, double>();
            pinfo2.Add("B", 2);
            Dictionary<string, double> pinfo3 = new Dictionary<string, double>();
            pinfo3.Add("C", 2);

            List<Promotion> promotions = new List<Promotion>()
            {
                new Promotion(1, pinfo1, 130),
                new Promotion(2, pinfo2, 45),
                new Promotion(3, pinfo3, 30)
            };


            // Act
            decimal result = PromotionEngine.ApplyPromotionToGetTotalSum(new List<Order>(), promotions, _productPricePairs);

            // Assert

            Assert.That(result, Is.EqualTo(0));

        }
    }
}
