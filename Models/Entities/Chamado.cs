namespace DeskFlowApi.Models.Entities
{
    public class Chamado
    {
        public int ChamadoId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Prioridade { get; set; }
        public string Status { get; set; }
        public string SolicitanteNome { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataFechamento { get; set; }
        public string Solucao { get; set; }
        public virtual Categoria Categoria { get; set; }
        public int CategoriaIdFK { get; set; }
        public ICollection<Interacao> InteracoesList { get; set; }

        public void Update(Chamado cham)
        {
            Titulo = cham.Titulo;
            Descricao = cham.Descricao;
            SolicitanteNome = cham.SolicitanteNome;
            Solucao = cham.Solucao;
            CategoriaIdFK = cham.CategoriaIdFK;
        }

    }
}

//Id, Titulo, Descricao, Prioridade (Baixa, Media, Alta), 
// Status (Aberto, EmAndamento, Fechado), SolicitanteNome, DataAbertura, DataFechamento, Solucao e CategoriaId.