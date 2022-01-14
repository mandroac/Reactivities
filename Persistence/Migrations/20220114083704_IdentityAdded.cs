using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class IdentityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("32d0828f-842a-41f7-830e-3a92bc56458e"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("3d10812b-eb2f-47d6-b6d0-21ae094a30bd"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("5a8381ca-bbfc-4cbe-af63-16defad363e6"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("5c48f595-d176-4276-9222-e83de6b0e0fe"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("64f93cc3-53a3-4403-be3c-b5fe7b11852b"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("73627b0b-2983-4504-9e00-606378c463a0"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("772ea05b-f021-489c-8f2f-6bc33ab7b527"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("9ca1d5e3-c6d0-40f3-a08e-de219611e802"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("bb66bd39-e534-482c-a42a-cbe834eb166a"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("c61a356b-7a34-4c6c-a8ec-217f39968f4b"));

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    Bio = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("2cdad5f3-32ae-46e3-acd2-fe91e2749032"), "drinks", "London", new DateTime(2021, 11, 14, 10, 37, 4, 161, DateTimeKind.Local).AddTicks(7082), "Activity 2 months ago", "Past Activity 1", "Pub" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("57fcef56-2625-4d7e-8ff4-ecfcd8240ff6"), "culture", "Paris", new DateTime(2021, 12, 14, 10, 37, 4, 163, DateTimeKind.Local).AddTicks(9206), "Activity 1 month ago", "Past Activity 2", "Louvre" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("1f7c4c0b-f322-4335-9c7f-d394ac4d7526"), "culture", "London", new DateTime(2022, 2, 14, 10, 37, 4, 163, DateTimeKind.Local).AddTicks(9238), "Activity 1 month in future", "Future Activity 1", "Natural History Museum" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("27115115-3a8b-4981-9cc0-a20a13fa5d3b"), "music", "London", new DateTime(2022, 3, 14, 10, 37, 4, 163, DateTimeKind.Local).AddTicks(9245), "Activity 2 months in future", "Future Activity 2", "O2 Arena" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("f595e9d6-3bd4-4a49-b249-54722d49974d"), "drinks", "London", new DateTime(2022, 4, 14, 10, 37, 4, 163, DateTimeKind.Local).AddTicks(9258), "Activity 3 months in future", "Future Activity 3", "Another pub" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("e1b6ad0f-f6f5-4c71-87ff-064125645ce2"), "drinks", "London", new DateTime(2022, 5, 14, 10, 37, 4, 163, DateTimeKind.Local).AddTicks(9262), "Activity 4 months in future", "Future Activity 4", "Yet another pub" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("5c61b6c8-e429-44d8-9be2-6c55a84c710b"), "drinks", "London", new DateTime(2022, 6, 14, 10, 37, 4, 163, DateTimeKind.Local).AddTicks(9267), "Activity 5 months in future", "Future Activity 5", "Just another pub" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("bfaefec9-7441-4ac8-877b-ac86a375b064"), "music", "London", new DateTime(2022, 7, 14, 10, 37, 4, 163, DateTimeKind.Local).AddTicks(9271), "Activity 6 months in future", "Future Activity 6", "Roundhouse Camden" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("a1c52781-57f2-486d-b250-eec043c9c175"), "travel", "London", new DateTime(2022, 8, 14, 10, 37, 4, 163, DateTimeKind.Local).AddTicks(9278), "Activity 2 months ago", "Future Activity 7", "Somewhere on the Thames" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("be4972c6-92ec-4bdd-ac0d-0653ffa917a7"), "film", "London", new DateTime(2022, 9, 14, 10, 37, 4, 163, DateTimeKind.Local).AddTicks(9282), "Activity 8 months in future", "Future Activity 8", "Cinema" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("1f7c4c0b-f322-4335-9c7f-d394ac4d7526"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("27115115-3a8b-4981-9cc0-a20a13fa5d3b"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("2cdad5f3-32ae-46e3-acd2-fe91e2749032"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("57fcef56-2625-4d7e-8ff4-ecfcd8240ff6"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("5c61b6c8-e429-44d8-9be2-6c55a84c710b"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("a1c52781-57f2-486d-b250-eec043c9c175"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("be4972c6-92ec-4bdd-ac0d-0653ffa917a7"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("bfaefec9-7441-4ac8-877b-ac86a375b064"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("e1b6ad0f-f6f5-4c71-87ff-064125645ce2"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("f595e9d6-3bd4-4a49-b249-54722d49974d"));

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("772ea05b-f021-489c-8f2f-6bc33ab7b527"), "drinks", "London", new DateTime(2021, 11, 4, 23, 26, 15, 953, DateTimeKind.Local).AddTicks(8929), "Activity 2 months ago", "Past Activity 1", "Pub" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("c61a356b-7a34-4c6c-a8ec-217f39968f4b"), "culture", "Paris", new DateTime(2021, 12, 4, 23, 26, 15, 955, DateTimeKind.Local).AddTicks(9677), "Activity 1 month ago", "Past Activity 2", "Louvre" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("5a8381ca-bbfc-4cbe-af63-16defad363e6"), "culture", "London", new DateTime(2022, 2, 4, 23, 26, 15, 955, DateTimeKind.Local).AddTicks(9704), "Activity 1 month in future", "Future Activity 1", "Natural History Museum" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("bb66bd39-e534-482c-a42a-cbe834eb166a"), "music", "London", new DateTime(2022, 3, 4, 23, 26, 15, 955, DateTimeKind.Local).AddTicks(9709), "Activity 2 months in future", "Future Activity 2", "O2 Arena" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("5c48f595-d176-4276-9222-e83de6b0e0fe"), "drinks", "London", new DateTime(2022, 4, 4, 23, 26, 15, 955, DateTimeKind.Local).AddTicks(9713), "Activity 3 months in future", "Future Activity 3", "Another pub" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("32d0828f-842a-41f7-830e-3a92bc56458e"), "drinks", "London", new DateTime(2022, 5, 4, 23, 26, 15, 955, DateTimeKind.Local).AddTicks(9716), "Activity 4 months in future", "Future Activity 4", "Yet another pub" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("9ca1d5e3-c6d0-40f3-a08e-de219611e802"), "drinks", "London", new DateTime(2022, 6, 4, 23, 26, 15, 955, DateTimeKind.Local).AddTicks(9720), "Activity 5 months in future", "Future Activity 5", "Just another pub" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("64f93cc3-53a3-4403-be3c-b5fe7b11852b"), "music", "London", new DateTime(2022, 7, 4, 23, 26, 15, 955, DateTimeKind.Local).AddTicks(9739), "Activity 6 months in future", "Future Activity 6", "Roundhouse Camden" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("73627b0b-2983-4504-9e00-606378c463a0"), "travel", "London", new DateTime(2022, 8, 4, 23, 26, 15, 955, DateTimeKind.Local).AddTicks(9742), "Activity 2 months ago", "Future Activity 7", "Somewhere on the Thames" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("3d10812b-eb2f-47d6-b6d0-21ae094a30bd"), "film", "London", new DateTime(2022, 9, 4, 23, 26, 15, 955, DateTimeKind.Local).AddTicks(9745), "Activity 8 months in future", "Future Activity 8", "Cinema" });
        }
    }
}
