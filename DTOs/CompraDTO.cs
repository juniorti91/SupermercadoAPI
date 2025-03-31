using System.ComponentModel.DataAnnotations.Schema;

namespace SupermercadoAPI.DTOs
{
    public class CompraDTO
    {
        public int Id { get; set; }
        public string Data_Compra { get; set; }
        public decimal Valor_Total { get; set; }
        public int Fornecedor_Id { get; set; } // Chave estrangeira para Fornecedor
    }

    public class CompraPorIdDTO
    {
        public string Data_Compra { get; set; }
        public decimal Valor_Total { get; set; }
        public int Fornecedor_Id { get; set; } // Chave estrangeira para Fornecedor
    }
}