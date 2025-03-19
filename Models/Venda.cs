namespace SupermercadoAPI.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorTotal { get; set; }
        public int ClienteId { get; set; } // Chave estrangeira para Cliente
        public int FuncionarioId { get; set; } // Chave estrangeira para Funcionario
    }
}