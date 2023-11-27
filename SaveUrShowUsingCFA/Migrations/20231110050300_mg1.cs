using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaveUrShowUsingCFA.Migrations
{
    public partial class mg1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "feedback",
                columns: table => new
                {
                    feedid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    moviename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback", x => x.feedid);
                });

            migrationBuilder.CreateTable(
                name: "FindTicket",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Theatrename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Moviename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    synopsis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trailer = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    heroname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    heroimg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    heroinename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    heroineimg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    charges = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FindTicket", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    userid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    password = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    confirmpassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usertype = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "BookingTicket",
                columns: table => new
                {
                    Bookid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seatnum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieId = table.Column<int>(type: "int", nullable: true),
                    Userid = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Slot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingTicket", x => x.Bookid);
                    table.ForeignKey(
                        name: "FK_BookingTicket_FindTicket_MovieId",
                        column: x => x.MovieId,
                        principalTable: "FindTicket",
                        principalColumn: "MovieId");
                    table.ForeignKey(
                        name: "FK_BookingTicket_Registration_Userid",
                        column: x => x.Userid,
                        principalTable: "Registration",
                        principalColumn: "userid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingTicket_MovieId",
                table: "BookingTicket",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingTicket_Userid",
                table: "BookingTicket",
                column: "Userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingTicket");

            migrationBuilder.DropTable(
                name: "feedback");

            migrationBuilder.DropTable(
                name: "FindTicket");

            migrationBuilder.DropTable(
                name: "Registration");
        }
    }
}
