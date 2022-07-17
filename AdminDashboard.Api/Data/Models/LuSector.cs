using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminDashboard.Api.Data.Models
{
    [Table("LuSector")]
    public class LuSector
    {
        [Key]
        public int SectorID { get; set; }
        public string vchVal { get; set; }
        public string vchDesc { get; set; }
    }
}
