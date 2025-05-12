using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mototrack_backend_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class challengedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MT_ORDEMSERVICO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Descricao = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    Prioridade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataAbertura = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DataFinalizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Responsavel = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PlacaMoto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MT_ORDEMSERVICO", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MT_ORDEMSERVICO");
        }
    }
}
