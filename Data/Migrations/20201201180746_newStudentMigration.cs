using Microsoft.EntityFrameworkCore.Migrations;

namespace SharpCodeAssignmentOne.Data.Migrations
{
    public partial class newStudentMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentInfo",
                columns: table => new
                {
                    StudentInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentInfoFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentInfoLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentInfoSex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentInfoAge = table.Column<int>(type: "int", nullable: false),
                    StudentInfoClass = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInfo", x => x.StudentInfoID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentInfo");
        }
    }
}
