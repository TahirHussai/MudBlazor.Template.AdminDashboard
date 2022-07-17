using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminDashboard.Api.Data.Models
{
    [Table("LuRegion")]
    public class LuRegion
    {
        [Key]
        public int RegionID { get; set; }
        public string vchVal { get; set; }
        public string vchDesc { get; set; }
    }
}
