using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RPGApp.Data;
using RPGApp.Models;
using System.Security.Claims;

namespace RPGApp.Controllers
{
    public class SessionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private string UserId;
        public SessionController(ApplicationDbContext context,IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            UserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ChangeSession(int id)
        {
            _context.Users.First(x => x.Id == UserId).CurrentSessionId = id;
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult ResetSession()
        {
            _context.Users.First(x => x.Id == UserId).CurrentSessionId = 0;
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
