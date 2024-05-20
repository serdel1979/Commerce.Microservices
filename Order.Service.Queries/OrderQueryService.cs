using Microsoft.EntityFrameworkCore;
using Order.Persistence.Database;
using Order.Service.Queries.DTOs;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Pagging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Service.Queries
{


    public interface IOrderQueryService
    {

        Task<DataCollection<OrderDTO>> GetAllAsync(int page, int take, IEnumerable<int> products = null);
        Task<OrderDTO> GetAsync(int Id);
    }

    public class OrderQueryService : IOrderQueryService
    {
        private readonly ApplicationDbContext _context;

        public OrderQueryService(ApplicationDbContext context)
        {
            this._context = context;
        }


        public async Task<DataCollection<OrderDTO>> GetAllAsync(int page, int take, IEnumerable<int> products)
        {
            var collection = await _context.Orders
                                    .GetPagedAsync(page, take);


            return collection.MapTo<DataCollection<OrderDTO>>();
        }

        public async Task<OrderDTO> GetAsync(int Id)
        {
            var order = (await _context.Orders.SingleAsync(x => x.Id == Id)).MapTo<OrderDTO>();
            if (order == null)
            {
                throw new KeyNotFoundException(nameof(order));
            }
            return order;
        }
    }
}
