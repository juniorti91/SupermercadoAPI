namespace SupermercadoAPI.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }

    public class CategoriaCreateDTO
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }

    public class CategoriaPorIdDTO
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}