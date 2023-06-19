using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gotrays.Service.Migrations
{
    public partial class AddChannelMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("b0884205-ba1b-4244-ab5f-411b6ab44a1e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f377502a-a209-4eb0-9769-4a3811540352"));

            migrationBuilder.CreateTable(
                name: "ChannelMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ChannelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChannelMembers_Channels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChannelMembers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Account", "Avatar", "CreationTime", "Creator", "IsDeleted", "IsDisable", "LastLoginTime", "ModificationTime", "Modifier", "Password", "Role", "Salt", "UserName" },
                values: new object[] { new Guid("af3cc4a1-ac60-497a-bfa5-3c1324287b6f"), "admin", "https://blog-simple.oss-cn-shenzhen.aliyuncs.com/Avatar.jpg", new DateTime(2023, 6, 19, 7, 40, 49, 353, DateTimeKind.Utc).AddTicks(5390), null, false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 19, 7, 40, 49, 353, DateTimeKind.Utc).AddTicks(5392), null, "4cab4efac8506b09a9a6460b5c5b4eef", "Admin", "3b5311c5f55b4386aab0c3cc709d8656", "admin" });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "Avatar", "CreationTime", "Creator", "Description", "IsDeleted", "ModificationTime", "Modifier", "Name", "UserId" },
                values: new object[] { new Guid("c388fdae-f6ac-4d35-a209-17851d36a678"), "https://blog-simple.oss-cn-shenzhen.aliyuncs.com/Avatar.jpg", new DateTime(2023, 6, 19, 7, 40, 49, 353, DateTimeKind.Utc).AddTicks(6137), null, "默认频道", false, new DateTime(2023, 6, 19, 7, 40, 49, 353, DateTimeKind.Utc).AddTicks(6137), null, "默认频道", new Guid("af3cc4a1-ac60-497a-bfa5-3c1324287b6f") });

            migrationBuilder.InsertData(
                table: "ChannelMembers",
                columns: new[] { "Id", "ChannelId", "UserId" },
                values: new object[] { new Guid("e6e0833a-fb04-4665-8564-44a2bc38063c"), new Guid("c388fdae-f6ac-4d35-a209-17851d36a678"), new Guid("af3cc4a1-ac60-497a-bfa5-3c1324287b6f") });

            migrationBuilder.CreateIndex(
                name: "IX_ChannelMembers_ChannelId_UserId",
                table: "ChannelMembers",
                columns: new[] { "ChannelId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChannelMembers_UserId",
                table: "ChannelMembers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChannelMembers");

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("c388fdae-f6ac-4d35-a209-17851d36a678"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("af3cc4a1-ac60-497a-bfa5-3c1324287b6f"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Account", "Avatar", "CreationTime", "Creator", "IsDeleted", "IsDisable", "LastLoginTime", "ModificationTime", "Modifier", "Password", "Role", "Salt", "UserName" },
                values: new object[] { new Guid("f377502a-a209-4eb0-9769-4a3811540352"), "admin", "https://blog-simple.oss-cn-shenzhen.aliyuncs.com/Avatar.jpg", new DateTime(2023, 6, 11, 16, 5, 32, 615, DateTimeKind.Utc).AddTicks(1580), null, false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 11, 16, 5, 32, 615, DateTimeKind.Utc).AddTicks(1582), null, "7c1f45eedd1b563b14506ea5d23b461a", "Admin", "f9d60b71ace84792b710f23af19c0e98", "admin" });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "Avatar", "CreationTime", "Creator", "Description", "IsDeleted", "ModificationTime", "Modifier", "Name", "UserId" },
                values: new object[] { new Guid("b0884205-ba1b-4244-ab5f-411b6ab44a1e"), "https://blog-simple.oss-cn-shenzhen.aliyuncs.com/Avatar.jpg", new DateTime(2023, 6, 11, 16, 5, 32, 615, DateTimeKind.Utc).AddTicks(2589), null, "默认频道", false, new DateTime(2023, 6, 11, 16, 5, 32, 615, DateTimeKind.Utc).AddTicks(2590), null, "默认频道", new Guid("f377502a-a209-4eb0-9769-4a3811540352") });
        }
    }
}
