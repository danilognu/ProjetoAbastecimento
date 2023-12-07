namespace ProjetoBitzen.Models
{
    public class MotoristaModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? CNH { get; set; }
        public string? Categoria { get; set; }
        public string DataNascimento { get; set; }
        public int Status { get; set; }
    }
}
