﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace TestAPP1.Migrations
{
    public partial class DoctorTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Doctors",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Doctors",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
