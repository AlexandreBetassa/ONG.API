using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ONG.Person.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddPet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Castrated = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");
        }
    }
}
