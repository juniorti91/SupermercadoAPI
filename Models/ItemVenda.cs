namespace SupermercadoAPI.Models
{
    public class ItemVenda
    {
        public int Id { get; set; }
        public string ValorVenda { get; set; } // Join com a tabela Venda
        public string NomeProduto { get; set; } // Join com a tabela Produto
        public int Quantidade { get; set; }
        public decimal Preco_Unitario { get; set; }
    }
}