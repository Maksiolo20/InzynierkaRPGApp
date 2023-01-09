using Microsoft.AspNetCore.Mvc;
using RPGApp.Data;
using RPGApp.Interfaces;
using RPGApp.Models;

namespace RPGApp.Controllers
{
	public class InvitePlayerController : Controller
	{
		private readonly IPlayer _player;

		public InvitePlayerController(IPlayer player)
		{
			_player= player;
		}
		[HttpGet]
		public IActionResult Index()
		{
			PlayerViewModel model = new PlayerViewModel();
			model.PlayerNameList = _player.GetPlayers();
			return View(model);
		}
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddPlayerToSession(PlayerViewModel Player)
		{
			_player.AddPlayer(Player);
			return RedirectToAction("Index");
		}
	}
}
