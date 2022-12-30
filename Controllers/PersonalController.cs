using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RPGApp.Data;
using RPGApp.Interfaces;
using RPGApp.Models;

namespace RPGApp.Controllers
{
	public class PersonalController:Controller
	{
		private readonly INotebook _notebook;
		private readonly IMapper _mapper;
		public PersonalController(INotebook notebook, IMapper mapper)
		{
			_notebook = notebook;
			_mapper = mapper;
		}
		public IActionResult Index()
		{
			List<NoteViewModel> NoteList = _mapper.Map<List<NoteViewModel>>(_notebook.GetNotebooks("Personal"));
			return View(NoteList);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreatePersonalNote(Note model)
		{
			model.ChosenNoteType = Note.NoteType.Personal;
			_notebook.AddNoteToDatabase(model);
			return RedirectToAction("Index");
		}
	}
}
