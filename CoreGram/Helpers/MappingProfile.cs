﻿using AutoMapper;
using CoreGram.Data.Dto;
using CoreGram.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGram.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<UserInfoDto, User>();
            CreateMap<User, UserInfoDto>();

            CreateMap<UserProfileDto, UserProfile>();
            CreateMap<UserProfile, UserProfileDto>();

            CreateMap<FollowerDto, Follower>();
            CreateMap<Follower, FollowerDto>();
            CreateMap<Follower, FollowerInfoDto>();
        }
    }
}
