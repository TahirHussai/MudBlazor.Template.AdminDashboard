using Microsoft.AspNetCore.Identity;

namespace AdminDashboard.Api.Data.Models
{
    public class ApiUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
    }
}
