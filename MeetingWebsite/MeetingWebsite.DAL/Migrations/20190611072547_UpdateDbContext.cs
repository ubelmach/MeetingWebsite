using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetingWebsite.DAL.Migrations
{
    public partial class UpdateDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLanguages_Languageses_LanguageId",
                table: "UserLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPurpose_PurposeOfDatings_PurposeId",
                table: "UserPurpose");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPurpose_UserProfiles_UserProfileId",
                table: "UserPurpose");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPurpose",
                table: "UserPurpose");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languageses",
                table: "Languageses");

            migrationBuilder.RenameTable(
                name: "UserPurpose",
                newName: "UserPurposes");

            migrationBuilder.RenameTable(
                name: "Languageses",
                newName: "Languages");

            migrationBuilder.RenameIndex(
                name: "IX_UserPurpose_UserProfileId",
                table: "UserPurposes",
                newName: "IX_UserPurposes_UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPurpose_PurposeId",
                table: "UserPurposes",
                newName: "IX_UserPurposes_PurposeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPurposes",
                table: "UserPurposes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLanguages_Languages_LanguageId",
                table: "UserLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPurposes_PurposeOfDatings_PurposeId",
                table: "UserPurposes",
                column: "PurposeId",
                principalTable: "PurposeOfDatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPurposes_UserProfiles_UserProfileId",
                table: "UserPurposes",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLanguages_Languages_LanguageId",
                table: "UserLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPurposes_PurposeOfDatings_PurposeId",
                table: "UserPurposes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPurposes_UserProfiles_UserProfileId",
                table: "UserPurposes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPurposes",
                table: "UserPurposes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.RenameTable(
                name: "UserPurposes",
                newName: "UserPurpose");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "Languageses");

            migrationBuilder.RenameIndex(
                name: "IX_UserPurposes_UserProfileId",
                table: "UserPurpose",
                newName: "IX_UserPurpose_UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPurposes_PurposeId",
                table: "UserPurpose",
                newName: "IX_UserPurpose_PurposeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPurpose",
                table: "UserPurpose",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languageses",
                table: "Languageses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLanguages_Languageses_LanguageId",
                table: "UserLanguages",
                column: "LanguageId",
                principalTable: "Languageses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPurpose_PurposeOfDatings_PurposeId",
                table: "UserPurpose",
                column: "PurposeId",
                principalTable: "PurposeOfDatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPurpose_UserProfiles_UserProfileId",
                table: "UserPurpose",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
