using Microsoft.AspNetCore.Mvc;
using RPGApp.Data;
using RPGApp.Interfaces;
using RPGApp.Models;
using System.Security.Claims;
using static RPGApp.Data.Note;

namespace RPGApp.Services
{
    public class NotebookService : INotebook
    {
        private readonly ApplicationDbContext _context;
        private string UserId;
        public NotebookService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            UserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public List<Note> GetNotebooks(string noteType)
        {
            List<Note> NoteList = new();
            var FilteredNotes = FilterNotes(_context.Notes.ToList(), noteType);
            foreach (var item in FilteredNotes)
            {
                if (item.SessionId == _context.Users.First(x => x.Id == UserId).CurrentSessionId)
                {
                    NoteList.Add(new Note()
                    {
                        Body = item.Body,
                        Title = item.Title,
                    });
                }
            }
            return NoteList;
        }

        public List<Note> FilterNotes(List<Note> ListToFilter, string noteType)
        {
            var FilteredList = ListToFilter.Where(x => x.ChosenNoteType.ToString() == noteType).ToList();
            return FilteredList;
        }

        public void AddNoteToDatabase(Note model)
        {
            model.SessionId = _context.Users.First(x => x.Id == UserId).CurrentSessionId;
            _context.Notes.Add(model);
            _context.SaveChanges();
        }
    }
}
