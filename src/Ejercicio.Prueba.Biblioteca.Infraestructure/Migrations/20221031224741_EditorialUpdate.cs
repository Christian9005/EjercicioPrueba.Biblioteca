using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ejercicio.Prueba.Biblioteca.Infraestructure.Migrations
{
    public partial class EditorialUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Editorials");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Libros",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Libros");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Editorials",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
