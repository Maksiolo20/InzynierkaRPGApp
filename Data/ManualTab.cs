using System.ComponentModel.DataAnnotations;
using static RPGApp.Data.Note;

namespace RPGApp.Data
{
	public class ManualTab
	{
		[Key]
		public int TabId { get; set; }
		public string Title { get; set; }
		public string? Body { get; set; }
		public string ManualURL { get; set; }
		public int SessionId { get; set; }
		public Session Session { get; set; }
	}
}
