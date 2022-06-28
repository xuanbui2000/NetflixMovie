using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetflixMovie.Migrations
{
    public partial class imgTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageTitle",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageTitle",
                table: "Movie");
        }
    }
}
