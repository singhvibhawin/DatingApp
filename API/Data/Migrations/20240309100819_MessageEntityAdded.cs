﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class MessageEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Photos_Users_AppUserId",
            //     table: "Photos");

            // migrationBuilder.AlterColumn<int>(
            //     name: "AppUserId",
            //     table: "Photos",
            //     type: "INTEGER",
            //     nullable: false,
            //     defaultValue: 0,
            //     oldClrType: typeof(int),
            //     oldType: "INTEGER",
            //     oldNullable: true);

            // migrationBuilder.CreateTable(
            //     name: "Likes",
            //     columns: table => new
            //     {
            //         SourceUserId = table.Column<int>(type: "INTEGER", nullable: false),
            //         TargetUserId = table.Column<int>(type: "INTEGER", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Likes", x => new { x.SourceUserId, x.TargetUserId });
            //         table.ForeignKey(
            //             name: "FK_Likes_Users_SourceUserId",
            //             column: x => x.SourceUserId,
            //             principalTable: "Users",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_Likes_Users_TargetUserId",
            //             column: x => x.TargetUserId,
            //             principalTable: "Users",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SenderId = table.Column<int>(type: "INTEGER", nullable: false),
                    SenderUsername = table.Column<string>(type: "TEXT", nullable: true),
                    RecipientId = table.Column<int>(type: "INTEGER", nullable: false),
                    RecipientUsername = table.Column<string>(type: "TEXT", nullable: true),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    DateRead = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MessageSent = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SenderDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    RecipientDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_TargetUserId",
                table: "Likes",
                column: "TargetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RecipientId",
                table: "Messages",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Users_AppUserId",
                table: "Photos",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Users_AppUserId",
                table: "Photos");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Photos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Users_AppUserId",
                table: "Photos",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
