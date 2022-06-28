namespace AdminDashboard.Api.Data
{
    public class JwtModel
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int Duration { get; set; }
    }
}
