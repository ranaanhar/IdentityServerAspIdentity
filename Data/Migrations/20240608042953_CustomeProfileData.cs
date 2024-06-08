using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServerAspIdentity.Data.Migrations
{
    /// <inheritdoc />
    public partial class CustomeProfileData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FavoriteColor",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavoriteColor",
                table: "AspNetUsers");
        }
    }
}
