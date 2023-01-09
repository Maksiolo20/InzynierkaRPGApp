using RPGApp.Models;

namespace RPGApp.Interfaces
{
	public interface IPlayer
	{
		List<PlayerModel> GetPlayers();
        PlayerViewModel GetPlayersEligibleToJoin();
		void AddPlayer(PlayerViewModel Player);
	}
}
