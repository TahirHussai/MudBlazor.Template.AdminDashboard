using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Server.Models
{
   [Table("UserProfile")]
    public class UserProfile
    {
       [Key]
        public int ID { get; set; }
        public string ForeignKeyId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
