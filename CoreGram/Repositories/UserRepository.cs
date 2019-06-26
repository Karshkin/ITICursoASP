using CoreGram.Data;
using CoreGram.Data.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGram.Repositories
{
    public class UserRepository
    {
        private readonly DataContext _context;

        public UserRepository(
            DataContext context
        )
        {
            _context = context;
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return _context.User.ToList();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _context.User.Find(id);
        }
    } 
}
