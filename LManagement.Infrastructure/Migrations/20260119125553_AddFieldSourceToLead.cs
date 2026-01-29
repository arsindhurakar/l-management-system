using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldSourceToLead : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "leads",
                type: "character varying(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_leads_Source",
                table: "leads",
                column: "Source");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_leads_Source",
                table: "leads");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "leads");
        }
    }
}
