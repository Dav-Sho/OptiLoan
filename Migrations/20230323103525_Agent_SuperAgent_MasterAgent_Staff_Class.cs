using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptiLoan.Migrations
{
    /// <inheritdoc />
    public partial class Agent_SuperAgent_MasterAgent_Staff_Class : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterAgents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: true),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    OrganizationCode = table.Column<int>(type: "int", nullable: false),
                    Class = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterAgents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterAgents_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MasterAgents_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: true),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    OrganizationCode = table.Column<int>(type: "int", nullable: false),
                    Class = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staffs_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Staffs_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SuperAgents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: true),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    MasterAgentId = table.Column<int>(type: "int", nullable: true),
                    MasterAgentCode = table.Column<int>(type: "int", nullable: false),
                    Class = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperAgents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuperAgents_MasterAgents_MasterAgentId",
                        column: x => x.MasterAgentId,
                        principalTable: "MasterAgents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SuperAgents_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: true),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    SuperAgentId = table.Column<int>(type: "int", nullable: true),
                    SuperAgentCode = table.Column<int>(type: "int", nullable: false),
                    Class = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agents_SuperAgents_SuperAgentId",
                        column: x => x.SuperAgentId,
                        principalTable: "SuperAgents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Agents_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_SuperAgentId",
                table: "Agents",
                column: "SuperAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_userId",
                table: "Agents",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterAgents_OrganizationId",
                table: "MasterAgents",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterAgents_userId",
                table: "MasterAgents",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_OrganizationId",
                table: "Staffs",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_userId",
                table: "Staffs",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperAgents_MasterAgentId",
                table: "SuperAgents",
                column: "MasterAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperAgents_userId",
                table: "SuperAgents",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "SuperAgents");

            migrationBuilder.DropTable(
                name: "MasterAgents");
        }
    }
}
