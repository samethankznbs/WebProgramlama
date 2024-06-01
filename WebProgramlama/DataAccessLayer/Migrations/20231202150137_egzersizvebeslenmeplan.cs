using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class egzersizvebeslenmeplan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeslenmePlanis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hedef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gunlukOgun = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kaloriHedef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    beslnemePlanBaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    planSuresi = table.Column<int>(type: "int", nullable: false),
                    AppDanisanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeslenmePlanis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeslenmePlanis_Danisans_AppDanisanId",
                        column: x => x.AppDanisanId,
                        principalTable: "Danisans",
                        principalColumn: "DanisanId");
                });

            migrationBuilder.CreateTable(
                name: "EgzersizProgramis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    egzersizAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hedef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    setSayisi = table.Column<int>(type: "int", nullable: false),
                    tekrarSayisi = table.Column<int>(type: "int", nullable: false),
                    programBaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    programSuresi = table.Column<int>(type: "int", nullable: false),
                    AppDanisanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EgzersizProgramis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EgzersizProgramis_Danisans_AppDanisanId",
                        column: x => x.AppDanisanId,
                        principalTable: "Danisans",
                        principalColumn: "DanisanId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeslenmePlanis_AppDanisanId",
                table: "BeslenmePlanis",
                column: "AppDanisanId");

            migrationBuilder.CreateIndex(
                name: "IX_EgzersizProgramis_AppDanisanId",
                table: "EgzersizProgramis",
                column: "AppDanisanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeslenmePlanis");

            migrationBuilder.DropTable(
                name: "EgzersizProgramis");
        }
    }
}
