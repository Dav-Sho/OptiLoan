using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptiLoan.Migrations
{
    /// <inheritdoc />
    public partial class Resloving_User_Relationship_Conflict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Users_userId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterAgents_Users_userId",
                table: "MasterAgents");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Users_userId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_SuperAgents_Users_userId",
                table: "SuperAgents");

            migrationBuilder.DropIndex(
                name: "IX_SuperAgents_userId",
                table: "SuperAgents");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_userId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_MasterAgents_userId",
                table: "MasterAgents");

            migrationBuilder.DropIndex(
                name: "IX_Agents_userId",
                table: "Agents");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "SuperAgents",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Staffs",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "MasterAgents",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Agents",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "SuperAgents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Staffs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "MasterAgents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Agents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SuperAgents_UserId",
                table: "SuperAgents",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_UserId",
                table: "Staffs",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MasterAgents_UserId",
                table: "MasterAgents",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Users_UserId",
                table: "Agents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterAgents_Users_UserId",
                table: "MasterAgents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Users_UserId",
                table: "Staffs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SuperAgents_Users_UserId",
                table: "SuperAgents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Users_UserId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterAgents_Users_UserId",
                table: "MasterAgents");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Users_UserId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_SuperAgents_Users_UserId",
                table: "SuperAgents");

            migrationBuilder.DropIndex(
                name: "IX_SuperAgents_UserId",
                table: "SuperAgents");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_UserId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_MasterAgents_UserId",
                table: "MasterAgents");

            migrationBuilder.DropIndex(
                name: "IX_Agents_UserId",
                table: "Agents");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "SuperAgents",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Staffs",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "MasterAgents",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Agents",
                newName: "userId");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "SuperAgents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "Staffs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "MasterAgents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "Agents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_SuperAgents_userId",
                table: "SuperAgents",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_userId",
                table: "Staffs",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterAgents_userId",
                table: "MasterAgents",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_userId",
                table: "Agents",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Users_userId",
                table: "Agents",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterAgents_Users_userId",
                table: "MasterAgents",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Users_userId",
                table: "Staffs",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SuperAgents_Users_userId",
                table: "SuperAgents",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
