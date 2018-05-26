using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("db/Product")]
    public class ProductController : Controller
    {
        private MyDBContext _context;

        public ProductController(MyDBContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product prod;
            
            prod = _context.Products.FirstOrDefault(p => p.Id == id);

            if (prod != null)
                return Ok(prod);

            return NotFound();
        }

        [HttpPost]
        public void Post([FromBody]Product prod)
        {
            Product exists;

            exists = _context.Products.FirstOrDefault(p => productEquals(prod, p));
            if (exists != null)
                return;

            _context.Products.Add(prod);
            _context.SaveChanges();
        }

        private bool productEquals(Product prod1, Product prod2)
        {
            if (prod1.Price != prod2.Price)
                return false;

            if (prod1.CategoryId != prod2.CategoryId)
                return false;

            if (prod1.Name != prod2.Name)
                return false;

            return true;
        }
    }
}