using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Library.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingSystemInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "ReturnDate",
                table: "UsersBooks",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ReservedOn",
                table: "UsersBooks",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ReservationExpiresOn",
                table: "UsersBooks",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "PickUpDate",
                table: "UsersBooks",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "UsersBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("023fe09a-5ed3-4b7c-8eeb-f323f9e43cbf"),
                column: "CoverImageUrl",
                value: "TheGreatGatsby.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1192f7d6-3197-4a88-87ce-a251dd1cf0b3"),
                column: "CoverImageUrl",
                value: "TheNameOfWind.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("3b57c8d7-a88e-4318-b5c4-0d1ab176c2e1"),
                column: "CoverImageUrl",
                value: "Pride.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("3fb3a2e4-5968-4eac-9838-eec211167561"),
                column: "CoverImageUrl",
                value: "It.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("43f42ae2-7f5f-4944-871e-52d9fd057e6a"),
                column: "CoverImageUrl",
                value: "PragmaticProgramer.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4f73e635-6290-4152-8c9b-cbcd4d09f496"),
                column: "CoverImageUrl",
                value: "Martian.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5571dd6b-512c-4d64-8620-cf469800d93c"),
                column: "CoverImageUrl",
                value: "DaVinciCode.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("65f62571-ee92-4e56-b6b9-dd7a8efe8e3f"),
                column: "CoverImageUrl",
                value: "theShining.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("7a183b2a-9af9-4412-9a2d-bcac7383e7ac"),
                column: "CoverImageUrl",
                value: "TheCatcherInTheRye.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("7f7663d2-b426-4b01-af52-8d617a2fe553"),
                column: "CoverImageUrl",
                value: "Refactoring.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8be4237a-cadb-4f8c-bfd8-68eab7b7c64e"),
                column: "CoverImageUrl",
                value: "ToKillMockingBird.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8c263c22-48fd-4ecd-9aa9-e01f2d8c0745"),
                column: "CoverImageUrl",
                value: "TheAlchemist.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("905974f8-f5b3-4eaf-a143-11b8345aca92"),
                column: "CoverImageUrl",
                value: "Fahrenheit451.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b5cebf85-e61a-4e95-b688-a2b0e6893bed"),
                column: "CoverImageUrl",
                value: "TheHobbit.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b6680038-dd42-4e75-9b24-ab7f2455393d"),
                column: "CoverImageUrl",
                value: "CrimeAndPunishment.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("cda5bf3e-e99c-4a9a-bc3c-889ec28b7031"),
                column: "CoverImageUrl",
                value: "BraveNewWorld.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("d292d10e-8797-4b79-be46-150c747a58bf"),
                column: "CoverImageUrl",
                value: "Dracula.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e2c70baa-d665-4ace-9409-6b053e41ed4f"),
                column: "CoverImageUrl",
                value: "SherlockHolmes.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ed7d0f41-9d87-4c33-a0c7-3620ed591fe3"),
                column: "CoverImageUrl",
                value: "SteveJobs.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("eeb61727-49d9-4b67-a836-1d3eacc4f08d"),
                column: "CoverImageUrl",
                value: "1984.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f057357a-d690-48ce-a4cc-e1a9748cc63c"),
                column: "CoverImageUrl",
                value: "CleanCode.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f15ea439-f2a1-40ac-8278-1056d7a75a52"),
                column: "CoverImageUrl",
                value: "Dune.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f315b770-aba6-4dd3-b9f0-c8b3d0dce787"),
                column: "CoverImageUrl",
                value: "Sapiens.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "UsersBooks");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ReturnDate",
                table: "UsersBooks",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ReservedOn",
                table: "UsersBooks",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ReservationExpiresOn",
                table: "UsersBooks",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "PickUpDate",
                table: "UsersBooks",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("023fe09a-5ed3-4b7c-8eeb-f323f9e43cbf"),
                column: "CoverImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1192f7d6-3197-4a88-87ce-a251dd1cf0b3"),
                column: "CoverImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("3b57c8d7-a88e-4318-b5c4-0d1ab176c2e1"),
                column: "CoverImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("3fb3a2e4-5968-4eac-9838-eec211167561"),
                column: "CoverImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("43f42ae2-7f5f-4944-871e-52d9fd057e6a"),
                column: "CoverImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4f73e635-6290-4152-8c9b-cbcd4d09f496"),
                column: "CoverImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5571dd6b-512c-4d64-8620-cf469800d93c"),
                column: "CoverImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("65f62571-ee92-4e56-b6b9-dd7a8efe8e3f"),
                column: "CoverImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("7a183b2a-9af9-4412-9a2d-bcac7383e7ac"),
                column: "CoverImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("7f7663d2-b426-4b01-af52-8d617a2fe553"),
                column: "CoverImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8be4237a-cadb-4f8c-bfd8-68eab7b7c64e"),
                column: "CoverImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8c263c22-48fd-4ecd-9aa9-e01f2d8c0745"),
                column: "CoverImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("905974f8-f5b3-4eaf-a143-11b8345aca92"),
                column: "CoverImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b5cebf85-e61a-4e95-b688-a2b0e6893bed"),
                column: "CoverImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b6680038-dd42-4e75-9b24-ab7f2455393d"),
                column: "CoverImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("cda5bf3e-e99c-4a9a-bc3c-889ec28b7031"),
                column: "CoverImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("d292d10e-8797-4b79-be46-150c747a58bf"),
                column: "CoverImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e2c70baa-d665-4ace-9409-6b053e41ed4f"),
                column: "CoverImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ed7d0f41-9d87-4c33-a0c7-3620ed591fe3"),
                column: "CoverImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("eeb61727-49d9-4b67-a836-1d3eacc4f08d"),
                column: "CoverImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f057357a-d690-48ce-a4cc-e1a9748cc63c"),
                column: "CoverImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f15ea439-f2a1-40ac-8278-1056d7a75a52"),
                column: "CoverImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f315b770-aba6-4dd3-b9f0-c8b3d0dce787"),
                column: "CoverImageUrl",
                value: null);
        }
    }
}
