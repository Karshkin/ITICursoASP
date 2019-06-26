using System;
using System.Collections.Generic;

namespace CoreGram.Models
{
    public partial class Users
    {
        public Users()
        {
            Comments = new HashSet<Comments>();
            FollowersFollower = new HashSet<Followers>();
            FollowersUser = new HashSet<Followers>();
            Likes = new HashSet<Likes>();
            Posts = new HashSet<Posts>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual UsersProfiles UsersProfiles { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Followers> FollowersFollower { get; set; }
        public virtual ICollection<Followers> FollowersUser { get; set; }
        public virtual ICollection<Likes> Likes { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
    }
}
