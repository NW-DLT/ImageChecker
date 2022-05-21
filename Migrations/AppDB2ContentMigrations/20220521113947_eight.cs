using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IT_StudioTestTask.Migrations.AppDB2ContentMigrations
{
    public partial class eight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CopyPhoto_Photos_photosId",
                table: "CopyPhoto");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_CopyPhoto_photosId",
                table: "CopyPhoto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CopyCheck = table.Column<bool>(type: "bit", nullable: false),
                    Disription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageSrc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CopyPhoto_photosId",
                table: "CopyPhoto",
                column: "photosId");

            migrationBuilder.AddForeignKey(
                name: "FK_CopyPhoto_Photos_photosId",
                table: "CopyPhoto",
                column: "photosId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
