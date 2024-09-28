using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nikolaeva_kt_43_21.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teachers_cathedras_f_department_id",
                table: "teachers");

            migrationBuilder.RenameColumn(
                name: "f_department_id",
                table: "teachers",
                newName: "f_cathedra_id");

            migrationBuilder.RenameIndex(
                name: "IX_teachers_f_department_id",
                table: "teachers",
                newName: "IX_teachers_f_cathedra_id");

            migrationBuilder.AddForeignKey(
                name: "FK_teachers_cathedras_f_cathedra_id",
                table: "teachers",
                column: "f_cathedra_id",
                principalTable: "cathedras",
                principalColumn: "cathedra_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teachers_cathedras_f_cathedra_id",
                table: "teachers");

            migrationBuilder.RenameColumn(
                name: "f_cathedra_id",
                table: "teachers",
                newName: "f_department_id");

            migrationBuilder.RenameIndex(
                name: "IX_teachers_f_cathedra_id",
                table: "teachers",
                newName: "IX_teachers_f_department_id");

            migrationBuilder.AddForeignKey(
                name: "FK_teachers_cathedras_f_department_id",
                table: "teachers",
                column: "f_department_id",
                principalTable: "cathedras",
                principalColumn: "cathedra_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
