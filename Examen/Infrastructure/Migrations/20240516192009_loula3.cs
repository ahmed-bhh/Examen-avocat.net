using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class loula3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    CIN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.CIN);
                });

            migrationBuilder.CreateTable(
                name: "Specialite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomSpecialite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Avocat",
                columns: table => new
                {
                    AvocatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateEmbauche = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpecialiteFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avocat", x => x.AvocatId);
                    table.ForeignKey(
                        name: "FK_Avocat_Specialite_SpecialiteFK",
                        column: x => x.SpecialiteFK,
                        principalTable: "Specialite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dossier",
                columns: table => new
                {
                    DateDepot = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Avocat_FK = table.Column<int>(type: "int", nullable: false),
                    Client_FK = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    frais = table.Column<double>(type: "float", nullable: false),
                    clos = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dossier", x => new { x.DateDepot, x.Client_FK, x.Avocat_FK });
                    table.ForeignKey(
                        name: "FK_Dossier_Avocat_Avocat_FK",
                        column: x => x.Avocat_FK,
                        principalTable: "Avocat",
                        principalColumn: "AvocatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dossier_Client_Client_FK",
                        column: x => x.Client_FK,
                        principalTable: "Client",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avocat_SpecialiteFK",
                table: "Avocat",
                column: "SpecialiteFK");

            migrationBuilder.CreateIndex(
                name: "IX_Dossier_Avocat_FK",
                table: "Dossier",
                column: "Avocat_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Dossier_Client_FK",
                table: "Dossier",
                column: "Client_FK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dossier");

            migrationBuilder.DropTable(
                name: "Avocat");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Specialite");
        }
    }
}
