using AutoMapper;
using BookStore.Entities.DataTransferObjects;
using BookStore.Entities.Models;

namespace BookStore.WebAPI.Utlities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDtoForUpdate, Book>().ReverseMap();
            CreateMap<Book, BookDto>();
            CreateMap<BookDtoForInsertion,Book>();
        }
    }
}
