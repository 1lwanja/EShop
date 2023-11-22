using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazingShop.Server.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Icon", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "book", "Books", "books" },
                    { 2, "camera-slr", "Electronics", "electronics" },
                    { 3, "aperture", "Video Games", "video games" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "DateUpdated", "Description", "Image", "IsDeleted", "IsPublic", "OriginalPrice", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 11, 22, 12, 12, 50, 717, DateTimeKind.Local).AddTicks(4858), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hitchhiker's Guide to the Galaxy (sometimes referred to as HG2G, HHGTTG, HG2G' or tHGttG) Is a comedy science fiction series", "https://upload.wikimedia.org/wikimedia/en/b/bd/H2G2_UK_front_cover.jpg", false, false, 19.99m, 9.99m, "The Hitchhiker's Guide to the Galaxy" },
                    { 2, 3, new DateTime(2023, 11, 22, 12, 12, 50, 717, DateTimeKind.Local).AddTicks(4882), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting", "https://half-life.fandom.com/wiki/The_G-Man", false, false, 29.99m, 8.19m, "Half-Life 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
