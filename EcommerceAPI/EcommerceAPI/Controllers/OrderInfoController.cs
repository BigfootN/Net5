using EcommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Controllers
{
    public class OrderInfoController : Controller
    {
        private MyDBContext _context;

        public OrderInfoController(MyDBContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult res;
            OrderInfo exists;

            exists = _context.OrderInfos.FirstOrDefault(c => c.Id == id);

            if (exists != null)
                res = Ok(exists);
            else
                res = NotFound();

            return res;
        }

        [HttpPost]
        public void Post([FromBody]OrderInfo orderInfo)
        {
            OrderInfo exists;

            exists = _context.OrderInfos.FirstOrDefault(o => OrderInfoEquals(o, orderInfo));

            if (exists == null)
            {
                _context.OrderInfos.Add(orderInfo);
                _context.SaveChanges();
            }
        }

        private bool OrderInfoEquals(OrderInfo order1, OrderInfo order2)
        {
            if (order1.OrderId != order2.OrderId)
                return false;

            if (order1.OrderStatusId != order2.OrderStatusId)
                return false;

            if (order1.ProductId != order2.ProductId)
                return false;

            if (order1.Quantity != order2.Quantity)
                return false;

            return true;
        }
    }
}
