using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirPort.DataAccess.Migrations
{
    public partial class CreatedBasicAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AirCrafts_AirCraftTypes_AirCraftTypeId",
                table: "AirCrafts");

            migrationBuilder.DropIndex(
                name: "IX_AirCrafts_AirCraftTypeId",
                table: "AirCrafts");

            migrationBuilder.DropColumn(
                name: "AirCraftTypeId",
                table: "AirCrafts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AirCrafts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AirCrafts_TypeId",
                table: "AirCrafts",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AirCrafts_AirCraftTypes_TypeId",
                table: "AirCrafts",
                column: "TypeId",
                principalTable: "AirCraftTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AirCrafts_AirCraftTypes_TypeId",
                table: "AirCrafts");

            migrationBuilder.DropIndex(
                name: "IX_AirCrafts_TypeId",
                table: "AirCrafts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AirCrafts",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<Guid>(
                name: "AirCraftTypeId",
                table: "AirCrafts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AirCrafts_AirCraftTypeId",
                table: "AirCrafts",
                column: "AirCraftTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AirCrafts_AirCraftTypes_AirCraftTypeId",
                table: "AirCrafts",
                column: "AirCraftTypeId",
                principalTable: "AirCraftTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
