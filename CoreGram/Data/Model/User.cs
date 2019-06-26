﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGram.Data.Model
{   
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Column("UserName",TypeName="nvarchar(150)")]
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

       

        
    }
}
