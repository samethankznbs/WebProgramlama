using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class duzeltme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "beslnemePlanBaslangicTarihi",
                table: "BeslenmePlanis",
                newName: "beslenmePlanBaslangicTarihi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "beslenmePlanBaslangicTarihi",
                table: "BeslenmePlanis",
                newName: "beslnemePlanBaslangicTarihi");
        }
    }
}
