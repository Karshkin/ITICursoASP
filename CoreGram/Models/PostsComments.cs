using System;
using System.Collections.Generic;

namespace CoreGram.Models
{
    public partial class PostsComments
    {
        public int PostId { get; set; }
        public int CommentId { get; set; }

        public virtual Comments Comment { get; set; }
        public virtual Posts Post { get; set; }
    }
}
