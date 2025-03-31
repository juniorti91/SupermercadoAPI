namespace SupermercadoAPI.Models
{
    public class ItemVenda
    {
        public int Id { get; set; }
        public int Venda_Id { get; set; } // chave estrangeira para Venda
        public int Produto_Id { get; set; } // chave estrangeira para Produto
        public int Quantidade { get; set; }
        public decimal Preco_Unitario { get; set; }
    }
}