using Microsoft.EntityFrameworkCore.Migrations;

namespace chatty.Migrations
{
    public partial class AddIsInternational : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInternational",
                table: "AirportEvents",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInternational",
                table: "AirportEvents");
        }
    }
}
