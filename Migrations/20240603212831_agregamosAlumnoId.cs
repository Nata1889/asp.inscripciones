using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inscripciones.Migrations
{
    /// <inheritdoc />
    public partial class agregamosAlumnoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inscripciones_alumnos_AlumnoId",
                table: "inscripciones");

            migrationBuilder.RenameColumn(
                name: "AlumnoId",
                table: "inscripciones",
                newName: "alumnoId");

            migrationBuilder.RenameIndex(
                name: "IX_inscripciones_AlumnoId",
                table: "inscripciones",
                newName: "IX_inscripciones_alumnoId");

            migrationBuilder.AlterColumn<int>(
                name: "alumnoId",
                table: "inscripciones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_inscripciones_alumnos_alumnoId",
                table: "inscripciones",
                column: "alumnoId",
                principalTable: "alumnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inscripciones_alumnos_alumnoId",
                table: "inscripciones");

            migrationBuilder.RenameColumn(
                name: "alumnoId",
                table: "inscripciones",
                newName: "AlumnoId");

            migrationBuilder.RenameIndex(
                name: "IX_inscripciones_alumnoId",
                table: "inscripciones",
                newName: "IX_inscripciones_AlumnoId");

            migrationBuilder.AlterColumn<int>(
                name: "AlumnoId",
                table: "inscripciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_inscripciones_alumnos_AlumnoId",
                table: "inscripciones",
                column: "AlumnoId",
                principalTable: "alumnos",
                principalColumn: "Id");
        }
    }
}
