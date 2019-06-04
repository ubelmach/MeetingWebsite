using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetingWebsite.DAL.Migrations
{
    public partial class AddPathInPhotoAlbum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "PhotoAlbums",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "PhotoAlbums");
        }
    }
}
