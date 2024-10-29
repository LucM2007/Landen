using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Landen.Migrations
{
    /// <inheritdoc />
    public partial class Landen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Land",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(type: "varchar(255)", nullable: false),
                    EersteTaal = table.Column<string>(type: "varchar(255)", nullable: false),
                    AantalInwooners = table.Column<int>(type: "int", nullable: false),
                    AantalInwoonersDatum = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Hooftstad = table.Column<string>(type: "varchar(255)", nullable: false),
                    TelefoonCode = table.Column<int>(type: "int", nullable: false),
                    Bnp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BnpDatum = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Gevonden = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Land", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Land_Naam_EersteTaal_AantalInwooners_AantalInwoonersDatum_Ho~",
                table: "Land",
                columns: new[] { "Naam", "EersteTaal", "AantalInwooners", "AantalInwoonersDatum", "Hooftstad", "TelefoonCode", "Bnp", "BnpDatum", "Gevonden" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Land");
        }
    }
}
