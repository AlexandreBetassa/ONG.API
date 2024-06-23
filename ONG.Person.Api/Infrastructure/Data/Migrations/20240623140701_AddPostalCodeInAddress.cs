using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ONG.Person.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddPostalCodeInAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Address",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Address");
        }
    }
}
