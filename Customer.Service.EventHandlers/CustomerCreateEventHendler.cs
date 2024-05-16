using Customer.Domain;
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
    public class CustomerCreateEventHendler : INotificationHandler<CustomerCreateCommand>
    {
        private readonly ApplicationDbContext _context;

        public CustomerCreateEventHendler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task Handle(CustomerCreateCommand notification, CancellationToken cancellationToken)
        {

            _context.Clients.Add(new Client
            {
                Name = notification.Name,
            });
            _context.SaveChanges();
        }
    }
}
