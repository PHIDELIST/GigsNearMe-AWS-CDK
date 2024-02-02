using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GigsNearMe.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(1024)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistID);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    VenueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(1024)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(1024)", nullable: true),
                    StateOrCounty = table.Column<string>(type: "nvarchar(1024)", nullable: true),
                    Country = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.VenueID);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    TourID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1024)", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.TourID);
                    table.ForeignKey(
                        name: "FK_Tours_Artists_ArtistID",
                        column: x => x.ArtistID,
                        principalTable: "Artists",
                        principalColumn: "ArtistID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gigs",
                columns: table => new
                {
                    GigID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistID = table.Column<int>(type: "int", nullable: false),
                    TourID = table.Column<int>(type: "int", nullable: true),
                    VenueID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gigs", x => x.GigID);
                    table.ForeignKey(
                        name: "FK_Gigs_Artists_ArtistID",
                        column: x => x.ArtistID,
                        principalTable: "Artists",
                        principalColumn: "ArtistID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gigs_Tours_TourID",
                        column: x => x.TourID,
                        principalTable: "Tours",
                        principalColumn: "TourID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Gigs_Venues_VenueID",
                        column: x => x.VenueID,
                        principalTable: "Venues",
                        principalColumn: "VenueID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistID", "Name" },
                values: new object[,]
                {
                    { 1, "The Marillos" },
                    { 2, "Fishmeister" },
                    { 3, "Pale Red" },
                    { 4, "Fender Dude" },
                    { 5, "Slightly Fuming" },
                    { 6, "Chunky Rain Storm" },
                    { 7, "Electrifying" },
                    { 8, "DepartingArtist" },
                    { 9, "BouncyArtist" }
                });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "VenueID", "City", "Country", "Name", "StateOrCounty" },
                values: new object[,]
                {
                    { 15, "Orlando", 9, "Some Plaza", "FL" },
                    { 16, "Buffalo", 9, "The Town Ballroom", "NY" },
                    { 17, "Los Angeles", 9, "A Theater", "CA" },
                    { 18, "San Francisco", 9, "The Old-time Ballroom", "CA" },
                    { 19, "Washington", 9, "2:30am Club", "DC" },
                    { 23, "Toronto", 1, "Our Music Hall", "ON" },
                    { 21, "Quebec", 1, "The Imperial Ball", "QC" },
                    { 22, "Montreal", 1, "Phone Theatre", "QC" },
                    { 14, "Tampa", 9, "Boat Trip to the Edge", "FL" },
                    { 24, "Sydney, NSW", 0, "Majestic Opera House", "NSW" },
                    { 20, "New York", 9, "PlayMore Theater", "NY" },
                    { 13, "Warsaw", 7, "Progresjaorno", "Masovia" },
                    { 9, "Villersexel", 3, "Chateau de chateau", "Haute-Saone" },
                    { 11, "Essen", 4, "Rounded Colosseum", "North Rhine-Westphalia" },
                    { 10, "Frankfurt", 4, "Thunderthalle", "Hesse" },
                    { 25, "Brisbane", 0, "Triffids", "QLD" },
                    { 8, "Glasgow", 8, "Oran Mor or Less", "Strathclyde" },
                    { 7, "Reading", 2, "A Six-Sider", "Berkshire" },
                    { 6, "Brighton", 2, "The Shiny Dome", "Sussex" },
                    { 5, "Birmingham", 2, "Large Symphony Hall", "West Midlands" },
                    { 4, "Cambridge", 2, "A Corn Exchange", "Cambridgeshire" },
                    { 3, "Gateshead", 2, "The Sage Plant", "Tyne and Wear" },
                    { 2, "Dublin", 5, "Vicarage Street", "County Dublin" },
                    { 1, "Belfast", 6, "A Hall in Ulster", "County Antrim" },
                    { 12, "Berlin", 4, "Admiralsbalast", "Brandenburg" },
                    { 26, "Sydney", 0, "Bank Arena", "NSW" }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "TourID", "ArtistID", "Name", "Start" },
                values: new object[,]
                {
                    { 1, 1, "North American", new DateTime(2021, 7, 23, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716) },
                    { 2, 1, "European", new DateTime(2021, 11, 23, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716) },
                    { 3, 2, "European", new DateTime(2021, 8, 23, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716) },
                    { 4, 2, "One and Done", new DateTime(2021, 11, 23, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716) },
                    { 5, 5, "One Night Only", new DateTime(2021, 10, 23, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716) },
                    { 6, 7, "Down Under Gone Topside", new DateTime(2021, 11, 23, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716) },
                    { 7, 8, "Me Without Them", new DateTime(2021, 6, 23, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716) },
                    { 8, 8, "Not Missing Them", new DateTime(2021, 8, 23, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716) },
                    { 9, 9, "Following Them", new DateTime(2021, 6, 23, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716) }
                });

            migrationBuilder.InsertData(
                table: "Gigs",
                columns: new[] { "GigID", "ArtistID", "Date", "TourID", "VenueID" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 7, 23, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 1, 17 },
                    { 29, 9, new DateTime(2021, 6, 23, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 9, 24 },
                    { 28, 8, new DateTime(2021, 9, 3, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 8, 22 },
                    { 27, 8, new DateTime(2021, 9, 1, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 8, 18 },
                    { 26, 8, new DateTime(2021, 8, 23, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 8, 16 },
                    { 25, 8, new DateTime(2021, 7, 4, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 7, 26 },
                    { 24, 8, new DateTime(2021, 7, 2, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 7, 25 },
                    { 23, 8, new DateTime(2021, 6, 30, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 7, 24 },
                    { 22, 7, new DateTime(2021, 12, 18, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 6, 11 },
                    { 21, 7, new DateTime(2021, 12, 13, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 6, 10 },
                    { 20, 7, new DateTime(2021, 12, 8, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 6, 8 },
                    { 19, 7, new DateTime(2021, 12, 1, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 6, 7 },
                    { 18, 7, new DateTime(2021, 11, 29, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 6, 6 },
                    { 17, 7, new DateTime(2021, 11, 23, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 6, 4 },
                    { 30, 9, new DateTime(2021, 7, 3, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 9, 25 },
                    { 16, 5, new DateTime(2021, 10, 23, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 5, 13 },
                    { 14, 2, new DateTime(2021, 8, 30, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 3, 9 },
                    { 13, 2, new DateTime(2021, 8, 28, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 3, 8 },
                    { 12, 2, new DateTime(2021, 8, 26, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 3, 7 },
                    { 11, 2, new DateTime(2021, 8, 24, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 3, 6 },
                    { 10, 2, new DateTime(2021, 8, 23, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 3, 5 },
                    { 9, 1, new DateTime(2021, 11, 29, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 2, 4 },
                    { 8, 1, new DateTime(2021, 11, 27, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 2, 3 },
                    { 7, 1, new DateTime(2021, 11, 25, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 2, 2 },
                    { 6, 1, new DateTime(2021, 11, 23, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 2, 1 },
                    { 5, 1, new DateTime(2021, 8, 12, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 1, 16 },
                    { 4, 1, new DateTime(2021, 8, 1, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 1, 20 },
                    { 3, 1, new DateTime(2021, 7, 28, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 1, 19 },
                    { 2, 1, new DateTime(2021, 7, 24, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 1, 18 },
                    { 15, 2, new DateTime(2021, 11, 23, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 4, 4 },
                    { 31, 9, new DateTime(2021, 7, 5, 22, 38, 18, 245, DateTimeKind.Utc).AddTicks(8716), 9, 26 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gigs_ArtistID",
                table: "Gigs",
                column: "ArtistID");

            migrationBuilder.CreateIndex(
                name: "IX_Gigs_TourID",
                table: "Gigs",
                column: "TourID");

            migrationBuilder.CreateIndex(
                name: "IX_Gigs_VenueID",
                table: "Gigs",
                column: "VenueID");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_ArtistID",
                table: "Tours",
                column: "ArtistID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gigs");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Venues");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
