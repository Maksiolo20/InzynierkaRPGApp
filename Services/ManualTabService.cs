using RPGApp.Data;
using RPGApp.Interfaces;
using RPGApp.Models;
using System.Security.Claims;

namespace RPGApp.Services
{
	public class ManualTabService:IManualTab
	{
		private readonly ApplicationDbContext _context;
		private string UserId;
		public ManualTabService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
		{
			_context = context;
			UserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
		}

		public List<ManualTab> GetTabs()
		{
			List<ManualTab> TabList = new();
			foreach (var item in _context.Tabs)
			{
				if (item.SessionId == _context.Users.First(x => x.Id == UserId).CurrentSessionId)
				{
					TabList.Add(new ManualTab()
					{
						Body = item.Body,
						Title = item.Title,
						ManualURL= item.ManualURL,
					});
				}
			}
			return TabList;
		}


		public void AddTabToDatabase(ManualTab model)
		{
			model.SessionId = _context.Users.First(x => x.Id == UserId).CurrentSessionId;
			_context.Tabs.Add(model);
			_context.SaveChanges();
		}
	}
}
