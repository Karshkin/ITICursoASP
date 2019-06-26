using System;
using System.Collections.Generic;

namespace CoreGram.Models
{
    public partial class UsersProfiles
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }

        public virtual Users IdNavigation { get; set; }
    }
}
