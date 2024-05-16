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

        public CustomerUpdateEventHendler()
        {
            
        }
        public Task Handle(CustomerUpdateCommand notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


    }
}
