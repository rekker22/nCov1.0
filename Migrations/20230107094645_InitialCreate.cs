using Microsoft.EntityFrameworkCore.Migrations;

namespace nCov1._0.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NCovStateData",
                columns: table => new
                {
                    SdCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalCases = table.Column<long>(type: "bigint", nullable: false),
                    LatCoordinates = table.Column<double>(type: "float", nullable: false),
                    LongCoordinates = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCovStateData", x => x.SdCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NCovStateData");
        }
    }
}
