namespace ProjetoBitzen.Models
{
    public class Motorista
    {
        public int Id { get; set; } 
        public string? Nome { get; set;}
        public string? CPF { get; set; }
        public string? CNH { get; set; }
        public string? Categoria { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Status { get; set; }
        public DateTime DataCadastroAlteracao { get; set; }
    }
}
