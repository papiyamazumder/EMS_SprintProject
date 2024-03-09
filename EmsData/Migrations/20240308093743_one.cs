using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmsData.Migrations
{
    public partial class one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Dept_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dept_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Dept_ID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Emp_ID = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Emp_First_Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Emp_Last_Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Emp_Date_of_Birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Emp_Date_of_Joining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Emp_Dept_ID = table.Column<int>(type: "int", nullable: false),
                    Emp_Grade = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Emp_Designation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Emp_Basic = table.Column<int>(type: "int", nullable: false),
                    Emp_Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Emp_Marital_Status = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Emp_Home_Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Emp_Contact_Num = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Emp_ID);
                });

            migrationBuilder.CreateTable(
                name: "Grade_Masters",
                columns: table => new
                {
                    Grade_Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Min_Salary = table.Column<int>(type: "int", nullable: false),
                    Max_Salary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade_Masters", x => x.Grade_Code);
                });

            migrationBuilder.CreateTable(
                name: "User_Masters",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Masters", x => x.UserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Grade_Masters");

            migrationBuilder.DropTable(
                name: "User_Masters");
        }
    }
}
