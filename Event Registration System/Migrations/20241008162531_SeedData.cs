using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Event_Registration_System.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Capacity", "Date", "Description", "Title" },
                values: new object[,]
                {
                    { 29, 200, new DateTime(2024, 11, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), "A fair featuring local authors and book signings.", "Book Fair" },
                    { 34, 500, new DateTime(2024, 6, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), "Join us for a day of tech talks and networking.", "Tech Conference 2024" },
                    { 166, 40, new DateTime(2024, 10, 25, 11, 0, 0, 0, DateTimeKind.Unspecified), "A hands-on workshop for amateur photographers to learn new skills.", "Photography Workshop" },
                    { 176, 75, new DateTime(2024, 11, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), "A relaxing weekend retreat focusing on mindfulness and yoga.", "Yoga Retreat" },
                    { 267, 100, new DateTime(2024, 12, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "A 3-day immersive coding bootcamp for beginners.", "Coding Bootcamp" },
                    { 337, 50, new DateTime(2024, 8, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), "Learn to cook delicious meals with our expert chefs.", "Cooking Workshop" },
                    { 460, 300, new DateTime(2024, 12, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), "A formal evening event to raise funds for local charities.", "Charity Gala" },
                    { 484, 150, new DateTime(2024, 9, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), "A seminar for small business owners to learn strategies for growth.", "Business Seminar" },
                    { 534, 1000, new DateTime(2024, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Enjoy a weekend of live music and entertainment.", "Music Festival" },
                    { 613, 200, new DateTime(2024, 7, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "Explore the latest art from local artists.", "Art Exhibition" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 460);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 484);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 534);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 613);
        }
    }
}
