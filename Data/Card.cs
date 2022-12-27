using System.ComponentModel.DataAnnotations;

namespace RPGApp.Data
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        public string? CardPath { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
		public int SessionId { get; set; }
        public Session Session { get; set; }
        public CardType ChosenCardType { get; set; }
        public enum CardType
        {
			HeroCardFiles,
			BestiaryCardFiles,
			NPCCardFiles
		}
    }
}