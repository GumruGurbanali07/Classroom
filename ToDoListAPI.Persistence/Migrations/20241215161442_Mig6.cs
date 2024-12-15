using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentTeachers_Students_StudentId",
                table: "StudentTeachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentTeachers",
                table: "StudentTeachers");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "StudentTeachers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "StudentTeachers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "StudentTeachers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentTeachers",
                table: "StudentTeachers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "StudentStudentTeacher",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentTeachersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentStudentTeacher", x => new { x.StudentId, x.StudentTeachersId });
                    table.ForeignKey(
                        name: "FK_StudentStudentTeacher_StudentTeachers_StudentTeachersId",
                        column: x => x.StudentTeachersId,
                        principalTable: "StudentTeachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentStudentTeacher_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentStudentTeacher_StudentTeachersId",
                table: "StudentStudentTeacher",
                column: "StudentTeachersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentStudentTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentTeachers",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "StudentTeachers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentTeachers",
                table: "StudentTeachers",
                columns: new[] { "StudentId", "TeacherId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTeachers_Students_StudentId",
                table: "StudentTeachers",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
