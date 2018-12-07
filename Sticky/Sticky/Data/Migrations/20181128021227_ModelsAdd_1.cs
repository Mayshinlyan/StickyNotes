using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sticky.Data.Migrations
{
    public partial class ModelsAdd_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    BoardType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Invites",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BoardForeignKey = table.Column<int>(nullable: false),
                    ApplicationUserIdForeignKey = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invites", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Invites_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invites_Boards_BoardForeignKey",
                        column: x => x.BoardForeignKey,
                        principalTable: "Boards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BoardId = table.Column<int>(nullable: true),
                    IsArchived = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    FontName = table.Column<string>(nullable: true),
                    FontColor = table.Column<string>(nullable: true),
                    FontSize = table.Column<int>(nullable: true),
                    Xcoor = table.Column<int>(nullable: true),
                    Ycoor = table.Column<int>(nullable: true),
                    Width = table.Column<int>(nullable: true),
                    Height = table.Column<int>(nullable: true),
                    LastEdit = table.Column<DateTime>(nullable: true),
                    BoardForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Notes_Boards_BoardForeignKey",
                        column: x => x.BoardForeignKey,
                        principalTable: "Boards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBoard",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BoardForeignKey = table.Column<int>(nullable: false),
                    ApplicationUserForeignKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBoard", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserBoard_AspNetUsers_ApplicationUserForeignKey",
                        column: x => x.ApplicationUserForeignKey,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserBoard_Boards_BoardForeignKey",
                        column: x => x.BoardForeignKey,
                        principalTable: "Boards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                }); 

            migrationBuilder.CreateIndex(
                name: "IX_Invites_ApplicationUserId",
                table: "Invites",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Invites_BoardForeignKey",
                table: "Invites",
                column: "BoardForeignKey");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invites");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "UserBoard");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
