using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercise_4.Migrations
{
    public partial class casehandleradded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Handlers_HandlerId",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_HandlerId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "HandlerId",
                table: "Cases");

            migrationBuilder.CreateTable(
                name: "CaseHandlers",
                columns: table => new
                {
                    CaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HandlerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseHandlers", x => new { x.CaseId, x.HandlerId });
                    table.ForeignKey(
                        name: "FK_CaseHandlers_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseHandlers_Handlers_HandlerId",
                        column: x => x.HandlerId,
                        principalTable: "Handlers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseHandlers_HandlerId",
                table: "CaseHandlers",
                column: "HandlerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseHandlers");

            migrationBuilder.AddColumn<int>(
                name: "HandlerId",
                table: "Cases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cases_HandlerId",
                table: "Cases",
                column: "HandlerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Handlers_HandlerId",
                table: "Cases",
                column: "HandlerId",
                principalTable: "Handlers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
