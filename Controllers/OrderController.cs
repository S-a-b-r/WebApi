using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Solution1.Models;
using Solution1.Services;

namespace Solution1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        public OrderController()
        {
        }

        [HttpGet]
        public ActionResult<List<Order>> GetAll()
        {
            return OrderService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            var order = OrderService.Get(id);

            if(order == null)
                return NotFound();

            return order;
        }
        
        // [HttpPost]
        // public IActionResult Add(int customerId, int cost)
        // {
        //     OrderService.Add(customerId, cost);
        //     return CreatedAtAction(nameof(Create), new { id = order.Id }, order);
        // }

        [HttpGet("{customerId}/orders")]
        public ActionResult<Order> GetOrders(int customerId)
        {
            var orders = OrderService.GetByCustomer(customerId);

            if(orders == null)
                return NotFound();

            return orders;
        }

        // POST action

        // PUT action

        // DELETE action
    }
}