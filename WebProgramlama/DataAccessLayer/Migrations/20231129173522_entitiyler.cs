using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class entitiyler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConfirmCodee",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Antrenors",
                columns: table => new
                {
                    AntrenorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UzmanlikAlani = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deneyim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antrenors", x => x.AntrenorId);
                    table.ForeignKey(
                        name: "FK_Antrenors_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Danisans",
                columns: table => new
                {
                    DanisanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hedef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kilo = table.Column<int>(type: "int", nullable: false),
                    boy = table.Column<int>(type: "int", nullable: false),
                    vucutYagOrani = table.Column<int>(type: "int", nullable: false),
                    kasKutlesi = table.Column<int>(type: "int", nullable: false),
                    vucutKitleİndex = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Danisans", x => x.DanisanId);
                    table.ForeignKey(
                        name: "FK_Danisans_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Antrenors_AppUserId",
                table: "Antrenors",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Danisans_AppUserId",
                table: "Danisans",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Antrenors");

            migrationBuilder.DropTable(
                name: "Danisans");

            migrationBuilder.DropColumn(
                name: "ConfirmCodee",
                table: "AspNetUsers");
        }
    }
}
