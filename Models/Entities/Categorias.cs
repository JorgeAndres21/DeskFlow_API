namespace DeskFlowApi.Models.Entities
{
    public class Categorias
    {
        public int CategotiaId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Chamados> ChamadosList { get; set; }
    }
}