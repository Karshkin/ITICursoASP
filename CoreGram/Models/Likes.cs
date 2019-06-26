using System;
using System.Collections.Generic;

namespace CoreGram.Models
{
    public partial class Likes
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }

        public virtual Posts Post { get; set; }
        public virtual Users User { get; set; }
    }
}
