using OederProcessSystem.Model;
using OrderProcessing.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Core.Services
{
    public class OrderService
    {

        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository order)
        {
            _orderRepository = order;
            
        }
        public Order CreateOrder(string name, double price, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Order quantity must be greater than 0.");

            if (price <= 0)
                throw new ArgumentException("Order Price must ber greater than 0");

            var order = new Order
            {
                Id = Guid.NewGuid(),
                Name = name,
                Quantity = quantity,
                Price = price,
            };

            _orderRepository.Add(order);
            return order;
        }

        public Order GetOrder(Guid id)
        {
            if (!_orderRepository.Exists(id))
                throw new KeyNotFoundException($"Order with ID {id} not found.");

            return _orderRepository.GetById(id);
        }


    }
}
