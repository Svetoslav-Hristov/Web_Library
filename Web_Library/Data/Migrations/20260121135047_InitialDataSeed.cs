using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web_Library.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Genre", "Title" },
                values: new object[,]
                {
                    { new Guid("023fe09a-5ed3-4b7c-8eeb-f323f9e43cbf"), "F. Scott Fitzgerald", 3, "The Great Gatsby" },
                    { new Guid("1192f7d6-3197-4a88-87ce-a251dd1cf0b3"), "Patrick Rothfuss", 0, "The Name of the Wind" },
                    { new Guid("3b57c8d7-a88e-4318-b5c4-0d1ab176c2e1"), "Jane Austen", 3, "Pride and Prejudice" },
                    { new Guid("3fb3a2e4-5968-4eac-9838-eec211167561"), "Stephen King", 4, "It" },
                    { new Guid("43f42ae2-7f5f-4944-871e-52d9fd057e6a"), "Andrew Hunt", 7, "The Pragmatic Programmer" },
                    { new Guid("4a8a88ba-79f6-44d6-8701-0c4d6bd7e412"), "Yuval Noah Harari", 6, "Homo Deus" },
                    { new Guid("4f73e635-6290-4152-8c9b-cbcd4d09f496"), "Andy Weir", 1, "The Martian" },
                    { new Guid("5571dd6b-512c-4d64-8620-cf469800d93c"), "Dan Brown", 11, "The Da Vinci Code" },
                    { new Guid("65f62571-ee92-4e56-b6b9-dd7a8efe8e3f"), "Stephen King", 4, "The Shining" },
                    { new Guid("7a183b2a-9af9-4412-9a2d-bcac7383e7ac"), "J.D. Salinger", 6, "The Catcher in the Rye" },
                    { new Guid("7f7663d2-b426-4b01-af52-8d617a2fe553"), "Martin Fowler", 7, "Refactoring" },
                    { new Guid("8be4237a-cadb-4f8c-bfd8-68eab7b7c64e"), "Harper Lee", 6, "To Kill a Mockingbird" },
                    { new Guid("8c263c22-48fd-4ecd-9aa9-e01f2d8c0745"), "Paulo Coelho", 8, "The Alchemist" },
                    { new Guid("905974f8-f5b3-4eaf-a143-11b8345aca92"), "Ray Bradbury", 1, "Fahrenheit 451" },
                    { new Guid("b5cebf85-e61a-4e95-b688-a2b0e6893bed"), "J.R.R. Tolkien", 0, "The Hobbit" },
                    { new Guid("b6680038-dd42-4e75-9b24-ab7f2455393d"), "Fyodor Dostoevsky", 8, "Crime and Punishment" },
                    { new Guid("cda5bf3e-e99c-4a9a-bc3c-889ec28b7031"), "Aldous Huxley", 1, "Brave New World" },
                    { new Guid("d292d10e-8797-4b79-be46-150c747a58bf"), "Bram Stoker", 4, "Dracula" },
                    { new Guid("e2c70baa-d665-4ace-9409-6b053e41ed4f"), "Arthur Conan Doyle", 2, "Sherlock Holmes" },
                    { new Guid("ed7d0f41-9d87-4c33-a0c7-3620ed591fe3"), "Walter Isaacson", 5, "Steve Jobs" },
                    { new Guid("eeb61727-49d9-4b67-a836-1d3eacc4f08d"), "George Orwell", 1, "1984" },
                    { new Guid("f057357a-d690-48ce-a4cc-e1a9748cc63c"), "Robert C. Martin", 7, "Clean Code" },
                    { new Guid("f15ea439-f2a1-40ac-8278-1056d7a75a52"), "Frank Herbert", 0, "Dune" },
                    { new Guid("f315b770-aba6-4dd3-b9f0-c8b3d0dce787"), "Yuval Noah Harari", 6, "Sapiens" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Age", "Email", "FirstName", "IsBlocked", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("19c4ebff-4f5c-4504-8641-0dd4fb9f2218"), "Sofia, Lozenets", 32, "maria.georgieva@library.bg", "Maria", false, "Georgieva", "+359887654321" },
                    { new Guid("30460549-2e0d-40c7-90ff-6f435900d186"), "Sofia, Nadezhda", 41, "georgi.ivanov@library.bg", "Georgi", true, "Ivanov", "+359889777888" },
                    { new Guid("376b646e-7761-428b-b62b-21c58734fca7"), "Sofia, Obelya", 46, "dimitar.hristov@library.bg", "Dimitar", true, "Hristov", "+359883111222" },
                    { new Guid("5c80ef3a-faad-40f4-b245-45790594fe37"), "Sofia, Geo Milev", 30, "radostina.nikolova@library.bg", "Radostina", false, "Nikolova", "+359882444555" },
                    { new Guid("66757a02-9ffa-4c13-8070-6aeb39d5a570"), "Sofia, Lyulin 5", 34, "vladimir.angelov@library.bg", "Vladimir", false, "Angelov", "+359881666777" },
                    { new Guid("7023f574-e36a-4c31-b4a0-65bba3947199"), "Sofia, Center", 27, "desislava.popova@library.bg", "Desislava", false, "Popova", "+359880888999" },
                    { new Guid("70d6692c-73ff-42fd-8992-1e175692b52f"), "Sofia, Druzhba 2", 23, "petya.koleva@library.bg", "Petya", false, "Koleva", "+359884222333" },
                    { new Guid("b97533fb-a904-4f0e-bacc-1dfd9f769122"), "Sofia, Krasno Selo", 35, "nikolay.stoyanov@library.bg", "Nikolay", false, "Stoyanov", "+359885999000" },
                    { new Guid("e6df1540-5bab-4126-b284-4a9af52c47cd"), "Sofia, Studentski Grad", 29, "elena.dimitrova@library.bg", "Elena", false, "Dimitrova", "+359886333444" },
                    { new Guid("f71797dc-7130-48d6-8f30-7d24d19bf347"), "Sofia, Mladost 1", 26, "ivan.petrov@library.bg", "Ivan", false, "Petrov", "+359888123456" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("023fe09a-5ed3-4b7c-8eeb-f323f9e43cbf"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1192f7d6-3197-4a88-87ce-a251dd1cf0b3"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("3b57c8d7-a88e-4318-b5c4-0d1ab176c2e1"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("3fb3a2e4-5968-4eac-9838-eec211167561"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("43f42ae2-7f5f-4944-871e-52d9fd057e6a"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4a8a88ba-79f6-44d6-8701-0c4d6bd7e412"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4f73e635-6290-4152-8c9b-cbcd4d09f496"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5571dd6b-512c-4d64-8620-cf469800d93c"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("65f62571-ee92-4e56-b6b9-dd7a8efe8e3f"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("7a183b2a-9af9-4412-9a2d-bcac7383e7ac"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("7f7663d2-b426-4b01-af52-8d617a2fe553"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8be4237a-cadb-4f8c-bfd8-68eab7b7c64e"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8c263c22-48fd-4ecd-9aa9-e01f2d8c0745"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("905974f8-f5b3-4eaf-a143-11b8345aca92"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b5cebf85-e61a-4e95-b688-a2b0e6893bed"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b6680038-dd42-4e75-9b24-ab7f2455393d"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("cda5bf3e-e99c-4a9a-bc3c-889ec28b7031"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("d292d10e-8797-4b79-be46-150c747a58bf"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e2c70baa-d665-4ace-9409-6b053e41ed4f"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ed7d0f41-9d87-4c33-a0c7-3620ed591fe3"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("eeb61727-49d9-4b67-a836-1d3eacc4f08d"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f057357a-d690-48ce-a4cc-e1a9748cc63c"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f15ea439-f2a1-40ac-8278-1056d7a75a52"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f315b770-aba6-4dd3-b9f0-c8b3d0dce787"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19c4ebff-4f5c-4504-8641-0dd4fb9f2218"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("30460549-2e0d-40c7-90ff-6f435900d186"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("376b646e-7761-428b-b62b-21c58734fca7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5c80ef3a-faad-40f4-b245-45790594fe37"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("66757a02-9ffa-4c13-8070-6aeb39d5a570"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7023f574-e36a-4c31-b4a0-65bba3947199"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("70d6692c-73ff-42fd-8992-1e175692b52f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b97533fb-a904-4f0e-bacc-1dfd9f769122"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e6df1540-5bab-4126-b284-4a9af52c47cd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f71797dc-7130-48d6-8f30-7d24d19bf347"));
        }
    }
}
