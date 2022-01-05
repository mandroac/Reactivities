using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
