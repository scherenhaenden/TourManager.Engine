using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TourManager.Data.Migrations
{
    public partial class CompleteAdresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Inserted = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    NameOfTour = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TouringDates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Inserted = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    DateOfTour = table.Column<DateTime>(nullable: false),
                    ToursId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouringDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TouringDates_Tours_ToursId",
                        column: x => x.ToursId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Inserted = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    loadIn = table.Column<DateTime>(nullable: false),
                    curfView = table.Column<DateTime>(nullable: false),
                    MaxCapacity = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    TouringDatesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venues_TouringDates_TouringDatesId",
                        column: x => x.TouringDatesId,
                        principalTable: "TouringDates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Inserted = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ManagerId = table.Column<int>(nullable: true),
                    Style = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true),
                    ToursId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bands_Tours_ToursId",
                        column: x => x.ToursId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Inserted = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BandsId = table.Column<int>(nullable: true),
                    VenuesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Bands_BandsId",
                        column: x => x.BandsId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contacts_Venues_VenuesId",
                        column: x => x.VenuesId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Inserted = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    HouseNameOrNumber = table.Column<string>(nullable: true),
                    PostalZip = table.Column<string>(nullable: true),
                    ExtranInfo = table.Column<string>(nullable: true),
                    ContactId = table.Column<int>(nullable: true),
                    VenuesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Venues_VenuesId",
                        column: x => x.VenuesId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Inserted = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    BandsId = table.Column<int>(nullable: true),
                    ContactId = table.Column<int>(nullable: true),
                    VenuesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emails_Bands_BandsId",
                        column: x => x.BandsId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emails_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emails_Venues_VenuesId",
                        column: x => x.VenuesId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TelefonNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Inserted = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    ContactId = table.Column<int>(nullable: true),
                    VenuesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelefonNumbers_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TelefonNumbers_Venues_VenuesId",
                        column: x => x.VenuesId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_ContactId",
                table: "Address",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_VenuesId",
                table: "Address",
                column: "VenuesId");

            migrationBuilder.CreateIndex(
                name: "IX_Bands_AddressId",
                table: "Bands",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Bands_ManagerId",
                table: "Bands",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bands_ToursId",
                table: "Bands",
                column: "ToursId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_BandsId",
                table: "Contacts",
                column: "BandsId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_VenuesId",
                table: "Contacts",
                column: "VenuesId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_BandsId",
                table: "Emails",
                column: "BandsId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_ContactId",
                table: "Emails",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_VenuesId",
                table: "Emails",
                column: "VenuesId");

            migrationBuilder.CreateIndex(
                name: "IX_TelefonNumbers_ContactId",
                table: "TelefonNumbers",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_TelefonNumbers_VenuesId",
                table: "TelefonNumbers",
                column: "VenuesId");

            migrationBuilder.CreateIndex(
                name: "IX_TouringDates_ToursId",
                table: "TouringDates",
                column: "ToursId");

            migrationBuilder.CreateIndex(
                name: "IX_Venues_TouringDatesId",
                table: "Venues",
                column: "TouringDatesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bands_Contacts_ManagerId",
                table: "Bands",
                column: "ManagerId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bands_Address_AddressId",
                table: "Bands",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Contacts_ContactId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Bands_Contacts_ManagerId",
                table: "Bands");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "TelefonNumbers");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Bands");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Venues");

            migrationBuilder.DropTable(
                name: "TouringDates");

            migrationBuilder.DropTable(
                name: "Tours");
        }
    }
}
