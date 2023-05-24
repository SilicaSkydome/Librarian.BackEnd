using AutoMapper;
using Librarian.BackEnd.Entity.Models;
using Librarian.BackEnd.Mapper.Dto.Book;
using Librarian.BackEnd.Mapper.Dto.Chapter;
using Librarian.BackEnd.Mapper.Dto.User;
using Librarian.BackEnd.Mapper.Dto.UserReading;

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
            CreateMap<UserLoginDto, User>();
            CreateMap<UserDataDto, User>();
            CreateMap<User, UserDataDto>();

            CreateMap<UserReadingPostDto, BookUserReading>();
        }
    }
}
