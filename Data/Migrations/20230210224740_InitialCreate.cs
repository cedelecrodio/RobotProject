using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ROBO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeadRotation = table.Column<int>(type: "int", nullable: false),
                    HeadInclination = table.Column<int>(type: "int", nullable: false),
                    LeftElbow = table.Column<int>(type: "int", nullable: false),
                    LeftFist = table.Column<int>(type: "int", nullable: false),
                    RightElbow = table.Column<int>(type: "int", nullable: false),
                    RightFist = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROBO", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ROBO");
        }
    }
}
