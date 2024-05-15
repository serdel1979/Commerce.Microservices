using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Service.EventHandlers.Commands
{
    public class CustomerCreateCommand : INotification
    {
       public string Name { get; set; }
    }
}
