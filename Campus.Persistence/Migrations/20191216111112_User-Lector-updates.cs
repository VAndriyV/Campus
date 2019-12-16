using Microsoft.EntityFrameworkCore.Migrations;

namespace Campus.Persistence.Migrations
{
    public partial class UserLectorupdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");
        }
    }
}
