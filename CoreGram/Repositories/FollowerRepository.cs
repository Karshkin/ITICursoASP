using AutoMapper;
using CoreGram.Data;
using CoreGram.Data.Dto;
using CoreGram.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGram.Repositories
{
    public class FollowerRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public FollowerRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<FollowerInfoDto> GetFollowers(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                throw new Exception("El usuario no existe");
            }

            var model = _context.Followers
                .Where(s => s.UserId == userId)
                .Include(s => s.UserFollower)
                    .ThenInclude(s => s.Profile)
                .OrderBy(s => s.UserFollower.Login)
                .ToList();

            return _mapper.Map<List<Follower>, List<FollowerInfoDto>>(model);
        }

        public List<FollowerInfoDto> GetFollowings(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                throw new Exception("El usuario no existe");
            }

            var model = _context.Followers
                .Where(s => s.FollowerId == userId)
                .Include(s => s.UserFollowing)
                    .ThenInclude(s => s.Profile)
                .OrderBy(s => s.UserFollowing.Login)
                .ToList();

            return _mapper.Map<List<Follower>, List<FollowerInfoDto>>(model);
        }
    }
}
