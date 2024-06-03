using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessageBoard.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Content", "Group", "PostTime", "user_name" },
                values: new object[] { 1, "What's up", "Video", new DateTime(2024, 6, 3, 15, 34, 0, 424, DateTimeKind.Local).AddTicks(491), "jon" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Content", "Group", "PostTime", "user_name" },
                values: new object[] { 2, "Not much", "Video", new DateTime(2024, 6, 3, 15, 34, 0, 424, DateTimeKind.Local).AddTicks(524), "join" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Content", "Group", "PostTime", "user_name" },
                values: new object[] { 3, "The weather", "Weather", new DateTime(2024, 6, 3, 15, 34, 0, 424, DateTimeKind.Local).AddTicks(526), "Mr.Weather" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3);
        }
    }
}
