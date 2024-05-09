using Catalog.Domain;
using Catalog.Service.EventHandlers;
using Catalog.Service.EventHandlers.Commands;
using Catalog.Service.EventHandlers.Exceptions;
using Catalog.Test.Config;
using Microsoft.Extensions.Logging;
using Moq;
using static Catalog.Common.Enums.Enums;

namespace Catalog.Test
{
    [TestClass]
    public class ProductInStockUpdateEventHandlerTest
    {

        private ILogger<ProductInStockUpdateEventHandler> GetLoger
        {
            get
            {
                return new Mock<ILogger<ProductInStockUpdateEventHandler>>()
                    .Object;
            }
        }

        [TestMethod]
        public void TryToSubstractStockWhenProductHasStock()
        {
            var context = ApplicationDbContextInMemory.Get();
            var productInStockId = 1;
            var productId = 1;

            context.Stocks.Add(new ProductInStock
            {
                Id = productInStockId,
                Stock = 1,
                ProductId = productId,
            });

            context.SaveChanges();

            var handler = new ProductInStockUpdateEventHandler(context, GetLoger);

            handler.Handle(new ProductInStockUpdateComand
            {
                Items = new List<ProductInStockUpdateItem>() {
                    new ProductInStockUpdateItem
                    {
                        ProductId = productId,
                        Stock = 1,
                        Action = ProductInStockAction.Substract
                    }
                }
            }, new CancellationToken()).Wait();

        }


        [TestMethod]
        [ExpectedException(typeof(ProductInStockUpdateComandException))]
        public void TryToSubstractStockWhenProductHasentStock()
        {
            var context = ApplicationDbContextInMemory.Get();
            var productInStockId = 2;
            var productId = 2;

            context.Stocks.Add(new ProductInStock
            {
                Id = productInStockId,
                Stock = 1,
                ProductId = productId,
            });

            context.SaveChanges();

            var handler = new ProductInStockUpdateEventHandler(context, GetLoger);

            try
            {
                handler.Handle(new ProductInStockUpdateComand
                {
                    Items = new List<ProductInStockUpdateItem>() {
                    new ProductInStockUpdateItem
                    {
                        ProductId = productId,
                        Stock = 2,
                        Action = ProductInStockAction.Substract
                    }
                }
                }, new CancellationToken()).Wait();
            }
            catch (AggregateException ae)
            {
                var exception = ae.GetBaseException();

                if(exception is ProductInStockUpdateComandException)
                {
                    throw new ProductInStockUpdateComandException(exception?.InnerException?.Message);
                }
            }


           

        }


        [TestMethod]
        public void TryToAddStockWhenProductHasStock()
        {
            var context = ApplicationDbContextInMemory.Get();
            var productInStockId = 3;
            var productId = 3;

            context.Stocks.Add(new ProductInStock
            {
                Id = productInStockId,
                Stock = 1,
                ProductId = productId,
            });

            context.SaveChanges();

            var handler = new ProductInStockUpdateEventHandler(context, GetLoger);

            handler.Handle(new ProductInStockUpdateComand
            {
                Items = new List<ProductInStockUpdateItem>() {
                    new ProductInStockUpdateItem
                    {
                        ProductId = productId,
                        Stock = 2,
                        Action = ProductInStockAction.Add
                    }
                }
            }, new CancellationToken()).Wait();

            var stockInDb = context.Stocks.Single(s => s.Id == productId).Stock;

            Assert.AreEqual(stockInDb, 3);
        }


        [TestMethod]
        public void TryToAddStockWhenProductNotExists()
        {
            var context = ApplicationDbContextInMemory.Get();
            var productId = 4;

            context.SaveChanges();

            var handler = new ProductInStockUpdateEventHandler(context, GetLoger);

            handler.Handle(new ProductInStockUpdateComand
            {
                Items = new List<ProductInStockUpdateItem>() {
                    new ProductInStockUpdateItem
                    {
                        ProductId = productId,
                        Stock = 2,
                        Action = ProductInStockAction.Add
                    }
                }
            }, new CancellationToken()).Wait();

            var stockInDb = context.Stocks.Single(s => s.Id == productId).Stock;

            Assert.AreEqual(stockInDb, 2);
        }

    }
}