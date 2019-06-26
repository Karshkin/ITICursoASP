using CoreGram.Data;
using CoreGram.Data.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGram.Repositories
{
    public class UserProfileRepository
    {
        private readonly DataContext _context;

        public UserProfileRepository(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<UserProfile> GetAll()
        {
            return _context.UserProfile.ToList();
        }

        [HttpGet("{id}")]
        public UserProfile Get(int id)
        {
            return _context.UserProfile.Find(id);
        }
    }
}
