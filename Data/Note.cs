using Microsoft.DotNet.Scaffolding.Shared.Project;
using System.ComponentModel.DataAnnotations;

namespace RPGApp.Data
{
	public class Note
	{
		[Key]
		public int NoteId { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
		public NoteType ChosenNoteType { get; set; }
		public int SessionId { get; set; }
		public Session Session { get; set; }

		public enum NoteType
		{
			Chronology,
			Plot,
			Personal,
			NPC
		}

    }
}
