using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ONG.Person.Api.Migrations
{
    /// <inheritdoc />
    public partial class AjustadoEntityPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "Complement",
                table: "Address",
                type: "nvarchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Complement",
                table: "Address",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Address",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "");
        }
    }
}
