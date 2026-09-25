using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeskFlowApi.Migrations
{
    /// <inheritdoc />
    public partial class modelagemDefinitiva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_categorias",
                columns: table => new
                {
                    idCat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeCat = table.Column<string>(type: "varchar(75)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_categorias", x => x.idCat);
                });

            migrationBuilder.CreateTable(
                name: "tb_chamados",
                columns: table => new
                {
                    idCham = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "varchar(100)", nullable: false),
                    descricao = table.Column<string>(type: "varchar(200)", nullable: true),
                    prioridade = table.Column<string>(type: "varchar(6)", nullable: false),
                    status = table.Column<string>(type: "varchar(20)", nullable: true, defaultValue: "aberto"),
                    solicitanteNome = table.Column<string>(type: "varchar(75)", nullable: false),
                    dataAbertura = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    dataFechamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    solucao = table.Column<string>(type: "varchar(250)", nullable: true),
                    CategoriaIdFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_chamados", x => x.idCham);
                    table.ForeignKey(
                        name: "FK_tb_chamados_tb_categorias_CategoriaIdFK",
                        column: x => x.CategoriaIdFK,
                        principalTable: "tb_categorias",
                        principalColumn: "idCat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_interacoes",
                columns: table => new
                {
                    interacoesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    autor = table.Column<string>(type: "varchar(50)", nullable: false),
                    mensagem = table.Column<string>(type: "varchar(250)", nullable: false),
                    ChamadoIdFK = table.Column<int>(type: "int", nullable: false),
                    dataRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_interacoes", x => x.interacoesId);
                    table.ForeignKey(
                        name: "FK_tb_interacoes_tb_chamados_ChamadoIdFK",
                        column: x => x.ChamadoIdFK,
                        principalTable: "tb_chamados",
                        principalColumn: "idCham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_chamados_CategoriaIdFK",
                table: "tb_chamados",
                column: "CategoriaIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_tb_interacoes_ChamadoIdFK",
                table: "tb_interacoes",
                column: "ChamadoIdFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_interacoes");

            migrationBuilder.DropTable(
                name: "tb_chamados");

            migrationBuilder.DropTable(
                name: "tb_categorias");
        }
    }
}
