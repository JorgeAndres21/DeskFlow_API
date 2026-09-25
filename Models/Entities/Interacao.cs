namespace DeskFlowApi.Models.Entities
{
    public class Interacao
    {
        public int InteracaoId { get; set; }
        public Chamado Chamado { get; set; }
        public string Autor { get; set; }
        public string Mensagem { get; set; }
        public int ChamadoIdFK { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}