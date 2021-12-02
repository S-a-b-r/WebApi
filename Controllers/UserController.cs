using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Solution1.Models;
using Solution1.Services;

namespace Solution1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public UserController()
        {
        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return UserService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = UserService.Get(id);

            if(user == null)
                return NotFound();

            return user;
        }
        
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