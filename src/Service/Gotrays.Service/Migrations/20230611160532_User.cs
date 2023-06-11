using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gotrays.Service.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Channels_UserId",
                table: "Channels");

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("e187fdad-26b3-4dec-b50a-83f939b065c9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2fae0a24-0445-49d5-88b8-cb831dedfe14"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Account", "Avatar", "CreationTime", "Creator", "IsDeleted", "IsDisable", "LastLoginTime", "ModificationTime", "Modifier", "Password", "Role", "Salt", "UserName" },
                values: new object[] { new Guid("f377502a-a209-4eb0-9769-4a3811540352"), "admin", "https://blog-simple.oss-cn-shenzhen.aliyuncs.com/Avatar.jpg", new DateTime(2023, 6, 11, 16, 5, 32, 615, DateTimeKind.Utc).AddTicks(1580), null, false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 11, 16, 5, 32, 615, DateTimeKind.Utc).AddTicks(1582), null, "7c1f45eedd1b563b14506ea5d23b461a", "Admin", "f9d60b71ace84792b710f23af19c0e98", "admin" });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "Avatar", "CreationTime", "Creator", "Description", "IsDeleted", "ModificationTime", "Modifier", "Name", "UserId" },
                values: new object[] { new Guid("b0884205-ba1b-4244-ab5f-411b6ab44a1e"), "https://blog-simple.oss-cn-shenzhen.aliyuncs.com/Avatar.jpg", new DateTime(2023, 6, 11, 16, 5, 32, 615, DateTimeKind.Utc).AddTicks(2589), null, "默认频道", false, new DateTime(2023, 6, 11, 16, 5, 32, 615, DateTimeKind.Utc).AddTicks(2590), null, "默认频道", new Guid("f377502a-a209-4eb0-9769-4a3811540352") });

            migrationBuilder.CreateIndex(
                name: "IX_Channels_UserId",
                table: "Channels",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Channels_UserId",
                table: "Channels");

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("b0884205-ba1b-4244-ab5f-411b6ab44a1e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f377502a-a209-4eb0-9769-4a3811540352"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Account", "Avatar", "CreationTime", "Creator", "IsDeleted", "IsDisable", "LastLoginTime", "ModificationTime", "Modifier", "Password", "Role", "Salt", "UserName" },
                values: new object[] { new Guid("2fae0a24-0445-49d5-88b8-cb831dedfe14"), "admin", "https://blog-simple.oss-cn-shenzhen.aliyuncs.com/Avatar.jpg", new DateTime(2023, 5, 31, 11, 10, 53, 984, DateTimeKind.Utc).AddTicks(337), null, false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 31, 11, 10, 53, 984, DateTimeKind.Utc).AddTicks(338), null, "e8d8a05acf4bafaf535acafc17d9480b", "Admin", "6e8f3bec45f74c96ae856b807e9b627d", "admin" });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "Avatar", "CreationTime", "Creator", "Description", "IsDeleted", "ModificationTime", "Modifier", "Name", "UserId" },
                values: new object[] { new Guid("e187fdad-26b3-4dec-b50a-83f939b065c9"), "https://blog-simple.oss-cn-shenzhen.aliyuncs.com/Avatar.jpg", new DateTime(2023, 5, 31, 11, 10, 53, 984, DateTimeKind.Utc).AddTicks(950), null, "默认频道", false, new DateTime(2023, 5, 31, 11, 10, 53, 984, DateTimeKind.Utc).AddTicks(951), null, "默认频道", new Guid("2fae0a24-0445-49d5-88b8-cb831dedfe14") });

            migrationBuilder.CreateIndex(
                name: "IX_Channels_UserId",
                table: "Channels",
                column: "UserId",
                unique: true);
        }
    }
}
