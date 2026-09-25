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

        private void ValidarStatus(string status)
        {
            string statusToLower = status.ToLower();

            if (statusToLower == "aberto" || statusToLower == "em_andamento" || statusToLower == "fechado")
            {
                Status = status;
            }
            else throw new Exception("Tipo de prioridade invalida");
        }
        private void ValidarPrioridade(string prioridade)
        {
            string prioridadeToLower = prioridade.ToLower();

            if (prioridadeToLower == "baixa" || prioridadeToLower == "media"
            || prioridadeToLower == "média" || prioridadeToLower == "alta")
            {
                Prioridade = prioridade;
            }
            else throw new Exception("Tipo de prioridade invalida");
        }
    }
}

//Id, Titulo, Descricao, Prioridade (Baixa, Media, Alta), 
// Status (Aberto, EmAndamento, Fechado), SolicitanteNome, DataAbertura, DataFechamento, Solucao e CategoriaId.