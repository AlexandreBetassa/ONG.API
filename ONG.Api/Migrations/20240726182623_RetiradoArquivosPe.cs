using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ONG.Person.Api.Migrations
{
    /// <inheritdoc />
    public partial class RetiradoArquivosPe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Castrated = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(50)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                });
        }
    }
}
