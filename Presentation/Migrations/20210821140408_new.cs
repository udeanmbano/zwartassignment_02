using Microsoft.EntityFrameworkCore.Migrations;

namespace ZwartsJWTApi.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "toDoLists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserLists",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLists", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_toDoLists_UserId1",
                table: "toDoLists",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_toDoLists_UserLists_UserId1",
                table: "toDoLists",
                column: "UserId1",
                principalTable: "UserLists",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_toDoLists_UserLists_UserId1",
                table: "toDoLists");

            migrationBuilder.DropTable(
                name: "UserLists");

            migrationBuilder.DropIndex(
                name: "IX_toDoLists_UserId1",
                table: "toDoLists");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "toDoLists");
        }
    }
}
