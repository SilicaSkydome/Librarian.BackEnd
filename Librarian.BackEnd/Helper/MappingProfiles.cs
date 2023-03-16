using AutoMapper;
using Librarian.BackEnd.Dto;
using Librarian.BackEnd.Models;

namespace Librarian.BackEnd.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookGetDto>();
            CreateMap<BookGetDto, Book>();
            CreateMap<BookPostDto, Book>();
            CreateMap<Chapter, ChapterGetDto>();
            CreateMap<ChapterGetDto, Chapter>();
            CreateMap<ChapterPostDto, Chapter>();
            CreateMap<User, UserGetDto>();
            CreateMap<UserPostDto, User>();
            CreateMap<UserPostDto, User>();
        }
    }
}
