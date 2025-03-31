using SupermercadoAPI.DTOs;

namespace SupermercadoAPI.Services.Interfaces
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<FuncionarioDTO>> ListarFuncionarios();
        Task<FuncionarioPorIdDTO> ObterFuncionarioPorId(int id);
        Task<FuncionarioDTO> CriarFuncionario(FuncionarioDTO funcionario);
        Task<FuncionarioDTO> AtualizarFuncionario(int id, FuncionarioDTO funcionario);
        Task<bool> DeletarFuncionario(int id);
    }
}