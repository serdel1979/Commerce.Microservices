using Customer.Persistence.Database;
using Customer.Service.EventHandlers.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Service.EventHandlers
{
    public class CustomerUpdateEventHendler : INotificationHandler<CustomerUpdateCommand>
    {
        private readonly ApplicationDbContext _context;

        public CustomerUpdateEventHendler(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task Handle(CustomerUpdateCommand notification, CancellationToken cancellationToken)
        {
            var customer =  _context.Clients.Where(cl=>cl.Id == notification.Id).FirstOrDefault();
            if (customer == null)
            {
                throw new KeyNotFoundException("Key not found");
            }
            customer.Id = notification.Id;
            customer.Name = notification.Name;
            _context.Update(customer);
            await _context.SaveChangesAsync();
        }


    }
}
