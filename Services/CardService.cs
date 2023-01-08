using AutoMapper;
using Microsoft.AspNetCore.Http;
using RPGApp.Data;
using RPGApp.Interfaces;
using RPGApp.Models;
using System.Security.Claims;
using static RPGApp.Data.Card;
using static RPGApp.Data.Note;

namespace RPGApp.Services
{
	public class CardService : ICard
	{
		Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnviroment;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ApplicationDbContext _context;
		public CardService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnviroment)
		{
			_context = context;
			_httpContextAccessor = httpContextAccessor;
			_hostingEnviroment = hostingEnviroment;

		}
		public List<CardFileModel> GetCards(CardType cardType)
		{
			string UserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

			List<CardFileModel> viewModel = new List<CardFileModel>();
			int currentSessionId = _context.Users.First(x => x.Id == UserId).CurrentSessionId;
			List<Card> ChosenCards = _context.Cards.Where(x => x.ChosenCardType==cardType)
												   .Where(x => x.SessionId == currentSessionId).ToList();
			foreach (var item in ChosenCards)
			{
				CardFileModel model = new CardFileModel()
					{
					Body = item.Body,
					CardId= item.CardId,
					Title= item.Title,
					CardPath = item.CardPath
				};
				viewModel.Add(model);
			}
			return viewModel;
		}
		public void AddCardToServer(Card model, string cardType, IFormFile file)
		{
			string UserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            model.SessionId = _context.Users.First(x => x.Id == UserId).CurrentSessionId;
			if (file != null)
			{
				model.CardPath = file.FileName;

				string fileName = $"{_hostingEnviroment.WebRootPath}\\{cardType}\\{model.CardPath}";
				using (FileStream fileStream = System.IO.File.Create(fileName))
				{
					file.CopyTo(fileStream);
					fileStream.Flush();
				}
			}
			if (cardType == "HeroCardFiles") model.ChosenCardType = CardType.HeroCardFiles;
			else if (cardType == "BeastiaryCardFiles") model.ChosenCardType = CardType.BestiaryCardFiles;
			else model.ChosenCardType = CardType.NPCCardFiles;
			_context.Cards.Add(model);
			_context.SaveChanges();
		}
	}
}
