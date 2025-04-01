using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupermercadoAPI.DTOs;

namespace SupermercadoAPI.Repository.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<ProdutoDTO>> ListarProdutos();
        Task<ProdutoPorIdDTO> ObterProdutoPorId(int id);
        Task<ProdutoDTO> CriarProduto(ProdutoDTO produto);
        Task<ProdutoDTO> AtualizarProduto(int id, ProdutoDTO produto);
        Task<bool> DeletarProduto(int id);
    }
}