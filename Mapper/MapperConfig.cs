using AutoMapper;
using RPGApp.Data;
using RPGApp.Models;

namespace RPGApp.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Note, ChronologyNoteModel>();
            CreateMap<Note, PlotNoteModel>();
            ////CreateMap<Note, NoteModel>();
            ////CreateMap<Note, NoteModel>();
        }
    }
}
