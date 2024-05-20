using Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Order.Common.Enums.Enums;

namespace Order.Service.Queries.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public OrderStatus Status { get; set; }
        public OrderPayment PaymentType { get; set; }
        public ICollection<OrderDetailDTO> Items { get; set; } = new List<OrderDetailDTO>();
        public DateTime CreateAt { get; set; }
        public decimal Total { get; set; }
    }
}
