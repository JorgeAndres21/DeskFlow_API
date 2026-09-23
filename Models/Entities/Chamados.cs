namespace DeskFlowApi.Models.Entities
{
    public class Chamados
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Prioridade { get; set; }
        public string Status { get; set; }
        public string SolicitanteNome { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataFechamento { get; set; }
        public string Solucao { get; set; }

    }
}

//Id, Titulo, Descricao, Prioridade (Baixa, Media, Alta), 
// Status (Aberto, EmAndamento, Fechado), SolicitanteNome, DataAbertura, DataFechamento, Solucao e CategoriaId.