using SupermercadoAPI.DTOs;
using SupermercadoAPI.Repository.Interfaces;
using SupermercadoAPI.Services.Interfaces;

namespace SupermercadoAPI.Repository
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorRepository(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        public Task<FornecedorDTO> AtualizarFornecedor(int id, FornecedorDTO fornecedor)
        {
            return _fornecedorService.AtualizarFornecedor(id, fornecedor);
        }

        public Task<FornecedorDTO> CriarFornecedor(FornecedorDTO fornecedor)
        {
            return _fornecedorService.CriarFornecedor(fornecedor);
        }

        public Task<bool> DeletarFornecedor(int id)
        {
            return _fornecedorService.DeletarFornecedor(id);
        }

        public Task<IEnumerable<FornecedorDTO>> ListarFornecedores()
        {
            return _fornecedorService.ListarFornecedores();
        }

        public Task<FornecedorPorIdDTO> ObterFornecedorPorId(int id)
        {
            return _fornecedorService.ObterFornecedorPorId(id);
        }
    }
}