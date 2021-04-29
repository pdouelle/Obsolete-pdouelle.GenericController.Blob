using Microsoft.EntityFrameworkCore.Migrations;

namespace pdouelle.GenericController.Blobs.Debug.Api.Migrations
{
    public partial class add_blobA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blobs_Offers_OfferId",
                table: "Blobs");

            migrationBuilder.AddForeignKey(
                name: "FK_Blobs_Offers_OfferId",
                table: "Blobs",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blobs_Offers_OfferId",
                table: "Blobs");

            migrationBuilder.AddForeignKey(
                name: "FK_Blobs_Offers_OfferId",
                table: "Blobs",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
