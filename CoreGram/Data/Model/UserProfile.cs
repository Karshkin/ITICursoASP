using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGram.Data.Model
{
    [Table("UsersProfile")]
    public class UserProfile
    {   
        [Key]
        public int Id { get; set; }

        [Column("FullName", TypeName="nvarchar(150)")]
        public string FullName { get; set; }
        public string Image { get; set; }

        [ForeignKey("UserId")]
        public UserProfile User { get; set; }

    }
}
