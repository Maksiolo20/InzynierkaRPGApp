using RPGApp.Data;
using RPGApp.Models;
using static RPGApp.Data.Card;

namespace RPGApp.Interfaces
{
	public interface ICard
	{
		public List<CardFileModel> GetCards(CardType cardType);
		public void AddCardToServer(Card model, string cardType, IFormFile file);
	}
}
