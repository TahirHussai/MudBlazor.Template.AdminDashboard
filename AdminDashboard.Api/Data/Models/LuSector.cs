﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminDashboard.Api.Data.Models
{
    [Table("LuSector")]
    public class LuSector
    {
        [Key]
        public int SectorID { get; set; }
        public string Abv { get; set; }
        public string Desc { get; set; }
    }
}
