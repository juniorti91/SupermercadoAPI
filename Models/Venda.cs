namespace SupermercadoAPI.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data_Venda { get; set; }
        public decimal Valor_Total { get; set; }
        public string NomeCliente { get; set; } // Join com a tabela Cliente
        public string NomeFuncionario { get; set; } // Join com a tabela Funcionario
    }
}