using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRJ4.Migrations
{
    /// <inheritdoc />
    public partial class TestMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bruger",
                columns: table => new
                {
                    BrugerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bruger__6FA2FB30AE403A15", x => x.BrugerID);
                });

            migrationBuilder.CreateTable(
                name: "Findtægt",
                columns: table => new
                {
                    Findtægt = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrugerID = table.Column<int>(type: "int", nullable: false),
                    Tekst = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Indtægt = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Dato = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Findtægt__2E1D3E026C53B483", x => x.Findtægt);
                    table.ForeignKey(
                        name: "FK__Findtægt__Bruger__4222D4EF",
                        column: x => x.BrugerID,
                        principalTable: "Bruger",
                        principalColumn: "BrugerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fudgifter",
                columns: table => new
                {
                    FudgiftID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrugerID = table.Column<int>(type: "int", nullable: false),
                    Pris = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Tekst = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Dato = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Fudgifte__12BF03E8C7E5D9C7", x => x.FudgiftID);
                    table.ForeignKey(
                        name: "FK__Fudgifter__Bruge__3C69FB99",
                        column: x => x.BrugerID,
                        principalTable: "Bruger",
                        principalColumn: "BrugerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vindtægter",
                columns: table => new
                {
                    VindtægtID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrugerID = table.Column<int>(type: "int", nullable: false),
                    Tekst = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Indtægt = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Dato = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vindtægt__83BCC36FD3543C24", x => x.VindtægtID);
                    table.ForeignKey(
                        name: "FK__Vindtægte__Bruge__3F466844",
                        column: x => x.BrugerID,
                        principalTable: "Bruger",
                        principalColumn: "BrugerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vudgifter",
                columns: table => new
                {
                    VudgiftID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrugerID = table.Column<int>(type: "int", nullable: false),
                    KategoriID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Pris = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Tekst = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Dato = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vudgifte__7E8DE19A4E24036F", x => x.VudgiftID);
                    table.ForeignKey(
                        name: "FK__Vudgifter__Bruge__398D8EEE",
                        column: x => x.BrugerID,
                        principalTable: "Bruger",
                        principalColumn: "BrugerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Findtægt_BrugerID",
                table: "Findtægt",
                column: "BrugerID");

            migrationBuilder.CreateIndex(
                name: "IX_Fudgifter_BrugerID",
                table: "Fudgifter",
                column: "BrugerID");

            migrationBuilder.CreateIndex(
                name: "IX_Vindtægter_BrugerID",
                table: "Vindtægter",
                column: "BrugerID");

            migrationBuilder.CreateIndex(
                name: "IX_Vudgifter_BrugerID",
                table: "Vudgifter",
                column: "BrugerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Findtægt");

            migrationBuilder.DropTable(
                name: "Fudgifter");

            migrationBuilder.DropTable(
                name: "Vindtægter");

            migrationBuilder.DropTable(
                name: "Vudgifter");

            migrationBuilder.DropTable(
                name: "Bruger");
        }
    }
}
