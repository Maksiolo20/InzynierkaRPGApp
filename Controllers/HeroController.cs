using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RPGApp.Data;
using RPGApp.Interfaces;
using RPGApp.Models;
using System.Security.Claims;

namespace RPGApp.Controllers
{
    public class HeroController : Controller
    {
		private readonly ICard _card;
		private ExpandedCardModel cardModel = new ExpandedCardModel();
		public HeroController(ICard card, IMapper mapper)
		{
			_card = card;
		}

		[HttpGet]
		public IActionResult Index()
		{
			cardModel.ListOfCards = _card.GetCards(Card.CardType.HeroCardFiles);
			return View(cardModel);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateHero(ExpandedCardModel model, IFormFile file)
		{
			_card.AddCardToServer(model.Card, "HeroCardFiles", file);
			return RedirectToAction("Index");
		}
	}
}
