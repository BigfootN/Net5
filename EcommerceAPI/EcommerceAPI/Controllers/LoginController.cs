using EcommerceAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Controllers
{
    [Authorize]
    [Route("api/db/Login")]
    public class LoginController : Controller
    {
        private MyDBContext _context;

        public LoginController(MyDBContext context)
        {
            _context = context;
        }

        [HttpGet("${id}")]
        public IActionResult Get(int id)
        {
            IActionResult ret;
            Login login;

            login = _context.Logins.FirstOrDefault(c => c.Id == id);
            if (login != null)
                ret = Ok(login);
            else
                ret = NotFound(login);

            return ret;
        }

        [HttpPost]
        public void Post([FromBody]Login login)
        {
            Login exists;

            exists = _context.Logins.FirstOrDefault(l => LoginEquals(login, l));

            if (exists == null)
            {
                _context.Logins.Add(login);
                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Login login;

            login = _context.Logins.FirstOrDefault(l => l.Id == id);

            if (login != null)
            {
                _context.Logins.Remove(login);
                _context.SaveChanges();
            }
        }

        private bool LoginEquals(Login log1, Login log2)
        {
            if (log1.Username != log2.Username)
                return false;

            if (log1.Password != log2.Password)
                return false;

            return true;
        }
    }
}
