using AutoMapper;
using Domain.Dtos;
using Domain.Entities;


namespace Infrastructure.MapperProfiles;

public class InfrastructureProfile : Profile
{
    public InfrastructureProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<Book, BookDetailDto>()
            .ForMember(bd => bd.AuthorCount, conf => conf.MapFrom(b => b.BookAuthors.Count()))
            .ForMember(bd => bd.ReviewCount, conf => conf.MapFrom(b => b.Reviews.Count()));
    }
}