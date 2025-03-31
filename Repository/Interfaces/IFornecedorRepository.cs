using SupermercadoAPI.DTOs;

namespace SupermercadoAPI.Repository.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<IEnumerable<FornecedorDTO>> ListarFornecedores();
        Task<FornecedorPorIdDTO> ObterFornecedorPorId(int id);
        Task<FornecedorDTO> CriarFornecedor(FornecedorDTO fornecedor);
        Task<FornecedorDTO> AtualizarFornecedor(int id, FornecedorDTO fornecedor);
        Task<bool> DeletarFornecedor(int id);
    }
}