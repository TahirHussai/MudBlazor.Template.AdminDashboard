using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminDashboard.Api.Data.Models
{
    [Table("LuSubCategory")]
    public class LuSubCategory
    {
        [Key]
        public int SubCatID { get; set; }
        public int CategoryRID { get; set; }

        public string Abv { get; set; }
        public string Desc { get; set; }
    }
}
