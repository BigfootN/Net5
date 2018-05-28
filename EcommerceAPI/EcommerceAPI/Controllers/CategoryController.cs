using EcommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Controllers
{
    [Route("db/category")]
    public class CategoryController : Controller
    {
        private MyDBContext _context;

        public CategoryController(MyDBContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult res;
            Category exists;

            exists = _context.Categories.FirstOrDefault(c => c.Id == id);

            if (exists != null)
                res = Ok(exists);
            else
                res = NotFound();

            return res;
        }

        [HttpPut]
        public void Post([FromBody]Category category)
        {
            Category exists;

            exists = _context.Categories.FirstOrDefault(c => CategoryEquals(c, category));

            if (exists == null)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
        }

        private bool CategoryEquals(Category cty1, Category cty2)
        {
            if (cty1.Name != cty2.Name)
                return false;

            return true;
        }
    }
}
