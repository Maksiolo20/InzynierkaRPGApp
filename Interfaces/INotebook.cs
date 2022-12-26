using RPGApp.Data;

namespace RPGApp.Interfaces
{
    public interface INotebook
    {
        public List<Note> GetNotebooks(string noteType);
        public void AddNoteToDatabase(Note model);

    }
}