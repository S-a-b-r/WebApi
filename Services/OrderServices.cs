using Solution1.Models;
using System.Collections.Generic;
using System.Linq;

namespace Solution1.Services
{
    public class OrderService
    {
        static List<Order> Orders { get; }
        static int nextId = 3;
        static OrderService()
        {
            Orders = new List<Order>
            {
                new Order { Id = 1, CustomerId = 1 , Cost = 500 },
                new Order { Id = 2, CustomerId = 2 , Cost = 1000 }
            };
        }

        public static List<Order> GetAll() => Orders;

        public static Order Get(int id) => Orders.FirstOrDefault(p => p.Id == id);
        public static Order GetByCustomer(int id) => Orders.FirstOrDefault(p => p.CustomerId == id);

        public static void Add(int customerId, int cost)
        {
            Order order = new Order();
            order.Id = nextId++;
            order.CustomerId = customerId;
            order.Cost = cost;
            Orders.Add(order);
        }

        public static void Delete(int id)
        {
            var order = Get(id);
            if(order is null)
                return;

            Orders.Remove(order);
        }

        public static void Update(Order order)
        {
            var index = Orders.FindIndex(p => p.Id == order.Id);
            if(index == -1)
                return;

            Orders[index] = order;
        }
    }
}