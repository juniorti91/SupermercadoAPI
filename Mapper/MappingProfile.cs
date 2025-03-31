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
            CreateMap<Categoria, CategoriaPorIdDTO>().ReverseMap();

            // Mapping for Cliente
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Cliente, ClientePorIdDTO>().ReverseMap();

            // Mapping for Compra
            CreateMap<Compra, CompraDTO>().ReverseMap();
            CreateMap<Compra, CompraPorIdDTO>().ReverseMap();

            // Mapping for Fornecedor
            CreateMap<Fornecedor, FornecedorDTO>().ReverseMap();
            CreateMap<Fornecedor, FornecedorPorIdDTO>().ReverseMap();

            // Mapping for Funcionario
            CreateMap<Funcionario, FuncionarioDTO>().ReverseMap();
            CreateMap<Funcionario, FuncionarioPorIdDTO>().ReverseMap();
        }
    }
}