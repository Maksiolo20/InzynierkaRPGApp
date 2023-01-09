namespace RPGApp.Data
{
    public class Session
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GameMasterId { get; set; }
        public virtual List<UserSession> Users { get; set; }
        public List<Card> Cards { get; set; }
        public List<Note> Notes { get; set; }
        public List<ManualTab> Tabs { get; set; }
        public List<Map> Maps { get; set; }
    }
}
