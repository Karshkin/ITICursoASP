using System;
using System.Collections.Generic;

namespace CoreGram.Models
{
    public partial class Posts
    {
        public Posts()
        {
            Likes = new HashSet<Likes>();
            PostsComments = new HashSet<PostsComments>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Photo { get; set; }
        public DateTime Date { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Likes> Likes { get; set; }
        public virtual ICollection<PostsComments> PostsComments { get; set; }
    }
}
