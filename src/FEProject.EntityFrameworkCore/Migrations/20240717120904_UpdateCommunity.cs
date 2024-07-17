using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FEProject.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommunity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Communities_AbpUsers_CreatedByUserId",
                table: "Communities");

            migrationBuilder.DropIndex(
                name: "IX_Communities_CreatedByUserId",
                table: "Communities");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Communities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "Communities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Communities_CreatedByUserId",
                table: "Communities",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Communities_AbpUsers_CreatedByUserId",
                table: "Communities",
                column: "CreatedByUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
