using Microsoft.EntityFrameworkCore.Migrations;

namespace Raspertise.Migrations
{
    public partial class adspeedanddataformat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Speed",
                table: "Advertisement",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Advertisement");
        }
    }
}
