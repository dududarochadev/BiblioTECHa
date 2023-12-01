using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiblioTECHa.Migrations
{
    /// <inheritdoc />
    public partial class EditBookAddCoverFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverFile",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverFile",
                table: "Books");
        }
    }
}
