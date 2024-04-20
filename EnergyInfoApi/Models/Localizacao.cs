namespace EnergyInfoApi.Models
{
    public class Localizacao
    {
        public int LocalizacaoId { get; set; }
        public string? Nome { get; set; }
        public string? Codigo { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? FonteEnergetica { get; set; }
        public string? PowerOutput { get; set; }
        public string? UnidadeMedida { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
