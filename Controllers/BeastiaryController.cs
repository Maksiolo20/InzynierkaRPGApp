using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RPGApp.Data;
using RPGApp.Interfaces;
using RPGApp.Models;
using System.Security.Claims;

namespace RPGApp.Controllers
{
	public class BeastiaryController : Controller
	{
        private readonly ICard _card;
        private readonly IMapper _mapper;
        private ExpandedCardModel cardModel = new ExpandedCardModel();
        public BeastiaryController(ICard card, IMapper mapper)
		{
            _card = card;
            _mapper = mapper;
        }

        [HttpGet]
		public IActionResult Index()
		{
            cardModel.ListOfCards = _card.GetCards(Card.CardType.BestiaryCardFiles);
            return View(cardModel);
		}

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBeast(ExpandedCardModel model, IFormFile file)
        {
            _card.AddCardToServer(model.Card, "BeastiaryCardFiles", file);
            return RedirectToAction("Index");
        }
    }
}
