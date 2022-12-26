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
	public class ChronologyController : Controller
	{
		private readonly INotebook _notebook;
        private readonly IMapper _mapper;
        public ChronologyController(INotebook notebook, IMapper mapper)
		{
            _notebook = notebook;
			_mapper = mapper;
		}
		public IActionResult Index()
		{
			List<ChronologyNoteModel> NoteList = _mapper.Map<List<ChronologyNoteModel>>(_notebook.GetNotebooks("Chronology"));	
			return View(NoteList);
		}

		[HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> CreateChronologyNote(Note model)
		{
			model.ChosenNoteType = Note.NoteType.Chronology;
			_notebook.AddNoteToDatabase(model);
            return RedirectToAction("Index");
		}
	}
}
