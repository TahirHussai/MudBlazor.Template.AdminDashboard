namespace AdminDashboard.Server.DTO
{
    public class SubRegionDTO
    {
        public int SubRegionID { get; set; }
        public int RegionRID { get; set; }
        public string Abv { get; set; }
        public string Desc { get; set; }
        public string RegionTitle { get; set; } = "";

    }
}
