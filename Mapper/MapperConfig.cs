﻿using AutoMapper;
using RPGApp.Data;
using RPGApp.Models;

namespace RPGApp.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Note, NoteViewModel>();
            CreateMap<ManualTab, ManualTabViewModel>();
			////CreateMap<Note, NoteModel>();
		}
    }
}
