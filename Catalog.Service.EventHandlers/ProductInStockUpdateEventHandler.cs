using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Catalog.Common.Enums.Enums;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Catalog.Service.EventHandlers
{
    public class ProductInStockUpdateEventHandler : INotificationHandler<ProductInStockUpdateComand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductInStockUpdateEventHandler> _logger;

        public ProductInStockUpdateEventHandler(ApplicationDbContext context, ILogger<ProductInStockUpdateEventHandler> logger)
        {
            this._context = context;
            this._logger = logger;
        }

        /*
         Acá tengo que implementar la lógica, regla de negocio del comando - aumentar stock y agregar nuevo o descontar stock
         */
        public async Task Handle(ProductInStockUpdateComand notification, CancellationToken cancellationToken)
        {

            _logger.LogInformation("---ProductInStockUpdateComand started---");

            var products = notification.Items.Select(x => x.ProductId);
            var stocks = await _context.Stocks.Where(x => products.Contains(x.ProductId)).ToListAsync();

            _logger.LogInformation("---Have products from database---");

            foreach (var item in notification.Items)
            {
                var entry = stocks.SingleOrDefault(x => x.ProductId == item.ProductId);

                if(item.Action == ProductInStockAction.Substract)
                {
                    if (entry == null || item.Stock > entry.Stock)
                    {
                        _logger.LogError($"Product no tiene stock suficiente");
                        throw new Exception($"Product {entry.ProductId} no tiene stock suficiente");
                    }

                    _logger.LogInformation($"---Actualización de stock--- Nuevo stock = {entry.Stock}");
                    entry.Stock -= entry.Stock;
                }
                else
                {
                    if (entry == null)
                    {
                        entry = new ProductInStock
                        {
                            ProductId = item.ProductId,
                        };
                        await _context.AddAsync(entry);
                    }
                    entry.Stock += item.Stock;
                    _logger.LogInformation($"---Actualización de stock--- Nuevo stock = {entry.Stock}");
                }
            }


            await _context.SaveChangesAsync();

            _logger.LogInformation("---ProductInStockUpdateComand ended---");

        }
    }
}
