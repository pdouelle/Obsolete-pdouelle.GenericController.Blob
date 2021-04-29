using Microsoft.EntityFrameworkCore.Migrations;

namespace pdouelle.GenericController.Blobs.Debug.Api.Migrations
{
    public partial class add_name_in_offer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Offers");
        }
    }
}
