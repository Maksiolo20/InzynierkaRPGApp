using System.ComponentModel.DataAnnotations;

namespace RPGApp.Data
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        public string CardName { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
    }
}