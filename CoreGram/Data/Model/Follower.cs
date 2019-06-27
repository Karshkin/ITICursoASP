using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGram.Data.Model
{
    [Table("Followers")]
    public class Follower
    {
        [Key]
        public int UserId { get; set; }
        public int FollowerId { get; set; }
        public DateTime Date { get; set; }
        public User UserFollower { get; internal set; }
        public User UserFollowing { get; internal set; }
    }
}
