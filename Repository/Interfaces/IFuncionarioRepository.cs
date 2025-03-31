using SupermercadoAPI.DTOs;

namespace SupermercadoAPI.Repository.Interfaces
{
    public interface IFuncionarioRepository
    {
        Task<IEnumerable<FuncionarioDTO>> ListarFuncionarios();
        Task<FuncionarioPorIdDTO> ObterFuncionarioPorId(int id);
        Task<FuncionarioDTO> CriarFuncionario(FuncionarioDTO funcionario);
        Task<FuncionarioDTO> AtualizarFuncionario(int id, FuncionarioDTO funcionario);
        Task<bool> DeletarFuncionario(int id);
    }
}