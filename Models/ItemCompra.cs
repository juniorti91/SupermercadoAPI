namespace SupermercadoAPI.Models
{
    public class ItemCompra
    {
        public int Id { get; set; }
        public string ValorCompra { get; set; } // Join com a tabela Compra
        public string NomeProduto { get; set; } // Join com a tabela Produto
        public int Quantidade { get; set; }
        public decimal Preco_Unitario { get; set; }
    }
}