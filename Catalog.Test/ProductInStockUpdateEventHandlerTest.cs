using Catalog.Domain;
using Catalog.Service.EventHandlers;
using Catalog.Service.EventHandlers.Commands;
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
    }
}