using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DersinKodu = table.Column<string>(type: "char(3)", nullable: false),
                    DersinAdi = table.Column<string>(type: "varchar(30)", nullable: false),
                    Sinifi = table.Column<byte>(type: "tinyint", nullable: false),
                    MuellimAdi = table.Column<string>(type: "varchar(20)", nullable: false),
                    MuellimSoyadi = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SagirdinNomresi = table.Column<byte>(type: "tinyint", nullable: false),
                    Ad = table.Column<string>(type: "varchar(30)", nullable: false),
                    Soyad = table.Column<string>(type: "varchar(30)", nullable: false),
                    Sinifi = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DersinKodu = table.Column<string>(type: "char(3)", nullable: false),
                    SagirdinNomresi = table.Column<byte>(type: "tinyint", nullable: false),
                    ImtahanTarixi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Qiymeti = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LessonsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_Lessons_LessonsId",
                        column: x => x.LessonsId,
                        principalTable: "Lessons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LessonsStudents",
                columns: table => new
                {
                    LessonsId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonsStudents", x => new { x.LessonsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_LessonsStudents_Lessons_LessonsId",
                        column: x => x.LessonsId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonsStudents_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamsStudents",
                columns: table => new
                {
                    ExamsId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamsStudents", x => new { x.ExamsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_ExamsStudents_Exams_ExamsId",
                        column: x => x.ExamsId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamsStudents_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_LessonsId",
                table: "Exams",
                column: "LessonsId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamsStudents_StudentsId",
                table: "ExamsStudents",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonsStudents_StudentsId",
                table: "LessonsStudents",
                column: "StudentsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamsStudents");

            migrationBuilder.DropTable(
                name: "LessonsStudents");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Lessons");
        }
    }
}
