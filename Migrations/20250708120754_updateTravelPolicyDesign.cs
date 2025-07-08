using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ava.Shared.Migrations
{
    /// <inheritdoc />
    public partial class updateTravelPolicyDesign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxResults",
                table: "TravelPolicies",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxResults",
                table: "TravelPolicies");
        }
    }
}
