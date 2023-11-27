using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Candid.Migrations
{
    /// <inheritdoc />
    public partial class Setup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    Lat = table.Column<decimal>(type: "decimal(10,7)", nullable: false),
                    Lng = table.Column<decimal>(type: "decimal(10,7)", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    IndustryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    isActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IndustryType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.IndustryId);
                });

            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    MajorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MajorName = table.Column<string>(type: "TEXT", nullable: false),
                    isActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    MajorCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.MajorId);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyEmail = table.Column<string>(type: "TEXT", nullable: true),
                    AddressId = table.Column<int>(type: "INTEGER", nullable: false),
                    WebsiteUrl = table.Column<string>(type: "TEXT", nullable: true),
                    isActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CompanyDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Companies_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    SystemDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AddressId = table.Column<int>(type: "INTEGER", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Ethnicity = table.Column<string>(type: "TEXT", nullable: false),
                    GPA = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    GraduationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PositionType = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId");
                });

            migrationBuilder.CreateTable(
                name: "CompanyIndustries",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: false),
                    IndustryId = table.Column<int>(type: "INTEGER", nullable: false),
                    isActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyIndustries", x => new { x.CompanyId, x.IndustryId });
                    table.ForeignKey(
                        name: "FK_CompanyIndustries_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyIndustries_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "IndustryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PositionName = table.Column<string>(type: "TEXT", nullable: false),
                    PositionDescription = table.Column<string>(type: "TEXT", nullable: true),
                    isActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    PositionType = table.Column<string>(type: "TEXT", nullable: false),
                    AddressId = table.Column<int>(type: "INTEGER", nullable: false),
                    Deadline = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionId);
                    table.ForeignKey(
                        name: "FK_Positions_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Positions_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId");
                });

            migrationBuilder.CreateTable(
                name: "AppUserMajors",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "TEXT", nullable: false),
                    MajorId = table.Column<int>(type: "INTEGER", nullable: false),
                    isActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserMajors", x => new { x.AppUserId, x.MajorId });
                    table.ForeignKey(
                        name: "FK_AppUserMajors_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserMajors_Majors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Majors",
                        principalColumn: "MajorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "PositionMajors",
                columns: table => new
                {
                    PositionId = table.Column<int>(type: "INTEGER", nullable: false),
                    MajorId = table.Column<int>(type: "INTEGER", nullable: false),
                    isActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionMajors", x => new { x.PositionId, x.MajorId });
                    table.ForeignKey(
                        name: "FK_PositionMajors_Majors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Majors",
                        principalColumn: "MajorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionMajors_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserPositions",
                columns: table => new
                {
                    AppUserPositionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StatusType = table.Column<string>(type: "TEXT", nullable: false),
                    StudentId = table.Column<string>(type: "TEXT", nullable: true),
                    PositionId = table.Column<int>(type: "INTEGER", nullable: false),
                    isActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateSubmitted = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InterviewId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserPositions", x => x.AppUserPositionId);
                    table.ForeignKey(
                        name: "FK_AppUserPositions_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppUserPositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionId");
                });

            migrationBuilder.CreateTable(
                name: "Interviews",
                columns: table => new
                {
                    InterviewId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Room = table.Column<string>(type: "TEXT", nullable: false),
                    isActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    InterviewDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatorId = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RecruiterId = table.Column<string>(type: "TEXT", nullable: true),
                    AppUserPositionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviews", x => x.InterviewId);
                    table.ForeignKey(
                        name: "FK_Interviews_AppUserPositions_AppUserPositionId",
                        column: x => x.AppUserPositionId,
                        principalTable: "AppUserPositions",
                        principalColumn: "AppUserPositionId");
                    table.ForeignKey(
                        name: "FK_Interviews_AspNetUsers_RecruiterId",
                        column: x => x.RecruiterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "Lat", "Lng", "PostalCode", "State", "Street" },
                values: new object[,]
                {
                    { 1, "San Francisco", 37.7897965m, -122.3969499m, "94105", "CA", "415 Mission St" },
                    { 2, "Houston", 29.7822672m, -95.64439809999999m, "77082-3101", "TX", "415 Highway 6 South" },
                    { 3, "Austin", 30.2658983m, -97.7493573m, "78701", "TX", "500 West 2nd Street Suite 1600" },
                    { 4, "McLean", 38.92425739999999m, -77.21347999999999m, "22102-3491", "VA", "1680 Capital One Dr" },
                    { 5, "Dallas", 32.910939m, -96.75466499999999m, "75243", "TX", "12500 TI Blvd" },
                    { 6, "McLean", 38.9270956m, -77.2151868m, "22102", "VA", "7930 Jones Branch Dr" },
                    { 7, "Chicago", 41.884798m, -87.62124589999999m, "60601", "IL", "200 E Randolph St" },
                    { 8, "Austin", 30.2761867m, -97.7437736m, "78701", "TX", "1300 Guadalupe St" },
                    { 9, "Austin", 30.2677245m, -97.7426175m, "78701", "TX", "515 Congress Ave Suite 2100" },
                    { 10, "Redmond", 47.6393783m, -122.1282593m, "98052", "WA", "1 Microsoft Way" },
                    { 11, "Katy", 29.7997717m, -95.7494015m, "77449", "TX", "1800 North Mason Road" },
                    { 12, "Chicago", 41.878474m, -87.6363853m, "60606", "IL", "233 S Wacker Dr" },
                    { 13, "Minneapolis", 44.9741779m, -93.27559649999999m, "55403", "MN", "1000 Nicollet Mall" },
                    { 14, "Austin", 30.2961708m, -97.73895429999999m, "78705", "TX", "1 David Park" },
                    { 15, "Austin", 30.267153m, -97.7430608m, "78712", "TX", "10117 Swallow Road" },
                    { 16, "Austin", 30.2260199m, -97.7789829m, "78786", "TX", "21344 Marcy Avenue" },
                    { 17, "Eagle Pass", 28.7091433m, -100.4995214m, "78852", "TX", "894 Kim Junction" },
                    { 18, "Austin", 30.267153m, -97.7430608m, "78729", "TX", "703 Anthes Lane" },
                    { 19, "Georgetown", 30.6410107m, -97.76340189999999m, "78628", "TX", "703 Forest Run Trail" },
                    { 20, "Austin", 30.2961708m, -97.73895429999999m, "78705", "TX", "51 Miller Park" },
                    { 21, "Austin", 30.267153m, -97.7430608m, "78704", "TX", "86086 Ryan Terrace" },
                    { 22, "College Station", 30.627977m, -96.3344068m, "77840", "TX", "97327 Express Avenue" },
                    { 23, "Austin", 30.267153m, -97.7430608m, "78756", "TX", "1 Arrowood Road" },
                    { 24, "Austin", 30.267153m, -97.7430608m, "78746", "TX", "5035 Dayton Court" },
                    { 25, "Austin", 30.3322876m, -97.7576175m, "78756", "TX", "90461 Evergreen Place" },
                    { 26, "Liberty", 30.057993m, -94.7954783m, "77575", "TX", "973 Stephen Alley" },
                    { 27, "San Antonio", 29.4251905m, -98.4945922m, "78203", "TX", "80319 Forster Parkway" },
                    { 28, "New Braunfels", 29.702566m, -98.12406349999999m, "78132", "TX", "96 Stang Hill" },
                    { 29, "New York", 40.7127753m, -74.0059728m, "10101", "NY", "23726 Main Crossing" },
                    { 30, "Lockhart", 29.8849441m, -97.6699996m, "78644", "TX", "6299 Moland Alley" },
                    { 31, "Kingwood", 30.07m, -95.22m, "77325", "TX", "6 Truax Street" },
                    { 32, "Beverly Hills", 34.0736204m, -118.4003563m, "90210", "CA", "50883 Heath Park" },
                    { 33, "Navasota", 30.3879845m, -96.0877349m, "77868", "TX", "5 Carberry Point" },
                    { 34, "Austin", 30.267153m, -97.7430608m, "78712", "TX", "10 Amoth Lane" },
                    { 35, "Austin", 30.267153m, -97.7430608m, "78712", "TX", "1186 Pepper Wood Junction" },
                    { 36, "Schenectady", 42.8142432m, -73.9395687m, "12345", "NY", "961 Cody Parkway" },
                    { 37, "Austin", 30.267153m, -97.7430608m, "78717", "TX", "4921 High Crossing Way" },
                    { 38, "Austin", 30.267153m, -97.7430608m, "78727", "TX", "145 Old Gate Alley" },
                    { 39, "Beaumont", 30.080174m, -94.1265562m, "77720", "TX", "6 Schlimgen Lane" },
                    { 40, "San Marcos", 29.8832749m, -97.9413941m, "78667", "TX", "6647 Eastlawn Trail" },
                    { 41, "Bergheim", 29.8274986m, -98.5752874m, "78004", "TX", "7 Mallard Court" },
                    { 42, "Austin", 30.267153m, -97.7430608m, "78789", "TX", "9517 Hooker Street" },
                    { 43, "Orlando", 28.5383832m, -81.3789269m, "32830", "FL", "9 Clemons Terrace" },
                    { 44, "South Padre Island", 26.1118401m, -97.16812569999999m, "78597", "TX", "37080 Darwin Parkway" },
                    { 45, "Austin", 30.267153m, -97.7430608m, "78744", "TX", "61 Iowa Drive" },
                    { 46, "Canyon Lake", 29.8781434m, -98.2431747m, "78133", "TX", "56 Express Trail" },
                    { 47, "Austin", 30.3161202m, -97.75497659999999m, "78779", "TX", "712 Dayton Terrace" },
                    { 48, "Austin", 30.267153m, -97.7430608m, "78720", "TX", "77 International Drive" },
                    { 49, "Austin", 30.267153m, -97.7430608m, "78705", "TX", "9 Dahle Road" },
                    { 50, "Round Rock", 30.5082551m, -97.678896m, "78680", "TX", "2036 Carpenter Alley" },
                    { 51, "Austin", 30.267153m, -97.7430608m, "78760", "TX", "773 Sullivan Court" },
                    { 52, "Sweet Home", 29.3452449m, -97.07165169999999m, "77987", "TX", "59 Dakota Point" },
                    { 53, "Corpus Christi", 27.687317m, -97.346665m, "78412", "TX", "20644 Badeau Point" },
                    { 54, "Pflugerville", 30.4332061m, -97.60057859999999m, "78660", "TX", "79 Starling Park" },
                    { 55, "Austin", 30.267153m, -97.7430608m, "78702", "TX", "71 Main Circle" },
                    { 56, "Austin", 30.267153m, -97.7430608m, "78713", "TX", "202 Ramsey Junction" },
                    { 57, "Austin", 30.267153m, -97.7430608m, "78712", "TX", "831 Namekagon Avenue" },
                    { 58, "Austin", 30.267153m, -97.7430608m, "78786", "TX", "6587 Debs Junction" },
                    { 59, "San Antonio", 29.4251905m, -98.4945922m, "78279", "TX", "37 Ohio Pass" },
                    { 60, "Navasota", 30.3879845m, -96.0877349m, "77868", "TX", "3 Bartillon Junction" },
                    { 61, "Boston", 42.3600825m, -71.0588801m, "02114", "MA", "59699 Hovde Terrace" },
                    { 62, "Marble Falls", 30.5782297m, -98.2729184m, "78654", "TX", "89 Jenna Terrace" },
                    { 63, "Austin", 30.267153m, -97.7430608m, "78730", "TX", "4 Main Place" },
                    { 64, "Austin", 30.267153m, -97.7430608m, "78712", "TX", "95 Longview Point" },
                    { 65, "Orlando", 28.5376214m, -81.3796806m, "32801", "FL", "400 South Orange Avenue" },
                    { 66, "Houston", 29.760271m, -95.3693347m, "77002", "TX", "901 Bagby Sreet" },
                    { 67, "Houston", 29.7533742m, -95.3657403m, "77002", "TX", "1301 Fannin Street" },
                    { 68, "Dallas", 32.8706424m, -96.93958149999999m, "75039", "TX", "5205 North O'Connor Boulevard" },
                    { 69, "Austin", 30.387725m, -97.71941299999999m, "78758", "TX", "10414 McKalla Place" },
                    { 70, "Los Angeles", 34.0432309m, -118.2671588m, "90015", "CA", "1111 South Figueroa Street" },
                    { 71, "Chicago", 41.8806277m, -87.6740485m, "60612", "IL", "1901 West Madison Street" },
                    { 72, "Richmond", 37.5751669m, -77.5407146m, "23173", "VA", "410 Westhampton Way" },
                    { 73, "Plano", 33.0287381m, -96.75190839999999m, "75075", "TX", "2200 Independence Parkway" },
                    { 74, "Dallas", 32.7876958m, -96.797163m, "75201", "TX", "2200 Ross Avenue" },
                    { 75, "New York", 40.7625263m, -73.97987909999999m, "10019", "NY", "1335 6th Avenue" },
                    { 76, "Austin", 30.2814504m, -97.73082409999999m, "78712", "TX", "2001 Robert Dedman Drive" },
                    { 77, "Houston", 29.7086716m, -95.5412771m, "77036", "TX", "8900 Bellaire Boulevard" },
                    { 78, "Dallas", 32.7885264m, -96.8044412m, "75202", "TX", "1717 McKinney Avenue" },
                    { 79, "Austin", 30.3277549m, -97.75071009999999m, "78731", "TX", "2825 Hancock Drive" },
                    { 80, "Fort Worth", 32.7411451m, -97.3683365m, "76107", "TX", "1911 Montgomery Street" },
                    { 81, "Austin", 30.284996m, -97.7447962m, "78705", "TX", "28 Holy Shizay Sheist Ln" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35f744f5-1211-434f-a4e2-16a1f9969f1c", null, "Recruiter", "RECRUITER" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", null, "Student", "STUDENT" },
                    { "f5f409f0-98b0-4334-9585-15097c4010c5", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "CompanyId", "ConcurrencyStamp", "DateCreated", "DateOfBirth", "Email", "EmailConfirmed", "Ethnicity", "FirstName", "GPA", "Gender", "GraduationDate", "IsActive", "LastLoginDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PositionType", "SecurityStamp", "SystemDate", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3f2b3516-a083-41a3-b663-a900deeba5c8", 0, null, null, "f1b1e107-b328-4bb9-b822-abc976921f51", new DateTime(2023, 11, 27, 0, 21, 22, 101, DateTimeKind.Local).AddTicks(680), null, "slayer@onegirl.net", false, "Asian", "Buffy", 0m, "F", null, true, null, "Summers", false, null, "SLAYER@ONEGIRL.NET", "SLAYER@ONEGIRL.NET", "AQAAAAIAAYagAAAAEFrYwch2Nq7kZTcB1i1jpdwK49RPiad8N7NTHzS1v91SN/cOUZUQmvGexKfKmsjL2w==", null, false, "FT", "36bcce6b-4f2d-46c1-adbc-30e3b0d0b402", new DateTime(2023, 11, 27, 0, 21, 22, 101, DateTimeKind.Local).AddTicks(690), false, "slayer@onegirl.net" },
                    { "572e7da2-be4a-4588-8759-5908d80f5c54", 0, null, null, "7be68174-59a1-40e7-9c15-8440eb4368c5", new DateTime(2023, 11, 27, 0, 21, 22, 63, DateTimeKind.Local).AddTicks(5350), null, "captain@enterprise.net", false, "Asian", "Jean Luc", 0m, "F", null, true, null, "Picard", false, null, "CAPTAIN@ENTERPRISE.NET", "CAPTAIN@ENTERPRISE.NET", "AQAAAAIAAYagAAAAEEDI1sRTrfeOuDQpehSz2yttbPaVjyrYj0YbyltHHu8uLOMgfDV/UrI1nbOp3QhqsA==", null, false, "FT", "678ddc1f-f16f-4ff5-a7f3-d292f7ca69eb", new DateTime(2023, 11, 27, 0, 21, 22, 63, DateTimeKind.Local).AddTicks(5360), false, "captain@enterprise.net" },
                    { "602f1c92-1c99-4a04-8b66-4b7ad8ecce0f", 0, null, null, "b5fae9bb-aef2-4537-90e4-3b7230b2e2ab", new DateTime(2023, 11, 27, 0, 21, 22, 180, DateTimeKind.Local).AddTicks(430), null, "twin@deservedbetter.com", false, "Asian", "Fred", 0m, "F", null, true, null, "Weasley", false, null, "TWIN@DESERVEDBETTER.COM", "TWIN@DESERVEDBETTER.COM", "AQAAAAIAAYagAAAAEJD/ia/caB0DW5RkemEfWnLIWF06RDtBr5dsE2KxDG+IfUcdto65eRVF1ArDlGJW/Q==", null, false, "FT", "353ef6b3-7b0a-471a-b6a7-c8f65688de92", new DateTime(2023, 11, 27, 0, 21, 22, 180, DateTimeKind.Local).AddTicks(450), false, "twin@deservedbetter.com" },
                    { "7ba8a22d-7a1b-453d-8767-4ad9627aa2c0", 0, null, null, "f7949ab2-0249-4ad8-b2e8-677b995fe34e", new DateTime(2023, 11, 27, 0, 21, 22, 139, DateTimeKind.Local).AddTicks(5750), null, "liz@ggmail.com", false, "Asian", "Elizabeth", 0m, "F", null, true, null, "Markham", false, null, "LIZ@GGMAIL.COM", "LIZ@GGMAIL.COM", "AQAAAAIAAYagAAAAEBqkmHmcyCYEvbChMOJA79kWkzhKsfe2ZPBImZypYRRIYGQxIqiXfsSsaAEQUPomKg==", null, false, "FT", "33f60c8e-f963-4832-8f69-bfea70ad60ec", new DateTime(2023, 11, 27, 0, 21, 22, 139, DateTimeKind.Local).AddTicks(5770), false, "liz@ggmail.com" },
                    { "e686046a-22e9-4148-8df5-6c0cc159a4ae", 0, null, null, "ebf51ea3-c32e-471a-884f-5c5f1fe21e4b", new DateTime(2023, 11, 27, 0, 21, 22, 26, DateTimeKind.Local).AddTicks(700), null, "ra@aoo.com", false, "Asian", "Allen", 0m, "F", null, true, null, "Rogers", false, null, "RA@AOO.COM", "RA@AOO.COM", "AQAAAAIAAYagAAAAEL7jmcka6JYkUAoXPIVqSzB2eA1CO0u7iufhnNSWzsHOEh1iSu5w7C19I6GRp3TGZg==", null, false, "FT", "b0de151e-d77e-4154-9940-ee386c9b5760", new DateTime(2023, 11, 27, 0, 21, 22, 26, DateTimeKind.Local).AddTicks(720), false, "ra@aoo.com" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "IndustryId", "IndustryType", "isActive" },
                values: new object[,]
                {
                    { 1, "Accounting", true },
                    { 2, "Consulting", true },
                    { 3, "Energy", true },
                    { 4, "Engineering", true },
                    { 5, "FinancialServices", true },
                    { 6, "Manufacturing", true },
                    { 7, "Hospitality", true },
                    { 8, "Insurance", true },
                    { 9, "Marketing", true },
                    { 10, "RealEstate", true },
                    { 11, "Technology", true },
                    { 12, "Retail", true },
                    { 13, "Transportation", true },
                    { 14, "Chemicals", true }
                });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "MajorId", "MajorCode", "MajorName", "isActive" },
                values: new object[,]
                {
                    { 1, "ACC", "Accounting", true },
                    { 2, "CBHP", "Canfield Business Honors Program", true },
                    { 3, "FIN", "Finance", true },
                    { 4, "IB", "International Business", true },
                    { 5, "MAN", "Management", true },
                    { 6, "MKT", "Marketing", true },
                    { 7, "SCM", "Supply Chain Management", true },
                    { 8, "MIS", "Management Information Systems", true },
                    { 9, "STM", "Science and Technology Management", true }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f5f409f0-98b0-4334-9585-15097c4010c5", "3f2b3516-a083-41a3-b663-a900deeba5c8" },
                    { "f5f409f0-98b0-4334-9585-15097c4010c5", "572e7da2-be4a-4588-8759-5908d80f5c54" },
                    { "f5f409f0-98b0-4334-9585-15097c4010c5", "602f1c92-1c99-4a04-8b66-4b7ad8ecce0f" },
                    { "f5f409f0-98b0-4334-9585-15097c4010c5", "7ba8a22d-7a1b-453d-8767-4ad9627aa2c0" },
                    { "f5f409f0-98b0-4334-9585-15097c4010c5", "e686046a-22e9-4148-8df5-6c0cc159a4ae" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "CompanyId", "ConcurrencyStamp", "DateCreated", "DateOfBirth", "Email", "EmailConfirmed", "Ethnicity", "FirstName", "GPA", "Gender", "GraduationDate", "IsActive", "LastLoginDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PositionType", "SecurityStamp", "SystemDate", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "01ea3680-b776-449d-9aea-7499148f95ed", 0, 22, null, "2c960335-50cd-49a7-8efd-2a03d4bde764", new DateTime(2023, 11, 27, 0, 21, 23, 265, DateTimeKind.Local).AddTicks(6280), new DateTime(1996, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "tfreeley@minnetonka.ci.us", false, "NativeHawaiianandOtherPacificIslander", "Tesa", 3.98m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Freeley", false, null, "TFREELEY@MINNETONKA.CI.US", "TFREELEY@MINNETONKA.CI.US", "AQAAAAIAAYagAAAAEE9vkU2yh9tTK5eRxcq4WWYgfd5z/19ILWrnpt/18ST/0bdmesxsKjFMni3r4cB6UQ==", null, false, "I", "636ac8be-4acf-4076-8cdc-ab9e697b15c4", new DateTime(2023, 11, 27, 0, 21, 23, 265, DateTimeKind.Local).AddTicks(6280), false, "tfreeley@minnetonka.ci.us" },
                    { "03572f20-ba44-4812-ad14-3c41b3013b27", 0, 61, null, "c8517434-acb6-40b1-8b15-d5fa06cbd8a3", new DateTime(2023, 11, 27, 0, 21, 24, 710, DateTimeKind.Local).AddTicks(480), new DateTime(1997, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "vinovino@grapes.com", false, "Hispanic", "Janet", 3.28m, "F", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Vino", false, null, "VINOVINO@GRAPES.COM", "VINOVINO@GRAPES.COM", "AQAAAAIAAYagAAAAECIaA1rHOumSea83g224nz7UEQBJ+R6VMp3NdYlryjgCJpU8cCcETu2GTlKrrIxYvQ==", null, false, "I", "faace6b9-85ad-4ac6-a76e-66304eea16f7", new DateTime(2023, 11, 27, 0, 21, 24, 710, DateTimeKind.Local).AddTicks(480), false, "vinovino@grapes.com" },
                    { "0b1f00e0-c3dc-49af-a337-a77a54ffef78", 0, 18, null, "54584a7b-9e1c-46c9-8d52-b70829225d17", new DateTime(2023, 11, 27, 0, 21, 23, 117, DateTimeKind.Local).AddTicks(4290), new DateTime(2003, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "limchou@gogle.com", false, "Asian", "Lim", 2.63m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Chou", false, null, "LIMCHOU@GOGLE.COM", "LIMCHOU@GOGLE.COM", "AQAAAAIAAYagAAAAECJy1ovZyGxVw7Wdd+Yy57fLgDd+1mA7uVfgUw/JrHEcSJSwCuMjelVwD0o01mW4uw==", null, false, "I", "2bb9ee4d-5844-48e7-a1ac-5cccbe3513db", new DateTime(2023, 11, 27, 0, 21, 23, 117, DateTimeKind.Local).AddTicks(4290), false, "limchou@gogle.com" },
                    { "0dd23141-9ae1-41de-b0ee-4416b7d6c4b8", 0, 16, null, "8009bf24-6a70-4d60-93ba-af784b43d813", new DateTime(2023, 11, 27, 0, 21, 23, 43, DateTimeKind.Local).AddTicks(2400), new DateTime(2002, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "franco@example.com", false, "White", "Franco", 3.20m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Broccolo", false, null, "FRANCO@EXAMPLE.COM", "FRANCO@EXAMPLE.COM", "AQAAAAIAAYagAAAAEE+nHn7OlQK702X16MVIe4yrOLu/q7cpvPrQo60muQjIIGQQ0Ab0v+sZ3p1vI38zPw==", null, false, "FT", "b908f20d-e02c-4524-93dd-17c540266eba", new DateTime(2023, 11, 27, 0, 21, 23, 43, DateTimeKind.Local).AddTicks(2400), false, "franco@example.com" },
                    { "0ea609e1-188e-4c4d-b21e-4571c423e49d", 0, 20, null, "a58b6335-83fa-4346-b41c-a3c9d31dd322", new DateTime(2023, 11, 27, 0, 21, 23, 191, DateTimeKind.Local).AddTicks(4940), new DateTime(2001, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "j.b.evans@aheca.org", false, "White", "Jim Bob", 2.64m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Evans", false, null, "J.B.EVANS@AHECA.ORG", "J.B.EVANS@AHECA.ORG", "AQAAAAIAAYagAAAAEJs7gGkl8kKwSP4xa178ftQPkZZz3TBDXpLEjBJZyzotAZStW3X0uaMwwa7Wf6qT2g==", null, false, "FT", "71f4b48b-30b8-436e-af0f-24694b6190b9", new DateTime(2023, 11, 27, 0, 21, 23, 191, DateTimeKind.Local).AddTicks(4940), false, "j.b.evans@aheca.org" },
                    { "13cf98cd-e1f6-4bd3-9ad1-4a2ad7f9fcde", 0, 64, null, "1df38ae6-f91f-46f5-b22a-0e3721a187a9", new DateTime(2023, 11, 27, 0, 21, 24, 822, DateTimeKind.Local).AddTicks(790), new DateTime(2001, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rwood@voyager.net", false, "White", "Reagan", 3.78m, "F", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Wood", false, null, "RWOOD@VOYAGER.NET", "RWOOD@VOYAGER.NET", "AQAAAAIAAYagAAAAEEJnm4D4UG84OSeXodyBtqUOg2TYRBaKFzD8yCbSKkb8/frKee0fmVL38aO6e6hwUg==", null, false, "FT", "13e4874a-79bc-4198-8c56-cdf3431c515b", new DateTime(2023, 11, 27, 0, 21, 24, 822, DateTimeKind.Local).AddTicks(790), false, "rwood@voyager.net" },
                    { "1a8190d7-2105-40d0-95e7-33af8313fbe7", 0, 53, null, "22e72321-42b3-4987-b428-f092d25118e9", new DateTime(2023, 11, 27, 0, 21, 24, 413, DateTimeKind.Local).AddTicks(7250), new DateTime(2003, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "estuart@anchor.net", false, "BlackOrAfricanAmerican", "Eric", 3.58m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Stuart", false, null, "ESTUART@ANCHOR.NET", "ESTUART@ANCHOR.NET", "AQAAAAIAAYagAAAAEIsYjmswUAD5excPpuW/SUyHzQylrIo+wXIKOc06ySGWy/Ui0IHA4I5S5KUSU0RL5w==", null, false, "FT", "2a56341d-6104-4a1b-a5cb-c1d714676455", new DateTime(2023, 11, 27, 0, 21, 24, 413, DateTimeKind.Local).AddTicks(7250), false, "estuart@anchor.net" },
                    { "220a343b-0d56-43ec-9951-ce983fc6c597", 0, 36, null, "f0aefff7-b378-4b61-88cd-b995c2e7d953", new DateTime(2023, 11, 27, 0, 21, 23, 783, DateTimeKind.Local).AddTicks(8830), new DateTime(2002, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "clarence@yoho.com", false, "White", "Clarence", 3.11m, "Other", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Martin", false, null, "CLARENCE@YOHO.COM", "CLARENCE@YOHO.COM", "AQAAAAIAAYagAAAAEMWZLR9CaKKzgng/0ISI2PTNrP7TrUKMykO1ZiLqwzlIFpE2gha2VEWtys/Bhsk8GA==", null, false, "I", "5e55f52b-e991-4966-beea-039faacf24ea", new DateTime(2023, 11, 27, 0, 21, 23, 783, DateTimeKind.Local).AddTicks(8830), false, "clarence@yoho.com" },
                    { "256f5ba9-1352-4558-acfc-33c67dbec1fd", 0, 58, null, "cd79380d-850a-4323-b5d7-2cea304c6410", new DateTime(2023, 11, 27, 0, 21, 24, 599, DateTimeKind.Local).AddTicks(1920), new DateTime(2003, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "teefrank@noclue.com", false, "BlackOrAfricanAmerican", "Frank", 3.50m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Tee", false, null, "TEEFRANK@NOCLUE.COM", "TEEFRANK@NOCLUE.COM", "AQAAAAIAAYagAAAAEOcsW/tA1rKtWqZUXohjvUhzW/1LkNefxr6NDsOr3ROTGYJlCZclVyVLulluOyyYxg==", null, false, "FT", "5dc8cc33-c190-4f94-b839-1f51b6390eb3", new DateTime(2023, 11, 27, 0, 21, 24, 599, DateTimeKind.Local).AddTicks(1920), false, "teefrank@noclue.com" },
                    { "265bfd9f-b3ea-4ef4-a6dc-7c52933e7089", 0, 52, null, "69de910c-37a2-4fc0-8c1c-769c6b0bd12f", new DateTime(2023, 11, 27, 0, 21, 24, 376, DateTimeKind.Local).AddTicks(6000), new DateTime(2002, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "dustroud@mail.com", false, "White", "Dustin", 3.49m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Stroud", false, null, "DUSTROUD@MAIL.COM", "DUSTROUD@MAIL.COM", "AQAAAAIAAYagAAAAEAt8ifmcEAW2jQOm4KyW6dBhYzJqTGgXpERDR8Bs5th6xSNTa/0HrHluOTzD2/N7/A==", null, false, "I", "bd479cdf-058d-440e-9283-20899cd727b7", new DateTime(2023, 11, 27, 0, 21, 24, 376, DateTimeKind.Local).AddTicks(6000), false, "dustroud@mail.com" },
                    { "28d260bd-b558-469b-8a47-d23479056931", 0, 26, null, "b90d1849-cd15-4c00-9e42-ac9d5844c7f4", new DateTime(2023, 11, 27, 0, 21, 23, 413, DateTimeKind.Local).AddTicks(7000), new DateTime(2000, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "wjhearniii@umich.org", false, "White", "John", 3.46m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Hearn", false, null, "WJHEARNIII@UMICH.ORG", "WJHEARNIII@UMICH.ORG", "AQAAAAIAAYagAAAAECa8NS+WOAbdqCxp1o+3n9PT2M42NYIU7CHSPN93eRHqZOgP5zZsSyNp6P2Qg3r3zg==", null, false, "FT", "1a3e96ad-e826-4342-95aa-d252b5cfe674", new DateTime(2023, 11, 27, 0, 21, 23, 413, DateTimeKind.Local).AddTicks(7000), false, "wjhearniii@umich.org" },
                    { "2a5122b4-c491-4274-b03c-38daba6cb1da", 0, 45, null, "94a10ca3-fcbf-4940-8972-db553a7acc04", new DateTime(2023, 11, 27, 0, 21, 24, 116, DateTimeKind.Local).AddTicks(9810), new DateTime(2002, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "jorge@noclue.com", false, "Hispanic", "Jorge", 3.64m, "M", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Rodriguez", false, null, "JORGE@NOCLUE.COM", "JORGE@NOCLUE.COM", "AQAAAAIAAYagAAAAECzd3Qpd7Ch4Mwq+eRsaNaS2/4DnCVAFLAbcdmiVWijk6YRIdEnLhBX5nXUn4h6vMQ==", null, false, "I", "031457ca-e5d4-4c22-9a98-eb21f2971132", new DateTime(2023, 11, 27, 0, 21, 24, 116, DateTimeKind.Local).AddTicks(9810), false, "jorge@noclue.com" },
                    { "2f40042e-6742-4e26-a789-dfd40c2de6fe", 0, 35, null, "e562810b-5c49-4b5b-a467-a01bac52ca1a", new DateTime(2023, 11, 27, 0, 21, 23, 746, DateTimeKind.Local).AddTicks(6670), new DateTime(2000, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "cmartin@beets.com", false, "NativeHawaiianandOtherPacificIslander", "Elizabeth", 3.53m, "Other", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Markham", false, null, "CMARTIN@BEETS.COM", "CMARTIN@BEETS.COM", "AQAAAAIAAYagAAAAEIcXseNyFYFRyT8Xs/V9yZ1kCPs/WWCS4fWCbyEVyUzNjIArq3XB8EDvzmrpY1vohQ==", null, false, "FT", "b969d3f2-716e-4395-a06d-d798a91450b0", new DateTime(2023, 11, 27, 0, 21, 23, 746, DateTimeKind.Local).AddTicks(6670), false, "cmartin@beets.com" },
                    { "328cad67-0c01-416f-9ec4-9d980e848e8a", 0, 50, null, "ba30fe90-393f-407a-995b-3ec36c6d0a05", new DateTime(2023, 11, 27, 0, 21, 24, 302, DateTimeKind.Local).AddTicks(4700), new DateTime(2002, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "sheffiled@gogle.com", false, "TwoOrMoreRaces", "Martin", 3.36m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Sheffield", false, null, "SHEFFILED@GOGLE.COM", "SHEFFILED@GOGLE.COM", "AQAAAAIAAYagAAAAEFLdD6gqQivQ7PiQ0iC2nL3NC0jUzcNDkutiCYgxoloyRZMPGNz9IclOyoCxOPd4ZA==", null, false, "I", "8562e20f-f5d0-46a5-abc2-e161515b71d1", new DateTime(2023, 11, 27, 0, 21, 24, 302, DateTimeKind.Local).AddTicks(4700), false, "sheffiled@gogle.com" },
                    { "346f26e0-7a5b-47b4-a810-6a1f3b4c6f7d", 0, 37, null, "11f5e56a-e523-4e0a-94de-4301a5b1aad4", new DateTime(2023, 11, 27, 0, 21, 23, 820, DateTimeKind.Local).AddTicks(7990), new DateTime(2003, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "gregmartinez@drdre.com", false, "Hispanic", "Gregory", 3.43m, "M", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Martinez", false, null, "GREGMARTINEZ@DRDRE.COM", "GREGMARTINEZ@DRDRE.COM", "AQAAAAIAAYagAAAAEDDDLvXbXdbVKcT2NGCHMRnxBZPr4InEY2jHq8aJmvOq0UVZZq+uZPbh52J9XadjlA==", null, false, "I", "5b937d07-27db-401c-b2f2-9532c317efa3", new DateTime(2023, 11, 27, 0, 21, 23, 820, DateTimeKind.Local).AddTicks(7990), false, "gregmartinez@drdre.com" },
                    { "37dd03ab-ef9a-4445-90af-3f9c0e020954", 0, 24, null, "c72d3e3b-bb98-45c0-9b04-f056a7408766", new DateTime(2023, 11, 27, 0, 21, 23, 339, DateTimeKind.Local).AddTicks(8670), new DateTime(1998, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "chaley@thug.com", false, "BlackOrAfricanAmerican", "Charles", 3.78m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Haley", false, null, "CHALEY@THUG.COM", "CHALEY@THUG.COM", "AQAAAAIAAYagAAAAED7dmpxTDNFdLcdzFjRsQJIcY+OREXS0J4cPS0zIEZuJYkZU8VaS2b2CG1s48sm/bA==", null, false, "I", "68cfd4b8-5d91-4b57-aedd-5533f3ad5c50", new DateTime(2023, 11, 27, 0, 21, 23, 339, DateTimeKind.Local).AddTicks(8670), false, "chaley@thug.com" },
                    { "39f638c4-d6a0-4fa3-a029-7603abf6f016", 0, 29, null, "5d7eea4a-d0d3-4411-bab2-98ca5a51538b", new DateTime(2023, 11, 27, 0, 21, 23, 524, DateTimeKind.Local).AddTicks(8950), new DateTime(2001, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "toddj@yourmom.com", false, "Hispanic", "Todd", 2.64m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Jacobs", false, null, "TODDJ@YOURMOM.COM", "TODDJ@YOURMOM.COM", "AQAAAAIAAYagAAAAEIJ1dNNxgcNwXbOqlQzMdrIb1XbmHEUFFNATDS5Hfddo6XCnQfoOyHV6JQIj2BqHJw==", null, false, "FT", "4aa19160-ab78-4bdb-89d1-cfd3d4d35e5a", new DateTime(2023, 11, 27, 0, 21, 23, 524, DateTimeKind.Local).AddTicks(8950), false, "toddj@yourmom.com" },
                    { "3d72a769-4341-4451-9277-fec699b48abd", 0, 59, null, "c8e2d19a-1844-4e52-8cbc-750329caba41", new DateTime(2023, 11, 27, 0, 21, 24, 636, DateTimeKind.Local).AddTicks(1520), new DateTime(2001, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ctucker@alphabet.co.uk", false, "Asian", "Clent", 3.04m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Tucker", false, null, "CTUCKER@ALPHABET.CO.UK", "CTUCKER@ALPHABET.CO.UK", "AQAAAAIAAYagAAAAECrrQXYSVVcc990usAT+rPDPDO467CBI6dOfipch06ODz4ym4XVNiYvhSKgojt3sfQ==", null, false, "I", "129745db-7b95-4dcd-b9a8-45c30e1fa5c4", new DateTime(2023, 11, 27, 0, 21, 24, 636, DateTimeKind.Local).AddTicks(1520), false, "ctucker@alphabet.co.uk" },
                    { "3d8da166-342d-41b6-b19a-20c0b0c94355", 0, 30, null, "cf44720b-f971-4c1c-87bb-af4baf53b413", new DateTime(2023, 11, 27, 0, 21, 23, 561, DateTimeKind.Local).AddTicks(8570), new DateTime(2001, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "thequeen@aska.net", false, "BlackOrAfricanAmerican", "Victoria", 3.72m, "F", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Lawrence", false, null, "THEQUEEN@ASKA.NET", "THEQUEEN@ASKA.NET", "AQAAAAIAAYagAAAAEFtxkU2sPbvycQbzLrMQP7GRkUWTTMA7rR4EEUsxqBIm+/lJYtvT8IyhMTmE+YGstQ==", null, false, "I", "92936bb1-6036-466d-9a1e-9c8750633fe9", new DateTime(2023, 11, 27, 0, 21, 23, 561, DateTimeKind.Local).AddTicks(8570), false, "thequeen@aska.net" },
                    { "3d96a487-37d1-409d-922a-43bbf0714eb7", 0, 43, null, "b9339356-b6b0-4381-a012-85c453ddc414", new DateTime(2023, 11, 27, 0, 21, 24, 43, DateTimeKind.Local).AddTicks(80), new DateTime(2001, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "megrhodes@freserve.co.uk", false, "TwoOrMoreRaces", "Megan", 3.14m, "F", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Rhodes", false, null, "MEGRHODES@FRESERVE.CO.UK", "MEGRHODES@FRESERVE.CO.UK", "AQAAAAIAAYagAAAAEBAL5OwZmhoYL7ZbmOhA7xI/bjvkWy2/dz9/cOU3fy7PkiZIUWNOJqflop6Ey6enNA==", null, false, "I", "2ed273a2-7c1c-40a1-a66b-325ef0805c84", new DateTime(2023, 11, 27, 0, 21, 24, 43, DateTimeKind.Local).AddTicks(80), false, "megrhodes@freserve.co.uk" },
                    { "48364611-796f-4747-9f4c-239563562ec9", 0, 14, null, "aa33b36e-bcf6-49e1-981a-ebc1d546f183", new DateTime(2023, 11, 27, 0, 21, 22, 968, DateTimeKind.Local).AddTicks(7210), new DateTime(2001, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "cbaker@example.com", false, "White", "Christopher", 3.91m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Baker", false, null, "CBAKER@EXAMPLE.COM", "CBAKER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPQX1JGMcvFt8PAiM4x+SnzS2EMpglBCFMyleftTPn2Nexjekq5Tb5cuCFUo2kzoRQ==", null, false, "FT", "bd5cb493-7808-45f0-b78a-c7b125685b5d", new DateTime(2023, 11, 27, 0, 21, 22, 968, DateTimeKind.Local).AddTicks(7210), false, "cbaker@example.com" },
                    { "4a9f84c2-3f33-46ba-8dc0-1f686aaa26fd", 0, 39, null, "6e48d356-5900-400d-8b27-338bf26b2522", new DateTime(2023, 11, 27, 0, 21, 23, 894, DateTimeKind.Local).AddTicks(8000), new DateTime(2003, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "knelson@aoll.com", false, "NativeHawaiianandOtherPacificIslander", "Kelly", 3.03m, "F", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Nelson", false, null, "KNELSON@AOLL.COM", "KNELSON@AOLL.COM", "AQAAAAIAAYagAAAAEPd7SL/VFdFM69QCDS/3M6rbJWSN+M5Urc9Q3YvUM1dGH5LzJwFvdmysMUzXZtOs3Q==", null, false, "FT", "42fe1c65-3bf1-4b7d-94bb-37893e1c19f1", new DateTime(2023, 11, 27, 0, 21, 23, 894, DateTimeKind.Local).AddTicks(8000), false, "knelson@aoll.com" },
                    { "5153f91e-7597-47ad-a924-bc032e064710", 0, 15, null, "09e184e2-af9d-40b5-baf9-4423414eaefb", new DateTime(2023, 11, 27, 0, 21, 23, 5, DateTimeKind.Local).AddTicks(9630), new DateTime(2000, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "banker@longhorn.net", false, "BlackOrAfricanAmerican", "Michelle", 3.52m, "F", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Banks", false, null, "BANKER@LONGHORN.NET", "BANKER@LONGHORN.NET", "AQAAAAIAAYagAAAAEO/VTa5ZdmQDyX66drRI5Yx70Q6QaOBvVVLs5d6FEG7TpTm3qoMfhxyJgzKuWKPefQ==", null, false, "I", "17109532-0543-47d4-a2a8-2fafdd599ef3", new DateTime(2023, 11, 27, 0, 21, 23, 5, DateTimeKind.Local).AddTicks(9630), false, "banker@longhorn.net" },
                    { "52972799-56b0-4b6b-91a7-ec844b1dd404", 0, 57, null, "be714fe2-e2e6-47c3-b686-b851ce72a8ad", new DateTime(2023, 11, 27, 0, 21, 24, 562, DateTimeKind.Local).AddTicks(2350), new DateTime(2003, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "rtaylor@gogle.com", false, "TwoOrMoreRaces", "Rachel", 2.88m, "F", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Taylor", false, null, "RTAYLOR@GOGLE.COM", "RTAYLOR@GOGLE.COM", "AQAAAAIAAYagAAAAED5D+ikroz+ZdVJ88dlHec2dErQ5rlC2N3RUBiKk8zqA1qLB88Dv6ksurjU84khZRg==", null, false, "I", "a656468a-bfa4-45f5-92b5-dfe14061c5cc", new DateTime(2023, 11, 27, 0, 21, 24, 562, DateTimeKind.Local).AddTicks(2350), false, "rtaylor@gogle.com" },
                    { "5550d8e4-bec0-401d-ac05-f4dab2cd7960", 0, 19, null, "a0413ba0-8544-448a-ad6a-bc75655d6e75", new DateTime(2023, 11, 27, 0, 21, 23, 154, DateTimeKind.Local).AddTicks(4000), new DateTime(2002, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "shdixon@aoll.com", false, "White", "Shan", 3.62m, "F", new DateTime(2026, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Dixon", false, null, "SHDIXON@AOLL.COM", "SHDIXON@AOLL.COM", "AQAAAAIAAYagAAAAEJwr0vv07+WNgXo0RSHf5UINDn82qR1rgi3FPj2BoKMN/e0ZRTm4shy0jUlVSwB4uA==", null, false, "I", "a8df9592-2da2-4471-914e-840053524926", new DateTime(2023, 11, 27, 0, 21, 23, 154, DateTimeKind.Local).AddTicks(4000), false, "shdixon@aoll.com" },
                    { "57cc3f93-1767-43b0-a60e-4ab753ac515e", 0, 60, null, "2d08344e-cca2-42db-9710-5b6bfd819323", new DateTime(2023, 11, 27, 0, 21, 24, 673, DateTimeKind.Local).AddTicks(900), new DateTime(2003, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "avelasco@yoho.com", false, "Hispanic", "Allen", 3.55m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Velasco", false, null, "AVELASCO@YOHO.COM", "AVELASCO@YOHO.COM", "AQAAAAIAAYagAAAAEBhtvMZu32FjYC3rYtLUTUTYfhYHrOkZ0Ks+6WL0Yzl3Fu5Z3QfNDEBWzuCg35c8iA==", null, false, "FT", "19f6a7de-9eaf-4ac0-8b36-64e7cd55f139", new DateTime(2023, 11, 27, 0, 21, 24, 673, DateTimeKind.Local).AddTicks(900), false, "avelasco@yoho.com" },
                    { "5fb43981-827c-4a20-9a78-9bfa640aefdb", 0, 25, null, "6ccef648-6311-4129-bb67-17f602f1fe92", new DateTime(2023, 11, 27, 0, 21, 23, 376, DateTimeKind.Local).AddTicks(7930), new DateTime(2003, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "jeffh@sonic.com", false, "BlackOrAfricanAmerican", "Jeffrey", 3.66m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Hampton", false, null, "JEFFH@SONIC.COM", "JEFFH@SONIC.COM", "AQAAAAIAAYagAAAAEPLcE0yRwuVwduN/q08iDNBJYrddpHX9aUO4MsjW+9hzVtWacgIcFdOnHJ5JV2erZA==", null, false, "I", "cbd45dc4-243a-448c-b403-8e8cc384a93d", new DateTime(2023, 11, 27, 0, 21, 23, 376, DateTimeKind.Local).AddTicks(7930), false, "jeffh@sonic.com" },
                    { "644e9749-c8c0-41b7-b1ad-d9d747f4209e", 0, 23, null, "33e1a55d-00a8-4b51-a222-68ac8263dad2", new DateTime(2023, 11, 27, 0, 21, 23, 302, DateTimeKind.Local).AddTicks(9430), new DateTime(2002, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "mgarcia@gogle.com", false, "Hispanic", "Margaret", 3.22m, "F", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Garcia", false, null, "MGARCIA@GOGLE.COM", "MGARCIA@GOGLE.COM", "AQAAAAIAAYagAAAAEPNcok+JT6G4TWHtoaHKFZsNuFLq+CW6rVVs1RUqwS5TxmibHW3kRDBDlga18BHNBw==", null, false, "FT", "43843432-57da-4b18-ab8b-7367a07e5b42", new DateTime(2023, 11, 27, 0, 21, 23, 302, DateTimeKind.Local).AddTicks(9430), false, "mgarcia@gogle.com" },
                    { "687382b3-a0e7-4239-b6d7-a1991f1ef1c8", 0, 47, null, "59598ae9-c399-43b4-a012-cb18b42004fb", new DateTime(2023, 11, 27, 0, 21, 24, 191, DateTimeKind.Local).AddTicks(3440), new DateTime(2002, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "stjean@athome.com", false, "White", "Olivier", 3.24m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Saint-Jean", false, null, "STJEAN@ATHOME.COM", "STJEAN@ATHOME.COM", "AQAAAAIAAYagAAAAENIcs8Xm6TaxWnFRrCdum50Ongc84sZ8tG+/0rIjyJuy/6ZSGZY0iR3EIBBiNVs/BQ==", null, false, "FT", "89ac538c-cae5-4c81-8580-1672e368dc84", new DateTime(2023, 11, 27, 0, 21, 24, 191, DateTimeKind.Local).AddTicks(3440), false, "stjean@athome.com" },
                    { "6d74195d-e27b-499b-b14c-77587f008c08", 0, 42, null, "3cd356ee-f02e-424f-a744-945dbced1ddf", new DateTime(2023, 11, 27, 0, 21, 24, 5, DateTimeKind.Local).AddTicks(9150), new DateTime(2001, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "ankaisrad@gogle.com", false, "White", "Anka", 3.67m, "Other", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Radkovich", false, null, "ANKAISRAD@GOGLE.COM", "ANKAISRAD@GOGLE.COM", "AQAAAAIAAYagAAAAEH6mm//9iMpeQhKsLnEgbEdGLTsZAcGNDXPa5T3adcdqcy+pGmickLgncOMvkjkCgA==", null, false, "FT", "a56cab24-3a97-42b3-8123-5fc302ea8b87", new DateTime(2023, 11, 27, 0, 21, 24, 5, DateTimeKind.Local).AddTicks(9150), false, "ankaisrad@gogle.com" },
                    { "6df8c34a-e08b-4093-88c7-710097c6b5f1", 0, 56, null, "c56be26b-a14c-457d-9cd0-a4b0e255de7f", new DateTime(2023, 11, 27, 0, 21, 24, 525, DateTimeKind.Local).AddTicks(770), new DateTime(2001, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "taylordjay@aoll.com", false, "TwoOrMoreRaces", "Allison", 3.07m, "F", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Taylor", false, null, "TAYLORDJAY@AOLL.COM", "TAYLORDJAY@AOLL.COM", "AQAAAAIAAYagAAAAEMKoygMfYV8fgk2Fyt81SP1Hzx0uHTq4UtnC8rc9fwfhVuzNVUx7EiHBJWN0J6LQ/A==", null, false, "FT", "407e1f3c-58e1-493d-9b2c-d246cb1ef311", new DateTime(2023, 11, 27, 0, 21, 24, 525, DateTimeKind.Local).AddTicks(770), false, "taylordjay@aoll.com" },
                    { "7149bce1-bbba-4674-bfc4-23c3efc069d0", 0, 54, null, "a343604c-7b47-469f-b30d-f1d05a63d88b", new DateTime(2023, 11, 27, 0, 21, 24, 450, DateTimeKind.Local).AddTicks(9280), new DateTime(2002, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "peterstump@noclue.com", false, "NativeHawaiianandOtherPacificIslander", "Peter", 2.55m, "M", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Stump", false, null, "PETERSTUMP@NOCLUE.COM", "PETERSTUMP@NOCLUE.COM", "AQAAAAIAAYagAAAAENBTKiEsdpAXqdVH+XWa9kWVT2KCFPW04wkpmJg9bYE4BbplcUJkuypAL7Ij6NtAaQ==", null, false, "I", "bda6c418-d60b-489c-8350-3e355bc068ce", new DateTime(2023, 11, 27, 0, 21, 24, 450, DateTimeKind.Local).AddTicks(9280), false, "peterstump@noclue.com" },
                    { "7e97875d-df90-4a44-94c4-76034b0a430a", 0, 33, null, "82dcf651-cb9c-4cba-b8c6-17593ba2030e", new DateTime(2023, 11, 27, 0, 21, 23, 672, DateTimeKind.Local).AddTicks(7290), new DateTime(2001, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "cluce@gogle.com", false, "White", "Chuck", 3.87m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Luce", false, null, "CLUCE@GOGLE.COM", "CLUCE@GOGLE.COM", "AQAAAAIAAYagAAAAENYo2h25wElzC/HUvWMfy7jAFJ9Zc6XVXpAHM/jN+q1Yy5VMkc4jQCNm/V/74vODXQ==", null, false, "I", "0cfa9281-1041-4738-8022-7823445a5881", new DateTime(2023, 11, 27, 0, 21, 23, 672, DateTimeKind.Local).AddTicks(7290), false, "cluce@gogle.com" },
                    { "90834150-7602-428c-a87d-1be247d2facd", 0, 32, null, "feb33ec8-6dfb-4b07-a7f0-e885fee90ab5", new DateTime(2023, 11, 27, 0, 21, 23, 635, DateTimeKind.Local).AddTicks(7670), new DateTime(2001, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "elowe@netscare.net", false, "White", "Ernest", 3.07m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Lowe", false, null, "ELOWE@NETSCARE.NET", "ELOWE@NETSCARE.NET", "AQAAAAIAAYagAAAAEPr0Rm60X2mYrs2pJzw7f58YiZtVcMDg30ctzdKQ3s9AOvYO3EvMcSH8z9IJZMJiEQ==", null, false, "FT", "b577e571-fd33-421e-aed1-e481e97a262a", new DateTime(2023, 11, 27, 0, 21, 23, 635, DateTimeKind.Local).AddTicks(7670), false, "elowe@netscare.net" },
                    { "9358a237-ed59-4a94-a727-a667e138046d", 0, 51, null, "5be4057f-1a59-4c81-9e91-909ece5a6f54", new DateTime(2023, 11, 27, 0, 21, 24, 339, DateTimeKind.Local).AddTicks(5240), new DateTime(2001, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "johnsmith187@aoll.com", false, "White", "John", 3.57m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Smith", false, null, "JOHNSMITH187@AOLL.COM", "JOHNSMITH187@AOLL.COM", "AQAAAAIAAYagAAAAEPWuskNv/M3DiZEXLuAob3Axi3eGxO1U7Vp52eJykWPtRtgjfeC7nl1RE8z+ifSJlg==", null, false, "FT", "082764cd-901e-462d-a70f-b0e05a3a5325", new DateTime(2023, 11, 27, 0, 21, 24, 339, DateTimeKind.Local).AddTicks(5240), false, "johnsmith187@aoll.com" },
                    { "99799e80-9fe2-4e2d-b99c-c79aaac69bed", 0, 55, null, "fd582690-1528-4189-bcad-0aebcf0f37ce", new DateTime(2023, 11, 27, 0, 21, 24, 487, DateTimeKind.Local).AddTicks(9170), new DateTime(2002, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "jtanner@mustang.net", false, "White", "Jeremy", 3.16m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Tanner", false, null, "JTANNER@MUSTANG.NET", "JTANNER@MUSTANG.NET", "AQAAAAIAAYagAAAAELK7hs+ofpnvpd4ld+gYresPrZ/1rTGlP9RMsPNJnlb2N6Kgv9e0EVOPZyZujLURkw==", null, false, "I", "d072a9f3-422a-4170-90ef-11fca0f99d7b", new DateTime(2023, 11, 27, 0, 21, 24, 487, DateTimeKind.Local).AddTicks(9170), false, "jtanner@mustang.net" },
                    { "a1b368b4-acc6-4e40-b7b6-3d54ac9e1780", 0, 21, null, "95a6bf60-d502-4359-84c3-b3e1ce22e0af", new DateTime(2023, 11, 27, 0, 21, 23, 228, DateTimeKind.Local).AddTicks(6530), new DateTime(2003, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "feeley@penguin.org", false, "White", "Lou Ann", 3.66m, "F", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Feeley", false, null, "FEELEY@PENGUIN.ORG", "FEELEY@PENGUIN.ORG", "AQAAAAIAAYagAAAAEL+RxOWSfvwC5j9FPcs/1SGdZ90bhS353zDZXL4BKpy9A33BWKbfmxqVW1KvNWV6nA==", null, false, "I", "f25424e3-baa8-4152-9780-d1af55d31886", new DateTime(2023, 11, 27, 0, 21, 23, 228, DateTimeKind.Local).AddTicks(6540), false, "feeley@penguin.org" },
                    { "a70a31f3-b64e-4b33-b861-44bea56b4193", 0, 38, null, "71b5adf3-c244-4459-b75f-51c090135c46", new DateTime(2023, 11, 27, 0, 21, 23, 857, DateTimeKind.Local).AddTicks(8520), new DateTime(2001, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "cmiller@bob.com", false, "TwoOrMoreRaces", "Charles", 3.14m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Miller", false, null, "CMILLER@BOB.COM", "CMILLER@BOB.COM", "AQAAAAIAAYagAAAAEN5iuEc0vyNpfFfhyZnm25Q0U6DpxHI98TT69FknlQ66X4p7Env36YALBrGv7cLFYg==", null, false, "I", "ff203743-5f02-42c4-a1e4-458efc978101", new DateTime(2023, 11, 27, 0, 21, 23, 857, DateTimeKind.Local).AddTicks(8520), false, "cmiller@bob.com" },
                    { "b5a65590-2734-426d-9edb-1ac9e9b94171", 0, 44, null, "0c4d5e71-8daa-4cec-8130-84118baf5633", new DateTime(2023, 11, 27, 0, 21, 24, 80, DateTimeKind.Local).AddTicks(500), new DateTime(2004, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "erynrice@aoll.com", false, "Asian", "Eryn", 3.92m, "F", new DateTime(2026, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Rice", false, null, "ERYNRICE@AOLL.COM", "ERYNRICE@AOLL.COM", "AQAAAAIAAYagAAAAEBAD6K98bzYCSgnVGp4+64+UZPVvBc9d0WHixpBvasyFoNobVxfw0IXP9IStACZpjQ==", null, false, "I", "45159cf2-7f83-414b-86bc-7c520a24cf46", new DateTime(2023, 11, 27, 0, 21, 24, 80, DateTimeKind.Local).AddTicks(500), false, "erynrice@aoll.com" },
                    { "bac69e34-296e-45e0-9e10-eba91b1b49f7", 0, 63, null, "89b44667-bc00-4d3b-bb38-105b2d4d355b", new DateTime(2023, 11, 27, 0, 21, 24, 784, DateTimeKind.Local).AddTicks(8840), new DateTime(2001, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "winner@hootmail.com", false, "TwoOrMoreRaces", "Louis", 2.57m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Winthorpe", false, null, "WINNER@HOOTMAIL.COM", "WINNER@HOOTMAIL.COM", "AQAAAAIAAYagAAAAEGY4qrSlLa7sty/pX/r3zNV4MS1bg8EzU80eo7N4mPI6Nob8z5e9whSsZZMWlb8BIg==", null, false, "FT", "81def8a1-0c63-4fae-a20e-65fb5802e56d", new DateTime(2023, 11, 27, 0, 21, 24, 784, DateTimeKind.Local).AddTicks(8840), false, "winner@hootmail.com" },
                    { "c92f1863-e2db-4fbd-b387-658543d28fcc", 0, 28, null, "342949de-a5bf-4545-aa82-99889e106d4c", new DateTime(2023, 11, 27, 0, 21, 23, 487, DateTimeKind.Local).AddTicks(8160), new DateTime(2001, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "ingram@jack.com", false, "BlackOrAfricanAmerican", "Brad", 3.72m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Ingram", false, null, "INGRAM@JACK.COM", "INGRAM@JACK.COM", "AQAAAAIAAYagAAAAEH8jQ8ZrFnZCtrOQkATOTEKLT1DZtWQmXr+slmQq9SvHbOLJlfrsYjlkIivzX7i7ig==", null, false, "I", "64693ad9-eec8-4dfc-8e06-c9526927b19e", new DateTime(2023, 11, 27, 0, 21, 23, 487, DateTimeKind.Local).AddTicks(8160), false, "ingram@jack.com" },
                    { "d255dfee-7295-4703-b928-ef90252eff3f", 0, 17, null, "c1b4911e-cde2-49b3-9c61-c4317761493a", new DateTime(2023, 11, 27, 0, 21, 23, 80, DateTimeKind.Local).AddTicks(4990), new DateTime(2001, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "wchang@example.com", false, "Asian", "Wendy", 3.56m, "F", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Chang", false, null, "WCHANG@EXAMPLE.COM", "WCHANG@EXAMPLE.COM", "AQAAAAIAAYagAAAAEITvRYRxt5aMVPRcDCa998IgSJCGw5LN9gfOd5tEyYg7gNWJk7XKvfPnyrU8bCleQg==", null, false, "I", "5651ed81-c1fc-46b6-a3e1-77f29fd30b69", new DateTime(2023, 11, 27, 0, 21, 23, 80, DateTimeKind.Local).AddTicks(4990), false, "wchang@example.com" },
                    { "d2836b28-45d2-4b6f-92b5-c8cfb11398ac", 0, 31, null, "ac87a523-985f-458c-97aa-e7cc9be9469c", new DateTime(2023, 11, 27, 0, 21, 23, 598, DateTimeKind.Local).AddTicks(8340), new DateTime(2004, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "linebacker@gogle.com", false, "Hispanic", "Erik", 3.15m, "M", new DateTime(2026, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Lineback", false, null, "LINEBACKER@GOGLE.COM", "LINEBACKER@GOGLE.COM", "AQAAAAIAAYagAAAAEEmtsGkKlyqlclFOM3wUtRe6saD8Fdp2RXqpHWslZ2Yn/yvPNDZ4IJAH07z7UfJFVw==", null, false, "I", "47f66d2b-ae58-4756-8b49-654fa0368e68", new DateTime(2023, 11, 27, 0, 21, 23, 598, DateTimeKind.Local).AddTicks(8340), false, "linebacker@gogle.com" },
                    { "d2ba8aed-668a-483d-a946-3538faf14f68", 0, 40, null, "39a11021-8dc9-4ee0-8098-aab195837ec0", new DateTime(2023, 11, 27, 0, 21, 23, 931, DateTimeKind.Local).AddTicks(9850), new DateTime(2000, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "joewin@xfactor.com", false, "Asian", "Joe", 3.65m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Nguyen", false, null, "JOEWIN@XFACTOR.COM", "JOEWIN@XFACTOR.COM", "AQAAAAIAAYagAAAAENp74risTvABOg7JPF9bKDfeM/7VgmoJAUFM729yIkrH0ziTwBFY44hV7MXFwQb1Mg==", null, false, "FT", "74ff380c-1ea4-4d06-8c49-42824412827d", new DateTime(2023, 11, 27, 0, 21, 23, 931, DateTimeKind.Local).AddTicks(9850), false, "joewin@xfactor.com" },
                    { "d81960be-0b0f-489f-b820-08ee7d70309f", 0, 62, null, "680d7c1b-6c48-4eb3-9b3b-fbf1e029455b", new DateTime(2023, 11, 27, 0, 21, 24, 747, DateTimeKind.Local).AddTicks(5780), new DateTime(2002, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "westj@pioneer.net", false, "NativeHawaiianandOtherPacificIslander", "Jake", 3.66m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "West", false, null, "WESTJ@PIONEER.NET", "WESTJ@PIONEER.NET", "AQAAAAIAAYagAAAAEEQEKLuqOmE4yb/1fpQ7c/mjm1RgJOKc1XKUIvjaDa+KdmbMGQ8ErxpEojh5H4nb4w==", null, false, "FT", "ecfd9742-9d56-487f-8740-1a0814c11c3b", new DateTime(2023, 11, 27, 0, 21, 24, 747, DateTimeKind.Local).AddTicks(5780), false, "westj@pioneer.net" },
                    { "d9817e52-014d-4707-b8ce-8c93870f6551", 0, 49, null, "56387a63-130e-427d-8513-d462793518b1", new DateTime(2023, 11, 27, 0, 21, 24, 265, DateTimeKind.Local).AddTicks(4450), new DateTime(2002, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "willsheff@email.com", false, "Hispanic", "William", 3.07m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Sewell", false, null, "WILLSHEFF@EMAIL.COM", "WILLSHEFF@EMAIL.COM", "AQAAAAIAAYagAAAAELN4/399KmX/xtESK5SCtk8IPSNWKuCLhTZxOBFoJlCJV8OJ/zLBxqTqlRf0Ze312g==", null, false, "FT", "2103f86b-0bb1-4ce8-9313-bc6bbd21c73c", new DateTime(2023, 11, 27, 0, 21, 24, 265, DateTimeKind.Local).AddTicks(4450), false, "willsheff@email.com" },
                    { "eafb614c-3610-41d5-b752-64b41f3ff423", 0, 27, null, "bc8241df-eff3-489a-a350-4c254a0cca0d", new DateTime(2023, 11, 27, 0, 21, 23, 450, DateTimeKind.Local).AddTicks(7350), new DateTime(2003, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahick@yaho.com", false, "TwoOrMoreRaces", "Anthony", 3.12m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Hicks", false, null, "AHICK@YAHO.COM", "AHICK@YAHO.COM", "AQAAAAIAAYagAAAAEK4TiHQ+5WN2vv4KQLvj5Lr+102ghTVVZy+WTYqykKVSOzlKFNa7paVKX/Cg7y7wyA==", null, false, "I", "2d65a076-2a4c-4c06-b7b1-d630c4b4ddde", new DateTime(2023, 11, 27, 0, 21, 23, 450, DateTimeKind.Local).AddTicks(7350), false, "ahick@yaho.com" },
                    { "f6d850ca-d51c-4d34-9c00-5bb5e7a75f05", 0, 41, null, "db4cc993-f109-4782-8e73-57b17ed28c65", new DateTime(2023, 11, 27, 0, 21, 23, 968, DateTimeKind.Local).AddTicks(9880), new DateTime(2001, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "orielly@foxnews.cnn", false, "White", "Bill", 3.46m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "O'Reilly", false, null, "ORIELLY@FOXNEWS.CNN", "ORIELLY@FOXNEWS.CNN", "AQAAAAIAAYagAAAAENL3mbP4R32pHeUTHQsg4srHy61LOEIxXLrgskaxIp+gL23ucpG3GYicggtBkOU3XQ==", null, false, "I", "fe3ba174-037d-42b0-beeb-c8dcf5305906", new DateTime(2023, 11, 27, 0, 21, 23, 968, DateTimeKind.Local).AddTicks(9880), false, "orielly@foxnews.cnn" },
                    { "f7a2b515-0702-4050-9292-40455946bc05", 0, 34, null, "4049f0e6-ee73-432e-883e-d1637befd48e", new DateTime(2023, 11, 27, 0, 21, 23, 709, DateTimeKind.Local).AddTicks(6610), new DateTime(2000, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "mackcloud@george.com", false, "White", "Jennifer", 4.00m, "Other", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "MacLeod", false, null, "MACKCLOUD@GEORGE.COM", "MACKCLOUD@GEORGE.COM", "AQAAAAIAAYagAAAAEIYbEelo8deP4I1v7DzL7SGTU+RC1GfR3affiwLgPcB4UqG4Rpx/Xw1TDp4g1o3+rA==", null, false, "FT", "ee3a13f8-3120-4e5d-a2cb-80da02f8e04d", new DateTime(2023, 11, 27, 0, 21, 23, 709, DateTimeKind.Local).AddTicks(6610), false, "mackcloud@george.com" },
                    { "fbc5df98-0f54-44e0-8a39-936bfb2dfdb5", 0, 48, null, "d360fc60-61c8-46d5-9006-5fed7defe826", new DateTime(2023, 11, 27, 0, 21, 24, 228, DateTimeKind.Local).AddTicks(3880), new DateTime(2002, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "saunders@pen.com", false, "White", "Sarah", 3.16m, "F", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Saunders", false, null, "SAUNDERS@PEN.COM", "SAUNDERS@PEN.COM", "AQAAAAIAAYagAAAAEP1IOUDGVlkbmV0ZTM5hBMuczOB8skMlgRLK50xUq07nJ+8Dr4RMabZh7rgd5RPXJw==", null, false, "I", "1c7ebc9f-83db-4e65-bd2c-aeb777c9167b", new DateTime(2023, 11, 27, 0, 21, 24, 228, DateTimeKind.Local).AddTicks(3880), false, "saunders@pen.com" },
                    { "fece1b79-dc85-4769-b814-1980f0dd5ee6", 0, 46, null, "133725c2-4675-4827-b67a-31d7742546b5", new DateTime(2023, 11, 27, 0, 21, 24, 154, DateTimeKind.Local).AddTicks(1210), new DateTime(2001, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "mrrogers@lovelyday.com", false, "BlackOrAfricanAmerican", "Allen", 3.01m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Rogers", false, null, "MRROGERS@LOVELYDAY.COM", "MRROGERS@LOVELYDAY.COM", "AQAAAAIAAYagAAAAEDUguinjmtW8RgWbZB0iyWJ1R+ewh4lGsl3onqDE3vwxh3wUr9mnhlnKy2Xv4ZzzBQ==", null, false, "I", "8be68fdd-ff5d-40c5-95f9-269883780920", new DateTime(2023, 11, 27, 0, 21, 24, 154, DateTimeKind.Local).AddTicks(1210), false, "mrrogers@lovelyday.com" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "AddressId", "CompanyDescription", "CompanyEmail", "CompanyName", "WebsiteUrl", "isActive" },
                values: new object[,]
                {
                    { 1, 1, "Accenture is a global management consulting, technology services and outsourcing company.", "accenture@example.com", "Accenture", "https://www.accenture.com/", true },
                    { 2, 2, "Shell Oil Company, including its consolidated companies and its share in equity companies, is one of America's leading oild and natural gas producers, natural gas marketers, gasoline marketers and petrochemical manufacturers.", "shell@example.com", "Shell", "https://www.shell.com/", true },
                    { 3, 3, "Deloitte is one of the leading professional services organizations in the United States specializing in audit, tax, consulting, and financial advisory services with clients in more than 20 industries.", "deloitte@example.com", "Deloitte", "https://www.deloitte.com/", true },
                    { 4, 4, "Capital One offers a broad spectrum of financial products and services to consumers, small businesses and commercial clients.", "capitalone@example.com", "Capital One", "https://www.capitalone.com/", true },
                    { 5, 5, "TI is one of the world’s largest global leaders in analog and digital semiconductor design and manufacturing", "texasinstruments@example.com", "Texas Instruments", "https://www.ti.com/", true },
                    { 6, 6, "Hilton Worldwide offers business and leisure travelers the finest in accommodations, service, amenities and value.", "hiltonworldwide@example.com", "Hilton Worldwide", "https://www.hilton.com/", true },
                    { 7, 7, "Aon is the leading global provider of risk management, insurance and reinsurance brokerage, and human resources solutions and outsourcing services.", "aon@example.com", "Aon", "https://www.aon.com/home/index", true },
                    { 8, 8, "Adlucent is a technology and analytics company specializing in selling products through the Internet for online retail clients.", "adlucent@example.com", "Adlucent", "https://www.adlucent.com/", true },
                    { 9, 9, "Stream Realty Partners, L.P. (Stream) is a national, commercial real estate firm with locations across the country.", "streamrealtypartners@example.com", "Stream Realty Partners", "https://streamrealty.com/", true },
                    { 10, 10, "Microsoft is the worldwide leader in software, services and solutions that help people and businesses realize their full potential.", "microsoft@example.com", "Microsoft", "https://www.microsoft.com/", true },
                    { 11, 11, "Academy Sports is intensely focused on being a leader in the sporting goods, outdoor and lifestyle retail arena", "academysports@example.com", "Academy Sports & Outdoors", "https://www.academy.com/", true },
                    { 12, 12, "United Airlines has the most modern and fuel-efficient fleet (when adjusted for cabin size), and the best new aircraft order book, among U.S. network carriers", "unitedairlines@example.com", "United Airlines", "https://www.united.com/", true },
                    { 13, 13, "Target is a leading retailer", "target@example.com", "Target", "https://www.target.com/", true }
                });

            migrationBuilder.InsertData(
                table: "AppUserMajors",
                columns: new[] { "AppUserId", "MajorId", "isActive" },
                values: new object[,]
                {
                    { "01ea3680-b776-449d-9aea-7499148f95ed", 1, true },
                    { "03572f20-ba44-4812-ad14-3c41b3013b27", 2, true },
                    { "0b1f00e0-c3dc-49af-a337-a77a54ffef78", 3, true },
                    { "0dd23141-9ae1-41de-b0ee-4416b7d6c4b8", 8, true },
                    { "0ea609e1-188e-4c4d-b21e-4571c423e49d", 1, true },
                    { "13cf98cd-e1f6-4bd3-9ad1-4a2ad7f9fcde", 1, true },
                    { "1a8190d7-2105-40d0-95e7-33af8313fbe7", 2, true },
                    { "220a343b-0d56-43ec-9951-ce983fc6c597", 7, true },
                    { "256f5ba9-1352-4558-acfc-33c67dbec1fd", 3, true },
                    { "265bfd9f-b3ea-4ef4-a6dc-7c52933e7089", 6, true },
                    { "28d260bd-b558-469b-8a47-d23479056931", 2, true },
                    { "2a5122b4-c491-4274-b03c-38daba6cb1da", 8, true },
                    { "2f40042e-6742-4e26-a789-dfd40c2de6fe", 2, true },
                    { "328cad67-0c01-416f-9ec4-9d980e848e8a", 8, true },
                    { "346f26e0-7a5b-47b4-a810-6a1f3b4c6f7d", 2, true },
                    { "37dd03ab-ef9a-4445-90af-3f9c0e020954", 8, true },
                    { "39f638c4-d6a0-4fa3-a029-7603abf6f016", 8, true },
                    { "3d72a769-4341-4451-9277-fec699b48abd", 8, true },
                    { "3d8da166-342d-41b6-b19a-20c0b0c94355", 8, true },
                    { "3d96a487-37d1-409d-922a-43bbf0714eb7", 5, true },
                    { "48364611-796f-4747-9f4c-239563562ec9", 8, true },
                    { "4a9f84c2-3f33-46ba-8dc0-1f686aaa26fd", 3, true },
                    { "5153f91e-7597-47ad-a924-bc032e064710", 4, true },
                    { "52972799-56b0-4b6b-91a7-ec844b1dd404", 3, true },
                    { "5550d8e4-bec0-401d-ac05-f4dab2cd7960", 4, true },
                    { "57cc3f93-1767-43b0-a60e-4ab753ac515e", 8, true },
                    { "5fb43981-827c-4a20-9a78-9bfa640aefdb", 9, true },
                    { "644e9749-c8c0-41b7-b1ad-d9d747f4209e", 8, true },
                    { "687382b3-a0e7-4239-b6d7-a1991f1ef1c8", 9, true },
                    { "6d74195d-e27b-499b-b14c-77587f008c08", 2, true },
                    { "6df8c34a-e08b-4093-88c7-710097c6b5f1", 6, true },
                    { "7149bce1-bbba-4674-bfc4-23c3efc069d0", 7, true },
                    { "7e97875d-df90-4a44-94c4-76034b0a430a", 1, true },
                    { "90834150-7602-428c-a87d-1be247d2facd", 3, true },
                    { "9358a237-ed59-4a94-a727-a667e138046d", 3, true },
                    { "99799e80-9fe2-4e2d-b99c-c79aaac69bed", 5, true },
                    { "a1b368b4-acc6-4e40-b7b6-3d54ac9e1780", 6, true },
                    { "a70a31f3-b64e-4b33-b861-44bea56b4193", 5, true },
                    { "b5a65590-2734-426d-9edb-1ac9e9b94171", 6, true },
                    { "bac69e34-296e-45e0-9e10-eba91b1b49f7", 3, true },
                    { "c92f1863-e2db-4fbd-b387-658543d28fcc", 7, true },
                    { "d255dfee-7295-4703-b928-ef90252eff3f", 3, true },
                    { "d2836b28-45d2-4b6f-92b5-c8cfb11398ac", 1, true },
                    { "d2ba8aed-668a-483d-a946-3538faf14f68", 5, true },
                    { "d81960be-0b0f-489f-b820-08ee7d70309f", 3, true },
                    { "d9817e52-014d-4707-b8ce-8c93870f6551", 8, true },
                    { "eafb614c-3610-41d5-b752-64b41f3ff423", 7, true },
                    { "f6d850ca-d51c-4d34-9c00-5bb5e7a75f05", 3, true },
                    { "f7a2b515-0702-4050-9292-40455946bc05", 8, true },
                    { "fbc5df98-0f54-44e0-8a39-936bfb2dfdb5", 7, true },
                    { "fece1b79-dc85-4769-b814-1980f0dd5ee6", 6, true }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "01ea3680-b776-449d-9aea-7499148f95ed" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "03572f20-ba44-4812-ad14-3c41b3013b27" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "0b1f00e0-c3dc-49af-a337-a77a54ffef78" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "0dd23141-9ae1-41de-b0ee-4416b7d6c4b8" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "0ea609e1-188e-4c4d-b21e-4571c423e49d" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "13cf98cd-e1f6-4bd3-9ad1-4a2ad7f9fcde" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "1a8190d7-2105-40d0-95e7-33af8313fbe7" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "220a343b-0d56-43ec-9951-ce983fc6c597" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "256f5ba9-1352-4558-acfc-33c67dbec1fd" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "265bfd9f-b3ea-4ef4-a6dc-7c52933e7089" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "28d260bd-b558-469b-8a47-d23479056931" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "2a5122b4-c491-4274-b03c-38daba6cb1da" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "2f40042e-6742-4e26-a789-dfd40c2de6fe" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "328cad67-0c01-416f-9ec4-9d980e848e8a" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "346f26e0-7a5b-47b4-a810-6a1f3b4c6f7d" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "37dd03ab-ef9a-4445-90af-3f9c0e020954" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "39f638c4-d6a0-4fa3-a029-7603abf6f016" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "3d72a769-4341-4451-9277-fec699b48abd" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "3d8da166-342d-41b6-b19a-20c0b0c94355" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "3d96a487-37d1-409d-922a-43bbf0714eb7" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "48364611-796f-4747-9f4c-239563562ec9" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "4a9f84c2-3f33-46ba-8dc0-1f686aaa26fd" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "5153f91e-7597-47ad-a924-bc032e064710" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "52972799-56b0-4b6b-91a7-ec844b1dd404" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "5550d8e4-bec0-401d-ac05-f4dab2cd7960" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "57cc3f93-1767-43b0-a60e-4ab753ac515e" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "5fb43981-827c-4a20-9a78-9bfa640aefdb" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "644e9749-c8c0-41b7-b1ad-d9d747f4209e" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "687382b3-a0e7-4239-b6d7-a1991f1ef1c8" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "6d74195d-e27b-499b-b14c-77587f008c08" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "6df8c34a-e08b-4093-88c7-710097c6b5f1" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "7149bce1-bbba-4674-bfc4-23c3efc069d0" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "7e97875d-df90-4a44-94c4-76034b0a430a" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "90834150-7602-428c-a87d-1be247d2facd" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "9358a237-ed59-4a94-a727-a667e138046d" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "99799e80-9fe2-4e2d-b99c-c79aaac69bed" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "a1b368b4-acc6-4e40-b7b6-3d54ac9e1780" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "a70a31f3-b64e-4b33-b861-44bea56b4193" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "b5a65590-2734-426d-9edb-1ac9e9b94171" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "bac69e34-296e-45e0-9e10-eba91b1b49f7" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "c92f1863-e2db-4fbd-b387-658543d28fcc" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "d255dfee-7295-4703-b928-ef90252eff3f" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "d2836b28-45d2-4b6f-92b5-c8cfb11398ac" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "d2ba8aed-668a-483d-a946-3538faf14f68" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "d81960be-0b0f-489f-b820-08ee7d70309f" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "d9817e52-014d-4707-b8ce-8c93870f6551" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "eafb614c-3610-41d5-b752-64b41f3ff423" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "f6d850ca-d51c-4d34-9c00-5bb5e7a75f05" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "f7a2b515-0702-4050-9292-40455946bc05" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "fbc5df98-0f54-44e0-8a39-936bfb2dfdb5" },
                    { "3edb8eb4-8829-4ac1-8aae-61b0208f7793", "fece1b79-dc85-4769-b814-1980f0dd5ee6" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "CompanyId", "ConcurrencyStamp", "DateCreated", "DateOfBirth", "Email", "EmailConfirmed", "Ethnicity", "FirstName", "GPA", "Gender", "GraduationDate", "IsActive", "LastLoginDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PositionType", "SecurityStamp", "SystemDate", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "052f63c6-1b53-49e0-bd38-02576d1c8de3", 0, null, 13, "8a63e18a-8525-431c-b5a2-1bbe9ad3f00d", new DateTime(2023, 11, 27, 0, 21, 22, 931, DateTimeKind.Local).AddTicks(3500), null, "target_spot@example.com", false, "Asian", "Spot", 0m, "F", null, true, null, "Dog", false, null, "TARGET_SPOT@EXAMPLE.COM", "TARGET_SPOT@EXAMPLE.COM", "AQAAAAIAAYagAAAAEEQ+bCP78RzAPyGdvToWfkojzCzQ4SAjOqn5OWT+JCONrr7fwZ9w4V9lg8R868yPZA==", null, false, "FT", "68dd8368-a7a4-40e8-8dd6-b219b4e1cdf5", new DateTime(2023, 11, 27, 0, 21, 22, 931, DateTimeKind.Local).AddTicks(3500), false, "target_spot@example.com" },
                    { "0b365700-8c77-49d1-9816-e99787e5e6fd", 0, null, 6, "a9b6515c-2627-43f9-a06d-0f1f6ded6627", new DateTime(2023, 11, 27, 0, 21, 22, 521, DateTimeKind.Local).AddTicks(8270), null, "yhuik9.Taylor@aool.com", false, "Asian", "Rachel", 0m, "F", null, true, null, "Taylor", false, null, "YHUIK9.TAYLOR@AOOL.COM", "YHUIK9.TAYLOR@AOOL.COM", "AQAAAAIAAYagAAAAEIl6QbR/dmTb2c76/oCPP74G3IGEUUGN6myYkO3aP442+/QD9szwEvs6L0490wiIUA==", null, false, "FT", "e69d89de-a29f-4994-bee6-1756daa3805d", new DateTime(2023, 11, 27, 0, 21, 22, 521, DateTimeKind.Local).AddTicks(8270), false, "yhuik9.Taylor@aool.com" },
                    { "33b27431-48dc-476d-9d08-66731a4810ac", 0, null, 2, "cb1384ee-0bde-4c3b-aa94-3f959fd22d41", new DateTime(2023, 11, 27, 0, 21, 22, 295, DateTimeKind.Local).AddTicks(9630), null, "elowe@netscrape.net", false, "Asian", "Ernest", 0m, "F", null, true, null, "Lowe", false, null, "ELOWE@NETSCRAPE.NET", "ELOWE@NETSCRAPE.NET", "AQAAAAIAAYagAAAAECa7043rwzqfiu3Ohmb8pZb5GenHG3PqdhdYFP5gQZpDfUrS2BYmGYAFAXAXkVOBIA==", null, false, "FT", "f1fc881e-aa14-4931-8090-5ce1737f3e57", new DateTime(2023, 11, 27, 0, 21, 22, 295, DateTimeKind.Local).AddTicks(9630), false, "elowe@netscrape.net" },
                    { "357bffbd-3907-44cf-86af-1369001075e3", 0, null, 3, "9c9e333a-0f1b-4074-ac47-ad8a410afc93", new DateTime(2023, 11, 27, 0, 21, 22, 333, DateTimeKind.Local).AddTicks(9040), null, "mclarence@aool.com", false, "Asian", "Clarence", 0m, "F", null, true, null, "Martin", false, null, "MCLARENCE@AOOL.COM", "MCLARENCE@AOOL.COM", "AQAAAAIAAYagAAAAENUHKAKnRXCuvhPXg6ABevJlZVmI1+AJLwvMXwYSWRk+jLWALiGMK1X09hiB90iWlw==", null, false, "FT", "54a52163-3b58-4d9a-8bd3-e7873c5ebb7b", new DateTime(2023, 11, 27, 0, 21, 22, 333, DateTimeKind.Local).AddTicks(9040), false, "mclarence@aool.com" },
                    { "3f145f9d-ee39-4dc5-9061-f4a98b864572", 0, null, 9, "963fccec-fa9e-4f68-9473-6c2ada335441", new DateTime(2023, 11, 27, 0, 21, 22, 632, DateTimeKind.Local).AddTicks(9680), null, "jojoe@ggmail.com", false, "Asian", "Joe", 0m, "F", null, true, null, "Nguyen", false, null, "JOJOE@GGMAIL.COM", "JOJOE@GGMAIL.COM", "AQAAAAIAAYagAAAAEEBiimSXabJ71bDXBXiuNTcmc00Sqf50FgIKXI+iYKzUjRYb4gBQ6pHapFdA1POoYg==", null, false, "FT", "7bab3e4d-d3e2-45e1-838f-8b0e6e17a11f", new DateTime(2023, 11, 27, 0, 21, 22, 632, DateTimeKind.Local).AddTicks(9700), false, "jojoe@ggmail.com" },
                    { "43bae340-93ba-4fe0-8b00-a8070a3b1be8", 0, null, 10, "fbee70a5-cc76-4a02-961e-c63e59b8a027", new DateTime(2023, 11, 27, 0, 21, 22, 745, DateTimeKind.Local).AddTicks(810), null, "louielouie@aool.com", false, "Asian", "Louis", 0m, "F", null, true, null, "Winthorpe", false, null, "LOUIELOUIE@AOOL.COM", "LOUIELOUIE@AOOL.COM", "AQAAAAIAAYagAAAAEJ0ArlRNuacu1W5smG9zUjP2Wsw3JuESHvw69uZN5isylleuvj9rd7SMCYTgPqOLSQ==", null, false, "FT", "346bea07-392d-425f-8f45-8f3647d7cc7d", new DateTime(2023, 11, 27, 0, 21, 22, 745, DateTimeKind.Local).AddTicks(820), false, "louielouie@aool.com" },
                    { "443c25e8-d6a7-48f6-837d-ed27c5641b25", 0, null, 7, "3da39ec2-6d84-456c-b7ab-d32b080c2992", new DateTime(2023, 11, 27, 0, 21, 22, 558, DateTimeKind.Local).AddTicks(7370), null, "tuck33@ggmail.com", false, "Asian", "Clent", 0m, "F", null, true, null, "Tucker", false, null, "TUCK33@GGMAIL.COM", "TUCK33@GGMAIL.COM", "AQAAAAIAAYagAAAAEGDzK388VBFToKziNzl9yh0EZji6QsOLRddzJ/d3Pv1zrB1RmBUb2zN7mFv86+Gv7Q==", null, false, "FT", "d5e9aa85-0c8e-46e0-be61-cd2b377c0ead", new DateTime(2023, 11, 27, 0, 21, 22, 558, DateTimeKind.Local).AddTicks(7370), false, "tuck33@ggmail.com" },
                    { "58d95d27-2ddd-4973-8c52-52e214e0298a", 0, null, 1, "eb3a57a0-d9dc-4e48-bd9f-7b4ba6b8b255", new DateTime(2023, 11, 27, 0, 21, 22, 258, DateTimeKind.Local).AddTicks(200), null, "toddy@aool.com", false, "Asian", "Todd", 0m, "F", null, true, null, "Jacobs", false, null, "TODDY@AOOL.COM", "TODDY@AOOL.COM", "AQAAAAIAAYagAAAAEI3a1cagZAIRwMH1s5WssJ0fHGPZBm5WZnBKC2VSXUVfNvl9ei9QQddrJnG1rxzxog==", null, false, "FT", "5a9a19ef-d6c5-4807-b585-27ece002b53f", new DateTime(2023, 11, 27, 0, 21, 22, 258, DateTimeKind.Local).AddTicks(220), false, "toddy@aool.com" },
                    { "84b54bd1-a3d0-4931-8ee2-9bee447d4d38", 0, null, 4, "1e52aa74-ead1-49a8-a83d-6fbd49881e44", new DateTime(2023, 11, 27, 0, 21, 22, 819, DateTimeKind.Local).AddTicks(6540), null, "or@aool.com", false, "Asian", "Anka", 0m, "F", null, true, null, "Radkovich", false, null, "OR@AOOL.COM", "OR@AOOL.COM", "AQAAAAIAAYagAAAAEJL/gh6FrNbkELwAbkLh/phPAVDvrzA1H1XSd2E2rNgkv0yfqFsmfKyOX/P3A+RRLg==", null, false, "FT", "f33d82b8-0d94-4404-891f-ad47d142b420", new DateTime(2023, 11, 27, 0, 21, 22, 819, DateTimeKind.Local).AddTicks(6540), false, "or@aool.com" },
                    { "945b9c87-0e9a-4fbb-9837-5012f8209a96", 0, null, 5, "a8073c0f-1dd1-48fb-a599-74c2bac03cbd", new DateTime(2023, 11, 27, 0, 21, 22, 447, DateTimeKind.Local).AddTicks(3160), null, "sheff44@ggmail.com", false, "Asian", "Martin", 0m, "F", null, true, null, "Sheffield", false, null, "SHEFF44@GGMAIL.COM", "SHEFF44@GGMAIL.COM", "AQAAAAIAAYagAAAAEJqUAmzJsrdlefNkBNSotqi3nofA19mCEsArjdVTkoy+iWjXHTVIxEcrcHLg1qBwLg==", null, false, "FT", "df630975-fe35-4444-9d3e-c1c090852276", new DateTime(2023, 11, 27, 0, 21, 22, 447, DateTimeKind.Local).AddTicks(3170), false, "sheff44@ggmail.com" },
                    { "b0460782-6f74-4d5c-aa9d-269a093692a4", 0, null, 3, "d1bd558d-82df-405a-9d6b-bf21e5e20520", new DateTime(2023, 11, 27, 0, 21, 22, 409, DateTimeKind.Local).AddTicks(3710), null, "megrhodes@freezing.co.uk", false, "Asian", "Megan", 0m, "F", null, true, null, "Rhodes", false, null, "MEGRHODES@FREEZING.CO.UK", "MEGRHODES@FREEZING.CO.UK", "AQAAAAIAAYagAAAAEI1hv/yTnHg3WtAqFnAsoj2+NcNc3mHJO/YeRJaHKx2orXea63JfzGOzCDuE/Ivmeg==", null, false, "FT", "2870ffd0-6b8e-440a-9351-512fd5bd63ed", new DateTime(2023, 11, 27, 0, 21, 22, 409, DateTimeKind.Local).AddTicks(3710), false, "megrhodes@freezing.co.uk" },
                    { "b83a2cc2-8853-4fa3-8d87-bbd570632a58", 0, null, 5, "8a7b3abd-2bc8-47e8-93f7-43a755b5429e", new DateTime(2023, 11, 27, 0, 21, 22, 484, DateTimeKind.Local).AddTicks(7590), null, "peterstump@hootmail.com", false, "Asian", "Peter", 0m, "F", null, true, null, "Stump", false, null, "PETERSTUMP@HOOTMAIL.COM", "PETERSTUMP@HOOTMAIL.COM", "AQAAAAIAAYagAAAAELXuz9uE8+zMt2QBxJ7Sv3MjPdQ/VOpNQOlN/jGVLO/AQpnhefnGJYh3efKcTv1rCQ==", null, false, "FT", "7e2d6e11-4d0a-426a-b955-96d1ca506313", new DateTime(2023, 11, 27, 0, 21, 22, 484, DateTimeKind.Local).AddTicks(7590), false, "peterstump@hootmail.com" },
                    { "bbe55bf7-da3e-4500-a9eb-3c0fc6c06d17", 0, null, 12, "4a241b64-e880-4247-9a1a-fbc2c6fabd5e", new DateTime(2023, 11, 27, 0, 21, 22, 856, DateTimeKind.Local).AddTicks(8330), null, "tanner@ggmail.com", false, "Asian", "Jeremy", 0m, "F", null, true, null, "Tanner", false, null, "TANNER@GGMAIL.COM", "TANNER@GGMAIL.COM", "AQAAAAIAAYagAAAAEEZUhb4kyM4FO6II7ojnWy2FvrGDqlhleLTjmgtQ59W4DLPewgcTBIyKHNC2NWt9rw==", null, false, "FT", "32f31237-c08e-49ea-b895-954589b5b66a", new DateTime(2023, 11, 27, 0, 21, 22, 856, DateTimeKind.Local).AddTicks(8330), false, "tanner@ggmail.com" },
                    { "c618f7db-8af7-4dab-8752-7d6235ea8936", 0, null, 11, "a1e652c4-3b79-4c18-bcac-cd44edcc32e6", new DateTime(2023, 11, 27, 0, 21, 22, 894, DateTimeKind.Local).AddTicks(610), null, "tee_frank@hootmail.com", false, "Asian", "Frank", 0m, "F", null, true, null, "Tee", false, null, "TEE_FRANK@HOOTMAIL.COM", "TEE_FRANK@HOOTMAIL.COM", "AQAAAAIAAYagAAAAEJZ8OxL9QGXePktAHTXQn6MGdu6oQhtMqlpdaBNsk/KQRQW6JR1miuU86Hcj7MCmPw==", null, false, "FT", "cc2e49a6-e23b-447c-aa02-bfc158a73ed9", new DateTime(2023, 11, 27, 0, 21, 22, 894, DateTimeKind.Local).AddTicks(610), false, "tee_frank@hootmail.com" },
                    { "c678143a-1885-4212-8b3d-6cce6eeccb39", 0, null, 4, "3a39c1b0-17da-42d0-afeb-c381a2390d0d", new DateTime(2023, 11, 27, 0, 21, 22, 782, DateTimeKind.Local).AddTicks(3740), null, "smartinmartin.Martin@aool.com", false, "Asian", "Gregory", 0m, "F", null, true, null, "Martinez", false, null, "SMARTINMARTIN.MARTIN@AOOL.COM", "SMARTINMARTIN.MARTIN@AOOL.COM", "AQAAAAIAAYagAAAAEHkXRYcLSdHDOyPkgei4Q/MwxUM3GlE1Ukqh2s4JWbXa7lMgxL1tiegJVBTX339Fow==", null, false, "FT", "0771b692-c0d0-4469-b4f1-029ff63a014a", new DateTime(2023, 11, 27, 0, 21, 22, 782, DateTimeKind.Local).AddTicks(3750), false, "smartinmartin.Martin@aool.com" },
                    { "ca354f47-0923-4c27-aff2-b4edddbfb473", 0, null, 3, "caf48231-a05b-4cd2-b7cf-ea6862788d78", new DateTime(2023, 11, 27, 0, 21, 22, 371, DateTimeKind.Local).AddTicks(5440), null, "nelson.Kelly@aool.com", false, "Asian", "Kelly", 0m, "F", null, true, null, "Nelson", false, null, "NELSON.KELLY@AOOL.COM", "NELSON.KELLY@AOOL.COM", "AQAAAAIAAYagAAAAEBx/+yVf3ELpRI57esrbUuvVDghelma6Jm5xPta7f5eDxt9mMZwzOiOXD/2dvF76TA==", null, false, "FT", "8faf50b5-ff5e-4065-9166-16f90576edec", new DateTime(2023, 11, 27, 0, 21, 22, 371, DateTimeKind.Local).AddTicks(5440), false, "nelson.Kelly@aool.com" },
                    { "cddce97c-953f-4991-a8fd-09442e50ea74", 0, null, 1, "13aaf8b3-0a81-47ad-b6b8-eb5e99255cac", new DateTime(2023, 11, 27, 0, 21, 22, 219, DateTimeKind.Local).AddTicks(4940), null, "michelle@example.com", false, "Asian", "Michelle", 0m, "F", null, true, null, "Banks", false, null, "MICHELLE@EXAMPLE.COM", "MICHELLE@EXAMPLE.COM", "AQAAAAIAAYagAAAAEC0GNn0Au7OvtrA6ctuCmGnEsJd0zqo+J7D96k621+slsi4EBNpP2ti26/rW0jtUPA==", null, false, "FT", "3ca4a033-3186-4c40-acc1-f64a8e1c91e9", new DateTime(2023, 11, 27, 0, 21, 22, 219, DateTimeKind.Local).AddTicks(4960), false, "michelle@example.com" },
                    { "cfcbce30-2de4-4dc2-9b8e-c986642c75d3", 0, null, 10, "8d4fc8d6-4aa3-4cf3-b2df-b3b114e8c619", new DateTime(2023, 11, 27, 0, 21, 22, 707, DateTimeKind.Local).AddTicks(6830), null, "orielly@foxnets.com", false, "Asian", "Bill", 0m, "F", null, true, null, "O'Reilly", false, null, "ORIELLY@FOXNETS.COM", "ORIELLY@FOXNETS.COM", "AQAAAAIAAYagAAAAEOUsO8MJpHeIv+zlr6ueXCC5ogD6zkE9JH3vZ5XAnPzfL+pmfIBzDTRdNCo2tKHqwQ==", null, false, "FT", "2236a5f4-521c-414a-84ff-65da24e73f10", new DateTime(2023, 11, 27, 0, 21, 22, 707, DateTimeKind.Local).AddTicks(6830), false, "orielly@foxnets.com" },
                    { "e0fac436-4daa-4272-8b21-eb1d95b2d535", 0, null, 8, "6896ed0c-0125-4fcf-8162-5cb451b4a840", new DateTime(2023, 11, 27, 0, 21, 22, 595, DateTimeKind.Local).AddTicks(7250), null, "taylordjay@aool.com", false, "Asian", "Allison", 0m, "F", null, true, null, "Taylor", false, null, "TAYLORDJAY@AOOL.COM", "TAYLORDJAY@AOOL.COM", "AQAAAAIAAYagAAAAEEF/A7ubH/7i6AzCxUTTtizs/VkI5ee5IsIsqXddM0UvJ/iH/6hKvFwvTBDWgR8zGQ==", null, false, "FT", "932126bc-a85f-443c-9ea0-e02b49eb43de", new DateTime(2023, 11, 27, 0, 21, 22, 595, DateTimeKind.Local).AddTicks(7250), false, "taylordjay@aool.com" },
                    { "f5372cd7-6d7d-4934-85b7-30d423d6f06e", 0, null, 10, "5210d136-089d-4dff-96b1-7eb52a657a77", new DateTime(2023, 11, 27, 0, 21, 22, 670, DateTimeKind.Local).AddTicks(3130), null, "hicks43@ggmail.com", false, "Asian", "Anthony", 0m, "F", null, true, null, "Hicks", false, null, "HICKS43@GGMAIL.COM", "HICKS43@GGMAIL.COM", "AQAAAAIAAYagAAAAEAsHcpa/CJK0xEOVigjVkozhlNH2/1bByFKd46oYVsh+8f8s9hO7deH7KQP0dEmW0A==", null, false, "FT", "ef9ce1a5-4e23-4c6f-af49-58a84a19af8d", new DateTime(2023, 11, 27, 0, 21, 22, 670, DateTimeKind.Local).AddTicks(3130), false, "hicks43@ggmail.com" }
                });

            migrationBuilder.InsertData(
                table: "CompanyIndustries",
                columns: new[] { "CompanyId", "IndustryId", "isActive" },
                values: new object[,]
                {
                    { 1, 2, true },
                    { 1, 11, true },
                    { 2, 3, true },
                    { 2, 14, true },
                    { 3, 1, true },
                    { 3, 2, true },
                    { 3, 11, true },
                    { 4, 5, true },
                    { 5, 6, true },
                    { 6, 7, true },
                    { 7, 2, true },
                    { 7, 8, true },
                    { 8, 9, true },
                    { 8, 11, true },
                    { 9, 10, true },
                    { 10, 11, true },
                    { 11, 12, true },
                    { 12, 13, true },
                    { 13, 12, true }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionId", "AddressId", "CompanyId", "Deadline", "PositionDescription", "PositionName", "PositionType", "isActive" },
                values: new object[,]
                {
                    { 1, 65, 11, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Financial Planning Intern", "I", true },
                    { 2, 66, 11, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Digital Product Manager", "FT", true },
                    { 3, 67, 1, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full-time consultant position", "Consultant ", "FT", true },
                    { 4, 68, 1, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Digital Intern", "I", true },
                    { 5, 69, 8, new DateTime(2023, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Help our marketing team develop new advertising strategies for local Austin businesses", "Marketing Intern", "I", true },
                    { 6, 70, 7, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Sales Associate", "FT", true },
                    { 7, 71, 7, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Project Manager", "FT", true },
                    { 8, 72, 4, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Developing a great new website for customer portfolio management", "Web Development", "FT", true },
                    { 9, 72, 4, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Financial Analyst", "FT", true },
                    { 10, 73, 4, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Analyst Development Program", "I", true },
                    { 11, 3, 3, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Work in our audit group", "Accounting Intern", "I", true },
                    { 12, 74, 3, new DateTime(2023, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Account Manager", "FT", true },
                    { 13, 75, 6, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Help analyze our amenities and customer rewards programs", "Amenities Analytics Intern", "I", true },
                    { 14, 10, 10, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Junior Programmer", "I", true },
                    { 15, 10, 10, new DateTime(2023, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Corporate Recruiting Intern", "I", true },
                    { 16, 76, 10, new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Business Analyst", "FT", true },
                    { 17, 10, 10, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Product Marketing Intern", "I", true },
                    { 18, 10, 10, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Program Manager", "FT", true },
                    { 19, 10, 10, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Security Analyst", "FT", true },
                    { 20, 77, 2, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Supply Chain Internship", "I", true },
                    { 21, 77, 2, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Handle procurement and vendor accounts", "Procurements Associate", "FT", true },
                    { 22, 13, 13, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Programmer Analyst", "FT", true },
                    { 23, 13, 13, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Intern", "I", true },
                    { 24, 78, 5, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "IT Rotational Program", "FT", true },
                    { 25, 78, 5, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Sales Rotational Program", "FT", true },
                    { 26, 79, 5, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Accounting Rotational Program", "FT", true },
                    { 27, 80, 12, new DateTime(2023, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Pilot", "FT", true }
                });

            migrationBuilder.InsertData(
                table: "AppUserPositions",
                columns: new[] { "AppUserPositionId", "DateSubmitted", "InterviewId", "PositionId", "StatusType", "StudentId", "isActive" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(3710), null, 5, "Accepted", "a1b368b4-acc6-4e40-b7b6-3d54ac9e1780", true },
                    { 2, new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(3740), null, 5, "Accepted", "b5a65590-2734-426d-9edb-1ac9e9b94171", true },
                    { 3, new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(3760), null, 15, "Accepted", "a70a31f3-b64e-4b33-b861-44bea56b4193", true },
                    { 4, new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(3780), null, 12, "Accepted", "1a8190d7-2105-40d0-95e7-33af8313fbe7", true },
                    { 5, new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(3800), null, 8, "Accepted", "48364611-796f-4747-9f4c-239563562ec9", true },
                    { 6, new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(3810), null, 13, "Accepted", "b5a65590-2734-426d-9edb-1ac9e9b94171", true },
                    { 7, new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(3820), null, 13, "Accepted", "01ea3680-b776-449d-9aea-7499148f95ed", true },
                    { 8, new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(3830), null, 13, "Accepted", "0b1f00e0-c3dc-49af-a337-a77a54ffef78", true },
                    { 9, new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(3840), null, 20, "Accepted", "c92f1863-e2db-4fbd-b387-658543d28fcc", true },
                    { 10, new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(3860), null, 20, "Accepted", "fbc5df98-0f54-44e0-8a39-936bfb2dfdb5", true },
                    { 11, new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(3870), null, 9, "Accepted", "9358a237-ed59-4a94-a727-a667e138046d", true },
                    { 12, new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(3890), null, 11, "Accepted", "7e97875d-df90-4a44-94c4-76034b0a430a", true },
                    { 13, new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(3900), null, 3, "Accepted", "1a8190d7-2105-40d0-95e7-33af8313fbe7", true },
                    { 14, new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(3910), null, 3, "Accepted", "28d260bd-b558-469b-8a47-d23479056931", true },
                    { 15, new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(3920), null, 12, "Accepted", "0ea609e1-188e-4c4d-b21e-4571c423e49d", true },
                    { 16, new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(3930), null, 12, "Pending", "13cf98cd-e1f6-4bd3-9ad1-4a2ad7f9fcde", true },
                    { 17, new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(3950), null, 26, "Pending", "13cf98cd-e1f6-4bd3-9ad1-4a2ad7f9fcde", true },
                    { 18, new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(3970), null, 3, "Pending", "13cf98cd-e1f6-4bd3-9ad1-4a2ad7f9fcde", true }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "35f744f5-1211-434f-a4e2-16a1f9969f1c", "052f63c6-1b53-49e0-bd38-02576d1c8de3" },
                    { "35f744f5-1211-434f-a4e2-16a1f9969f1c", "0b365700-8c77-49d1-9816-e99787e5e6fd" },
                    { "35f744f5-1211-434f-a4e2-16a1f9969f1c", "33b27431-48dc-476d-9d08-66731a4810ac" },
                    { "35f744f5-1211-434f-a4e2-16a1f9969f1c", "357bffbd-3907-44cf-86af-1369001075e3" },
                    { "35f744f5-1211-434f-a4e2-16a1f9969f1c", "3f145f9d-ee39-4dc5-9061-f4a98b864572" },
                    { "35f744f5-1211-434f-a4e2-16a1f9969f1c", "43bae340-93ba-4fe0-8b00-a8070a3b1be8" },
                    { "35f744f5-1211-434f-a4e2-16a1f9969f1c", "443c25e8-d6a7-48f6-837d-ed27c5641b25" },
                    { "35f744f5-1211-434f-a4e2-16a1f9969f1c", "58d95d27-2ddd-4973-8c52-52e214e0298a" },
                    { "35f744f5-1211-434f-a4e2-16a1f9969f1c", "84b54bd1-a3d0-4931-8ee2-9bee447d4d38" },
                    { "35f744f5-1211-434f-a4e2-16a1f9969f1c", "945b9c87-0e9a-4fbb-9837-5012f8209a96" },
                    { "35f744f5-1211-434f-a4e2-16a1f9969f1c", "b0460782-6f74-4d5c-aa9d-269a093692a4" },
                    { "35f744f5-1211-434f-a4e2-16a1f9969f1c", "b83a2cc2-8853-4fa3-8d87-bbd570632a58" },
                    { "35f744f5-1211-434f-a4e2-16a1f9969f1c", "bbe55bf7-da3e-4500-a9eb-3c0fc6c06d17" },
                    { "35f744f5-1211-434f-a4e2-16a1f9969f1c", "c618f7db-8af7-4dab-8752-7d6235ea8936" },
                    { "35f744f5-1211-434f-a4e2-16a1f9969f1c", "c678143a-1885-4212-8b3d-6cce6eeccb39" },
                    { "35f744f5-1211-434f-a4e2-16a1f9969f1c", "ca354f47-0923-4c27-aff2-b4edddbfb473" },
                    { "35f744f5-1211-434f-a4e2-16a1f9969f1c", "cddce97c-953f-4991-a8fd-09442e50ea74" },
                    { "35f744f5-1211-434f-a4e2-16a1f9969f1c", "cfcbce30-2de4-4dc2-9b8e-c986642c75d3" },
                    { "35f744f5-1211-434f-a4e2-16a1f9969f1c", "e0fac436-4daa-4272-8b21-eb1d95b2d535" },
                    { "35f744f5-1211-434f-a4e2-16a1f9969f1c", "f5372cd7-6d7d-4934-85b7-30d423d6f06e" }
                });

            migrationBuilder.InsertData(
                table: "PositionMajors",
                columns: new[] { "MajorId", "PositionId", "isActive" },
                values: new object[,]
                {
                    { 1, 1, true },
                    { 2, 1, true },
                    { 3, 1, true },
                    { 2, 2, true },
                    { 5, 2, true },
                    { 6, 2, true },
                    { 8, 2, true },
                    { 1, 3, true },
                    { 2, 3, true },
                    { 8, 3, true },
                    { 6, 4, true },
                    { 8, 4, true },
                    { 6, 5, true },
                    { 1, 6, true },
                    { 3, 6, true },
                    { 6, 6, true },
                    { 1, 7, true },
                    { 2, 7, true },
                    { 3, 7, true },
                    { 4, 7, true },
                    { 6, 7, true },
                    { 7, 7, true },
                    { 8, 7, true },
                    { 8, 8, true },
                    { 3, 9, true },
                    { 2, 10, true },
                    { 3, 10, true },
                    { 8, 10, true },
                    { 1, 11, true },
                    { 1, 12, true },
                    { 2, 12, true },
                    { 2, 13, true },
                    { 3, 13, true },
                    { 6, 13, true },
                    { 8, 13, true },
                    { 8, 14, true },
                    { 5, 15, true },
                    { 8, 16, true },
                    { 6, 17, true },
                    { 8, 17, true },
                    { 6, 18, true },
                    { 8, 18, true },
                    { 8, 19, true },
                    { 7, 20, true },
                    { 7, 21, true },
                    { 8, 22, true },
                    { 1, 23, true },
                    { 2, 23, true },
                    { 3, 23, true },
                    { 4, 23, true },
                    { 5, 23, true },
                    { 6, 23, true },
                    { 7, 23, true },
                    { 8, 23, true },
                    { 9, 23, true },
                    { 8, 24, true },
                    { 1, 25, true },
                    { 3, 25, true },
                    { 5, 25, true },
                    { 6, 25, true },
                    { 1, 26, true },
                    { 1, 27, true },
                    { 2, 27, true },
                    { 3, 27, true },
                    { 4, 27, true },
                    { 6, 27, true },
                    { 7, 27, true },
                    { 8, 27, true }
                });

            migrationBuilder.InsertData(
                table: "Interviews",
                columns: new[] { "InterviewId", "AppUserPositionId", "CreatorId", "DateCreated", "InterviewDate", "RecruiterId", "Room", "isActive" },
                values: new object[,]
                {
                    { 1, 1, "e0fac436-4daa-4272-8b21-eb1d95b2d535", new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(4010), new DateTime(2023, 5, 13, 13, 0, 0, 0, DateTimeKind.Unspecified), "e0fac436-4daa-4272-8b21-eb1d95b2d535", "Two", true },
                    { 2, 2, "e0fac436-4daa-4272-8b21-eb1d95b2d535", new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(4050), new DateTime(2023, 5, 14, 13, 0, 0, 0, DateTimeKind.Unspecified), "e0fac436-4daa-4272-8b21-eb1d95b2d535", "Two", true },
                    { 3, 3, "43bae340-93ba-4fe0-8b00-a8070a3b1be8", new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(4060), new DateTime(2023, 5, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), "43bae340-93ba-4fe0-8b00-a8070a3b1be8", "Two", true },
                    { 4, 4, "357bffbd-3907-44cf-86af-1369001075e3", new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(4070), new DateTime(2023, 5, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "357bffbd-3907-44cf-86af-1369001075e3", "One", true },
                    { 5, 5, "c678143a-1885-4212-8b3d-6cce6eeccb39", new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(4080), new DateTime(2023, 5, 16, 14, 0, 0, 0, DateTimeKind.Unspecified), "c678143a-1885-4212-8b3d-6cce6eeccb39", "Two", true },
                    { 6, 6, "0b365700-8c77-49d1-9816-e99787e5e6fd", new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(4090), new DateTime(2023, 4, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "0b365700-8c77-49d1-9816-e99787e5e6fd", "One", true },
                    { 7, 7, "0b365700-8c77-49d1-9816-e99787e5e6fd", new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(4100), new DateTime(2023, 4, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "0b365700-8c77-49d1-9816-e99787e5e6fd", "One", true },
                    { 8, 8, "0b365700-8c77-49d1-9816-e99787e5e6fd", new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(4120), new DateTime(2023, 4, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), "0b365700-8c77-49d1-9816-e99787e5e6fd", "Four", true },
                    { 9, 9, "33b27431-48dc-476d-9d08-66731a4810ac", new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(4130), new DateTime(2023, 5, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "33b27431-48dc-476d-9d08-66731a4810ac", "One", true },
                    { 10, 10, "33b27431-48dc-476d-9d08-66731a4810ac", new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(4130), new DateTime(2023, 5, 10, 11, 0, 0, 0, DateTimeKind.Unspecified), "33b27431-48dc-476d-9d08-66731a4810ac", "One", true },
                    { 11, 11, "84b54bd1-a3d0-4931-8ee2-9bee447d4d38", new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(4140), new DateTime(2023, 5, 16, 15, 0, 0, 0, DateTimeKind.Unspecified), "84b54bd1-a3d0-4931-8ee2-9bee447d4d38", "Three", true },
                    { 12, 12, "ca354f47-0923-4c27-aff2-b4edddbfb473", new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(4150), new DateTime(2023, 5, 16, 11, 0, 0, 0, DateTimeKind.Unspecified), "ca354f47-0923-4c27-aff2-b4edddbfb473", "Four", true },
                    { 13, 13, "cddce97c-953f-4991-a8fd-09442e50ea74", new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(4160), new DateTime(2023, 6, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), "cddce97c-953f-4991-a8fd-09442e50ea74", "Three", true },
                    { 14, 14, "58d95d27-2ddd-4973-8c52-52e214e0298a", new DateTime(2023, 11, 27, 0, 21, 24, 859, DateTimeKind.Local).AddTicks(4170), new DateTime(2023, 6, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), "58d95d27-2ddd-4973-8c52-52e214e0298a", "Three", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserMajors_MajorId",
                table: "AppUserMajors",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserPositions_InterviewId",
                table: "AppUserPositions",
                column: "InterviewId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserPositions_PositionId",
                table: "AppUserPositions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserPositions_StudentId",
                table: "AppUserPositions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AddressId",
                table: "Companies",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyIndustries_IndustryId",
                table: "CompanyIndustries",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_AppUserPositionId",
                table: "Interviews",
                column: "AppUserPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_RecruiterId",
                table: "Interviews",
                column: "RecruiterId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionMajors_MajorId",
                table: "PositionMajors",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_AddressId",
                table: "Positions",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_CompanyId",
                table: "Positions",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserPositions_Interviews_InterviewId",
                table: "AppUserPositions",
                column: "InterviewId",
                principalTable: "Interviews",
                principalColumn: "InterviewId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserPositions_AspNetUsers_StudentId",
                table: "AppUserPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_AspNetUsers_RecruiterId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserPositions_Interviews_InterviewId",
                table: "AppUserPositions");

            migrationBuilder.DropTable(
                name: "AppUserMajors");

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
                name: "CompanyIndustries");

            migrationBuilder.DropTable(
                name: "PositionMajors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Industries");

            migrationBuilder.DropTable(
                name: "Majors");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Interviews");

            migrationBuilder.DropTable(
                name: "AppUserPositions");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
