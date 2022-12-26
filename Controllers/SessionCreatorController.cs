using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RPGApp.Data;
using RPGApp.Models;

namespace RPGApp.Controllers
{
	public class SessionCreatorController : Controller
	{
		private readonly UserManager<User> _manager;
		private readonly ApplicationDbContext _context;

		public SessionCreatorController(UserManager<User> manager, ApplicationDbContext context)
		{
			_manager = manager;
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateSession(Session model)
		{
			User user = _manager.GetUserAsync(HttpContext.User).Result;
			model.GameMaster = user;
			_context.Add(model);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
