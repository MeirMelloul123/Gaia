using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaiaApi.Migrations
{
    /// <inheritdoc />
    public partial class initial_gaia_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OPERATION_HISTORY",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRST_FIELD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OPERATION_TYPE_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SECOND_FIELD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RESULT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERATION_HISTORY", x => x.ID);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OPERATION_HISTORY");

            migrationBuilder.DropTable(
                name: "OPERATION_TYPE");
        }
    }
}
