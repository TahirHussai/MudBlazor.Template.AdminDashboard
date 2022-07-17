using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminDashboard.Api.Data.Models
{
    [Table("LuSubCategory")]
    public class LuSubCategory
    {
        [Key]
        public int SubCatID { get; set; }
        public string vchVal { get; set; }
        public string vchDesc { get; set; }
    }
}
