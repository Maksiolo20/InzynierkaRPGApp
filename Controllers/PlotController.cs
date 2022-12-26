using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RPGApp.Data;
using RPGApp.Interfaces;
using RPGApp.Models;
using System.Security.Claims;

namespace RPGApp.Controllers
{
	public class PlotController : Controller
	{
		private readonly INotebook _notebook;
        private readonly IMapper _mapper;
        public PlotController(INotebook notebook, IMapper mapper)
		{
            _notebook = notebook;
			_mapper = mapper;
		}
		public IActionResult Index()
		{
			List<PlotNoteModel> NoteList = _mapper.Map<List<PlotNoteModel>>(_notebook.GetNotebooks("Plot"));	
			return View(NoteList);
		}

		[HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> CreatePlotNote(Note model)
		{
			model.ChosenNoteType = Note.NoteType.Plot;
			_notebook.AddNoteToDatabase(model);
            return RedirectToAction("Index");
		}
	}
}
