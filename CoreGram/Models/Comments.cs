using System;
using System.Collections.Generic;

namespace CoreGram.Models
{
    public partial class Comments
    {
        public Comments()
        {
            PostsComments = new HashSet<PostsComments>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Remark { get; set; }
        public DateTime Date { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<PostsComments> PostsComments { get; set; }
    }
}
