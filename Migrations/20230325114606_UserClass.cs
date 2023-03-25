using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptiLoan.Migrations
{
    /// <inheritdoc />
    public partial class UserClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class",
                table: "SuperAgents");

            migrationBuilder.DropColumn(
                name: "Class",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Class",
                table: "MasterAgents");

            migrationBuilder.DropColumn(
                name: "Class",
                table: "Agents");

            migrationBuilder.AddColumn<string>(
                name: "UserClass",
                table: "SuperAgents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserClass",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserClass",
                table: "MasterAgents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserClass",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserClass",
                table: "SuperAgents");

            migrationBuilder.DropColumn(
                name: "UserClass",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "UserClass",
                table: "MasterAgents");

            migrationBuilder.DropColumn(
                name: "UserClass",
                table: "Agents");

            migrationBuilder.AddColumn<int>(
                name: "Class",
                table: "SuperAgents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Class",
                table: "Staffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Class",
                table: "MasterAgents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Class",
                table: "Agents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
