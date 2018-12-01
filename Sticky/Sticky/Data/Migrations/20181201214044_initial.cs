using Microsoft.EntityFrameworkCore.Migrations;

namespace Sticky.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invites_AspNetUsers_ApplicationUserId",
                table: "Invites");

            migrationBuilder.DropForeignKey(
                name: "FK_Invites_Boards_BoardForeignKey",
                table: "Invites");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Boards_BoardForeignKey",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBoard_AspNetUsers_ApplicationUserForeignKey",
                table: "UserBoard");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBoard_Boards_BoardForeignKey",
                table: "UserBoard");

            migrationBuilder.DropIndex(
                name: "IX_Notes_BoardForeignKey",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBoard",
                table: "UserBoard");

            migrationBuilder.DropIndex(
                name: "IX_UserBoard_ApplicationUserForeignKey",
                table: "UserBoard");

            migrationBuilder.DropIndex(
                name: "IX_UserBoard_BoardForeignKey",
                table: "UserBoard");

            migrationBuilder.DropColumn(
                name: "BoardForeignKey",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserIdForeignKey",
                table: "Invites");

            migrationBuilder.DropColumn(
                name: "BoardForeignKey",
                table: "UserBoard");

            migrationBuilder.RenameTable(
                name: "UserBoard",
                newName: "UserBoards");

            migrationBuilder.RenameColumn(
                name: "BoardId",
                table: "Notes",
                newName: "BoardID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Notes",
                newName: "NoteID");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Invites",
                newName: "ApplicationUserID");

            migrationBuilder.RenameColumn(
                name: "BoardForeignKey",
                table: "Invites",
                newName: "BoardID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Invites",
                newName: "InviteID");

            migrationBuilder.RenameIndex(
                name: "IX_Invites_ApplicationUserId",
                table: "Invites",
                newName: "IX_Invites_ApplicationUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Invites_BoardForeignKey",
                table: "Invites",
                newName: "IX_Invites_BoardID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Boards",
                newName: "BoardID");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserForeignKey",
                table: "UserBoards",
                newName: "TypeUser");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "UserBoards",
                newName: "UserBoardID");

            migrationBuilder.AlterColumn<int>(
                name: "BoardID",
                table: "Notes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TypeUser",
                table: "UserBoards",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserBoards",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BoardID1",
                table: "UserBoards",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBoards",
                table: "UserBoards",
                column: "UserBoardID");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_BoardID",
                table: "Notes",
                column: "BoardID");

            migrationBuilder.CreateIndex(
                name: "IX_UserBoards_ApplicationUserId",
                table: "UserBoards",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBoards_BoardID1",
                table: "UserBoards",
                column: "BoardID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_AspNetUsers_ApplicationUserID",
                table: "Invites",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_Boards_BoardID",
                table: "Invites",
                column: "BoardID",
                principalTable: "Boards",
                principalColumn: "BoardID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Boards_BoardID",
                table: "Notes",
                column: "BoardID",
                principalTable: "Boards",
                principalColumn: "BoardID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBoards_AspNetUsers_ApplicationUserId",
                table: "UserBoards",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBoards_Boards_BoardID1",
                table: "UserBoards",
                column: "BoardID1",
                principalTable: "Boards",
                principalColumn: "BoardID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invites_AspNetUsers_ApplicationUserID",
                table: "Invites");

            migrationBuilder.DropForeignKey(
                name: "FK_Invites_Boards_BoardID",
                table: "Invites");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Boards_BoardID",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBoards_AspNetUsers_ApplicationUserId",
                table: "UserBoards");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBoards_Boards_BoardID1",
                table: "UserBoards");

            migrationBuilder.DropIndex(
                name: "IX_Notes_BoardID",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBoards",
                table: "UserBoards");

            migrationBuilder.DropIndex(
                name: "IX_UserBoards_ApplicationUserId",
                table: "UserBoards");

            migrationBuilder.DropIndex(
                name: "IX_UserBoards_BoardID1",
                table: "UserBoards");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserBoards");

            migrationBuilder.DropColumn(
                name: "BoardID1",
                table: "UserBoards");

            migrationBuilder.RenameTable(
                name: "UserBoards",
                newName: "UserBoard");

            migrationBuilder.RenameColumn(
                name: "BoardID",
                table: "Notes",
                newName: "BoardId");

            migrationBuilder.RenameColumn(
                name: "NoteID",
                table: "Notes",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "Invites",
                newName: "ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "BoardID",
                table: "Invites",
                newName: "BoardForeignKey");

            migrationBuilder.RenameColumn(
                name: "InviteID",
                table: "Invites",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Invites_ApplicationUserID",
                table: "Invites",
                newName: "IX_Invites_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Invites_BoardID",
                table: "Invites",
                newName: "IX_Invites_BoardForeignKey");

            migrationBuilder.RenameColumn(
                name: "BoardID",
                table: "Boards",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "TypeUser",
                table: "UserBoard",
                newName: "ApplicationUserForeignKey");

            migrationBuilder.RenameColumn(
                name: "UserBoardID",
                table: "UserBoard",
                newName: "ID");

            migrationBuilder.AlterColumn<int>(
                name: "BoardId",
                table: "Notes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "BoardForeignKey",
                table: "Notes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserIdForeignKey",
                table: "Invites",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserForeignKey",
                table: "UserBoard",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BoardForeignKey",
                table: "UserBoard",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBoard",
                table: "UserBoard",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_BoardForeignKey",
                table: "Notes",
                column: "BoardForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_UserBoard_ApplicationUserForeignKey",
                table: "UserBoard",
                column: "ApplicationUserForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_UserBoard_BoardForeignKey",
                table: "UserBoard",
                column: "BoardForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_AspNetUsers_ApplicationUserId",
                table: "Invites",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_Boards_BoardForeignKey",
                table: "Invites",
                column: "BoardForeignKey",
                principalTable: "Boards",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Boards_BoardForeignKey",
                table: "Notes",
                column: "BoardForeignKey",
                principalTable: "Boards",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBoard_AspNetUsers_ApplicationUserForeignKey",
                table: "UserBoard",
                column: "ApplicationUserForeignKey",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBoard_Boards_BoardForeignKey",
                table: "UserBoard",
                column: "BoardForeignKey",
                principalTable: "Boards",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
