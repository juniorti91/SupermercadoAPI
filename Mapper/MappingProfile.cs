using AutoMapper;
using SupermercadoAPI.DTOs;
using SupermercadoAPI.Models;

namespace SupermercadoAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping for Categoria
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Categoria, CategoriaCreateDTO>().ReverseMap();
            CreateMap<Categoria, CategoriaPorIdDTO>().ReverseMap();
        }
    }
}