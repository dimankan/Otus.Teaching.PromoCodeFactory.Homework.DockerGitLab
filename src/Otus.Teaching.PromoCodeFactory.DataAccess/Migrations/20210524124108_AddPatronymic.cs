using Microsoft.EntityFrameworkCore.Migrations;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Migrations
{
    public partial class AddPatronymic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Patronymic",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Patronymic",
                table: "Customers");
        }
    }
}
