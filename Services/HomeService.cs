using Microsoft.AspNetCore.Identity;
using RPGApp.Data;
using RPGApp.Interfaces;
using RPGApp.Models;
using System.Security.Claims;
using static RPGApp.Data.Card;

namespace RPGApp.Services
{
    public class HomeService : IHome
    {
        Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnviroment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;
        public HomeService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnviroment)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnviroment = hostingEnviroment;
        }
        public List<CardFileModel> GetCardsByType(CardType cardType, int sessionId)
        {
            List<CardFileModel> result = new List<CardFileModel>();
            List<Card> ChosenCards = _context.Cards.Where(x => x.ChosenCardType == cardType)
                                               .Where(x => x.SessionId == sessionId).ToList();
            int firstThreeElems = 0;
            foreach (var item in ChosenCards)
            {
                if (firstThreeElems == 3) break;
                CardFileModel model = new CardFileModel()
                {
                    Body = item.Body,
                    CardId = item.CardId,
                    Title = item.Title,
                    CardPath = item.CardPath
                };
                result.Add(model);
                firstThreeElems++;
            }
            return result;
        }
        public MapViewModel GetMaps(int sessionId)
        {
            MapViewModel result = new MapViewModel();
            List<Map> mapsInSession = result.MapsInSession = _context.Maps.Where(x => x.SessionId == sessionId).Take(3).ToList();
            return result;
        }
        public List<NoteViewModel> GetNotebooksByType(string noteType, int sessionId)
        {
            List<NoteViewModel> NoteList = new();
            var FilteredNotes = _context.Notes.ToList().Where(x => x.ChosenNoteType.ToString() == noteType).ToList();
            int firstThreeElems = 0;
            foreach (var item in FilteredNotes)
            {
                if (item.SessionId == sessionId)
                {
                    if (firstThreeElems == 3) break;
                    NoteList.Add(new NoteViewModel()
                    {
                        Body = item.Body,
                        Title = item.Title,
                    });
                }
                firstThreeElems++;
            }
            return NoteList;
        }
        public List<ManualTabViewModel> GetTabs(int sessionId)
        {
            List<ManualTabViewModel> TabList = new();
            int firstThreeElems = 0;
            foreach (var item in _context.Tabs)
            {
                if (item.SessionId == sessionId)
                {
                    if (firstThreeElems == 3) break;
                    TabList.Add(new ManualTabViewModel()
                    {
                        Body = item.Body,
                        Title = item.Title,
                        ManualURL = item.ManualURL,
                    });
                }
                firstThreeElems++;
            }
            return TabList;
        }
    }
}
