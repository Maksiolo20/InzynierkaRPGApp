using Microsoft.AspNetCore.Server.HttpSys;

namespace RPGApp.Models
{
    public class SessionUser
    {
        public string UserId { get; set; }
        public int SessionId { get; set; }
    }
}
