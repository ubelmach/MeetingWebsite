using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetingWebsite.DAL.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "AnonymityMode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BadHabits",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Education",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FinancialSituation",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Interests",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KnowledgeOfLanguages",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PurposeOfDating",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ZodiacSign",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BlackLists",
                newName: "CurrentUserId");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "AspNetUsers",
                newName: "HomeDir");

            migrationBuilder.AddColumn<int>(
                name: "AlbumId",
                table: "Files",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "CurrentUserId",
                table: "BlackLists",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "HomeDir",
                table: "AspNetUsers",
                newName: "Weight");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverId",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AnonymityMode",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BadHabits",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinancialSituation",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Height",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Interests",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KnowledgeOfLanguages",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurposeOfDating",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZodiacSign",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
