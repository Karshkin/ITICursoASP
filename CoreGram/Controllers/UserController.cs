using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreGram.Data;
using CoreGram.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _context.User.ToListAsync();
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            return await _context.User.FindAsync(id);
        }

        // POST api/user
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User item)
        {
            _context.User.Add(item);
            await _context.SaveChangesAsync();
            return Ok(item);
        }
        
        // PUT api/user/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User item)
        {   
            if (id != item.Id)
            {
                throw new Exception("Mal");
            }

            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(item);
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userFinder = _context.User.Find(id);
            
            if (userFinder == null)
            {
                throw new Exception("El usuario no existe");
            }

            _context.Remove(userFinder);
            await _context.SaveChangesAsync();
            return Ok(id);
        }
    }
}
