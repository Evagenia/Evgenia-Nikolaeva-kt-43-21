using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nikolaeva_kt_43_21.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_cathedras_f_head_teacher_id",
                table: "cathedras");

            migrationBuilder.CreateIndex(
                name: "IX_cathedras_f_head_teacher_id",
                table: "cathedras",
                column: "f_head_teacher_id",
                unique: true,
                filter: "[f_head_teacher_id] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_cathedras_f_head_teacher_id",
                table: "cathedras");

            migrationBuilder.CreateIndex(
                name: "IX_cathedras_f_head_teacher_id",
                table: "cathedras",
                column: "f_head_teacher_id");
        }
    }
}
