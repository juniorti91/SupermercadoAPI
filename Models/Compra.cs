namespace SupermercadoAPI.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public DateTime DataCompra { get; set; }
        public decimal ValorTotal { get; set; }
        public int FornecedorId { get; set; } // Chave estrangeira para Fornecedor
    }
}