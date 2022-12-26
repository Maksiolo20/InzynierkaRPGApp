using System.ComponentModel.DataAnnotations;

namespace RPGApp.Data
{
	public class NPCCharacter
	{
		[Key]
		public int NPCId { get; set; }
		public string NPCName { get; set; }
		public int SessionId { get; set; }
		public Session Session { get; set; }
	}
}
