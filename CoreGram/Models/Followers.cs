using System;
using System.Collections.Generic;

namespace CoreGram.Models
{
    public partial class Followers
    {
        public int UserId { get; set; }
        public int FollowerId { get; set; }
        public DateTime Date { get; set; }

        public virtual Users Follower { get; set; }
        public virtual Users User { get; set; }
    }
}
