using Microsoft.AspNetCore.Identity;

namespace RPGApp.Data
{
    public class User : IdentityUser
    {
        public int CurrentSessionId { get; set; }
        public virtual IEnumerable<UserSession> Sessions{ get; set; }
    }
}
