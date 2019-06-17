using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreGram.Data;
using CoreGram.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace CoreGram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;

            if (_context.User.Count() == 0)
            {   
                for (int i = 0; i < 10; i++)
                {
                    User user = new User
                    {
                        Login = "User"+i,
                        Password = "Pass"+i
                    };
                    _context.Add(user);
                }
               
                _context.SaveChanges();
            }
        }

        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _context.User.ToList();
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return _context.User.Find(id);
        }

        // POST api/user
        [HttpPost]
        public void Post([FromBody] User item)
        {
            _context.User.Add(item);
            _context.SaveChanges();
        }
        
        // PUT api/user/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User item)
        {   
            if (id != item.Id)
            {
                throw new Exception("Mal");
            }

            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var userFinder = _context.User.Find(id);
            
            if (userFinder == null)
            {
                throw new Exception("El usuario no existe");
            }

            _context.Remove(userFinder);
            _context.SaveChanges();
        }
    }
}
