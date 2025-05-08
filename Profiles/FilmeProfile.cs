using AutoMapper;
using FilmesApi.Dtos;
using FilmesApi.Entity;

namespace FilmesApi.Profiles;

public class FilmeProfile : Profile
{

    public FilmeProfile() {
        CreateMap<CreateFilmeDto, Filme>();
    }
}
