namespace AdminDashboard.Api.Data.Models
{
    public class ResponseModel
    {
        public string Token { get; set; }
        public string ResponseMessage { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string ProfilePicture { get; set; }
        public string UserName { get; set; }
        public bool IsSuccess { get; set; }
    }
}
