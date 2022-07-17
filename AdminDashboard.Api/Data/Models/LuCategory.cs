using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminDashboard.Api.Data.Models
{
    [Table("LuCategory")]
    public class LuCategory
    {
        [Key]
        public int ID { get; set; }
        public string vchVal { get; set; }
        public string vchDesc { get; set; }
    }
}
