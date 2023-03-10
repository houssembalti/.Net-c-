using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fluentap2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fullname_LastName",
                table: "Passengers",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "fullname_FirstName",
                table: "Passengers",
                newName: "first_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Passengers",
                newName: "fullname_LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Passengers",
                newName: "fullname_FirstName");
        }
    }
}
