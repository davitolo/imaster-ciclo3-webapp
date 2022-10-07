using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Huellitasco.App.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Historia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicial = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Correo = table.Column<string>(nullable: true),
                    TarjetaPreofesional = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VisitasPyP",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaVisita = table.Column<DateTime>(nullable: false),
                    Temperatura = table.Column<float>(nullable: false),
                    Peso = table.Column<float>(nullable: false),
                    FrecuenciaRespiratoria = table.Column<float>(nullable: false),
                    FrecuenciaCardiaca = table.Column<float>(nullable: false),
                    EstadoAnimo = table.Column<string>(nullable: true),
                    IdVeterinario = table.Column<int>(nullable: false),
                    Recomendaciones = table.Column<string>(nullable: true),
                    HistoriaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitasPyP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitasPyP_Historia_HistoriaId",
                        column: x => x.HistoriaId,
                        principalTable: "Historia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mascota",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Especie = table.Column<string>(nullable: true),
                    Raza = table.Column<string>(nullable: true),
                    DuenoId = table.Column<int>(nullable: true),
                    VeterinarioId = table.Column<int>(nullable: true),
                    HistoriaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mascota_Personas_DuenoId",
                        column: x => x.DuenoId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mascota_Historia_HistoriaId",
                        column: x => x.HistoriaId,
                        principalTable: "Historia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mascota_Personas_VeterinarioId",
                        column: x => x.VeterinarioId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_DuenoId",
                table: "Mascota",
                column: "DuenoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_HistoriaId",
                table: "Mascota",
                column: "HistoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_VeterinarioId",
                table: "Mascota",
                column: "VeterinarioId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitasPyP_HistoriaId",
                table: "VisitasPyP",
                column: "HistoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mascota");

            migrationBuilder.DropTable(
                name: "VisitasPyP");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Historia");
        }
    }
}
