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

            modelBuilder.Entity<Categoria>(cat =>
            {
                cat.ToTable("tb_categorias");

                cat.HasKey(c => c.CategoriaId);

                cat.Property(c => c.CategoriaId)
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
                .HasForeignKey(c => c.CategoriaIdFK);
            });

            modelBuilder.Entity<Chamado>(cham =>
            {
                cham.ToTable("tb_chamados");

                cham.HasKey(c => c.ChamadoId);

                cham.Property(c => c.ChamadoId)
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
                .HasDefaultValueSql("getdate()");

                cham.Property(c => c.DataFechamento)
                .HasColumnName("dataFechamento");

                cham.Property(c => c.Solucao)
                .HasColumnName("solucao")
                .HasColumnType("varchar(250)");

                cham.HasMany(c => c.InteracoesList)
                .WithOne(c => c.Chamado)
                .HasForeignKey(c => c.ChamadoIdFK);
            });

            modelBuilder.Entity<Interacao>(inter =>
            {
                inter.ToTable("tb_interacoes");

                inter.HasKey(i => i.InteracaoId);

                inter.Property(i => i.InteracaoId)
                .HasColumnName("interacoesId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(seed: 1, increment: 1);

                inter.Property(i => i.Autor)
                .HasColumnName("autor")
                .HasColumnType("varchar(50)")
                .IsRequired();

                inter.Property(i => i.Mensagem)
                .HasColumnName("mensagem")
                .HasColumnType("varchar(250)")
                .IsRequired();

                inter.Property(i => i.DataRegistro)
                .HasColumnName("dataRegistro");
            });
        }
    }
}