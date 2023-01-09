namespace RPGApp.Interfaces
{
	public interface IPlayer
	{
		List<string> GetPlayers();
		void AddPlayer(string player);
	}
}
