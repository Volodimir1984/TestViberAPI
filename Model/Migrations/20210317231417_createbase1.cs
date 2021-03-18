using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class createbase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdViber = table.Column<string>(type: "varchar(200)", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: true),
                    Language = table.Column<string>(type: "varchar(10)", nullable: true),
                    Country = table.Column<string>(type: "varchar(10)", nullable: true),
                    DeviceType = table.Column<string>(name: "Device Type", type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("AK_Users_IdViber", x => x.IdViber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
