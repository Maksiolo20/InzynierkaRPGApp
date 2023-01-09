using System.ComponentModel.DataAnnotations.Schema;

namespace RPGApp.Data
{
    public class UserSession
    {
        public string UserIdsFK { get; set; }
        public int SessionIdsFK { get; set; }    
        public virtual User User { get; set; }
        public virtual Session Session { get; set; }
    }
}
