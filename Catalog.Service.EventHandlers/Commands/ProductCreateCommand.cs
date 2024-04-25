using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Service.EventHandlers.Commands
{

    /*
     acá tembién necesito instalar mediatr para heredar de INotification
     si necesito retornar debo heredar de otra interfaz
     */
    public class ProductCreateCommand : INotification
    {
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public decimal Price { get; set; }
    }
}
