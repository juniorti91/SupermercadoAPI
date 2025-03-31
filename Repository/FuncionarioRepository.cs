using SupermercadoAPI.DTOs;
using SupermercadoAPI.Repository.Interfaces;
using SupermercadoAPI.Services.Interfaces;

namespace SupermercadoAPI.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioRepository(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        public Task<FuncionarioDTO> AtualizarFuncionario(int id, FuncionarioDTO funcionario)
        {
            return _funcionarioService.AtualizarFuncionario(id, funcionario);
        }

        public Task<FuncionarioDTO> CriarFuncionario(FuncionarioDTO funcionario)
        {
            return _funcionarioService.CriarFuncionario(funcionario);
        }

        public Task<bool> DeletarFuncionario(int id)
        {
            return _funcionarioService.DeletarFuncionario(id);
        }

        public Task<IEnumerable<FuncionarioDTO>> ListarFuncionarios()
        {
            return _funcionarioService.ListarFuncionarios();
        }

        public Task<FuncionarioPorIdDTO> ObterFuncionarioPorId(int id)
        {
            return _funcionarioService.ObterFuncionarioPorId(id);
        }
    }
}