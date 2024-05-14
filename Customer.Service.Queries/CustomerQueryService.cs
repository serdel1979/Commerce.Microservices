using Customer.Domain;
using Customer.Persistence.Database;
using Customer.Service.Queries.DTOs;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Pagging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Service.Queries
{

    public interface ICustomerQueryService
    {

        Task<DataCollection<ClientDTO>> GetAllAsync(int page, int take, IEnumerable<int> products = null);
        Task<ClientDTO> GetAsync(int Id);
    }


    public class CustomerQueryService : ICustomerQueryService
    {
        private readonly ApplicationDbContext _context;

        public CustomerQueryService(ApplicationDbContext context)
        {
            this._context = context;
        }


        public async Task<DataCollection<ClientDTO>> GetAllAsync(int page, int take, IEnumerable<int> clients = null)
        {
            var collection = await _context.Clients
                                    .Where(x => clients == null || clients.Contains(x.Id))
                                    .OrderByDescending(clients => clients.Id)
                                    .GetPagedAsync(page, take);


            return collection.MapTo<DataCollection<ClientDTO>>();
        }

        public async Task<ClientDTO> GetAsync(int Id)
        {
            var client = (await _context.Clients.SingleAsync(x => x.Id == Id)).MapTo<ClientDTO>();
            if (client == null)
            {
                throw new KeyNotFoundException(nameof(client));
            }
            return client;
        }
    }
}
