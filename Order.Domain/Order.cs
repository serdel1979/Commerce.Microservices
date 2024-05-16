using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Order.Common.Enums.Enums;

namespace Order.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public OrderStatus Status { get; set; }
        public OrderPayment PaymentType { get; set; }
        public ICollection<OrderDetail> Items { get; set; } = new List<OrderDetail>();
        public DateTime CreateAt { get; set; }
        public decimal Total { get; set; }
    }
}
