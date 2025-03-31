namespace SupermercadoAPI.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data_Venda { get; set; }
        public decimal Valor_Total { get; set; }
        public int Cliente_Id { get; set; } // Chave estrangeira para Cliente
        public int Funcionario_Id { get; set; } // Chave estrangeira para Funcionario
    }
}