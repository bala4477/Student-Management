using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspCore1.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "marks",
                columns: table => new
                {
                    MarkID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    SubjectID_1 = table.Column<int>(type: "int", nullable: false),
                    SubjectName_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject_1_Mark = table.Column<int>(type: "int", nullable: false),
                    SubjectID_2 = table.Column<int>(type: "int", nullable: false),
                    SubjectName_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject_2_Mark = table.Column<int>(type: "int", nullable: false),
                    SubjectID_3 = table.Column<int>(type: "int", nullable: false),
                    SubjectName_3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject_3_Mark = table.Column<int>(type: "int", nullable: false),
                    SubjectID_4 = table.Column<int>(type: "int", nullable: false),
                    SubjectName_4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject_4_Mark = table.Column<int>(type: "int", nullable: false),
                    SubjectID_5 = table.Column<int>(type: "int", nullable: false),
                    SubjectName_5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject_5_Mark = table.Column<int>(type: "int", nullable: false),
                    SubjectID_6 = table.Column<int>(type: "int", nullable: false),
                    SubjectName_6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject_6_Mark = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marks", x => x.MarkID);
                    table.ForeignKey(
                        name: "FK_marks_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_marks_StudentID",
                table: "marks",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "marks");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
