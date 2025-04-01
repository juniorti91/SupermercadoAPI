using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupermercadoAPI.DTOs;
using SupermercadoAPI.Repository.Interfaces;
using SupermercadoAPI.Services.Interfaces;

namespace SupermercadoAPI.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IProdutoService _produtoService;

        public ProdutoRepository(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public Task<ProdutoDTO> AtualizarProduto(int id, ProdutoDTO produto)
        {
            return _produtoService.AtualizarProduto(id, produto);
        }

        public Task<ProdutoDTO> CriarProduto(ProdutoDTO produto)
        {
            return _produtoService.CriarProduto(produto);
        }

        public Task<bool> DeletarProduto(int id)
        {
            return _produtoService.DeletarProduto(id);
        }

        public Task<IEnumerable<ProdutoDTO>> ListarProdutos()
        {
            return _produtoService.ListarProdutos();
        }

        public Task<ProdutoPorIdDTO> ObterProdutoPorId(int id)
        {
            return _produtoService.ObterProdutoPorId(id);
        }
    }
}