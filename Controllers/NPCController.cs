using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RPGApp.Data;
using RPGApp.Interfaces;
using RPGApp.Models;

namespace RPGApp.Controllers
{
	public class NPCController : Controller
	{
		private readonly ICard _card;
		private ExpandedCardModel cardModel = new ExpandedCardModel();
		public NPCController(ICard card, IMapper mapper)
		{
			_card = card;
		}
        [HttpGet]
        public IActionResult Index()
		{
			cardModel.ListOfCards = _card.GetCards(Card.CardType.NPCCardFiles);
			return View(cardModel);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateNPC(ExpandedCardModel model, IFormFile file)
		{
			_card.AddCardToServer(model.Card, "NPCCardFiles", file);
			return RedirectToAction("Index");
		}
	}
}
