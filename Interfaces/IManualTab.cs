using RPGApp.Data;
using RPGApp.Models;

namespace RPGApp.Interfaces
{
	public interface IManualTab
	{
		public List<ManualTab> GetTabs();
		public void AddTabToDatabase(ManualTab model);
	}
}
