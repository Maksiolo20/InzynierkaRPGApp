namespace RPGApp.Models
{
	public class NPCCharacterModel
	{
		public int FileId { get; set; } = 0;
		public string Name { get; set; } = "";
		public string Path { get; set; } = "";
		public List<NPCCharacterModel> NPCCharacters { get; set; } = new List<NPCCharacterModel>();
	}
}
