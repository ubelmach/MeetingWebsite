using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetingWebsite.DAL.Migrations
{
    public partial class Add_column_Date_in_BlackList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "BlackLists",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "BlackLists");
        }
    }
}
