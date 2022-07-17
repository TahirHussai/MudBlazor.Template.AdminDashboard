using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminDashboard.Api.Data.Models
{
    [Table("LuSubRegion")]
    public class LuSubRegion
    {
        [Key]
        public int SubRegionID { get; set; }
        public string vchVal { get; set; }
        public string vchDesc { get; set; }
    }
}
