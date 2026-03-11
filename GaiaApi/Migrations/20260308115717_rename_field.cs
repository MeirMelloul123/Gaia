using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaiaApi.Migrations
{
    /// <inheritdoc />
    public partial class rename_field : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SYMBOL",
                table: "OPERATION",
                newName: "FORMULA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FORMULA",
                table: "OPERATION",
                newName: "SYMBOL");
        }
    }
}
