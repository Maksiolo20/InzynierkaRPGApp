using RPGApp.Models;

namespace RPGApp.Models
{
    public class HomeModel
    {
        public string BigText { get; set; }
        public List<string> Text { get; set; } = new List<string>();
        public List<CardFileModel>? HeroCards { get; set; }
        public List<CardFileModel>? BeastiaryCards { get; set; }
        public List<CardFileModel>? NPCCards { get; set; }
        public MapViewModel? Maps { get; set; }
        public List<NoteViewModel>? ChronologyNotes { get; set; }
        public List<NoteViewModel>? PlotNotes { get; set; }
        public List<NoteViewModel>? PersonalNotes { get; set; }
        public List<ManualTabViewModel>? ManualTab { get; set; }
        public bool ShowSessionDetails { get; set; }
    }
}
