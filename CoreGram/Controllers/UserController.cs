using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreGram.Data;
using CoreGram.Data.Model;
using CoreGram.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreGram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DataContext _context;
        UserRepository _userRepository;

        public UserController(DataContext context, UserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
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
        /// <summary>
        /// Listado de Usuarios
        /// </summary>
        /// <remarks>
        /// Ejemplo de peticion:
        /// 
        ///     GET /user
        ///     {
        ///     
        ///     }
        /// </remarks>
        /// <returns>Listado de los usuarios de la base de datos</returns>
        /// <response code="200">Devuelve el listado de los usuarios de la base de datos</response>
        /// <response code="400">Cuerpo de petición erroneo</response>
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return _userRepository.GetAll();
        }

        // GET api/user/5
        /// <summary>
        /// Detalle de usuario
        /// </summary>
        /// <remarks>
        /// Ejemplo de peticion:
        /// 
        ///     GET /user/1
        ///     {
        ///     
        ///     }
        /// </remarks>
        /// <returns>Usuario del id</returns>
        /// <response code="200">Devuelve el usuario del id indicado</response>
        /// <response code="400">Cuerpo de petición erroneo</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            return await _context.User.FindAsync(id);
        }

        // POST api/user
        /// <summary>
        /// Inserción de usuario
        /// </summary>
        /// <remarks>
        /// Ejemplo de peticion:
        /// 
        ///     POST /user
        ///     {
        ///         "id":0,
        ///         "Login":"Usuario1",
        ///         "Password":"Pass1"
        ///     }
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>Usuario recién creado</returns>
        /// <response code="200">Devuelve el usuario creado recientemente</response>
        /// <response code="400">Cuerpo de petición erroneo</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User item)
        {
            _context.User.Add(item);
            await _context.SaveChangesAsync();
            return Ok(item);
        }

        // PUT api/user/5
        /// <summary>
        /// Modificación de usuario
        /// </summary>
        /// <remarks>
        /// Ejemplo de peticion:
        /// 
        ///     PUT /user/1
        ///     {
        ///         "id":1,
        ///         "Login":"Usuario1",
        ///         "Password":"Pass1"
        ///     }
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>Usuario recién modificado</returns>
        /// <response code="200">Devuelve el usuario modificado recientemente</response>
        /// <response code="400">Cuerpo de petición erroneo</response>
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
        /// <summary>
        /// Eliminado de usuario
        /// </summary>
        /// <remarks>
        /// Ejemplo de peticion:
        /// 
        ///     Delete /user/1
        ///     {
        ///         
        ///     }
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>OK con el usuario eliminado recientemente</returns>
        /// <response code="200">Devuelve el id del usuario eliminado recientemente</response>
        /// <response code="400">Cuerpo de petición erroneo</response>
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
