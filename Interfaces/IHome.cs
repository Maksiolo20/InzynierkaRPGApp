using RPGApp.Data;
using RPGApp.Models;
using static RPGApp.Data.Card;

namespace RPGApp.Interfaces
{
    public interface IHome
    {
        public List<CardFileModel> GetCardsByType(CardType cardType, int sessionId);
        public MapViewModel GetMaps(int sessionId);
        public List<NoteViewModel> GetNotebooksByType(string noteType, int sessionId);
        public List<ManualTabViewModel> GetTabs(int sessionId);
    }
}
