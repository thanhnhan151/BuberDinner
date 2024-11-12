using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuberDinner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AverageRating_Value = table.Column<double>(type: "float", nullable: true),
                    AverageRating_NumRatings = table.Column<int>(type: "int", nullable: false),
                    HostId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuDinnerId",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuDinnerId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuDinnerId_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuReviewId",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuReviewId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuReviewId_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuSection",
                columns: table => new
                {
                    MenuSectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuSection", x => new { x.MenuSectionId, x.MenuId });
                    table.ForeignKey(
                        name: "FK_MenuSection_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                columns: table => new
                {
                    MenuItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuSectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => new { x.MenuItemId, x.MenuSectionId, x.MenuId });
                    table.ForeignKey(
                        name: "FK_MenuItem_MenuSection_MenuSectionId_MenuId",
                        columns: x => new { x.MenuSectionId, x.MenuId },
                        principalTable: "MenuSection",
                        principalColumns: new[] { "MenuSectionId", "MenuId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuDinnerId_MenuId",
                table: "MenuDinnerId",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_MenuSectionId_MenuId",
                table: "MenuItem",
                columns: new[] { "MenuSectionId", "MenuId" });

            migrationBuilder.CreateIndex(
                name: "IX_MenuReviewId_MenuId",
                table: "MenuReviewId",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuSection_MenuId",
                table: "MenuSection",
                column: "MenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuDinnerId");

            migrationBuilder.DropTable(
                name: "MenuItem");

            migrationBuilder.DropTable(
                name: "MenuReviewId");

            migrationBuilder.DropTable(
                name: "MenuSection");

            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
