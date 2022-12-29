using System.ComponentModel.DataAnnotations;

namespace RPGApp.Data
{
    public class Map
    {
        [Key]
        public int MapId { get; set; }
        public string? MapPath { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
    }
}
