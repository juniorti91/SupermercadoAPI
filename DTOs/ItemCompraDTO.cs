namespace SupermercadoAPI.DTOs
{
    public class ItemCompraDTO
    {
        public int Id { get; set; }
        public int Compra_Id { get; set; } // chave estrangeira para Compra
        public int Produto_Id { get; set; } // chave estrangeira para Produto
        public int Quantidade { get; set; }
        public decimal Preco_Unitario { get; set; }
    }

    public class ItemCompraPorIdDTO
    {
        public int Compra_Id { get; set; } // chave estrangeira para Compra
        public int Produto_Id { get; set; } // chave estrangeira para Produto
        public int Quantidade { get; set; }
        public decimal Preco_Unitario { get; set; }
    }
}