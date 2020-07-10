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

        [Test]
        public void ApplyPromotionToGetTotalSum_ProductPriceDictionaryIsNull_ThrowArgumentNullException()
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


            List<Order> orders = new List<Order>();

            orders.AddRange(new Order[] {
                new Order()
                {
                    OrderId =1,
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Id = "A"
                        },
                        new Product
                        {
                            Id = "B"
                        },
                        new Product
                        {
                            Id = "C"
                        }
                    }
                }
            });

            // Assert

            Assert.That(() => PromotionEngine.ApplyPromotionToGetTotalSum(orders, promotions, null), Throws.ArgumentNullException);
        }

        [Test]
        public void ApplyPromotionToGetTotalSum_ProductPriceDictionaryIsEmpty_ThrowArgumentNullException()
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

            List<Order> orders = new List<Order>();

            orders.AddRange(new Order[] {
                new Order()
                {
                    OrderId =1,
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Id = "A"
                        },
                        new Product
                        {
                            Id = "B"
                        },
                        new Product
                        {
                            Id = "C"
                        }
                    }
                }
            });



            // Assert

            Assert.That(() => PromotionEngine.ApplyPromotionToGetTotalSum(orders, promotions, new Dictionary<string, int>()), Throws.ArgumentNullException);

        }

        [Test]
        public void ApplyPromotionToGetTotalSum_NoPromotionApplied_ReturnExpectedSum_Example1()
        {
            // Arrange
            
            List<Order> orders = new List<Order>();

            orders.AddRange(new Order[] {
                new Order()
                {
                    OrderId =1,
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Id = "A"
                        },
                        new Product
                        {
                            Id = "B"
                        },
                        new Product
                        {
                            Id = "C"
                        }
                    }
                }
            });

            // Act 
            decimal result = PromotionEngine.ApplyPromotionToGetTotalSum(orders, new List<Promotion>(), _productPricePairs);

            // Assert

            Assert.That(result, Is.EqualTo(100));

        }

        [Test]
        public void ApplyPromotionToGetTotalSum_AfterApplyingValidPromotion_ReturnExpectedSum_Example2()
        {
            // Arrange
            Dictionary<string, double> pinfo1 = new Dictionary<string, double>();
            pinfo1.Add("A", 3);
            Dictionary<string, double> pinfo2 = new Dictionary<string, double>();
            pinfo2.Add("B", 2);
            Dictionary<string, double> pinfo3 = new Dictionary<string, double>();
            pinfo3.Add("C", 1);
            pinfo3.Add("D", 1);

            List<Promotion> promotions = new List<Promotion>()
            {
                new Promotion(1, pinfo1, 130),
                new Promotion(2, pinfo2, 45),
                new Promotion(3, pinfo3, 30)
            };

            List<Order> orders = new List<Order>();

            orders.AddRange(new Order[] {
                new Order()
                {
                    OrderId =1,
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Id = "A"
                        },
                        new Product
                        {
                            Id = "B"
                        },
                        new Product
                        {
                            Id = "C"
                        }
                    }
                },
                 new Order()
                {
                    OrderId =2,
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Id = "A"
                        },
                        new Product
                        {
                            Id = "A"
                        },
                        new Product
                        {
                            Id = "A"
                        },
                        new Product
                        {
                            Id = "A"
                        },
                        new Product
                        {
                            Id = "B"
                        },
                        new Product
                        {
                            Id = "B"
                        },
                        new Product
                        {
                            Id = "B"
                        },
                        new Product
                        {
                            Id = "B"
                        }
                    }
                }
            });

            // Act 
            decimal result = PromotionEngine.ApplyPromotionToGetTotalSum(orders, promotions, _productPricePairs);

            // Assert

            Assert.That(result, Is.EqualTo(370));

        }

        [Test]
        public void ApplyPromotionToGetTotalSum_AfterApplyingValidPromotion_ReturnExpectedSum_Example3()
        {
            // Arrange
            Dictionary<string, double> pinfo1 = new Dictionary<string, double>();
            pinfo1.Add("A", 3);
            Dictionary<string, double> pinfo2 = new Dictionary<string, double>();
            pinfo2.Add("B", 2);
            Dictionary<string, double> pinfo3 = new Dictionary<string, double>();
            pinfo3.Add("C", 1);
            pinfo3.Add("D", 1);

            List<Promotion> promotions = new List<Promotion>()
            {
                new Promotion(1, pinfo1, 130),
                new Promotion(2, pinfo2, 45),
                new Promotion(3, pinfo3, 30)
            };

            List<Order> orders = new List<Order>();

            orders.AddRange(new Order[] {
                new Order()
                {
                    OrderId =1,
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Id = "A"
                        },
                        new Product
                        {
                            Id = "B"
                        },
                        new Product
                        {
                            Id = "C"
                        }
                    }
                },
                new Order()
                {
                    OrderId =1,
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Id = "A"
                        },
                        new Product
                        {
                            Id = "A"
                        },
                        new Product
                        {
                            Id = "B"
                        },
                        new Product
                        {
                            Id = "B"
                        },
                        new Product
                        {
                            Id = "B"
                        },
                        new Product
                        {
                            Id = "B"
                        },
                        new Product
                        {
                            Id = "D"
                        }
                    }
                }
            });

            // Act 
            decimal result = PromotionEngine.ApplyPromotionToGetTotalSum(orders, promotions, _productPricePairs);

            // Assert

            Assert.That(result, Is.EqualTo(280));

        }

        [Test]
        public void ApplyPromotionToGetTotalSum_AfterApplyingValidPromotionIncludingPercentageScenario_ReturnExpectedSum()
        {
            // Arrange
            Dictionary<string, double> pinfo1 = new Dictionary<string, double>();
            pinfo1.Add("A", 3);
            Dictionary<string, double> pinfo2 = new Dictionary<string, double>();
            pinfo2.Add("B", 2);
            Dictionary<string, double> pinfo3 = new Dictionary<string, double>();
            pinfo3.Add("C", 2);
            Dictionary<string, double> pinfo4 = new Dictionary<string, double>();
            pinfo4.Add("D", 0.5);

            List<Promotion> promotions = new List<Promotion>()
            {
                new Promotion(1, pinfo1, 130),
                new Promotion(2, pinfo2, 45),
                new Promotion(3, pinfo3, 30),
                new Promotion(4, pinfo4, 0m, false) // to include %
            };

            List<Order> orders = new List<Order>();

            orders.AddRange(new Order[] {
                new Order()
                {
                    OrderId =1,
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Id = "A"
                        },
                        new Product
                        {
                            Id = "B"
                        },
                        new Product
                        {
                            Id = "C"
                        }
                    }
                },
                 new Order()
                {
                    OrderId =2,
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Id = "A"
                        },
                        new Product
                        {
                            Id = "A"
                        },
                        new Product
                        {
                            Id = "A"
                        },
                        new Product
                        {
                            Id = "A"
                        },
                        new Product
                        {
                            Id = "B"
                        },
                        new Product
                        {
                            Id = "B"
                        },
                        new Product
                        {
                            Id = "B"
                        },
                        new Product
                        {
                            Id = "B"
                        },
                        new Product
                        {
                            Id = "D"
                        }
                    }
                }
            });

            // Act 
            decimal result = PromotionEngine.ApplyPromotionToGetTotalSum(orders, promotions, _productPricePairs);

            // Assert

            Assert.That(result, Is.EqualTo(377.5m));

        }
    }
}
