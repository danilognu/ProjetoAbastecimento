namespace ProjetoBitzen.Models
{
    public class Abastecimento
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public int MotoristaId { get; set; }
        public string? TipoCombustivel { get; set; }
        public DateTime Data { get; set; }
        public decimal QuantidadeAbastecida { get; set; }
        public DateTime DataCadastroAlteracao { get; set; }
        public string? NomeVeiculo { get; set; }
        public string? NomeMotorista { get; set; }
    }
}
