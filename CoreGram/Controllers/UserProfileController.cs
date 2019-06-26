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
    public class UserProfileController : ControllerBase
    {
        DataContext _context;
        UserProfileRepository _userProfileRepository;

        public UserProfileController(DataContext context, UserProfileRepository userProfileRepository)
        {
            _context = context;
            _userProfileRepository = userProfileRepository;
            if (_context.User.Count() == 0)
            {   
                for (int i = 0; i < 10; i++)
                {
                    User user = new User
                    {
                        Login = "User"+i,
                        Password = "Pass"+i,
                        Email = "Email"+i+"@test.com"
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
        public ActionResult<List<UserProfile>> GetAll()
        {
            return _userProfileRepository.GetAll();
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
        public async Task<ActionResult<UserProfile>> Get(int id)
        {
            return await _context.UserProfile.FindAsync(id);
        }

      
    }
}
