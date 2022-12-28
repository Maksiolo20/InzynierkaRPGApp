using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RPGApp.Data;
using RPGApp.Interfaces;
using RPGApp.Models;

namespace RPGApp.Controllers
{
	public class ManualTabController : Controller
	{
		private readonly IManualTab _manualTab;
		private readonly IMapper _mapper;
		public ManualTabController(IManualTab manualTab, IMapper mapper)
		{
			_manualTab = manualTab;
			_mapper = mapper;
		}
		public IActionResult Index()
		{
			List<ManualTabViewModel> NoteList = _mapper.Map<List<ManualTabViewModel>>(_manualTab.GetTabs());
			return View(NoteList);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateManualTab(ManualTab model)
		{
			_manualTab.AddTabToDatabase(model);
			return RedirectToAction("Index");
		}
	}
}
