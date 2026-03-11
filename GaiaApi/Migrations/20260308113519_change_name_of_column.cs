using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaiaApi.Migrations
{
    /// <inheritdoc />
    public partial class change_name_of_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OPERATION_HISTORY_OPERATION_OperationId",
                table: "OPERATION_HISTORY");

            migrationBuilder.DropColumn(
                name: "OPERATION_TYPE_ID",
                table: "OPERATION_HISTORY");

            migrationBuilder.RenameColumn(
                name: "OperationId",
                table: "OPERATION_HISTORY",
                newName: "OPERATION_ID");

            migrationBuilder.RenameIndex(
                name: "IX_OPERATION_HISTORY_OperationId",
                table: "OPERATION_HISTORY",
                newName: "IX_OPERATION_HISTORY_OPERATION_ID");

            migrationBuilder.RenameColumn(
                name: "DESC",
                table: "OPERATION",
                newName: "SYMBOL");

            migrationBuilder.AddColumn<string>(
                name: "NAME",
                table: "OPERATION",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_OPERATION_HISTORY_OPERATION_OPERATION_ID",
                table: "OPERATION_HISTORY",
                column: "OPERATION_ID",
                principalTable: "OPERATION",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OPERATION_HISTORY_OPERATION_OPERATION_ID",
                table: "OPERATION_HISTORY");

            migrationBuilder.DropColumn(
                name: "NAME",
                table: "OPERATION");

            migrationBuilder.RenameColumn(
                name: "OPERATION_ID",
                table: "OPERATION_HISTORY",
                newName: "OperationId");

            migrationBuilder.RenameIndex(
                name: "IX_OPERATION_HISTORY_OPERATION_ID",
                table: "OPERATION_HISTORY",
                newName: "IX_OPERATION_HISTORY_OperationId");

            migrationBuilder.RenameColumn(
                name: "SYMBOL",
                table: "OPERATION",
                newName: "DESC");

            migrationBuilder.AddColumn<int>(
                name: "OPERATION_TYPE_ID",
                table: "OPERATION_HISTORY",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_OPERATION_HISTORY_OPERATION_OperationId",
                table: "OPERATION_HISTORY",
                column: "OperationId",
                principalTable: "OPERATION",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
