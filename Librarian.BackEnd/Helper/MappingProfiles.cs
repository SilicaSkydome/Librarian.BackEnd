using AutoMapper;
using Librarian.BackEnd.Dto;
using Librarian.BackEnd.Models;

namespace Librarian.BackEnd.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
            CreateMap<Chapter, ChapterDto>();
            CreateMap<ChapterDto, Chapter>();
        }
    }
}
