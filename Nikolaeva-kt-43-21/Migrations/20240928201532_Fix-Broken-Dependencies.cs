using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nikolaeva_kt_43_21.Migrations
{
    /// <inheritdoc />
    public partial class FixBrokenDependencies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "f_head_teacher_id",
                table: "cathedras",
                type: "int",
                nullable: true,
                comment: "Идентификатор заведующего кафедрой",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Идентификатор заведующего кафедрой");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "f_head_teacher_id",
                table: "cathedras",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Идентификатор заведующего кафедрой",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Идентификатор заведующего кафедрой");
        }
    }
}
