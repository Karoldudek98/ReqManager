using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReqManager.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Reqs",
                table: "Reqs");

            migrationBuilder.RenameTable(
                name: "Reqs",
                newName: "Requests");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                table: "Requests",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Requests");

            migrationBuilder.RenameTable(
                name: "Requests",
                newName: "Reqs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reqs",
                table: "Reqs",
                column: "Id");
        }
    }
}
