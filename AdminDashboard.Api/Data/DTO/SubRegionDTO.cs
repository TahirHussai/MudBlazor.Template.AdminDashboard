﻿namespace AdminDashboard.Api.Data.DTO
{
    public class SubRegionDTO
    {
        public int SubRegionID { get; set; }
        public int RegionRID { get; set; }
        public string? RegionTitle { get; set; }
        public string Abv { get; set; }
        public string Desc { get; set; }
    }
}
