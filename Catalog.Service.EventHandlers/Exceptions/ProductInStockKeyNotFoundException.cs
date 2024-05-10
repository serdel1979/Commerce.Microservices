using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Service.EventHandlers.Exceptions
{
    public class ProductInStockKeyNotFoundException : Exception
    {
        public ProductInStockKeyNotFoundException(string Message) : base(Message)
        {
            
        }
    }
}
