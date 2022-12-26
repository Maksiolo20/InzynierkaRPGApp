namespace RPGApp.Models
{
	public class BestiaryCardFileModel
	{
		public int FileId { get; set; } = 0;
		public string Name { get; set; } = "";
		public string Path { get; set; } = "";
		public List<BestiaryCardFileModel> BestiaryCardFiles { get; set; } = new List<BestiaryCardFileModel>();
	}
}
