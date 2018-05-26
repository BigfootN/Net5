using EcommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Controllers
{
    [Route("db")]
    public class ClientController : Controller
    {
        private MyDBContext _context;

        public ClientController(MyDBContext context)
        {
            _context = context;
        }

        [HttpGet("${id}")]
        public IActionResult Get(int id)
        {
            IActionResult ret;
            Client client;

            client = _context.Clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
                ret = NotFound();
            else
                ret = Ok(client);

            return ret;
        }

        [HttpPut]
        public void Post([FromBody]Client client)
        {
            Client exists;

            exists = _context.Clients.FirstOrDefault(c => clientEquals(c, client));

            if (exists != null)
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
            }
        }

        private bool clientEquals(Client client1, Client client2)
        {
            if (client1.LastName != client2.LastName)
                return false;

            if (client1.Name != client2.Name)
                return false;

            return true;
        }
    }

}
