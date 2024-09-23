using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmojiHub_Backend.Migrations
{
    /// <inheritdoc />
    public partial class NullableUserIdinEmojiList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmojiLists_Users_UserId",
                table: "EmojiLists");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "EmojiLists",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EmojiLists_Users_UserId",
                table: "EmojiLists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmojiLists_Users_UserId",
                table: "EmojiLists");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "EmojiLists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmojiLists_Users_UserId",
                table: "EmojiLists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
