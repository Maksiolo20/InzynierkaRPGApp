using RPGApp.Data;

namespace RPGApp.Models
{
    public class PlayerViewModel
    {
        public User Player { get; set; }
        public List<PlayerModel> PlayerNameList { get; set; } = new List<PlayerModel>();
    }
}
