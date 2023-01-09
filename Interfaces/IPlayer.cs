using RPGApp.Models;

namespace RPGApp.Interfaces
{
	public interface IPlayer
	{
		List<PlayerModel> GetPlayers();
		void AddPlayer(PlayerViewModel Player);
	}
}
