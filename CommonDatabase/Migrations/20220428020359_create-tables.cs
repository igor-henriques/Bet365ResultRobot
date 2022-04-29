using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommonDatabase.Migrations
{
    public partial class createtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Odd",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoEvento = table.Column<byte>(type: "tinyint", nullable: false),
                    NomeTimeCasa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProbabilidadeVitoriaTimeCasa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NomeTimeVisitante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProbabilidadeVitoriaTimeVisitante = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProbabilidadeEmpate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaisDe2_5Gols = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenosDe2_5Gols = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PontuacaoCorretaTimeCasa_1_0 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PontuacaoCorretaTimeCasa_2_0 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PontuacaoCorretaTimeCasa_2_1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PontuacaoCorretaTimeVisitante_1_0 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PontuacaoCorretaTimeVisitante_2_0 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PontuacaoCorretaTimeVisitante_2_1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PontuacaoCorretaEmpate_1_0 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PontuacaoCorretaEmpate_2_0 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PontuacaoCorretaEmpate_2_1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VisitadoOuEmpate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VisitadoOuVisitante = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmpateOuVisitante = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total0Gols = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total1Gols = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total2Gols = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total3Gols = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total4Gols = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odd", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resultado",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoEvento = table.Column<byte>(type: "tinyint", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomeTimeCasa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PontuacaoTimeCasa = table.Column<short>(type: "smallint", nullable: false),
                    NomeTimeVisitante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PontuacaoTimeVisitante = table.Column<short>(type: "smallint", nullable: false),
                    TotalGols = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultado", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Odd");

            migrationBuilder.DropTable(
                name: "Resultado");
        }
    }
}
