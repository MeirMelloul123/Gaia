using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaiaApi.Migrations
{
    /// <inheritdoc />
    public partial class update_db_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OPERATION_TYPE");

            migrationBuilder.DropColumn(
                name: "OPERATION_TYPE_CODE",
                table: "OPERATION_HISTORY");

            migrationBuilder.RenameColumn(
                name: "CREATE_DATE",
                table: "OPERATION_HISTORY",
                newName: "CREATE_AT");

            migrationBuilder.AddColumn<int>(
                name: "OPERATION_TYPE_ID",
                table: "OPERATION_HISTORY",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OperationId",
                table: "OPERATION_HISTORY",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OPERATION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESC = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERATION", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OPERATION_HISTORY_OperationId",
                table: "OPERATION_HISTORY",
                column: "OperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_OPERATION_HISTORY_OPERATION_OperationId",
                table: "OPERATION_HISTORY",
                column: "OperationId",
                principalTable: "OPERATION",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OPERATION_HISTORY_OPERATION_OperationId",
                table: "OPERATION_HISTORY");

            migrationBuilder.DropTable(
                name: "OPERATION");

            migrationBuilder.DropIndex(
                name: "IX_OPERATION_HISTORY_OperationId",
                table: "OPERATION_HISTORY");

            migrationBuilder.DropColumn(
                name: "OPERATION_TYPE_ID",
                table: "OPERATION_HISTORY");

            migrationBuilder.DropColumn(
                name: "OperationId",
                table: "OPERATION_HISTORY");

            migrationBuilder.RenameColumn(
                name: "CREATE_AT",
                table: "OPERATION_HISTORY",
                newName: "CREATE_DATE");

            migrationBuilder.AddColumn<string>(
                name: "OPERATION_TYPE_CODE",
                table: "OPERATION_HISTORY",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OPERATION_TYPE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESC = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERATION_TYPE", x => x.ID);
                });
        }
    }
}
