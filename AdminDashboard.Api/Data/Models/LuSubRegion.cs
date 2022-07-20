using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminDashboard.Api.Data.Models
{
    [Table("LuSubRegion")]
    public class LuSubRegion
    {
        [Key]
        public int SubRegionID { get; set; }
        public int RegionRID { get; set; }

        public string Abv { get; set; }
        public string Desc { get; set; }
    }
}
