namespace ProjetoBitzen.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string TipoCombustivel { get; set; }
        public string Fabricante { get; set; }
        public int AnoFabricacao { get; set; }
        public decimal CapacidadeTanque { get; set; }
        public string Observacao { get; set; }
        public DateTime DataCadastroAlteracao { get; set; }
    }
}
