using System.ComponentModel.DataAnnotations.Schema;

namespace SupermercadoAPI.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public string Data_Compra { get; set; }
        public decimal Valor_Total { get; set; }
        public string NomeFornecedor  { get; set; } // Join com a tabela Fornecedor
    }
}