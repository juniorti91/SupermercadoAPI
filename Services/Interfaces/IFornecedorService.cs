using SupermercadoAPI.DTOs;

namespace SupermercadoAPI.Services.Interfaces
{
    public interface IFornecedorService
    {
        Task<IEnumerable<FornecedorDTO>> ListarFornecedores();
        Task<FornecedorPorIdDTO> ObterFornecedorPorId(int id);
        Task<FornecedorDTO> CriarFornecedor(FornecedorDTO fornecedor);
        Task<FornecedorDTO> AtualizarFornecedor(int id, FornecedorDTO fornecedor);
        Task<bool> DeletarFornecedor(int id);
    }
}