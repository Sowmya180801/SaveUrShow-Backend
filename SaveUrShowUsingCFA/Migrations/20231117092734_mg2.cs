using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaveUrShowUsingCFA.Migrations
{
    public partial class mg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "screening",
                table: "FindTicket",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "screening",
                table: "FindTicket");
        }
    }
}
