using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swd.PlayCollector.Model.Migrations
{
    /// <inheritdoc />
    public partial class CollectionItemNumberSizeDieZweite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "CollectionItems",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                comment: "Number of collection item",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "Number of collection item");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "CollectionItems",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "Number of collection item",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldComment: "Number of collection item");
        }
    }
}
