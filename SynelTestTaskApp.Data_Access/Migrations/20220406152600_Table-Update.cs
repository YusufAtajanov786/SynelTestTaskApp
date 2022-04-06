using Microsoft.EntityFrameworkCore.Migrations;

namespace SynelTestTaskApp.Data_Access.Migrations
{
    public partial class TableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employes",
                table: "Employes");

            migrationBuilder.RenameTable(
                name: "Employes",
                newName: "Employees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employes",
                table: "Employes",
                column: "Id");
        }
    }
}
