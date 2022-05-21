using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IT_StudioTestTask.Migrations.AppDB2ContentMigrations
{
    public partial class seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CopyPhoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    photosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CopyPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CopyPhoto_Photos_photosId",
                        column: x => x.photosId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CopyPhoto_photosId",
                table: "CopyPhoto",
                column: "photosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CopyPhoto");
        }
    }
}
