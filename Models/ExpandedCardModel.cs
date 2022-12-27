using RPGApp.Data;

namespace RPGApp.Models
{
	public class ExpandedCardModel
	{
		public List<CardFileModel> ListOfCards { get; set; }
		public Card Card { get; set; }
	}
}
