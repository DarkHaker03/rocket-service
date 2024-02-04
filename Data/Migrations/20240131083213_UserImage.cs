using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UserImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_uw_employee_UserId",
                table: "uw_employee");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "uw_user",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_uw_user_ImageId",
                table: "uw_user",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_employee_UserId",
                table: "uw_employee",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_uw_user_uw_images_ImageId",
                table: "uw_user",
                column: "ImageId",
                principalTable: "uw_images",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_uw_user_uw_images_ImageId",
                table: "uw_user");

            migrationBuilder.DropIndex(
                name: "IX_uw_user_ImageId",
                table: "uw_user");

            migrationBuilder.DropIndex(
                name: "IX_uw_employee_UserId",
                table: "uw_employee");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "uw_user");

            migrationBuilder.CreateIndex(
                name: "IX_uw_employee_UserId",
                table: "uw_employee",
                column: "UserId");
        }
    }
}
