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
			List<string> playerList = _player.GetPlayers();
			return View(playerList);
		}
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddPlayerToSession(string playerName)
		{
			_player.AddPlayer(playerName);
			return RedirectToAction("Index");
		}
	}
}
