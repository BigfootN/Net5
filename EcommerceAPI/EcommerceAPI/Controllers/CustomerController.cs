﻿using EcommerceAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Controllers
{
    [Route("api/db/Customer")]
    [Authorize]
    public class CustomerController : Controller
    {
        private MyDBContext _context;

        public CustomerController(MyDBContext context)
        {
            _context = context;
        }

        [HttpGet("${id}")]
        public IActionResult Get(int id)
        {
            IActionResult ret;
            Customer client;

            client = _context.Clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
                ret = NotFound();
            else
                ret = Ok(client);

            return ret;
        }

        [HttpPut]
        public void Post([FromBody]Customer client)
        {
            Customer exists;

            exists = _context.Clients.FirstOrDefault(c => clientEquals(c, client));

            if (exists != null)
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
            }
        }

        private bool clientEquals(Customer client1, Customer client2)
        {
            if (client1.LastName != client2.LastName)
                return false;

            if (client1.Name != client2.Name)
                return false;

            return true;
        }
    }

}
