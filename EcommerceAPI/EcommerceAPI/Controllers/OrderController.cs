using EcommerceAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Controllers
{
    [Route("db/Order")]
    [Authorize]
    public class OrderController : Controller
    {
        private MyDBContext _context;

        public OrderController(MyDBContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult ret;
            Order order;

            order = _context.Orders.FirstOrDefault(o => o.Id == id);

            if (order == null)
                ret = NotFound();
            else
                ret = Ok(order);

            return ret;
        }

        [HttpPost]
        public void Post([FromBody]Order order)
        {
            if (_context.Orders.FirstOrDefault(o => orderEquals(o, order)) == null)
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
            }
        }

        private bool orderEquals(Order order1, Order order2)
        {
            if (order1.Id != order2.Id)
                return false;

            if (order1.Price != order2.Price)
                return false;

            if (order1.ClientId != order2.ClientId)
                return false;

            return true;
        }
    }
}
