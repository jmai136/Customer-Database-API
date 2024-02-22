using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CustomerDatabaseAPI.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CustomerDatabase");

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "CustomerDatabase",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLineOne = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressLineTwo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CallNotes",
                schema: "CustomerDatabase",
                columns: table => new
                {
                    CallNotesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CallNotesDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsResolved = table.Column<byte>(type: "tinyint", nullable: false),
                    CallReasonType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallNotes", x => x.CallNotesID);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "CustomerDatabase",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyIndustry = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                schema: "CustomerDatabase",
                columns: table => new
                {
                    EmailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailCharacters = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    EmailAccountType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.EmailID);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "CustomerDatabase",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                schema: "CustomerDatabase",
                columns: table => new
                {
                    PhoneNumberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumberDigits = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    PhoneNumberType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => x.PhoneNumberID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Csr",
                schema: "CustomerDatabase",
                columns: table => new
                {
                    CustomerSupportRepresentativeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", nullable: true),
                    CompanyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Csr", x => x.CustomerSupportRepresentativeID);
                    table.ForeignKey(
                        name: "FK_Csr_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalSchema: "CustomerDatabase",
                        principalTable: "Company",
                        principalColumn: "CompanyID");
                    table.ForeignKey(
                        name: "FK_Csr_Person_PersonID",
                        column: x => x.PersonID,
                        principalSchema: "CustomerDatabase",
                        principalTable: "Person",
                        principalColumn: "PersonID");
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "CustomerDatabase",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customer_Person_PersonID",
                        column: x => x.PersonID,
                        principalSchema: "CustomerDatabase",
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyInfo",
                schema: "CustomerDatabase",
                columns: table => new
                {
                    CompanyInfoID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: true),
                    AddressID = table.Column<int>(type: "int", nullable: true),
                    EmailID = table.Column<int>(type: "int", nullable: true),
                    PhoneNumberID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInfo", x => x.CompanyInfoID);
                    table.ForeignKey(
                        name: "FK_CompanyInfo_Address_CompanyInfoID",
                        column: x => x.CompanyInfoID,
                        principalSchema: "CustomerDatabase",
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyInfo_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalSchema: "CustomerDatabase",
                        principalTable: "Company",
                        principalColumn: "CompanyID");
                    table.ForeignKey(
                        name: "FK_CompanyInfo_Email_CompanyInfoID",
                        column: x => x.CompanyInfoID,
                        principalSchema: "CustomerDatabase",
                        principalTable: "Email",
                        principalColumn: "EmailID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyInfo_PhoneNumber_CompanyInfoID",
                        column: x => x.CompanyInfoID,
                        principalSchema: "CustomerDatabase",
                        principalTable: "PhoneNumber",
                        principalColumn: "PhoneNumberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonInfo",
                schema: "CustomerDatabase",
                columns: table => new
                {
                    PersonInfoID = table.Column<int>(type: "int", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: true),
                    AddressID = table.Column<int>(type: "int", nullable: true),
                    PhoneNumberID = table.Column<int>(type: "int", nullable: true),
                    EmailID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInfo", x => x.PersonInfoID);
                    table.ForeignKey(
                        name: "FK_PersonInfo_Address_PersonInfoID",
                        column: x => x.PersonInfoID,
                        principalSchema: "CustomerDatabase",
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInfo_Email_PersonInfoID",
                        column: x => x.PersonInfoID,
                        principalSchema: "CustomerDatabase",
                        principalTable: "Email",
                        principalColumn: "EmailID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInfo_Person_PersonID",
                        column: x => x.PersonID,
                        principalSchema: "CustomerDatabase",
                        principalTable: "Person",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_PersonInfo_PhoneNumber_PersonInfoID",
                        column: x => x.PersonInfoID,
                        principalSchema: "CustomerDatabase",
                        principalTable: "PhoneNumber",
                        principalColumn: "PhoneNumberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Call",
                schema: "CustomerDatabase",
                columns: table => new
                {
                    CallID = table.Column<int>(type: "int", nullable: false),
                    CallNotesID = table.Column<int>(type: "int", nullable: true),
                    CallDurationStartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CallDurationEndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    CustomerSupportRepresentativeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Call", x => x.CallID);
                    table.ForeignKey(
                        name: "FK_Call_CallNotes_CallNotesID",
                        column: x => x.CallNotesID,
                        principalSchema: "CustomerDatabase",
                        principalTable: "CallNotes",
                        principalColumn: "CallNotesID");
                    table.ForeignKey(
                        name: "FK_Call_Csr_CustomerSupportRepresentativeID",
                        column: x => x.CustomerSupportRepresentativeID,
                        principalSchema: "CustomerDatabase",
                        principalTable: "Csr",
                        principalColumn: "CustomerSupportRepresentativeID");
                    table.ForeignKey(
                        name: "FK_Call_Customer_CallID",
                        column: x => x.CallID,
                        principalSchema: "CustomerDatabase",
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "CustomerDatabase",
                table: "Address",
                columns: new[] { "AddressID", "AddressLineOne", "AddressLineTwo", "AddressType", "City", "State" },
                values: new object[,]
                {
                    { 1, "9929 Sulphur Springs Ave. Muskego", "", "DOMICILE", "Milwaukee", "WI" },
                    { 2, "17 Fairview Road Cheaspeake", "", "BUSINESS", "Toledo", "CA" }
                });

            migrationBuilder.InsertData(
                schema: "CustomerDatabase",
                table: "CallNotes",
                columns: new[] { "CallNotesID", "CallNotesDescription", "CallReasonType", "IsResolved" },
                values: new object[] { 1, "", "BILLING_AND_PAYMENT", (byte)1 });

            migrationBuilder.InsertData(
                schema: "CustomerDatabase",
                table: "Company",
                columns: new[] { "CompanyID", "CompanyDescription", "CompanyIndustry", "CompanyName" },
                values: new object[] { 1, "", "HOSPITALITY", "The Shimada Clan" });

            migrationBuilder.InsertData(
                schema: "CustomerDatabase",
                table: "Email",
                columns: new[] { "EmailID", "EmailAccountType", "EmailCharacters" },
                values: new object[,]
                {
                    { 1, "HOME", "shimadabro@gmail.com" },
                    { 2, "HOME", "shimadaclan@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "CustomerDatabase",
                table: "Person",
                columns: new[] { "PersonID", "BirthDate", "FirstName", "LastName", "MiddleName" },
                values: new object[,]
                {
                    { 1, new DateOnly(1997, 10, 25), "Genji", "Shimada", null },
                    { 2, new DateOnly(1990, 3, 14), "Hanzo", "Shimada", null }
                });

            migrationBuilder.InsertData(
                schema: "CustomerDatabase",
                table: "PhoneNumber",
                columns: new[] { "PhoneNumberID", "PhoneNumberDigits", "PhoneNumberType" },
                values: new object[,]
                {
                    { 1, "1925064920", "WORK" },
                    { 2, "7392018402", "WORK" }
                });

            migrationBuilder.InsertData(
                schema: "CustomerDatabase",
                table: "CompanyInfo",
                columns: new[] { "CompanyInfoID", "AddressID", "CompanyID", "EmailID", "PhoneNumberID" },
                values: new object[] { 1, 2, 1, 2, 2 });

            migrationBuilder.InsertData(
                schema: "CustomerDatabase",
                table: "Csr",
                columns: new[] { "CustomerSupportRepresentativeID", "CompanyID", "PersonID" },
                values: new object[] { 1, 1, 2 });

            migrationBuilder.InsertData(
                schema: "CustomerDatabase",
                table: "Customer",
                columns: new[] { "CustomerID", "PersonID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                schema: "CustomerDatabase",
                table: "PersonInfo",
                columns: new[] { "PersonInfoID", "AddressID", "EmailID", "PersonID", "PhoneNumberID" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1 },
                    { 2, 1, 1, 2, 1 }
                });

            migrationBuilder.InsertData(
                schema: "CustomerDatabase",
                table: "Call",
                columns: new[] { "CallID", "CallDurationEndDateTime", "CallDurationStartDateTime", "CallNotesID", "CustomerID", "CustomerSupportRepresentativeID" },
                values: new object[] { 1, new DateTime(2020, 12, 5, 19, 30, 17, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 5, 17, 25, 9, 0, DateTimeKind.Unspecified), 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Call_CallNotesID",
                schema: "CustomerDatabase",
                table: "Call",
                column: "CallNotesID");

            migrationBuilder.CreateIndex(
                name: "IX_Call_CustomerSupportRepresentativeID",
                schema: "CustomerDatabase",
                table: "Call",
                column: "CustomerSupportRepresentativeID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyInfo_CompanyID",
                schema: "CustomerDatabase",
                table: "CompanyInfo",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Csr_CompanyID",
                schema: "CustomerDatabase",
                table: "Csr",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Csr_PersonID",
                schema: "CustomerDatabase",
                table: "Csr",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PersonID",
                schema: "CustomerDatabase",
                table: "Customer",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInfo_PersonID",
                schema: "CustomerDatabase",
                table: "PersonInfo",
                column: "PersonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Call",
                schema: "CustomerDatabase");

            migrationBuilder.DropTable(
                name: "CompanyInfo",
                schema: "CustomerDatabase");

            migrationBuilder.DropTable(
                name: "PersonInfo",
                schema: "CustomerDatabase");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CallNotes",
                schema: "CustomerDatabase");

            migrationBuilder.DropTable(
                name: "Csr",
                schema: "CustomerDatabase");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "CustomerDatabase");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "CustomerDatabase");

            migrationBuilder.DropTable(
                name: "Email",
                schema: "CustomerDatabase");

            migrationBuilder.DropTable(
                name: "PhoneNumber",
                schema: "CustomerDatabase");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "CustomerDatabase");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "CustomerDatabase");
        }
    }
}
