using AutoMapper;
using Librarian.BackEnd.Entity.Models;
using Librarian.BackEnd.Mapper.Dto;

namespace Librarian.BackEnd.Mapper.Helper
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
