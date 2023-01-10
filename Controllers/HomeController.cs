using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RPGApp.Data;
using RPGApp.Interfaces;
using RPGApp.Models;
using System.Diagnostics;

namespace RPGApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IHome _home;


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, SignInManager<User> signInManager, UserManager<User> userManager, ApplicationDbContext context, IHome home)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
            _home = home;
        }

        public IActionResult Index()
        {
            HomeModel model = new HomeModel();
            if (_signInManager.IsSignedIn(User))
            {
                int currentSession = _context.Users.First(x => x.Id == _userManager.GetUserAsync(User).Result.Id).CurrentSessionId;
                //string? chosenSessionName = ;
                if (currentSession == 0)
                {
                    model.BigText = "Zalogowano";

                    model.Text.Add(new string("W RPGApp możesz trzymać wiele sesji gier. Każda z nich przechowuje swoje dane"));
                    if(User.IsInRole("GameMaster"))
                    {
                        model.Text.Add(new string("Utwórz nową sesję gry lub wybierz jedną z wcześniej stworzonych"));
                    }
                    else
                    {
                        model.Text.Add(new string("Wybierz jedną z sesji gier, do której jesteś zaproszony/a"));
                    }
                }
                else
                {
                    model.ShowSessionDetails = true;
                    model.BigText = $"Wybrano sesję: {_context.Sessions.FirstOrDefault(x => x.Id == currentSession).Name}";
                    if (User.IsInRole("GameMaster"))
                    {
                        model.Text.Add(new string("Przechowuj karty postaci oraz informacje o bohaterach, przeciwnikach oraz postaciach NPC w zakładkach Bohaterowie, Bestiariusz oraz Postacie NPC"));
                        model.Text.Add(new string("Twórz i otwieraj zapisane mapy w zakładce Mapy Świata"));
                        model.Text.Add(new string("Trzymaj swoje notatki w uporządkowany sposób w wcześniej przygotowanych zakładkach Notatnik Chronologii, Fabularny oraz Osobisty"));
                        model.Text.Add(new string("Twórz skróty do podręczników w Zakładce do Podręczników"));
                        model.Text.Add(new string("Dodawaj graczy do sesji, by mieli wgląd w swoje karty postaci oraz mapy"));
                    }
                    else
                    {
                        model.Text.Add(new string("W zakładce Bohaterowie masz wgląd do kart postaci graczy oraz do dodatkowych informacji o tych postaciach."));
                        model.Text.Add(new string("Otwieraj mapy wprowadzone przez Mistrza Gry w zakładce Mapy Świata"));
                    }
                    model.Maps = _home.GetMaps(currentSession);
                    model.HeroCards = _home.GetCardsByType(Card.CardType.HeroCardFiles, currentSession);
                    model.BeastiaryCards = _home.GetCardsByType(Card.CardType.BestiaryCardFiles, currentSession);
                    model.NPCCards = _home.GetCardsByType(Card.CardType.NPCCardFiles, currentSession);
                    model.ChronologyNotes = _home.GetNotebooksByType("Chronology", currentSession);
                    model.PersonalNotes = _home.GetNotebooksByType("Personal", currentSession);
                    model.PlotNotes = _home.GetNotebooksByType("Plot", currentSession);
                    model.ManualTab = _home.GetTabs(currentSession);

                }
            }
            else
            {
                model.BigText = "Witaj";
                model.Text.Add(new string("RPGApp to aplikacja pomagająca Mistrzowi Gry w przeprowadzaniu sesji gier RPG. Umożliwia przechowywanie i modyfikcaję informacji takich jak karty postaci, notatki oraz mapy"));
                model.Text.Add(new string("Dla graczy udostępnione są karty postaci oraz mapy. Lecz wpierw muszą być zaproszeni przez mistrza gry do sesji"));
                model.Text.Add(new string("Zaloguj się lub zarejestruj nowe konto, by skorzystać z aplikacji"));
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}