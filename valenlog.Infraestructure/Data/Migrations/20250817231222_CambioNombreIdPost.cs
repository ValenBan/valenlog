using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace valenlog.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CambioNombreIdPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cuid",
                table: "Posts",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Posts",
                newName: "cuid");
        }
    }
}
