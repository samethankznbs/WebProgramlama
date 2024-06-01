using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class antrenordanisaneslestirme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppAntrenorId",
                table: "Danisans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Danisans_AppAntrenorId",
                table: "Danisans",
                column: "AppAntrenorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Danisans_Antrenors_AppAntrenorId",
                table: "Danisans",
                column: "AppAntrenorId",
                principalTable: "Antrenors",
                principalColumn: "AntrenorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Danisans_Antrenors_AppAntrenorId",
                table: "Danisans");

            migrationBuilder.DropIndex(
                name: "IX_Danisans_AppAntrenorId",
                table: "Danisans");

            migrationBuilder.DropColumn(
                name: "AppAntrenorId",
                table: "Danisans");
        }
    }
}
