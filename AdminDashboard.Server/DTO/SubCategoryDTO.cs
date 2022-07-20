namespace AdminDashboard.Server.DTO
{
    public class SubCategoryDTO
    {
        public int SubCatID { get; set; }
        public int CategoryRID { get; set; }
        public string? CategoryTitle { get; set; }
        public string Abv { get; set; }
        public string Desc { get; set; }
    }
}
