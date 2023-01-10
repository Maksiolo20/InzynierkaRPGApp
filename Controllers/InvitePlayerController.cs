using Microsoft.AspNetCore.Mvc;
using RPGApp.Data;
using RPGApp.Interfaces;
using RPGApp.Models;

namespace RPGApp.Controllers
{
	public class InvitePlayerController : Controller
	{
		private readonly IPlayer _player;
		public PlayerViewModel model { get; set; } = new PlayerViewModel();
		public InvitePlayerController(IPlayer player)
		{
			_player= player;
		}
		[HttpGet]
		public IActionResult Index()
		{
			model.PlayerNameList = _player.GetPlayers();
			return View(model);
		}
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			model = _player.GetPlayersEligibleToJoin();
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> AddPlayerToSession(PlayerViewModel NewPlayer)
		{
			_player.AddPlayer(NewPlayer.PlayerName);
			return RedirectToAction("Index");
		}
	}
}
