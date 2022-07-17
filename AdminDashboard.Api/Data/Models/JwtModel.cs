namespace AdminDashboard.Api.Data.Models
{
    public class JwtModel
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int Duration { get; set; }
    }
}
