using Microsoft.EntityFrameworkCore.Migrations;

namespace PartnerAPI.Migrations
{
    public partial class mymigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartnerInfo",
                columns: table => new
                {
                    emailId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    phoneNum = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerInfo", x => x.emailId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartnerInfo");
        }
    }
}
