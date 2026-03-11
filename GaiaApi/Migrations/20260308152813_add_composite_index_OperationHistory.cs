using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaiaApi.Migrations
{
    /// <inheritdoc />
    public partial class add_composite_index_OperationHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OPERATION_HISTORY_OPERATION_ID",
                table: "OPERATION_HISTORY");

            migrationBuilder.CreateIndex(
                name: "IX_OPERATION_HISTORY_OPERATION_ID_CREATE_AT",
                table: "OPERATION_HISTORY",
                columns: new[] { "OPERATION_ID", "CREATE_AT" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OPERATION_HISTORY_OPERATION_ID_CREATE_AT",
                table: "OPERATION_HISTORY");

            migrationBuilder.CreateIndex(
                name: "IX_OPERATION_HISTORY_OPERATION_ID",
                table: "OPERATION_HISTORY",
                column: "OPERATION_ID");
        }
    }
}
