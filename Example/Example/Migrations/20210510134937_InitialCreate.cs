using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Example.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblJobTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Mounth = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblJobTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblManagerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblManagerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblJobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    JobTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblJobs_tblJobTypes_JobTypeID",
                        column: x => x.JobTypeID,
                        principalTable: "tblJobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblManagers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateOfEmployee = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblManagers_tblManagerTypes_ManagerTypeId",
                        column: x => x.ManagerTypeId,
                        principalTable: "tblManagerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblJobTypeSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTypeID = table.Column<int>(type: "int", nullable: false),
                    SkillID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblJobTypeSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblJobTypeSkills_tblJobTypes_JobTypeID",
                        column: x => x.JobTypeID,
                        principalTable: "tblJobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblJobTypeSkills_tblSkills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "tblSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateOfEmployee = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmployees_tblManagers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "tblManagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblJobAvailabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    JobID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblJobAvailabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblJobAvailabilities_tblEmployees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "tblEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblJobAvailabilities_tblJobs_JobID",
                        column: x => x.JobID,
                        principalTable: "tblJobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblManagerTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { 1, "Full-Time" },
                    { 2, "Part-Time" },
                    { 3, "Over-Time" }
                });

            migrationBuilder.InsertData(
                table: "tblSkills",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "[.NET]" });

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployees_Email",
                table: "tblEmployees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployees_ManagerId",
                table: "tblEmployees",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblJobAvailabilities_EmployeeID",
                table: "tblJobAvailabilities",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_tblJobAvailabilities_JobID",
                table: "tblJobAvailabilities",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_tblJobs_JobTypeID",
                table: "tblJobs",
                column: "JobTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_tblJobTypes_Name",
                table: "tblJobTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblJobTypeSkills_JobTypeID",
                table: "tblJobTypeSkills",
                column: "JobTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_tblJobTypeSkills_SkillID",
                table: "tblJobTypeSkills",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_tblManagers_ManagerTypeId",
                table: "tblManagers",
                column: "ManagerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblSkills_Name",
                table: "tblSkills",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblJobAvailabilities");

            migrationBuilder.DropTable(
                name: "tblJobTypeSkills");

            migrationBuilder.DropTable(
                name: "tblEmployees");

            migrationBuilder.DropTable(
                name: "tblJobs");

            migrationBuilder.DropTable(
                name: "tblSkills");

            migrationBuilder.DropTable(
                name: "tblManagers");

            migrationBuilder.DropTable(
                name: "tblJobTypes");

            migrationBuilder.DropTable(
                name: "tblManagerTypes");
        }
    }
}
