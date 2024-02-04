using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "uw_images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ObjectCreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uw_images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "uw_user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Telephone = table.Column<string>(type: "text", nullable: true),
                    Login = table.Column<string>(type: "text", nullable: true),
                    OtherContacts = table.Column<string>(type: "text", nullable: true),
                    ObjectCreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uw_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_uw_user_uw_images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "uw_images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_uw_user_Email",
                table: "uw_user",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_uw_user_ImageId",
                table: "uw_user",
                column: "ImageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "uw_user");

            migrationBuilder.DropTable(
                name: "uw_images");
        }
    }
}
