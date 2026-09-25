namespace DeskFlowApi.Models.Entities
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Chamado> ChamadosList { get; set; }
    }
}