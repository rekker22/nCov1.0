using Microsoft.EntityFrameworkCore.Migrations;

namespace nCov1._0.Migrations
{
    public partial class AddItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nCovStateData",
                columns: table => new
                {
                    sdCode = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    sName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    dName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    TotalCases = table.Column<long>(nullable: false),
                    LatCoordinates = table.Column<double>(nullable: false),
                    LongCoordinates = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tmp_ms_x__A3801A317F3F7A1E", x => x.sdCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nCovStateData");
        }
    }
}
