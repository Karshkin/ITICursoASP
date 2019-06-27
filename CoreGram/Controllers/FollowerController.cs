using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreGram.Data;
using CoreGram.Data.Dto;
using CoreGram.Data.Model;
using CoreGram.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreGram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowerController : ControllerBase
    {
        DataContext _context;
        FollowerRepository _repository;

        public FollowerController(DataContext context, FollowerRepository repository)
        {
            _context = context;
            _repository = repository;

    
        }

        // GET api/users
        /// <summary>
        /// Obtiene el listado de todos los usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet("(userId)")]
        public ActionResult<List<FollowerInfoDto>> GetFollowers(int userId)
        {
            return _repository.GetFollowers(userId);
        }

        [HttpGet("Following/(userId)")]
        public ActionResult<List<FollowerInfoDto>> GetFollowings(int userId)
        {
            return _repository.GetFollowers(userId);
        }

    }
}
