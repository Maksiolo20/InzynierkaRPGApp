namespace RPGApp.Models
{
    public class HeroCardFileModel
    {
        public int FileId { get; set; } = 0;
        public string Name { get; set; } = "";
        public string Path { get; set; } = "";
        public List<HeroCardFileModel> HeroCardFiles { get; set; } = new List<HeroCardFileModel>();
    }
}
