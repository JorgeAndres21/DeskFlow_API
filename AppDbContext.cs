using Microsoft.EntityFrameworkCore;
using DeskFlowApi.Models.Entities;

namespace DeskFlowApi
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categorias>(cat =>
            {
                cat.ToTable("tb_categorias");

                cat.HasKey(c => c.CategotiaId);

                cat.Property(c => c.CategotiaId)
                .HasColumnName("idCat")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(seed: 1, increment: 1);

                cat.Property(c => c.Nome)
                .HasColumnName("nomeCat")
                .HasColumnType("varchar(75)")
                .IsRequired();

                cat.HasMany(c => c.ChamadosList)
                .WithOne(c => c.Categoria)
                .HasForeignKey(c => c.CategoriaIdKey);
            });

            modelBuilder.Entity<Chamados>(cham =>
            {
                cham.ToTable("tb_chamados");

                cham.Property(c => c.ChamadosId)
                .HasColumnName("idCham")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(seed: 1, increment: 1);

                cham.Property(c => c.Titulo)
                .HasColumnName("titulo")
                .HasColumnType("varchar(100)")
                .IsRequired();

                cham.Property(c => c.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("varchar(200)");

                cham.Property(c => c.Prioridade)
                .HasColumnName("prioridade")
                .HasColumnType("varchar(6)")
                .IsRequired();

                cham.Property(c => c.Status)
                .HasColumnName("status")
                .HasColumnType("varchar(20)")
                .HasDefaultValue("aberto");

                cham.Property(c => c.SolicitanteNome)
                .HasColumnName("solicitanteNome")
                .HasColumnType("varchar(75)")
                .IsRequired();

                cham.Property(c => c.DataAbertura)
                .HasColumnName("dataAbertura")
                .HasDefaultValue("getdate()");

                cham.Property(c => c.DataFechamento)
                .HasColumnName("dataFechamento");

                cham.Property(c => c.Solucao)
                .HasColumnName("solucao")
                .HasColumnType("varchar(250)");
            });
        }
    }
}