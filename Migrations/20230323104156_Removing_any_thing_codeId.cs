using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptiLoan.Migrations
{
    /// <inheritdoc />
    public partial class Removing_any_thing_codeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterAgentCode",
                table: "SuperAgents");

            migrationBuilder.DropColumn(
                name: "OrganizationCode",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "OrganizationCode",
                table: "MasterAgents");

            migrationBuilder.DropColumn(
                name: "SuperAgentCode",
                table: "Agents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MasterAgentCode",
                table: "SuperAgents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationCode",
                table: "Staffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationCode",
                table: "MasterAgents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SuperAgentCode",
                table: "Agents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
