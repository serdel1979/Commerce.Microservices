using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Service.EventHandlers.Exceptions
{
    public class ProductInStockUpdateComandException : Exception
    {
        public ProductInStockUpdateComandException(string Message):base(Message)
        {
            
        }

    }
}
