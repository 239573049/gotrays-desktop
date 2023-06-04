using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gotrays.Service.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Account = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Salt = table.Column<string>(type: "TEXT", nullable: false),
                    Avatar = table.Column<string>(type: "TEXT", nullable: false),
                    IsDisable = table.Column<bool>(type: "INTEGER", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: true),
                    LastLoginTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Creator = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modifier = table.Column<Guid>(type: "TEXT", nullable: true),
                    ModificationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Avatar = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Creator = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modifier = table.Column<Guid>(type: "TEXT", nullable: true),
                    ModificationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Channels_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Account", "Avatar", "CreationTime", "Creator", "IsDeleted", "IsDisable", "LastLoginTime", "ModificationTime", "Modifier", "Password", "Role", "Salt", "UserName" },
                values: new object[] { new Guid("2fae0a24-0445-49d5-88b8-cb831dedfe14"), "admin", "https://blog-simple.oss-cn-shenzhen.aliyuncs.com/Avatar.jpg", new DateTime(2023, 5, 31, 11, 10, 53, 984, DateTimeKind.Utc).AddTicks(337), null, false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 31, 11, 10, 53, 984, DateTimeKind.Utc).AddTicks(338), null, "e8d8a05acf4bafaf535acafc17d9480b", "Admin", "6e8f3bec45f74c96ae856b807e9b627d", "admin" });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "Avatar", "CreationTime", "Creator", "Description", "IsDeleted", "ModificationTime", "Modifier", "Name", "UserId" },
                values: new object[] { new Guid("e187fdad-26b3-4dec-b50a-83f939b065c9"), "https://blog-simple.oss-cn-shenzhen.aliyuncs.com/Avatar.jpg", new DateTime(2023, 5, 31, 11, 10, 53, 984, DateTimeKind.Utc).AddTicks(950), null, "默认频道", false, new DateTime(2023, 5, 31, 11, 10, 53, 984, DateTimeKind.Utc).AddTicks(951), null, "默认频道", new Guid("2fae0a24-0445-49d5-88b8-cb831dedfe14") });

            migrationBuilder.CreateIndex(
                name: "IX_Channels_Name",
                table: "Channels",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Channels_UserId",
                table: "Channels",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Account",
                table: "Users",
                column: "Account",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Channels");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
