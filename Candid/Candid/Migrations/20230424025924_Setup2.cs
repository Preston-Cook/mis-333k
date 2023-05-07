using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Candid.Migrations
{
    /// <inheritdoc />
    public partial class Setup2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", null, "Recruiter", "RECRUITER" },
                    { "d2e5e116-d5fd-45df-a531-aa661fec879c", null, "Admin", "ADMIN" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "CompanyId", "ConcurrencyStamp", "DateCreated", "DateOfBirth", "Email", "EmailConfirmed", "Ethnicity", "FirstName", "GPA", "Gender", "GraduationDate", "IsActive", "LastLoginDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PositionType", "SecurityStamp", "SystemDate", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "13f522a5-c59c-4c75-b767-6077ca503450", 0, null, null, "80d6f0bd-bab6-467a-b476-77e6444056a2", new DateTime(2023, 4, 23, 21, 59, 21, 989, DateTimeKind.Local).AddTicks(1200), null, "ra@aoo.com", false, "Asian", "Allen", 0m, "F", null, true, null, "Rogers", false, null, "RA@AOO.COM", "RA@AOO.COM", "AQAAAAIAAYagAAAAEBaQ2IoyNqqiFHslVUpoMGXvkHk/SdgljjbvncwOgzsfJf35y3Th49A5ZvFLAi9lAg==", null, false, "FT", "ceb09d6a-f20f-47e7-8d77-4ba0d56ad87c", new DateTime(2023, 4, 23, 21, 59, 21, 989, DateTimeKind.Local).AddTicks(1220), false, "ra@aoo.com" },
                    { "3b6e8ffc-8aa1-4e52-8c14-d01a3daeb582", 0, null, null, "29441270-58d1-4c4e-837f-4cbddacc4452", new DateTime(2023, 4, 23, 21, 59, 22, 63, DateTimeKind.Local).AddTicks(8030), null, "slayer@onegirl.net", false, "Asian", "Buffy", 0m, "F", null, true, null, "Summers", false, null, "SLAYER@ONEGIRL.NET", "SLAYER@ONEGIRL.NET", "AQAAAAIAAYagAAAAEOJjFLumzEwFznUV88cWWDTFvaz9KmYTMFDAnhj5Kt3QU/AdrqfLgeZ2aa5mzJPmeg==", null, false, "FT", "528603df-f7f2-420e-bb0e-2ed4b7268758", new DateTime(2023, 4, 23, 21, 59, 22, 63, DateTimeKind.Local).AddTicks(8040), false, "slayer@onegirl.net" },
                    { "677b36c2-c5de-497a-8465-b56fe96af334", 0, null, null, "63e14db8-f6c9-404c-a922-2458203d875b", new DateTime(2023, 4, 23, 21, 59, 22, 26, DateTimeKind.Local).AddTicks(6200), null, "captain@enterprise.net", false, "Asian", "Jean Luc", 0m, "F", null, true, null, "Picard", false, null, "CAPTAIN@ENTERPRISE.NET", "CAPTAIN@ENTERPRISE.NET", "AQAAAAIAAYagAAAAEOyIYuaqvE4P/3EjTc8UYJ9JEmYD4nJjKV/WbsJYlqQy0r7EedRnj9iWa6IDrWrqcA==", null, false, "FT", "26902f45-3e4f-4533-911e-02241655ba18", new DateTime(2023, 4, 23, 21, 59, 22, 26, DateTimeKind.Local).AddTicks(6220), false, "captain@enterprise.net" },
                    { "cd2971ad-feae-4428-9e1a-d564b8cb8610", 0, null, null, "0b64a70a-f844-48d2-891e-ab251ddd58da", new DateTime(2023, 4, 23, 21, 59, 22, 101, DateTimeKind.Local).AddTicks(130), null, "liz@ggmail.com", false, "Asian", "Elizabeth", 0m, "F", null, true, null, "Markham", false, null, "LIZ@GGMAIL.COM", "LIZ@GGMAIL.COM", "AQAAAAIAAYagAAAAEKmOVsZI24HB3oDWYoE+vfv03rAkDXfjX+QJPqAuDBsVLG33ReVbnRvCITUmZx0fLA==", null, false, "FT", "63e7c5f0-8347-4c94-b34a-187f349e962e", new DateTime(2023, 4, 23, 21, 59, 22, 101, DateTimeKind.Local).AddTicks(130), false, "liz@ggmail.com" },
                    { "f9424b1d-fb39-47d4-b3ce-0d2e48bb5e78", 0, null, null, "c1e3f0b3-303b-487b-8802-2817121114cc", new DateTime(2023, 4, 23, 21, 59, 22, 138, DateTimeKind.Local).AddTicks(7490), null, "twin@deservedbetter.com", false, "Asian", "Fred", 0m, "F", null, true, null, "Weasley", false, null, "TWIN@DESERVEDBETTER.COM", "TWIN@DESERVEDBETTER.COM", "AQAAAAIAAYagAAAAEI6AsEJfBwumea9u8yNaoJZDP2U3C9lhZOITIZyCd4ug/e0APP+jPlj1LTVukerLWA==", null, false, "FT", "850fa74c-8a28-4127-9d29-25ea8d0b4e09", new DateTime(2023, 4, 23, 21, 59, 22, 138, DateTimeKind.Local).AddTicks(7490), false, "twin@deservedbetter.com" }
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
                    { "d2e5e116-d5fd-45df-a531-aa661fec879c", "13f522a5-c59c-4c75-b767-6077ca503450" },
                    { "d2e5e116-d5fd-45df-a531-aa661fec879c", "3b6e8ffc-8aa1-4e52-8c14-d01a3daeb582" },
                    { "d2e5e116-d5fd-45df-a531-aa661fec879c", "677b36c2-c5de-497a-8465-b56fe96af334" },
                    { "d2e5e116-d5fd-45df-a531-aa661fec879c", "cd2971ad-feae-4428-9e1a-d564b8cb8610" },
                    { "d2e5e116-d5fd-45df-a531-aa661fec879c", "f9424b1d-fb39-47d4-b3ce-0d2e48bb5e78" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "CompanyId", "ConcurrencyStamp", "DateCreated", "DateOfBirth", "Email", "EmailConfirmed", "Ethnicity", "FirstName", "GPA", "Gender", "GraduationDate", "IsActive", "LastLoginDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PositionType", "SecurityStamp", "SystemDate", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0cb96c55-c6ba-4e81-bdc2-209d7b957282", 0, 32, null, "5626f7d7-b4a6-427e-af56-4401daec44ea", new DateTime(2023, 4, 23, 21, 59, 23, 599, DateTimeKind.Local).AddTicks(8960), new DateTime(2001, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "elowe@netscare.net", false, "White", "Ernest", 3.07m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Lowe", false, null, "ELOWE@NETSCARE.NET", "ELOWE@NETSCARE.NET", "AQAAAAIAAYagAAAAEII0MwnWj3OK2fLqrbgfI6hjkhM4Nc/nPilNG7CrWRxJ9GcsnJMfpZKP+CZruuIFeg==", null, false, "FT", "fb4291b7-2d4d-48c6-a7b4-a13373aaa34a", new DateTime(2023, 4, 23, 21, 59, 23, 599, DateTimeKind.Local).AddTicks(8960), false, "elowe@netscare.net" },
                    { "1066cc51-a1ab-4767-a91f-7459610a7092", 0, 22, null, "ef50344c-08c0-445e-b482-5f0c46682e4d", new DateTime(2023, 4, 23, 21, 59, 23, 228, DateTimeKind.Local).AddTicks(880), new DateTime(1996, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "tfreeley@minnetonka.ci.us", false, "NativeHawaiianandOtherPacificIslander", "Tesa", 3.98m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Freeley", false, null, "TFREELEY@MINNETONKA.CI.US", "TFREELEY@MINNETONKA.CI.US", "AQAAAAIAAYagAAAAEG1+jNdG29WAW6O+sxp8ZJDaZCNOCzTXuL8wg8bUKnlVfqfAkOV9CPvIOAOOzxkduA==", null, false, "I", "18007fd6-b5bd-4952-8d46-43192d3992b3", new DateTime(2023, 4, 23, 21, 59, 23, 228, DateTimeKind.Local).AddTicks(900), false, "tfreeley@minnetonka.ci.us" },
                    { "112c0553-9717-4894-9590-7246e414e899", 0, 21, null, "46ac098e-0830-4598-9838-0dd693080c00", new DateTime(2023, 4, 23, 21, 59, 23, 190, DateTimeKind.Local).AddTicks(7830), new DateTime(2003, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "feeley@penguin.org", false, "White", "Lou Ann", 3.66m, "F", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Feeley", false, null, "FEELEY@PENGUIN.ORG", "FEELEY@PENGUIN.ORG", "AQAAAAIAAYagAAAAEG1xLFX239Wj9Apxblc0STCeKi8ChVyZMaomtlPi0Ikf/eX0PvQFmFvInfK6YOSZnQ==", null, false, "I", "88f214fe-a4f2-4377-b0c3-491d48bfe0b7", new DateTime(2023, 4, 23, 21, 59, 23, 190, DateTimeKind.Local).AddTicks(7830), false, "feeley@penguin.org" },
                    { "133a1335-8c77-48d2-a556-09e94fe742cb", 0, 19, null, "105c62b7-bf19-4c18-ad15-8d26fa7b9bcb", new DateTime(2023, 4, 23, 21, 59, 23, 115, DateTimeKind.Local).AddTicks(9660), new DateTime(2002, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "shdixon@aoll.com", false, "White", "Shan", 3.62m, "F", new DateTime(2026, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Dixon", false, null, "SHDIXON@AOLL.COM", "SHDIXON@AOLL.COM", "AQAAAAIAAYagAAAAEGMn8IIacY/JlR7ZIX6oCDVhxcCNvycrmDGafOMLsTlc4+zX0uXqp+eZdEgGQzs/qg==", null, false, "I", "09b4f610-3e78-49fb-adc2-cb1009b6feb1", new DateTime(2023, 4, 23, 21, 59, 23, 115, DateTimeKind.Local).AddTicks(9670), false, "shdixon@aoll.com" },
                    { "182a6b63-09a3-4744-b03b-7b09dde76618", 0, 37, null, "ea709202-2588-4c23-b744-641c4b096604", new DateTime(2023, 4, 23, 21, 59, 23, 786, DateTimeKind.Local).AddTicks(1610), new DateTime(2003, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "gregmartinez@drdre.com", false, "Hispanic", "Gregory", 3.43m, "M", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Martinez", false, null, "GREGMARTINEZ@DRDRE.COM", "GREGMARTINEZ@DRDRE.COM", "AQAAAAIAAYagAAAAECjQUYMv+1Hu2rY01PtON+agNMfjkJiew15tSuRz4ajNaOajknDYHQ9I/mwHcpAW9w==", null, false, "I", "84861529-6da2-414e-a394-2e150d86ac6d", new DateTime(2023, 4, 23, 21, 59, 23, 786, DateTimeKind.Local).AddTicks(1610), false, "gregmartinez@drdre.com" },
                    { "1bcfd888-c765-449d-a286-bcca98b19c19", 0, 34, null, "3ce4724d-767a-49ae-ba16-7e7b640aa386", new DateTime(2023, 4, 23, 21, 59, 23, 674, DateTimeKind.Local).AddTicks(3740), new DateTime(2000, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "mackcloud@george.com", false, "White", "Jennifer", 4.00m, "Other", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "MacLeod", false, null, "MACKCLOUD@GEORGE.COM", "MACKCLOUD@GEORGE.COM", "AQAAAAIAAYagAAAAEJDExwVXsARZMFSceoWy0w1+uL2LQskYOTw4COroRAPwTJoP8patMkEPuWBwlCIBlg==", null, false, "FT", "af4ad73f-efb4-487d-bd6b-32c660ac055d", new DateTime(2023, 4, 23, 21, 59, 23, 674, DateTimeKind.Local).AddTicks(3740), false, "mackcloud@george.com" },
                    { "2377e694-030a-4ef6-8590-99f0ccb8c583", 0, 16, null, "8f1505ea-0df4-4980-8c95-cdd87272bb19", new DateTime(2023, 4, 23, 21, 59, 23, 4, DateTimeKind.Local).AddTicks(5520), new DateTime(2002, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "franco@example.com", false, "White", "Franco", 3.20m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Broccolo", false, null, "FRANCO@EXAMPLE.COM", "FRANCO@EXAMPLE.COM", "AQAAAAIAAYagAAAAEF/lSHjsyWzoCFMZv2OnLHSihyNSeVbEBrd8N1K7lAWMli/L4P6w7e5E4aGC9ZcQSw==", null, false, "FT", "6891237c-e89f-44ff-961f-e28fd2e3d23e", new DateTime(2023, 4, 23, 21, 59, 23, 4, DateTimeKind.Local).AddTicks(5530), false, "franco@example.com" },
                    { "249f0ae9-9fb9-4d7d-864a-aa058cf6d1c9", 0, 35, null, "5395d778-024c-4190-b670-af1bef1a2539", new DateTime(2023, 4, 23, 21, 59, 23, 711, DateTimeKind.Local).AddTicks(6910), new DateTime(2000, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "cmartin@beets.com", false, "NativeHawaiianandOtherPacificIslander", "Elizabeth", 3.53m, "Other", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Markham", false, null, "CMARTIN@BEETS.COM", "CMARTIN@BEETS.COM", "AQAAAAIAAYagAAAAEJA9WHraWy/MYU6V3xueEFnGmOauS14xjWKgKHkJg1TZdo9pAduDJtrlJxG2crQkxQ==", null, false, "FT", "40e477ea-25ad-4669-8be5-c12b169eb9ac", new DateTime(2023, 4, 23, 21, 59, 23, 711, DateTimeKind.Local).AddTicks(6910), false, "cmartin@beets.com" },
                    { "3415e8da-751f-4450-8327-6e42ab913dae", 0, 40, null, "3605ff44-10f9-4b65-814d-532addb9d55e", new DateTime(2023, 4, 23, 21, 59, 23, 897, DateTimeKind.Local).AddTicks(9950), new DateTime(2000, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "joewin@xfactor.com", false, "Asian", "Joe", 3.65m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Nguyen", false, null, "JOEWIN@XFACTOR.COM", "JOEWIN@XFACTOR.COM", "AQAAAAIAAYagAAAAEJ2wnew1onjbIpv2i4eaCFDPK3qkDAp+k6HFywTqhO8xMXO4gNBw84pDfavDOZav5g==", null, false, "FT", "9d2a5e7a-9f8c-4104-8fec-94b0b8ff6cea", new DateTime(2023, 4, 23, 21, 59, 23, 897, DateTimeKind.Local).AddTicks(9950), false, "joewin@xfactor.com" },
                    { "4ecfc6da-b7a5-4b90-9846-4784ce99a2e2", 0, 43, null, "507a0641-e3ec-4775-88a1-767b2e58f487", new DateTime(2023, 4, 23, 21, 59, 24, 9, DateTimeKind.Local).AddTicks(3500), new DateTime(2001, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "megrhodes@freserve.co.uk", false, "TwoOrMoreRaces", "Megan", 3.14m, "F", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Rhodes", false, null, "MEGRHODES@FRESERVE.CO.UK", "MEGRHODES@FRESERVE.CO.UK", "AQAAAAIAAYagAAAAEMU9NxAJl2KtEvLqh/wYqrl4cXH99vgqv2xPhGXUWE3DJGhh1xXmdXT3Dq9nNRo2xA==", null, false, "I", "e2feff0c-226a-47b8-bce6-1af0023260c4", new DateTime(2023, 4, 23, 21, 59, 24, 9, DateTimeKind.Local).AddTicks(3510), false, "megrhodes@freserve.co.uk" },
                    { "523f552e-c26f-432c-9bd5-66a4464db93e", 0, 33, null, "9d031fc1-555d-444a-acc2-201f791cbf01", new DateTime(2023, 4, 23, 21, 59, 23, 637, DateTimeKind.Local).AddTicks(550), new DateTime(2001, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "cluce@gogle.com", false, "White", "Chuck", 3.87m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Luce", false, null, "CLUCE@GOGLE.COM", "CLUCE@GOGLE.COM", "AQAAAAIAAYagAAAAENxHrrMrvYUmb4C9mzxTHoJgq1TEPbU+Sucnuyz3QijSLFt3bkpJfJTM5uixWafm0w==", null, false, "I", "944e7b33-f875-4cda-ba4b-1d4cef6be995", new DateTime(2023, 4, 23, 21, 59, 23, 637, DateTimeKind.Local).AddTicks(550), false, "cluce@gogle.com" },
                    { "5449f2bb-06a1-4291-b108-404103418fd6", 0, 15, null, "79e078cf-12e0-412f-b28c-82b17e4c2526", new DateTime(2023, 4, 23, 21, 59, 22, 967, DateTimeKind.Local).AddTicks(3550), new DateTime(2000, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "banker@longhorn.net", false, "BlackOrAfricanAmerican", "Michelle", 3.52m, "F", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Banks", false, null, "BANKER@LONGHORN.NET", "BANKER@LONGHORN.NET", "AQAAAAIAAYagAAAAEOAsw640spqlTpXrJlp/etbLe/OZRxnP/7sRzZSMBw6b+qyE6wgHKXMoHEcPnkxy3A==", null, false, "I", "a1436ce6-a894-4d87-a56b-d3e3095026f0", new DateTime(2023, 4, 23, 21, 59, 22, 967, DateTimeKind.Local).AddTicks(3550), false, "banker@longhorn.net" },
                    { "57a6f1e7-0d26-428f-aebd-ec233a1ba643", 0, 25, null, "12a9421b-e397-41db-8744-8d063602a1a0", new DateTime(2023, 4, 23, 21, 59, 23, 339, DateTimeKind.Local).AddTicks(4390), new DateTime(2003, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "jeffh@sonic.com", false, "BlackOrAfricanAmerican", "Jeffrey", 3.66m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Hampton", false, null, "JEFFH@SONIC.COM", "JEFFH@SONIC.COM", "AQAAAAIAAYagAAAAELzhpLgkBEoLz8Fl1Sp8WJiEvQq6txbU6PIqo6EDorAbmD9qex9GupV97GXpXD4RkQ==", null, false, "I", "a283c464-f77d-4309-830c-ff4541da10ff", new DateTime(2023, 4, 23, 21, 59, 23, 339, DateTimeKind.Local).AddTicks(4400), false, "jeffh@sonic.com" },
                    { "5993c6c2-b79c-40ac-8e69-d1e26794c0a8", 0, 28, null, "ebe4eec6-68c7-46f8-af8f-ec102d51a4c1", new DateTime(2023, 4, 23, 21, 59, 23, 450, DateTimeKind.Local).AddTicks(9080), new DateTime(2001, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "ingram@jack.com", false, "BlackOrAfricanAmerican", "Brad", 3.72m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Ingram", false, null, "INGRAM@JACK.COM", "INGRAM@JACK.COM", "AQAAAAIAAYagAAAAELAFGw68Ygdxwqdt98xrsgz6hnVEmJKesbroSguo28nhhM2kbu9jsG6JNDBCGJWi6Q==", null, false, "I", "37e0d939-9a53-4fde-bc65-c6dc34714516", new DateTime(2023, 4, 23, 21, 59, 23, 450, DateTimeKind.Local).AddTicks(9080), false, "ingram@jack.com" },
                    { "60cae427-0d8f-4873-84dd-5e9212a0664c", 0, 59, null, "199d9812-e3f6-4a42-9b0d-08645baac904", new DateTime(2023, 4, 23, 21, 59, 24, 604, DateTimeKind.Local).AddTicks(4530), new DateTime(2001, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ctucker@alphabet.co.uk", false, "Asian", "Clent", 3.04m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Tucker", false, null, "CTUCKER@ALPHABET.CO.UK", "CTUCKER@ALPHABET.CO.UK", "AQAAAAIAAYagAAAAELNxouCbzZ753UR2J/fRLK5ylwRMyToIlD+zdDr2hzFQsusbspLCQ/XLsXalKSpxUg==", null, false, "I", "995be886-0e63-4831-b607-870c8341c7cd", new DateTime(2023, 4, 23, 21, 59, 24, 604, DateTimeKind.Local).AddTicks(4530), false, "ctucker@alphabet.co.uk" },
                    { "6631fef5-5287-4ca2-abd7-4621ad392c86", 0, 38, null, "ae3c9378-d04a-4764-931d-4a575377b860", new DateTime(2023, 4, 23, 21, 59, 23, 823, DateTimeKind.Local).AddTicks(4640), new DateTime(2001, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "cmiller@bob.com", false, "TwoOrMoreRaces", "Charles", 3.14m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Miller", false, null, "CMILLER@BOB.COM", "CMILLER@BOB.COM", "AQAAAAIAAYagAAAAEJB5aLBNzxFJ83uwGEn1/SkJoAuhXdce0lOerw9/HX8ueWDVNfi27vdUTyrxs+A2tQ==", null, false, "I", "d9d3cadf-5663-4812-9d35-3b180200f781", new DateTime(2023, 4, 23, 21, 59, 23, 823, DateTimeKind.Local).AddTicks(4650), false, "cmiller@bob.com" },
                    { "69cb26a9-9508-46c0-bc6e-fa217aa75a13", 0, 53, null, "132cb29d-59be-4d6f-a97b-9e0139ebd665", new DateTime(2023, 4, 23, 21, 59, 24, 381, DateTimeKind.Local).AddTicks(2160), new DateTime(2003, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "estuart@anchor.net", false, "BlackOrAfricanAmerican", "Eric", 3.58m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Stuart", false, null, "ESTUART@ANCHOR.NET", "ESTUART@ANCHOR.NET", "AQAAAAIAAYagAAAAEOfIjzxBWuz4MRS7iiPLg+iFTq78SxGrTAtNLFFN6M9uNZJKckgtoDxbafmZXCIKOg==", null, false, "FT", "a090cf37-4b40-4c3a-ad6f-d90baa8238cb", new DateTime(2023, 4, 23, 21, 59, 24, 381, DateTimeKind.Local).AddTicks(2170), false, "estuart@anchor.net" },
                    { "7573173a-8c71-41f6-a352-5a064aee1dac", 0, 57, null, "958c6574-b5d5-4634-8c03-f88f62074bf4", new DateTime(2023, 4, 23, 21, 59, 24, 529, DateTimeKind.Local).AddTicks(9860), new DateTime(2003, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "rtaylor@gogle.com", false, "TwoOrMoreRaces", "Rachel", 2.88m, "F", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Taylor", false, null, "RTAYLOR@GOGLE.COM", "RTAYLOR@GOGLE.COM", "AQAAAAIAAYagAAAAEF2L2KaSVTmAV/fAITcnLxcfsC6Qi8cY0MQr/zTE5u9RENqasLX3qFyRZg/WE2DGFQ==", null, false, "I", "999efbdb-5c4e-4d32-9901-133aaa55dc58", new DateTime(2023, 4, 23, 21, 59, 24, 529, DateTimeKind.Local).AddTicks(9870), false, "rtaylor@gogle.com" },
                    { "776ac473-3f9a-4f09-8b4e-0225a72f428c", 0, 64, null, "5458d8ac-3ba3-4b06-8f8b-b7a3a8ad8efa", new DateTime(2023, 4, 23, 21, 59, 24, 790, DateTimeKind.Local).AddTicks(7260), new DateTime(2001, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rwood@voyager.net", false, "White", "Reagan", 3.78m, "F", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Wood", false, null, "RWOOD@VOYAGER.NET", "RWOOD@VOYAGER.NET", "AQAAAAIAAYagAAAAEKdgxjJkkmslopGWkmHnCfmTumlrghw9pZCIAQvoHfiXZ93huaE67qljT6lHuitJwQ==", null, false, "FT", "3a7dc312-9b0c-4baa-a035-f8d6ea03d0a3", new DateTime(2023, 4, 23, 21, 59, 24, 790, DateTimeKind.Local).AddTicks(7260), false, "rwood@voyager.net" },
                    { "7b4f4718-f143-4d36-b210-6e4924931d87", 0, 51, null, "c8caaadb-0c4d-45e2-96ef-f3514ac6517a", new DateTime(2023, 4, 23, 21, 59, 24, 306, DateTimeKind.Local).AddTicks(9380), new DateTime(2001, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "johnsmith187@aoll.com", false, "White", "John", 3.57m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Smith", false, null, "JOHNSMITH187@AOLL.COM", "JOHNSMITH187@AOLL.COM", "AQAAAAIAAYagAAAAEJtrYJjZk0/LT4amprs81uZajLALgZCyXpqN0MfGnZx9118u9sS2tujPkry8TmyySQ==", null, false, "FT", "556f808f-13e5-46a3-9ed3-70c9239ba90b", new DateTime(2023, 4, 23, 21, 59, 24, 306, DateTimeKind.Local).AddTicks(9380), false, "johnsmith187@aoll.com" },
                    { "81b8a64f-fa24-4cdf-a94d-ab1acd5597f8", 0, 60, null, "a403e8b0-204c-41b7-9370-9157ad9b2e6c", new DateTime(2023, 4, 23, 21, 59, 24, 641, DateTimeKind.Local).AddTicks(8370), new DateTime(2003, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "avelasco@yoho.com", false, "Hispanic", "Allen", 3.55m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Velasco", false, null, "AVELASCO@YOHO.COM", "AVELASCO@YOHO.COM", "AQAAAAIAAYagAAAAEO+rAo2hw8WESVOERuJjcL2Lhq4DagyA0gxIhzA3oIWgfJf6RFBt9XnFdJesNTXWJA==", null, false, "FT", "84316dd9-765c-49e0-bfda-3464bc3e39a6", new DateTime(2023, 4, 23, 21, 59, 24, 641, DateTimeKind.Local).AddTicks(8380), false, "avelasco@yoho.com" },
                    { "8b8c27db-812d-47ba-a927-c84b1aacb645", 0, 58, null, "ca4822b1-d1cc-454e-adae-a4c7d01e6dbb", new DateTime(2023, 4, 23, 21, 59, 24, 567, DateTimeKind.Local).AddTicks(800), new DateTime(2003, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "teefrank@noclue.com", false, "BlackOrAfricanAmerican", "Frank", 3.50m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Tee", false, null, "TEEFRANK@NOCLUE.COM", "TEEFRANK@NOCLUE.COM", "AQAAAAIAAYagAAAAEGUCwvsS4P21aVbGOeGOfXOtL35/gbirW5K7r3mdGBCJMbF+/mF+UvYfHivBxFFdLw==", null, false, "FT", "bdd74fc6-986e-487b-b3fe-e7ea33683e26", new DateTime(2023, 4, 23, 21, 59, 24, 567, DateTimeKind.Local).AddTicks(800), false, "teefrank@noclue.com" },
                    { "8d64652a-9817-4172-82cd-8d32f42f2db6", 0, 27, null, "e25f61b4-ed7a-4eca-8fa2-5c20ceb73036", new DateTime(2023, 4, 23, 21, 59, 23, 413, DateTimeKind.Local).AddTicks(8350), new DateTime(2003, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahick@yaho.com", false, "TwoOrMoreRaces", "Anthony", 3.12m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Hicks", false, null, "AHICK@YAHO.COM", "AHICK@YAHO.COM", "AQAAAAIAAYagAAAAEMGXZ2pdGpuXVwjnEH3+pjbmrQKK++0beThW9k0vOzcTVeNYWI8mUtK2+UqI5Sj8Yw==", null, false, "I", "d0e092d5-8289-41bf-ab81-4a4acb2a80c0", new DateTime(2023, 4, 23, 21, 59, 23, 413, DateTimeKind.Local).AddTicks(8360), false, "ahick@yaho.com" },
                    { "8f391bcb-df75-475a-a481-4aca008508c9", 0, 23, null, "164938c5-992d-4e78-92f4-f73ef5d7afe9", new DateTime(2023, 4, 23, 21, 59, 23, 265, DateTimeKind.Local).AddTicks(1560), new DateTime(2002, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "mgarcia@gogle.com", false, "Hispanic", "Margaret", 3.22m, "F", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Garcia", false, null, "MGARCIA@GOGLE.COM", "MGARCIA@GOGLE.COM", "AQAAAAIAAYagAAAAEOpfhjf7vTqpeB2r5MvUvq8sRwWjWXYdcpP2OW6TG2npdmFVKQb6Ko2rTmLqPfxPng==", null, false, "FT", "ce06e63a-d8ba-4a0f-abb4-7485f15f9c21", new DateTime(2023, 4, 23, 21, 59, 23, 265, DateTimeKind.Local).AddTicks(1560), false, "mgarcia@gogle.com" },
                    { "8fde2dd6-cffe-4dca-b5a1-f3bb2a2d869b", 0, 45, null, "9bf58260-917e-4471-8d4b-1e27d1f416ba", new DateTime(2023, 4, 23, 21, 59, 24, 83, DateTimeKind.Local).AddTicks(5190), new DateTime(2002, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "jorge@noclue.com", false, "Hispanic", "Jorge", 3.64m, "M", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Rodriguez", false, null, "JORGE@NOCLUE.COM", "JORGE@NOCLUE.COM", "AQAAAAIAAYagAAAAEE98msH/MR0xvmqPTrGhyowAxrSp7CuUDKPw/b1rPsratmiWKimVStbYA4nQ7JXfGw==", null, false, "I", "44b10da3-f4af-4778-8727-ce0047474295", new DateTime(2023, 4, 23, 21, 59, 24, 83, DateTimeKind.Local).AddTicks(5190), false, "jorge@noclue.com" },
                    { "9457e4ad-c052-4b0d-9a77-f717b44fe246", 0, 29, null, "15b7a1a5-3d91-4a64-89b0-abf5a25663ff", new DateTime(2023, 4, 23, 21, 59, 23, 488, DateTimeKind.Local).AddTicks(1970), new DateTime(2001, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "toddj@yourmom.com", false, "Hispanic", "Todd", 2.64m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Jacobs", false, null, "TODDJ@YOURMOM.COM", "TODDJ@YOURMOM.COM", "AQAAAAIAAYagAAAAEKyDA8R6cocD1KXdL5j+0Hmf7hg7KLF5CMO+QnpPZAxX+DxYbAPuH/wD1A/HTHEsKA==", null, false, "FT", "f7da3e16-718a-4c5e-b5b4-2218d12eb0d2", new DateTime(2023, 4, 23, 21, 59, 23, 488, DateTimeKind.Local).AddTicks(1970), false, "toddj@yourmom.com" },
                    { "9d65d32c-4ed3-4ba9-a72e-4491f5df921b", 0, 48, null, "c3defbe1-2e89-46a1-965b-7b5359ccf728", new DateTime(2023, 4, 23, 21, 59, 24, 195, DateTimeKind.Local).AddTicks(2660), new DateTime(2002, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "saunders@pen.com", false, "White", "Sarah", 3.16m, "F", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Saunders", false, null, "SAUNDERS@PEN.COM", "SAUNDERS@PEN.COM", "AQAAAAIAAYagAAAAEBzJQtdcADju0PPIJH/Yk/NUiWRtqsbWGAcB0X9DDfJwQuLUjyrioIAGlWMUZ+/S/g==", null, false, "I", "6b2d44d5-05f0-4ce5-b28d-483e46bc802d", new DateTime(2023, 4, 23, 21, 59, 24, 195, DateTimeKind.Local).AddTicks(2660), false, "saunders@pen.com" },
                    { "a7fa66b0-4aed-4409-afff-272b8aaa2907", 0, 18, null, "ff27b847-a7af-4d1d-9e65-08dbe06ecec7", new DateTime(2023, 4, 23, 21, 59, 23, 78, DateTimeKind.Local).AddTicks(8280), new DateTime(2003, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "limchou@gogle.com", false, "Asian", "Lim", 2.63m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Chou", false, null, "LIMCHOU@GOGLE.COM", "LIMCHOU@GOGLE.COM", "AQAAAAIAAYagAAAAEH+URlcDIPao4DsvXSuqoygeH5ZLjouCrg6bWgNZUIXWwiPT1i2gDSKxCJx2dZjZdw==", null, false, "I", "27ac4064-e0bd-4bab-874a-9d5fc928e178", new DateTime(2023, 4, 23, 21, 59, 23, 78, DateTimeKind.Local).AddTicks(8280), false, "limchou@gogle.com" },
                    { "aded3147-1b49-44da-a7d0-765912bdaf37", 0, 41, null, "5820b8d1-fb21-41b3-8416-8ed5e449f174", new DateTime(2023, 4, 23, 21, 59, 23, 935, DateTimeKind.Local).AddTicks(1120), new DateTime(2001, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "orielly@foxnews.cnn", false, "White", "Bill", 3.46m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "O'Reilly", false, null, "ORIELLY@FOXNEWS.CNN", "ORIELLY@FOXNEWS.CNN", "AQAAAAIAAYagAAAAEEiob1E6/NLwkDxbI2M++nn1709Ff6eaMefoGj/EhAxfIaqOSJ2DzWgNZ+NWny0LkA==", null, false, "I", "d2f027c6-3cc5-4ce5-958c-96b66a6fe62e", new DateTime(2023, 4, 23, 21, 59, 23, 935, DateTimeKind.Local).AddTicks(1130), false, "orielly@foxnews.cnn" },
                    { "b1f980d2-eeea-400a-8c88-a7793ac59e82", 0, 31, null, "d14e653f-2613-40dd-8650-2ee439b95b42", new DateTime(2023, 4, 23, 21, 59, 23, 562, DateTimeKind.Local).AddTicks(8170), new DateTime(2004, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "linebacker@gogle.com", false, "Hispanic", "Erik", 3.15m, "M", new DateTime(2026, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Lineback", false, null, "LINEBACKER@GOGLE.COM", "LINEBACKER@GOGLE.COM", "AQAAAAIAAYagAAAAEK2z3zad3RWSHRNPVppuIFBmMLtXGoPe3c+lVBwJ8kazV+zYv2UTZmGFGoSD7sejeQ==", null, false, "I", "1c944f8c-e9d2-40cf-a96f-84dc19448102", new DateTime(2023, 4, 23, 21, 59, 23, 562, DateTimeKind.Local).AddTicks(8180), false, "linebacker@gogle.com" },
                    { "b1faccab-3207-418b-9e44-4a78ed008612", 0, 61, null, "1aa064b8-428a-4dcf-8eea-8c64ba403f8b", new DateTime(2023, 4, 23, 21, 59, 24, 679, DateTimeKind.Local).AddTicks(1560), new DateTime(1997, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "vinovino@grapes.com", false, "Hispanic", "Janet", 3.28m, "F", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Vino", false, null, "VINOVINO@GRAPES.COM", "VINOVINO@GRAPES.COM", "AQAAAAIAAYagAAAAEA8LhiGWTFErDh4XMHlCIF1h/THju3HYLHv4t/XDeAYjQqUZUwin7kGb4griXHIKuA==", null, false, "I", "3b1d5abe-d4bb-43bd-b80b-5b7fdb060c7f", new DateTime(2023, 4, 23, 21, 59, 24, 679, DateTimeKind.Local).AddTicks(1570), false, "vinovino@grapes.com" },
                    { "b4dc7510-7624-4329-a270-2487e28692e8", 0, 54, null, "c5ab467e-f57b-47a8-a70f-678b88ee1333", new DateTime(2023, 4, 23, 21, 59, 24, 418, DateTimeKind.Local).AddTicks(3790), new DateTime(2002, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "peterstump@noclue.com", false, "NativeHawaiianandOtherPacificIslander", "Peter", 2.55m, "M", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Stump", false, null, "PETERSTUMP@NOCLUE.COM", "PETERSTUMP@NOCLUE.COM", "AQAAAAIAAYagAAAAEEj9u1iwioCXjzDSZmllxX54aQFnozN6lcfV6IDNIi1Ri2jU23MTK8eQL5veJlcmhA==", null, false, "I", "47182fee-28e5-4032-9056-28a27ca9273a", new DateTime(2023, 4, 23, 21, 59, 24, 418, DateTimeKind.Local).AddTicks(3790), false, "peterstump@noclue.com" },
                    { "b6f1c0f1-5bca-4677-b4ac-59df9694b308", 0, 63, null, "1008a700-4967-4223-90b8-23f0697cc5ff", new DateTime(2023, 4, 23, 21, 59, 24, 753, DateTimeKind.Local).AddTicks(5430), new DateTime(2001, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "winner@hootmail.com", false, "TwoOrMoreRaces", "Louis", 2.57m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Winthorpe", false, null, "WINNER@HOOTMAIL.COM", "WINNER@HOOTMAIL.COM", "AQAAAAIAAYagAAAAEBPJLv0Wq754qo/XhW4Z9GWgQarJvliO6k7oAh8uycUQJ3W/YQhqHHM1ur82Fj1muw==", null, false, "FT", "878ce862-e4d1-464b-bab5-b60ec56986a9", new DateTime(2023, 4, 23, 21, 59, 24, 753, DateTimeKind.Local).AddTicks(5430), false, "winner@hootmail.com" },
                    { "bb2caa99-1ced-4c4d-b197-178257ce2e5f", 0, 36, null, "5b1dc70e-ee60-47fe-bc29-eaaf0b85f8f4", new DateTime(2023, 4, 23, 21, 59, 23, 749, DateTimeKind.Local).AddTicks(350), new DateTime(2002, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "clarence@yoho.com", false, "White", "Clarence", 3.11m, "Other", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Martin", false, null, "CLARENCE@YOHO.COM", "CLARENCE@YOHO.COM", "AQAAAAIAAYagAAAAEHdNyRzvgksW77/9o1coLdcqSj+d8h2ZFhMTt4LEMrhCxy6L/NVPHcYmo0+WC7FhmA==", null, false, "I", "a4d8faca-2feb-4db0-b453-a0388ddc8582", new DateTime(2023, 4, 23, 21, 59, 23, 749, DateTimeKind.Local).AddTicks(350), false, "clarence@yoho.com" },
                    { "bc30683e-b23d-4dfa-ac61-a6eb24670952", 0, 17, null, "af60a685-7d78-4678-87b9-d772f1534526", new DateTime(2023, 4, 23, 21, 59, 23, 41, DateTimeKind.Local).AddTicks(6700), new DateTime(2001, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "wchang@example.com", false, "Asian", "Wendy", 3.56m, "F", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Chang", false, null, "WCHANG@EXAMPLE.COM", "WCHANG@EXAMPLE.COM", "AQAAAAIAAYagAAAAEP5Wlsrx5ipggruY1JM2UIjTf5zaZEphAzMfxkRcKPc3WQ8AQdkRw+i+avmCbMcrLA==", null, false, "I", "9be39345-9e80-4fba-bab6-ec9e5fa4f558", new DateTime(2023, 4, 23, 21, 59, 23, 41, DateTimeKind.Local).AddTicks(6700), false, "wchang@example.com" },
                    { "c43a68a0-4e1e-4b6b-a60e-7689d2b8ee85", 0, 47, null, "5941470b-4224-4a3e-abae-a897a756a7e7", new DateTime(2023, 4, 23, 21, 59, 24, 158, DateTimeKind.Local).AddTicks(710), new DateTime(2002, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "stjean@athome.com", false, "White", "Olivier", 3.24m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Saint-Jean", false, null, "STJEAN@ATHOME.COM", "STJEAN@ATHOME.COM", "AQAAAAIAAYagAAAAED/g2LYDUnKjrXsBJUQUFWRA8RX7T7kC7iRBVwXemclP+RphFXVLEpe3rY5RKknogQ==", null, false, "FT", "e71e584b-208a-45af-a0a7-89191a59a171", new DateTime(2023, 4, 23, 21, 59, 24, 158, DateTimeKind.Local).AddTicks(730), false, "stjean@athome.com" },
                    { "cb86ec9e-bc98-4973-aa47-bba78cfab53b", 0, 20, null, "0c3d8d02-5021-454a-b4ed-f528b49fc449", new DateTime(2023, 4, 23, 21, 59, 23, 153, DateTimeKind.Local).AddTicks(3120), new DateTime(2001, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "j.b.evans@aheca.org", false, "White", "Jim Bob", 2.64m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Evans", false, null, "J.B.EVANS@AHECA.ORG", "J.B.EVANS@AHECA.ORG", "AQAAAAIAAYagAAAAEGiydQmG0ICwfd0iMgT9UXtuY67iTNDwaVKrVcpb6p34gdaMGJhoYB28RhIMGRSHdg==", null, false, "FT", "8f6d0c5b-7f7d-4536-a330-fd8e39e95e05", new DateTime(2023, 4, 23, 21, 59, 23, 153, DateTimeKind.Local).AddTicks(3130), false, "j.b.evans@aheca.org" },
                    { "cc1fbb3a-6ba8-400a-b00c-88d70619c5ef", 0, 39, null, "5aa1961f-7eb8-4b2f-849c-d318bfde7ffa", new DateTime(2023, 4, 23, 21, 59, 23, 860, DateTimeKind.Local).AddTicks(8490), new DateTime(2003, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "knelson@aoll.com", false, "NativeHawaiianandOtherPacificIslander", "Kelly", 3.03m, "F", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Nelson", false, null, "KNELSON@AOLL.COM", "KNELSON@AOLL.COM", "AQAAAAIAAYagAAAAEJFTOOaih6gdCzQ3jOTpuErlBEyTJqHxjnELBUJ+m5TyfcpD0xnQ+zaicCLPd/4ENQ==", null, false, "FT", "d3c7b3bc-dbd9-4e4b-947a-08056803a7d2", new DateTime(2023, 4, 23, 21, 59, 23, 860, DateTimeKind.Local).AddTicks(8490), false, "knelson@aoll.com" },
                    { "ccfe848a-ff30-4948-a9bb-4494f5ef7442", 0, 24, null, "c5bb42b3-00b3-4e4b-9e28-e61333a3eb46", new DateTime(2023, 4, 23, 21, 59, 23, 302, DateTimeKind.Local).AddTicks(2730), new DateTime(1998, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "chaley@thug.com", false, "BlackOrAfricanAmerican", "Charles", 3.78m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Haley", false, null, "CHALEY@THUG.COM", "CHALEY@THUG.COM", "AQAAAAIAAYagAAAAENDci5vdy5VsK0hMykt/Yn/47qFyuVBwzF5j6sG0xFi/u8YhfKURMBm1ibmwD2hyvg==", null, false, "I", "6cffd348-db4f-48a6-b50b-291d6543bd35", new DateTime(2023, 4, 23, 21, 59, 23, 302, DateTimeKind.Local).AddTicks(2730), false, "chaley@thug.com" },
                    { "ce61ea89-8818-44ae-8b16-6366761a6313", 0, 49, null, "1f6c3744-c508-4b2b-96f0-c47a5ad4f10f", new DateTime(2023, 4, 23, 21, 59, 24, 232, DateTimeKind.Local).AddTicks(6190), new DateTime(2002, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "willsheff@email.com", false, "Hispanic", "William", 3.07m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Sewell", false, null, "WILLSHEFF@EMAIL.COM", "WILLSHEFF@EMAIL.COM", "AQAAAAIAAYagAAAAELm3w2Epe71ZKzY9ySQ+1uJF0GwXiB0OvDgtXJrzObjSVKUIMVu/+0sDl0xzLSf9qA==", null, false, "FT", "aecc6b29-0123-4a7f-ad14-2907e1f75571", new DateTime(2023, 4, 23, 21, 59, 24, 232, DateTimeKind.Local).AddTicks(6190), false, "willsheff@email.com" },
                    { "d56aa3bd-b1c7-4edb-9186-ffb1971348aa", 0, 62, null, "f5d7d7be-0d7d-4d83-9b11-1d1d10958842", new DateTime(2023, 4, 23, 21, 59, 24, 716, DateTimeKind.Local).AddTicks(3410), new DateTime(2002, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "westj@pioneer.net", false, "NativeHawaiianandOtherPacificIslander", "Jake", 3.66m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "West", false, null, "WESTJ@PIONEER.NET", "WESTJ@PIONEER.NET", "AQAAAAIAAYagAAAAEOFho0fAwAskYuqBeuK6vMgAzlONzvBmQFGQ1yX90VWo/+fKPGQq//e9tYU/Kuziww==", null, false, "FT", "5611b72f-72a4-4cb5-ad05-27b7b54b7b7f", new DateTime(2023, 4, 23, 21, 59, 24, 716, DateTimeKind.Local).AddTicks(3420), false, "westj@pioneer.net" },
                    { "daab1bfe-16da-42f4-b553-5747b916d7e1", 0, 56, null, "60771193-44d2-45b3-8451-659c76b6b361", new DateTime(2023, 4, 23, 21, 59, 24, 492, DateTimeKind.Local).AddTicks(7040), new DateTime(2001, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "taylordjay@aoll.com", false, "TwoOrMoreRaces", "Allison", 3.07m, "F", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Taylor", false, null, "TAYLORDJAY@AOLL.COM", "TAYLORDJAY@AOLL.COM", "AQAAAAIAAYagAAAAELM1yrlsjCDpPJKOuO3mL/+KP+2cxCCULOyZV1pNEGlKkoQQq7bE3YLDRnZrrMOnAA==", null, false, "FT", "f777aa15-a878-4daa-a483-2e879d03abb4", new DateTime(2023, 4, 23, 21, 59, 24, 492, DateTimeKind.Local).AddTicks(7040), false, "taylordjay@aoll.com" },
                    { "dd8698f5-ffee-41a8-b5e7-89647e015669", 0, 52, null, "629b7523-df24-4911-baab-7499ab751f0b", new DateTime(2023, 4, 23, 21, 59, 24, 344, DateTimeKind.Local).AddTicks(1350), new DateTime(2002, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "dustroud@mail.com", false, "White", "Dustin", 3.49m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Stroud", false, null, "DUSTROUD@MAIL.COM", "DUSTROUD@MAIL.COM", "AQAAAAIAAYagAAAAEHPMdT3P6Mex3dwekYZ4B6I2Yxngf0bOOttFVozFlk8eLSbhvhbvFyPTHJXkdoZ5+A==", null, false, "I", "6e0161a1-8793-45ef-a820-8e2ac12e1054", new DateTime(2023, 4, 23, 21, 59, 24, 344, DateTimeKind.Local).AddTicks(1350), false, "dustroud@mail.com" },
                    { "ddf4e679-1d22-45c7-b332-c3955d8b798a", 0, 50, null, "e090be6d-965e-4c9b-88f5-712a4ad328f1", new DateTime(2023, 4, 23, 21, 59, 24, 269, DateTimeKind.Local).AddTicks(7910), new DateTime(2002, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "sheffiled@gogle.com", false, "TwoOrMoreRaces", "Martin", 3.36m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Sheffield", false, null, "SHEFFILED@GOGLE.COM", "SHEFFILED@GOGLE.COM", "AQAAAAIAAYagAAAAEHKHVaBy7HNExmHnCiaIfFMPYwNnw0oo35XneY4MaYKyi0PxhjAuYkzqIhbJt5AuHQ==", null, false, "I", "ff9e4fcc-26f9-4156-a824-8a9e7eceeaac", new DateTime(2023, 4, 23, 21, 59, 24, 269, DateTimeKind.Local).AddTicks(7910), false, "sheffiled@gogle.com" },
                    { "e4d90733-3e62-4b97-926a-54561fb63ae3", 0, 26, null, "29f94cf9-3333-4942-9969-ee3b323f0ee6", new DateTime(2023, 4, 23, 21, 59, 23, 376, DateTimeKind.Local).AddTicks(5770), new DateTime(2000, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "wjhearniii@umich.org", false, "White", "John", 3.46m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Hearn", false, null, "WJHEARNIII@UMICH.ORG", "WJHEARNIII@UMICH.ORG", "AQAAAAIAAYagAAAAEGsy6n0+YboJ6Zo6XYIiBNz2QIC0KNkdV+VFF7R3DwNyXkmVDuBzSRd95YLMdPovCA==", null, false, "FT", "3077c6e0-0bbc-4068-920c-72b0463c5b97", new DateTime(2023, 4, 23, 21, 59, 23, 376, DateTimeKind.Local).AddTicks(5780), false, "wjhearniii@umich.org" },
                    { "e51b4197-c122-49c1-ab25-5a4716a73e33", 0, 42, null, "3dfafb7f-77a9-412a-a66e-07cad8aa8e2e", new DateTime(2023, 4, 23, 21, 59, 23, 972, DateTimeKind.Local).AddTicks(2720), new DateTime(2001, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "ankaisrad@gogle.com", false, "White", "Anka", 3.67m, "Other", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Radkovich", false, null, "ANKAISRAD@GOGLE.COM", "ANKAISRAD@GOGLE.COM", "AQAAAAIAAYagAAAAEJbv4QARk21Z47XNMe62pNRkWlrjdzfBk/C3Z/CUYKz9SwM+EQNW16jKZG8RZx1IXA==", null, false, "FT", "f99ed964-309f-4acc-9c75-d1366529b61f", new DateTime(2023, 4, 23, 21, 59, 23, 972, DateTimeKind.Local).AddTicks(2720), false, "ankaisrad@gogle.com" },
                    { "ea76119b-5ded-497f-a4fb-7091bd52d82a", 0, 30, null, "83d22c05-7eaa-4672-8fd9-c43bfaf15f40", new DateTime(2023, 4, 23, 21, 59, 23, 525, DateTimeKind.Local).AddTicks(5390), new DateTime(2001, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "thequeen@aska.net", false, "BlackOrAfricanAmerican", "Victoria", 3.72m, "F", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Lawrence", false, null, "THEQUEEN@ASKA.NET", "THEQUEEN@ASKA.NET", "AQAAAAIAAYagAAAAELrHDedKWC2kFx4UqjhfTFy2H1mc7UPrQZHZA/rhaWiRCW9RNgXhSVmY/ipmyIWd5w==", null, false, "I", "ab3326a4-cc57-4a0a-bdc4-587aa981e95f", new DateTime(2023, 4, 23, 21, 59, 23, 525, DateTimeKind.Local).AddTicks(5400), false, "thequeen@aska.net" },
                    { "eac2f179-0bc8-406c-acba-49812724b40d", 0, 14, null, "f5b3f0a5-804b-4338-a759-801ec64d910d", new DateTime(2023, 4, 23, 21, 59, 22, 930, DateTimeKind.Local).AddTicks(1150), new DateTime(2001, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "cbaker@example.com", false, "White", "Christopher", 3.91m, "M", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Baker", false, null, "CBAKER@EXAMPLE.COM", "CBAKER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPZjCYjW2emF4LpqFjPH6PW27vWoFFJc5HNHWnqSkEPHWczDOPop3agocdeAxVgC0A==", null, false, "FT", "19154bed-7ba5-4421-82b9-795fb86f406c", new DateTime(2023, 4, 23, 21, 59, 22, 930, DateTimeKind.Local).AddTicks(1160), false, "cbaker@example.com" },
                    { "ec3ba1cd-24de-4012-865b-c8cd4e59dac4", 0, 44, null, "2b92ec75-7ee8-4452-83cc-9ac9d71044ba", new DateTime(2023, 4, 23, 21, 59, 24, 46, DateTimeKind.Local).AddTicks(4280), new DateTime(2004, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "erynrice@aoll.com", false, "Asian", "Eryn", 3.92m, "F", new DateTime(2026, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Rice", false, null, "ERYNRICE@AOLL.COM", "ERYNRICE@AOLL.COM", "AQAAAAIAAYagAAAAEIxH2n7OdwRvI7n+x6Qx8/KjEgYKoczBvRii9uuESBv0VcVOY4/mCbJGjxwt9ALyJg==", null, false, "I", "ca9e3672-d705-400f-b5a6-8fc2feee8078", new DateTime(2023, 4, 23, 21, 59, 24, 46, DateTimeKind.Local).AddTicks(4280), false, "erynrice@aoll.com" },
                    { "ef563ec2-99e3-4aa0-b9c9-3bc6deac215f", 0, 46, null, "977b8b58-5709-4872-959a-8f9977cab323", new DateTime(2023, 4, 23, 21, 59, 24, 120, DateTimeKind.Local).AddTicks(6910), new DateTime(2001, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "mrrogers@lovelyday.com", false, "BlackOrAfricanAmerican", "Allen", 3.01m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Rogers", false, null, "MRROGERS@LOVELYDAY.COM", "MRROGERS@LOVELYDAY.COM", "AQAAAAIAAYagAAAAEG7CQIc+5kGCFSX0C2Row+tSAN0//LOCu0+5daxvjvH+bKiEp1vepzNNFJZqWzRnHA==", null, false, "I", "4ce8cfa5-a03d-4aa0-b50e-e567f50a7f97", new DateTime(2023, 4, 23, 21, 59, 24, 120, DateTimeKind.Local).AddTicks(6910), false, "mrrogers@lovelyday.com" },
                    { "fc9db39e-6880-41ba-b723-2daff5dc03f2", 0, 55, null, "3fbf80fb-f0e7-4e6f-a3de-0e167d47253a", new DateTime(2023, 4, 23, 21, 59, 24, 455, DateTimeKind.Local).AddTicks(5680), new DateTime(2002, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "jtanner@mustang.net", false, "White", "Jeremy", 3.16m, "M", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Tanner", false, null, "JTANNER@MUSTANG.NET", "JTANNER@MUSTANG.NET", "AQAAAAIAAYagAAAAEGTAU32TfTcjbZbVAQd7XnKft8wwPpH2rj7SLHB7nnZv43t8Xfjg4eIh3c4ySRJz5A==", null, false, "I", "f04a0964-de4d-40e4-a80e-6989c57e2dc2", new DateTime(2023, 4, 23, 21, 59, 24, 455, DateTimeKind.Local).AddTicks(5680), false, "jtanner@mustang.net" }
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
                    { "0cb96c55-c6ba-4e81-bdc2-209d7b957282", 3, true },
                    { "1066cc51-a1ab-4767-a91f-7459610a7092", 1, true },
                    { "112c0553-9717-4894-9590-7246e414e899", 6, true },
                    { "133a1335-8c77-48d2-a556-09e94fe742cb", 4, true },
                    { "182a6b63-09a3-4744-b03b-7b09dde76618", 2, true },
                    { "1bcfd888-c765-449d-a286-bcca98b19c19", 8, true },
                    { "2377e694-030a-4ef6-8590-99f0ccb8c583", 8, true },
                    { "249f0ae9-9fb9-4d7d-864a-aa058cf6d1c9", 2, true },
                    { "3415e8da-751f-4450-8327-6e42ab913dae", 5, true },
                    { "4ecfc6da-b7a5-4b90-9846-4784ce99a2e2", 5, true },
                    { "523f552e-c26f-432c-9bd5-66a4464db93e", 1, true },
                    { "5449f2bb-06a1-4291-b108-404103418fd6", 4, true },
                    { "57a6f1e7-0d26-428f-aebd-ec233a1ba643", 9, true },
                    { "5993c6c2-b79c-40ac-8e69-d1e26794c0a8", 7, true },
                    { "60cae427-0d8f-4873-84dd-5e9212a0664c", 8, true },
                    { "6631fef5-5287-4ca2-abd7-4621ad392c86", 5, true },
                    { "69cb26a9-9508-46c0-bc6e-fa217aa75a13", 2, true },
                    { "7573173a-8c71-41f6-a352-5a064aee1dac", 3, true },
                    { "776ac473-3f9a-4f09-8b4e-0225a72f428c", 1, true },
                    { "7b4f4718-f143-4d36-b210-6e4924931d87", 3, true },
                    { "81b8a64f-fa24-4cdf-a94d-ab1acd5597f8", 8, true },
                    { "8b8c27db-812d-47ba-a927-c84b1aacb645", 3, true },
                    { "8d64652a-9817-4172-82cd-8d32f42f2db6", 7, true },
                    { "8f391bcb-df75-475a-a481-4aca008508c9", 8, true },
                    { "8fde2dd6-cffe-4dca-b5a1-f3bb2a2d869b", 8, true },
                    { "9457e4ad-c052-4b0d-9a77-f717b44fe246", 8, true },
                    { "9d65d32c-4ed3-4ba9-a72e-4491f5df921b", 7, true },
                    { "a7fa66b0-4aed-4409-afff-272b8aaa2907", 3, true },
                    { "aded3147-1b49-44da-a7d0-765912bdaf37", 3, true },
                    { "b1f980d2-eeea-400a-8c88-a7793ac59e82", 1, true },
                    { "b1faccab-3207-418b-9e44-4a78ed008612", 2, true },
                    { "b4dc7510-7624-4329-a270-2487e28692e8", 7, true },
                    { "b6f1c0f1-5bca-4677-b4ac-59df9694b308", 3, true },
                    { "bb2caa99-1ced-4c4d-b197-178257ce2e5f", 7, true },
                    { "bc30683e-b23d-4dfa-ac61-a6eb24670952", 3, true },
                    { "c43a68a0-4e1e-4b6b-a60e-7689d2b8ee85", 9, true },
                    { "cb86ec9e-bc98-4973-aa47-bba78cfab53b", 1, true },
                    { "cc1fbb3a-6ba8-400a-b00c-88d70619c5ef", 3, true },
                    { "ccfe848a-ff30-4948-a9bb-4494f5ef7442", 8, true },
                    { "ce61ea89-8818-44ae-8b16-6366761a6313", 8, true },
                    { "d56aa3bd-b1c7-4edb-9186-ffb1971348aa", 3, true },
                    { "daab1bfe-16da-42f4-b553-5747b916d7e1", 6, true },
                    { "dd8698f5-ffee-41a8-b5e7-89647e015669", 6, true },
                    { "ddf4e679-1d22-45c7-b332-c3955d8b798a", 8, true },
                    { "e4d90733-3e62-4b97-926a-54561fb63ae3", 2, true },
                    { "e51b4197-c122-49c1-ab25-5a4716a73e33", 2, true },
                    { "ea76119b-5ded-497f-a4fb-7091bd52d82a", 8, true },
                    { "eac2f179-0bc8-406c-acba-49812724b40d", 8, true },
                    { "ec3ba1cd-24de-4012-865b-c8cd4e59dac4", 6, true },
                    { "ef563ec2-99e3-4aa0-b9c9-3bc6deac215f", 6, true },
                    { "fc9db39e-6880-41ba-b723-2daff5dc03f2", 5, true }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "0cb96c55-c6ba-4e81-bdc2-209d7b957282" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "1066cc51-a1ab-4767-a91f-7459610a7092" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "112c0553-9717-4894-9590-7246e414e899" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "133a1335-8c77-48d2-a556-09e94fe742cb" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "182a6b63-09a3-4744-b03b-7b09dde76618" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "1bcfd888-c765-449d-a286-bcca98b19c19" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "2377e694-030a-4ef6-8590-99f0ccb8c583" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "249f0ae9-9fb9-4d7d-864a-aa058cf6d1c9" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "3415e8da-751f-4450-8327-6e42ab913dae" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "4ecfc6da-b7a5-4b90-9846-4784ce99a2e2" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "523f552e-c26f-432c-9bd5-66a4464db93e" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "5449f2bb-06a1-4291-b108-404103418fd6" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "57a6f1e7-0d26-428f-aebd-ec233a1ba643" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "5993c6c2-b79c-40ac-8e69-d1e26794c0a8" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "60cae427-0d8f-4873-84dd-5e9212a0664c" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "6631fef5-5287-4ca2-abd7-4621ad392c86" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "69cb26a9-9508-46c0-bc6e-fa217aa75a13" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "7573173a-8c71-41f6-a352-5a064aee1dac" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "776ac473-3f9a-4f09-8b4e-0225a72f428c" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "7b4f4718-f143-4d36-b210-6e4924931d87" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "81b8a64f-fa24-4cdf-a94d-ab1acd5597f8" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "8b8c27db-812d-47ba-a927-c84b1aacb645" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "8d64652a-9817-4172-82cd-8d32f42f2db6" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "8f391bcb-df75-475a-a481-4aca008508c9" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "8fde2dd6-cffe-4dca-b5a1-f3bb2a2d869b" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "9457e4ad-c052-4b0d-9a77-f717b44fe246" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "9d65d32c-4ed3-4ba9-a72e-4491f5df921b" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "a7fa66b0-4aed-4409-afff-272b8aaa2907" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "aded3147-1b49-44da-a7d0-765912bdaf37" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "b1f980d2-eeea-400a-8c88-a7793ac59e82" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "b1faccab-3207-418b-9e44-4a78ed008612" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "b4dc7510-7624-4329-a270-2487e28692e8" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "b6f1c0f1-5bca-4677-b4ac-59df9694b308" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "bb2caa99-1ced-4c4d-b197-178257ce2e5f" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "bc30683e-b23d-4dfa-ac61-a6eb24670952" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "c43a68a0-4e1e-4b6b-a60e-7689d2b8ee85" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "cb86ec9e-bc98-4973-aa47-bba78cfab53b" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "cc1fbb3a-6ba8-400a-b00c-88d70619c5ef" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "ccfe848a-ff30-4948-a9bb-4494f5ef7442" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "ce61ea89-8818-44ae-8b16-6366761a6313" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "d56aa3bd-b1c7-4edb-9186-ffb1971348aa" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "daab1bfe-16da-42f4-b553-5747b916d7e1" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "dd8698f5-ffee-41a8-b5e7-89647e015669" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "ddf4e679-1d22-45c7-b332-c3955d8b798a" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "e4d90733-3e62-4b97-926a-54561fb63ae3" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "e51b4197-c122-49c1-ab25-5a4716a73e33" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "ea76119b-5ded-497f-a4fb-7091bd52d82a" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "eac2f179-0bc8-406c-acba-49812724b40d" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "ec3ba1cd-24de-4012-865b-c8cd4e59dac4" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "ef563ec2-99e3-4aa0-b9c9-3bc6deac215f" },
                    { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "fc9db39e-6880-41ba-b723-2daff5dc03f2" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "CompanyId", "ConcurrencyStamp", "DateCreated", "DateOfBirth", "Email", "EmailConfirmed", "Ethnicity", "FirstName", "GPA", "Gender", "GraduationDate", "IsActive", "LastLoginDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PositionType", "SecurityStamp", "SystemDate", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "30caf059-b889-45c0-bcc8-062f0f57a06d", 0, null, 10, "bfef7b33-0a91-4a9a-aab7-bf68f6c3e54b", new DateTime(2023, 4, 23, 21, 59, 22, 632, DateTimeKind.Local).AddTicks(6200), null, "hicks43@ggmail.com", false, "Asian", "Anthony", 0m, "F", null, true, null, "Hicks", false, null, "HICKS43@GGMAIL.COM", "HICKS43@GGMAIL.COM", "AQAAAAIAAYagAAAAEMyCc5+AzZiKnjlBvznzFEdDsGJ6sljKmxJ+5odMiwrZ5LFdJWqOicfDuCY+kh+4dw==", null, false, "FT", "a2fb2d69-6f95-432d-bda9-a11823427c96", new DateTime(2023, 4, 23, 21, 59, 22, 632, DateTimeKind.Local).AddTicks(6210), false, "hicks43@ggmail.com" },
                    { "3358b2db-cdd0-4b15-bd97-c97ae08d172f", 0, null, 4, "76506b60-4ce8-45e2-902a-0e639fde5ccb", new DateTime(2023, 4, 23, 21, 59, 22, 781, DateTimeKind.Local).AddTicks(5660), null, "or@aool.com", false, "Asian", "Anka", 0m, "F", null, true, null, "Radkovich", false, null, "OR@AOOL.COM", "OR@AOOL.COM", "AQAAAAIAAYagAAAAENEqjiJJaCJ6c/RwN5Zz68E+tg4vJyxAJd2FigQSGDLa3s9SWskASBGwM55yDPyu3w==", null, false, "FT", "17f10d51-7c1d-4b58-ac2a-15426a6e4235", new DateTime(2023, 4, 23, 21, 59, 22, 781, DateTimeKind.Local).AddTicks(5670), false, "or@aool.com" },
                    { "34f24e25-36a7-4293-b497-ad8329741278", 0, null, 3, "6e3403b3-b972-4bf9-8405-7082538a9a58", new DateTime(2023, 4, 23, 21, 59, 22, 292, DateTimeKind.Local).AddTicks(1140), null, "mclarence@aool.com", false, "Asian", "Clarence", 0m, "F", null, true, null, "Martin", false, null, "MCLARENCE@AOOL.COM", "MCLARENCE@AOOL.COM", "AQAAAAIAAYagAAAAEG8q7k1+kLYpXn9wJgjxVr1ELNmdnX3jz6AIfHKxXxn2OuLrv9wRJoASw5PHdl++ag==", null, false, "FT", "35e2cece-9997-4ce3-9d36-11d13d457455", new DateTime(2023, 4, 23, 21, 59, 22, 292, DateTimeKind.Local).AddTicks(1140), false, "mclarence@aool.com" },
                    { "39df0958-b951-47ab-8c70-30708af91bf3", 0, null, 10, "ebd34f2d-d58b-47b2-852d-4b657e08ab03", new DateTime(2023, 4, 23, 21, 59, 22, 670, DateTimeKind.Local).AddTicks(910), null, "orielly@foxnets.com", false, "Asian", "Bill", 0m, "F", null, true, null, "O'Reilly", false, null, "ORIELLY@FOXNETS.COM", "ORIELLY@FOXNETS.COM", "AQAAAAIAAYagAAAAEILL8V1BU8Y1BfUqI5Ifzh0IKGdB0beQpr+XKXXwUQDa4GrEbSSgQgvIkVgioHhGyg==", null, false, "FT", "32c8c81d-8545-4502-8118-22d19f857ce0", new DateTime(2023, 4, 23, 21, 59, 22, 670, DateTimeKind.Local).AddTicks(910), false, "orielly@foxnets.com" },
                    { "4955ae5a-39a7-4e7f-857e-102d10c26c77", 0, null, 2, "7828a65c-38ff-42de-8c11-e90232d579cf", new DateTime(2023, 4, 23, 21, 59, 22, 253, DateTimeKind.Local).AddTicks(8560), null, "elowe@netscrape.net", false, "Asian", "Ernest", 0m, "F", null, true, null, "Lowe", false, null, "ELOWE@NETSCRAPE.NET", "ELOWE@NETSCRAPE.NET", "AQAAAAIAAYagAAAAEOxiwFs9+NBiOq+5r2Bx46BNJYrJHSID1VYaEvbUrvbehk/MyWK+JOHbMxGLTUkE7Q==", null, false, "FT", "1a8514e7-9786-4945-aec7-a555dbf59054", new DateTime(2023, 4, 23, 21, 59, 22, 253, DateTimeKind.Local).AddTicks(8560), false, "elowe@netscrape.net" },
                    { "5cb15e84-86ac-4b42-b60f-8989c5a063e3", 0, null, 12, "69731011-682d-43d7-8f62-69583ebfe815", new DateTime(2023, 4, 23, 21, 59, 22, 818, DateTimeKind.Local).AddTicks(6330), null, "tanner@ggmail.com", false, "Asian", "Jeremy", 0m, "F", null, true, null, "Tanner", false, null, "TANNER@GGMAIL.COM", "TANNER@GGMAIL.COM", "AQAAAAIAAYagAAAAEPtWXcmmTwPY102FOyANWLzpJD/FGs9mBP4K68dI+1GHog8Zwbe5j1z9Z7JecUG/VA==", null, false, "FT", "56ce4571-b663-4a49-ad4a-f21431006efc", new DateTime(2023, 4, 23, 21, 59, 22, 818, DateTimeKind.Local).AddTicks(6340), false, "tanner@ggmail.com" },
                    { "5f4072f1-4938-499f-9287-503a5f536b76", 0, null, 3, "b5eb7277-d49f-4a53-ae3b-60efea7e0ba2", new DateTime(2023, 4, 23, 21, 59, 22, 368, DateTimeKind.Local).AddTicks(4710), null, "megrhodes@freezing.co.uk", false, "Asian", "Megan", 0m, "F", null, true, null, "Rhodes", false, null, "MEGRHODES@FREEZING.CO.UK", "MEGRHODES@FREEZING.CO.UK", "AQAAAAIAAYagAAAAELrnOiixzDC0DvgnZ/9cBC0aTYt7BywYAYilqWOx3IplvaroRbV2H97w6Ok3WyMmeg==", null, false, "FT", "97077a04-d0ec-4a29-b621-95de04b0bfd0", new DateTime(2023, 4, 23, 21, 59, 22, 368, DateTimeKind.Local).AddTicks(4730), false, "megrhodes@freezing.co.uk" },
                    { "7499a7ad-44e0-40f5-b044-163cc86e8e5f", 0, null, 13, "e64aa49b-1cf9-4093-9b0b-57745799f71f", new DateTime(2023, 4, 23, 21, 59, 22, 892, DateTimeKind.Local).AddTicks(9520), null, "target_spot@example.com", false, "Asian", "Spot", 0m, "F", null, true, null, "Dog", false, null, "TARGET_SPOT@EXAMPLE.COM", "TARGET_SPOT@EXAMPLE.COM", "AQAAAAIAAYagAAAAEB5lj3BcUGqseZEez/7LjsQI0egQjg/UkhcoMP46yfof7f6zQPNV8sIsUqKFQR3/+g==", null, false, "FT", "f4999092-4c36-479e-b19c-59f26c99967a", new DateTime(2023, 4, 23, 21, 59, 22, 892, DateTimeKind.Local).AddTicks(9520), false, "target_spot@example.com" },
                    { "7781ee93-7275-42a4-8240-0a76a05fd402", 0, null, 11, "2a1121d7-e72d-4b75-ba87-b3c48583b458", new DateTime(2023, 4, 23, 21, 59, 22, 855, DateTimeKind.Local).AddTicks(7550), null, "tee_frank@hootmail.com", false, "Asian", "Frank", 0m, "F", null, true, null, "Tee", false, null, "TEE_FRANK@HOOTMAIL.COM", "TEE_FRANK@HOOTMAIL.COM", "AQAAAAIAAYagAAAAEA3UDvEFxWFPY97obwbu3h+NdMCMQAaLM4xBN8KEbPI1MdhlWW5N/BhAUlzRz2dEXQ==", null, false, "FT", "872d76d3-8cb8-42ce-b829-9c9d8604b8a4", new DateTime(2023, 4, 23, 21, 59, 22, 855, DateTimeKind.Local).AddTicks(7550), false, "tee_frank@hootmail.com" },
                    { "7adb64f0-0d74-4449-b469-daa8799f20b4", 0, null, 1, "f7d2cb69-3b17-411a-8bb4-0e9757d2af2f", new DateTime(2023, 4, 23, 21, 59, 22, 177, DateTimeKind.Local).AddTicks(4020), null, "michelle@example.com", false, "Asian", "Michelle", 0m, "F", null, true, null, "Banks", false, null, "MICHELLE@EXAMPLE.COM", "MICHELLE@EXAMPLE.COM", "AQAAAAIAAYagAAAAEDpvcFF5ZD52C9isFHn4s9J36CXgoKw4+/o7orARjWgURo4+fZFFSy425HuumrXUtA==", null, false, "FT", "498d36e1-a241-40bb-b94f-4978df103362", new DateTime(2023, 4, 23, 21, 59, 22, 177, DateTimeKind.Local).AddTicks(4040), false, "michelle@example.com" },
                    { "7dbe4c9e-a015-47cb-8098-57a60cfccc4b", 0, null, 8, "12366a5a-0d6b-486d-94ca-025dc8151444", new DateTime(2023, 4, 23, 21, 59, 22, 558, DateTimeKind.Local).AddTicks(2390), null, "taylordjay@aool.com", false, "Asian", "Allison", 0m, "F", null, true, null, "Taylor", false, null, "TAYLORDJAY@AOOL.COM", "TAYLORDJAY@AOOL.COM", "AQAAAAIAAYagAAAAEMkIpWIVv83S25oT6VhMXu6jFiqULrHigA+54JxHsT0qvyb5tMiNs7sew13pwlDWrA==", null, false, "FT", "643f235e-2bc5-40b6-9af6-5d8e3f95710c", new DateTime(2023, 4, 23, 21, 59, 22, 558, DateTimeKind.Local).AddTicks(2400), false, "taylordjay@aool.com" },
                    { "92a565c6-4096-4b59-99c6-aee76311b68a", 0, null, 7, "87e3f422-777b-4195-948e-5b6da1f25ee5", new DateTime(2023, 4, 23, 21, 59, 22, 521, DateTimeKind.Local).AddTicks(650), null, "tuck33@ggmail.com", false, "Asian", "Clent", 0m, "F", null, true, null, "Tucker", false, null, "TUCK33@GGMAIL.COM", "TUCK33@GGMAIL.COM", "AQAAAAIAAYagAAAAEL0leAoc6NMtt3mmPOpwJAsiEBwOIfEMdiakOHDBAMtf89Qux0vMXzRrNOWVi9p3/A==", null, false, "FT", "67fd9f41-1280-48a6-8d5a-04cb323a4f75", new DateTime(2023, 4, 23, 21, 59, 22, 521, DateTimeKind.Local).AddTicks(650), false, "tuck33@ggmail.com" },
                    { "a0cec485-38d5-4365-8081-5b285943df45", 0, null, 10, "383916d4-3ee5-4140-9dd8-fd7d65537a7b", new DateTime(2023, 4, 23, 21, 59, 22, 707, DateTimeKind.Local).AddTicks(3020), null, "louielouie@aool.com", false, "Asian", "Louis", 0m, "F", null, true, null, "Winthorpe", false, null, "LOUIELOUIE@AOOL.COM", "LOUIELOUIE@AOOL.COM", "AQAAAAIAAYagAAAAEMJEMDuguWfmzwiEtitxPUsu1H4sJYt04p0MouD3LfBZw4+fhLgOo/+dzyxt4DtMfw==", null, false, "FT", "3a9a57a2-94a5-450f-a7b9-ba94726c976b", new DateTime(2023, 4, 23, 21, 59, 22, 707, DateTimeKind.Local).AddTicks(3030), false, "louielouie@aool.com" },
                    { "ab89fdf5-cbd2-49c3-b01f-025ae7f9e046", 0, null, 9, "53f1eb5b-2f9d-4b0c-be45-5f26dbc35812", new DateTime(2023, 4, 23, 21, 59, 22, 595, DateTimeKind.Local).AddTicks(3850), null, "jojoe@ggmail.com", false, "Asian", "Joe", 0m, "F", null, true, null, "Nguyen", false, null, "JOJOE@GGMAIL.COM", "JOJOE@GGMAIL.COM", "AQAAAAIAAYagAAAAEPt2Txst8fx7FZfNJMSuRWz6VPfWb+sLcrzI0qOCl+FKEF6sXHr0XvYuutZsj/VYIQ==", null, false, "FT", "918ba746-8b3a-4de7-aabb-e2310ab16078", new DateTime(2023, 4, 23, 21, 59, 22, 595, DateTimeKind.Local).AddTicks(3850), false, "jojoe@ggmail.com" },
                    { "ac036877-901d-464a-b02e-494acf94ad4d", 0, null, 5, "c04fbe75-249c-4aa0-9fbe-0a7f51cb24d4", new DateTime(2023, 4, 23, 21, 59, 22, 445, DateTimeKind.Local).AddTicks(2370), null, "peterstump@hootmail.com", false, "Asian", "Peter", 0m, "F", null, true, null, "Stump", false, null, "PETERSTUMP@HOOTMAIL.COM", "PETERSTUMP@HOOTMAIL.COM", "AQAAAAIAAYagAAAAEGVKjtTJbMuutrw1pOw3EIEewWNOWTN2/0kylu6gsatVuUrJzflMsJ95wsrC6Wt78w==", null, false, "FT", "c914e492-7bb2-4eb8-8136-79633b8ba528", new DateTime(2023, 4, 23, 21, 59, 22, 445, DateTimeKind.Local).AddTicks(2370), false, "peterstump@hootmail.com" },
                    { "c5506eb1-7594-4e74-bac7-04ecf82cca5f", 0, null, 4, "98e7f1db-5bfa-4af1-8fd9-8b7703478350", new DateTime(2023, 4, 23, 21, 59, 22, 744, DateTimeKind.Local).AddTicks(3940), null, "smartinmartin.Martin@aool.com", false, "Asian", "Gregory", 0m, "F", null, true, null, "Martinez", false, null, "SMARTINMARTIN.MARTIN@AOOL.COM", "SMARTINMARTIN.MARTIN@AOOL.COM", "AQAAAAIAAYagAAAAEGDb9NljHpYkGPXbsZpnVYtV1qJVGk0B+AajAEBSXru3aIE2ba+qmYw/F71tqV1e4w==", null, false, "FT", "9eb61932-51a3-45be-81d9-4d2674b7f321", new DateTime(2023, 4, 23, 21, 59, 22, 744, DateTimeKind.Local).AddTicks(3940), false, "smartinmartin.Martin@aool.com" },
                    { "dbbf9288-ae29-4d22-a1cd-8a4fe86ebf50", 0, null, 3, "d0f333e4-3682-4849-a633-f96715da73f1", new DateTime(2023, 4, 23, 21, 59, 22, 330, DateTimeKind.Local).AddTicks(2910), null, "nelson.Kelly@aool.com", false, "Asian", "Kelly", 0m, "F", null, true, null, "Nelson", false, null, "NELSON.KELLY@AOOL.COM", "NELSON.KELLY@AOOL.COM", "AQAAAAIAAYagAAAAENd0RczSJEaCySORsjjXkRMLQPoSk/t3VnJclkS1Ln6qvTwPlv5CyWn6xOMmCwDPsw==", null, false, "FT", "dfed3961-ae25-480a-a70a-efd790da50a3", new DateTime(2023, 4, 23, 21, 59, 22, 330, DateTimeKind.Local).AddTicks(2910), false, "nelson.Kelly@aool.com" },
                    { "df8f08ba-e7e0-467a-a048-dbf9f75b19ce", 0, null, 1, "557ddc07-9d01-44c1-9cef-ce83fe98a053", new DateTime(2023, 4, 23, 21, 59, 22, 215, DateTimeKind.Local).AddTicks(6010), null, "toddy@aool.com", false, "Asian", "Todd", 0m, "F", null, true, null, "Jacobs", false, null, "TODDY@AOOL.COM", "TODDY@AOOL.COM", "AQAAAAIAAYagAAAAEHjyiG+CEahug8VdSn5Q48eskHwM/6vongTOU8NdS0apZkY9sVvHfdA/e7nZxoU5VA==", null, false, "FT", "00881773-9db9-437c-a1cf-2c356c108815", new DateTime(2023, 4, 23, 21, 59, 22, 215, DateTimeKind.Local).AddTicks(6020), false, "toddy@aool.com" },
                    { "e841f6c0-ad73-4c41-88bf-3b70e014f8ca", 0, null, 6, "92915a56-8d7b-42d1-833f-ea3c89be2a55", new DateTime(2023, 4, 23, 21, 59, 22, 483, DateTimeKind.Local).AddTicks(7140), null, "yhuik9.Taylor@aool.com", false, "Asian", "Rachel", 0m, "F", null, true, null, "Taylor", false, null, "YHUIK9.TAYLOR@AOOL.COM", "YHUIK9.TAYLOR@AOOL.COM", "AQAAAAIAAYagAAAAEEu74/MQ0Vx8H47Q66mVSgo8gipxGbYJW2clSIJjQoFuOgaEyT0xZUqbQCRuqSIYbQ==", null, false, "FT", "4552aecb-788b-483d-8921-1b3279685e37", new DateTime(2023, 4, 23, 21, 59, 22, 483, DateTimeKind.Local).AddTicks(7150), false, "yhuik9.Taylor@aool.com" },
                    { "fc557e69-6813-435f-b1f2-233dddfca80e", 0, null, 5, "cc0b5c0c-3e8c-4557-957b-46b977057772", new DateTime(2023, 4, 23, 21, 59, 22, 406, DateTimeKind.Local).AddTicks(7770), null, "sheff44@ggmail.com", false, "Asian", "Martin", 0m, "F", null, true, null, "Sheffield", false, null, "SHEFF44@GGMAIL.COM", "SHEFF44@GGMAIL.COM", "AQAAAAIAAYagAAAAEH+0yfb/r+w0S7Y5WSy0OJojYX8bT7VJkGiS6RTTMARo3ErbNSAgTOjcVQvY+A2Nng==", null, false, "FT", "df322145-1629-47ff-ba86-375c6596e417", new DateTime(2023, 4, 23, 21, 59, 22, 406, DateTimeKind.Local).AddTicks(7770), false, "sheff44@ggmail.com" }
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
                    { 1, new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(1930), null, 5, "Accepted", "112c0553-9717-4894-9590-7246e414e899", true },
                    { 2, new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(1960), null, 5, "Accepted", "ec3ba1cd-24de-4012-865b-c8cd4e59dac4", true },
                    { 3, new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(1980), null, 15, "Accepted", "6631fef5-5287-4ca2-abd7-4621ad392c86", true },
                    { 4, new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2000), null, 12, "Accepted", "69cb26a9-9508-46c0-bc6e-fa217aa75a13", true },
                    { 5, new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2020), null, 8, "Accepted", "eac2f179-0bc8-406c-acba-49812724b40d", true },
                    { 6, new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2030), null, 13, "Accepted", "ec3ba1cd-24de-4012-865b-c8cd4e59dac4", true },
                    { 7, new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2050), null, 13, "Accepted", "1066cc51-a1ab-4767-a91f-7459610a7092", true },
                    { 8, new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2060), null, 13, "Accepted", "a7fa66b0-4aed-4409-afff-272b8aaa2907", true },
                    { 9, new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2070), null, 20, "Accepted", "5993c6c2-b79c-40ac-8e69-d1e26794c0a8", true },
                    { 10, new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2090), null, 20, "Accepted", "9d65d32c-4ed3-4ba9-a72e-4491f5df921b", true },
                    { 11, new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2100), null, 9, "Accepted", "7b4f4718-f143-4d36-b210-6e4924931d87", true },
                    { 12, new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2120), null, 11, "Accepted", "523f552e-c26f-432c-9bd5-66a4464db93e", true },
                    { 13, new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2130), null, 3, "Accepted", "69cb26a9-9508-46c0-bc6e-fa217aa75a13", true },
                    { 14, new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2150), null, 3, "Accepted", "e4d90733-3e62-4b97-926a-54561fb63ae3", true },
                    { 15, new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2160), null, 12, "Accepted", "cb86ec9e-bc98-4973-aa47-bba78cfab53b", true },
                    { 16, new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2170), null, 12, "Pending", "776ac473-3f9a-4f09-8b4e-0225a72f428c", true },
                    { 17, new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2200), null, 26, "Pending", "776ac473-3f9a-4f09-8b4e-0225a72f428c", true },
                    { 18, new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2220), null, 3, "Pending", "776ac473-3f9a-4f09-8b4e-0225a72f428c", true }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "30caf059-b889-45c0-bcc8-062f0f57a06d" },
                    { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "3358b2db-cdd0-4b15-bd97-c97ae08d172f" },
                    { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "34f24e25-36a7-4293-b497-ad8329741278" },
                    { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "39df0958-b951-47ab-8c70-30708af91bf3" },
                    { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "4955ae5a-39a7-4e7f-857e-102d10c26c77" },
                    { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "5cb15e84-86ac-4b42-b60f-8989c5a063e3" },
                    { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "5f4072f1-4938-499f-9287-503a5f536b76" },
                    { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "7499a7ad-44e0-40f5-b044-163cc86e8e5f" },
                    { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "7781ee93-7275-42a4-8240-0a76a05fd402" },
                    { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "7adb64f0-0d74-4449-b469-daa8799f20b4" },
                    { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "7dbe4c9e-a015-47cb-8098-57a60cfccc4b" },
                    { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "92a565c6-4096-4b59-99c6-aee76311b68a" },
                    { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "a0cec485-38d5-4365-8081-5b285943df45" },
                    { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "ab89fdf5-cbd2-49c3-b01f-025ae7f9e046" },
                    { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "ac036877-901d-464a-b02e-494acf94ad4d" },
                    { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "c5506eb1-7594-4e74-bac7-04ecf82cca5f" },
                    { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "dbbf9288-ae29-4d22-a1cd-8a4fe86ebf50" },
                    { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "df8f08ba-e7e0-467a-a048-dbf9f75b19ce" },
                    { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "e841f6c0-ad73-4c41-88bf-3b70e014f8ca" },
                    { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "fc557e69-6813-435f-b1f2-233dddfca80e" }
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
                    { 1, 1, "7dbe4c9e-a015-47cb-8098-57a60cfccc4b", new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2290), new DateTime(2023, 5, 13, 13, 0, 0, 0, DateTimeKind.Unspecified), "7dbe4c9e-a015-47cb-8098-57a60cfccc4b", "Two", true },
                    { 2, 2, "7dbe4c9e-a015-47cb-8098-57a60cfccc4b", new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2340), new DateTime(2023, 5, 14, 13, 0, 0, 0, DateTimeKind.Unspecified), "7dbe4c9e-a015-47cb-8098-57a60cfccc4b", "Two", true },
                    { 3, 3, "a0cec485-38d5-4365-8081-5b285943df45", new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2350), new DateTime(2023, 5, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), "a0cec485-38d5-4365-8081-5b285943df45", "Two", true },
                    { 4, 4, "34f24e25-36a7-4293-b497-ad8329741278", new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2370), new DateTime(2023, 5, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "34f24e25-36a7-4293-b497-ad8329741278", "One", true },
                    { 5, 5, "c5506eb1-7594-4e74-bac7-04ecf82cca5f", new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2390), new DateTime(2023, 5, 16, 14, 0, 0, 0, DateTimeKind.Unspecified), "c5506eb1-7594-4e74-bac7-04ecf82cca5f", "Two", true },
                    { 6, 6, "e841f6c0-ad73-4c41-88bf-3b70e014f8ca", new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2400), new DateTime(2023, 4, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "e841f6c0-ad73-4c41-88bf-3b70e014f8ca", "One", true },
                    { 7, 7, "e841f6c0-ad73-4c41-88bf-3b70e014f8ca", new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2410), new DateTime(2023, 4, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "e841f6c0-ad73-4c41-88bf-3b70e014f8ca", "One", true },
                    { 8, 8, "e841f6c0-ad73-4c41-88bf-3b70e014f8ca", new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2430), new DateTime(2023, 4, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), "e841f6c0-ad73-4c41-88bf-3b70e014f8ca", "Four", true },
                    { 9, 9, "4955ae5a-39a7-4e7f-857e-102d10c26c77", new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2440), new DateTime(2023, 5, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "4955ae5a-39a7-4e7f-857e-102d10c26c77", "One", true },
                    { 10, 10, "4955ae5a-39a7-4e7f-857e-102d10c26c77", new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2460), new DateTime(2023, 5, 10, 11, 0, 0, 0, DateTimeKind.Unspecified), "4955ae5a-39a7-4e7f-857e-102d10c26c77", "One", true },
                    { 11, 11, "3358b2db-cdd0-4b15-bd97-c97ae08d172f", new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2470), new DateTime(2023, 5, 16, 15, 0, 0, 0, DateTimeKind.Unspecified), "3358b2db-cdd0-4b15-bd97-c97ae08d172f", "Three", true },
                    { 12, 12, "dbbf9288-ae29-4d22-a1cd-8a4fe86ebf50", new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2480), new DateTime(2023, 5, 16, 11, 0, 0, 0, DateTimeKind.Unspecified), "dbbf9288-ae29-4d22-a1cd-8a4fe86ebf50", "Four", true },
                    { 13, 13, "7adb64f0-0d74-4449-b469-daa8799f20b4", new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2490), new DateTime(2023, 6, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), "7adb64f0-0d74-4449-b469-daa8799f20b4", "Three", true },
                    { 14, 14, "df8f08ba-e7e0-467a-a048-dbf9f75b19ce", new DateTime(2023, 4, 23, 21, 59, 24, 828, DateTimeKind.Local).AddTicks(2500), new DateTime(2023, 6, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), "df8f08ba-e7e0-467a-a048-dbf9f75b19ce", "Three", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "0cb96c55-c6ba-4e81-bdc2-209d7b957282", 3 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "1066cc51-a1ab-4767-a91f-7459610a7092", 1 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "112c0553-9717-4894-9590-7246e414e899", 6 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "133a1335-8c77-48d2-a556-09e94fe742cb", 4 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "182a6b63-09a3-4744-b03b-7b09dde76618", 2 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "1bcfd888-c765-449d-a286-bcca98b19c19", 8 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "2377e694-030a-4ef6-8590-99f0ccb8c583", 8 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "249f0ae9-9fb9-4d7d-864a-aa058cf6d1c9", 2 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "3415e8da-751f-4450-8327-6e42ab913dae", 5 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "4ecfc6da-b7a5-4b90-9846-4784ce99a2e2", 5 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "523f552e-c26f-432c-9bd5-66a4464db93e", 1 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "5449f2bb-06a1-4291-b108-404103418fd6", 4 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "57a6f1e7-0d26-428f-aebd-ec233a1ba643", 9 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "5993c6c2-b79c-40ac-8e69-d1e26794c0a8", 7 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "60cae427-0d8f-4873-84dd-5e9212a0664c", 8 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "6631fef5-5287-4ca2-abd7-4621ad392c86", 5 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "69cb26a9-9508-46c0-bc6e-fa217aa75a13", 2 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "7573173a-8c71-41f6-a352-5a064aee1dac", 3 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "776ac473-3f9a-4f09-8b4e-0225a72f428c", 1 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "7b4f4718-f143-4d36-b210-6e4924931d87", 3 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "81b8a64f-fa24-4cdf-a94d-ab1acd5597f8", 8 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "8b8c27db-812d-47ba-a927-c84b1aacb645", 3 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "8d64652a-9817-4172-82cd-8d32f42f2db6", 7 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "8f391bcb-df75-475a-a481-4aca008508c9", 8 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "8fde2dd6-cffe-4dca-b5a1-f3bb2a2d869b", 8 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "9457e4ad-c052-4b0d-9a77-f717b44fe246", 8 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "9d65d32c-4ed3-4ba9-a72e-4491f5df921b", 7 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "a7fa66b0-4aed-4409-afff-272b8aaa2907", 3 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "aded3147-1b49-44da-a7d0-765912bdaf37", 3 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "b1f980d2-eeea-400a-8c88-a7793ac59e82", 1 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "b1faccab-3207-418b-9e44-4a78ed008612", 2 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "b4dc7510-7624-4329-a270-2487e28692e8", 7 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "b6f1c0f1-5bca-4677-b4ac-59df9694b308", 3 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "bb2caa99-1ced-4c4d-b197-178257ce2e5f", 7 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "bc30683e-b23d-4dfa-ac61-a6eb24670952", 3 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "c43a68a0-4e1e-4b6b-a60e-7689d2b8ee85", 9 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "cb86ec9e-bc98-4973-aa47-bba78cfab53b", 1 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "cc1fbb3a-6ba8-400a-b00c-88d70619c5ef", 3 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "ccfe848a-ff30-4948-a9bb-4494f5ef7442", 8 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "ce61ea89-8818-44ae-8b16-6366761a6313", 8 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "d56aa3bd-b1c7-4edb-9186-ffb1971348aa", 3 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "daab1bfe-16da-42f4-b553-5747b916d7e1", 6 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "dd8698f5-ffee-41a8-b5e7-89647e015669", 6 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "ddf4e679-1d22-45c7-b332-c3955d8b798a", 8 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "e4d90733-3e62-4b97-926a-54561fb63ae3", 2 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "e51b4197-c122-49c1-ab25-5a4716a73e33", 2 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "ea76119b-5ded-497f-a4fb-7091bd52d82a", 8 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "eac2f179-0bc8-406c-acba-49812724b40d", 8 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "ec3ba1cd-24de-4012-865b-c8cd4e59dac4", 6 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "ef563ec2-99e3-4aa0-b9c9-3bc6deac215f", 6 });

            migrationBuilder.DeleteData(
                table: "AppUserMajors",
                keyColumns: new[] { "AppUserId", "MajorId" },
                keyValues: new object[] { "fc9db39e-6880-41ba-b723-2daff5dc03f2", 5 });

            migrationBuilder.DeleteData(
                table: "AppUserPositions",
                keyColumn: "AppUserPositionId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AppUserPositions",
                keyColumn: "AppUserPositionId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AppUserPositions",
                keyColumn: "AppUserPositionId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AppUserPositions",
                keyColumn: "AppUserPositionId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "0cb96c55-c6ba-4e81-bdc2-209d7b957282" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "1066cc51-a1ab-4767-a91f-7459610a7092" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "112c0553-9717-4894-9590-7246e414e899" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "133a1335-8c77-48d2-a556-09e94fe742cb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d2e5e116-d5fd-45df-a531-aa661fec879c", "13f522a5-c59c-4c75-b767-6077ca503450" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "182a6b63-09a3-4744-b03b-7b09dde76618" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "1bcfd888-c765-449d-a286-bcca98b19c19" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "2377e694-030a-4ef6-8590-99f0ccb8c583" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "249f0ae9-9fb9-4d7d-864a-aa058cf6d1c9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "30caf059-b889-45c0-bcc8-062f0f57a06d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "3358b2db-cdd0-4b15-bd97-c97ae08d172f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "3415e8da-751f-4450-8327-6e42ab913dae" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "34f24e25-36a7-4293-b497-ad8329741278" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "39df0958-b951-47ab-8c70-30708af91bf3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d2e5e116-d5fd-45df-a531-aa661fec879c", "3b6e8ffc-8aa1-4e52-8c14-d01a3daeb582" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "4955ae5a-39a7-4e7f-857e-102d10c26c77" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "4ecfc6da-b7a5-4b90-9846-4784ce99a2e2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "523f552e-c26f-432c-9bd5-66a4464db93e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "5449f2bb-06a1-4291-b108-404103418fd6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "57a6f1e7-0d26-428f-aebd-ec233a1ba643" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "5993c6c2-b79c-40ac-8e69-d1e26794c0a8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "5cb15e84-86ac-4b42-b60f-8989c5a063e3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "5f4072f1-4938-499f-9287-503a5f536b76" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "60cae427-0d8f-4873-84dd-5e9212a0664c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "6631fef5-5287-4ca2-abd7-4621ad392c86" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d2e5e116-d5fd-45df-a531-aa661fec879c", "677b36c2-c5de-497a-8465-b56fe96af334" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "69cb26a9-9508-46c0-bc6e-fa217aa75a13" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "7499a7ad-44e0-40f5-b044-163cc86e8e5f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "7573173a-8c71-41f6-a352-5a064aee1dac" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "776ac473-3f9a-4f09-8b4e-0225a72f428c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "7781ee93-7275-42a4-8240-0a76a05fd402" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "7adb64f0-0d74-4449-b469-daa8799f20b4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "7b4f4718-f143-4d36-b210-6e4924931d87" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "7dbe4c9e-a015-47cb-8098-57a60cfccc4b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "81b8a64f-fa24-4cdf-a94d-ab1acd5597f8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "8b8c27db-812d-47ba-a927-c84b1aacb645" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "8d64652a-9817-4172-82cd-8d32f42f2db6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "8f391bcb-df75-475a-a481-4aca008508c9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "8fde2dd6-cffe-4dca-b5a1-f3bb2a2d869b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "92a565c6-4096-4b59-99c6-aee76311b68a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "9457e4ad-c052-4b0d-9a77-f717b44fe246" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "9d65d32c-4ed3-4ba9-a72e-4491f5df921b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "a0cec485-38d5-4365-8081-5b285943df45" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "a7fa66b0-4aed-4409-afff-272b8aaa2907" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "ab89fdf5-cbd2-49c3-b01f-025ae7f9e046" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "ac036877-901d-464a-b02e-494acf94ad4d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "aded3147-1b49-44da-a7d0-765912bdaf37" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "b1f980d2-eeea-400a-8c88-a7793ac59e82" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "b1faccab-3207-418b-9e44-4a78ed008612" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "b4dc7510-7624-4329-a270-2487e28692e8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "b6f1c0f1-5bca-4677-b4ac-59df9694b308" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "bb2caa99-1ced-4c4d-b197-178257ce2e5f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "bc30683e-b23d-4dfa-ac61-a6eb24670952" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "c43a68a0-4e1e-4b6b-a60e-7689d2b8ee85" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "c5506eb1-7594-4e74-bac7-04ecf82cca5f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "cb86ec9e-bc98-4973-aa47-bba78cfab53b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "cc1fbb3a-6ba8-400a-b00c-88d70619c5ef" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "ccfe848a-ff30-4948-a9bb-4494f5ef7442" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d2e5e116-d5fd-45df-a531-aa661fec879c", "cd2971ad-feae-4428-9e1a-d564b8cb8610" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "ce61ea89-8818-44ae-8b16-6366761a6313" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "d56aa3bd-b1c7-4edb-9186-ffb1971348aa" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "daab1bfe-16da-42f4-b553-5747b916d7e1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "dbbf9288-ae29-4d22-a1cd-8a4fe86ebf50" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "dd8698f5-ffee-41a8-b5e7-89647e015669" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "ddf4e679-1d22-45c7-b332-c3955d8b798a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "df8f08ba-e7e0-467a-a048-dbf9f75b19ce" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "e4d90733-3e62-4b97-926a-54561fb63ae3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "e51b4197-c122-49c1-ab25-5a4716a73e33" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "e841f6c0-ad73-4c41-88bf-3b70e014f8ca" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "ea76119b-5ded-497f-a4fb-7091bd52d82a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "eac2f179-0bc8-406c-acba-49812724b40d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "ec3ba1cd-24de-4012-865b-c8cd4e59dac4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "ef563ec2-99e3-4aa0-b9c9-3bc6deac215f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d2e5e116-d5fd-45df-a531-aa661fec879c", "f9424b1d-fb39-47d4-b3ce-0d2e48bb5e78" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "48da8abf-4c0f-4b2b-8c00-58dac4bceebb", "fc557e69-6813-435f-b1f2-233dddfca80e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eafb2ef1-90c8-4e52-8962-ad68ff67512f", "fc9db39e-6880-41ba-b723-2daff5dc03f2" });

            migrationBuilder.DeleteData(
                table: "CompanyIndustries",
                keyColumns: new[] { "CompanyId", "IndustryId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CompanyIndustries",
                keyColumns: new[] { "CompanyId", "IndustryId" },
                keyValues: new object[] { 1, 11 });

            migrationBuilder.DeleteData(
                table: "CompanyIndustries",
                keyColumns: new[] { "CompanyId", "IndustryId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CompanyIndustries",
                keyColumns: new[] { "CompanyId", "IndustryId" },
                keyValues: new object[] { 2, 14 });

            migrationBuilder.DeleteData(
                table: "CompanyIndustries",
                keyColumns: new[] { "CompanyId", "IndustryId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CompanyIndustries",
                keyColumns: new[] { "CompanyId", "IndustryId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "CompanyIndustries",
                keyColumns: new[] { "CompanyId", "IndustryId" },
                keyValues: new object[] { 3, 11 });

            migrationBuilder.DeleteData(
                table: "CompanyIndustries",
                keyColumns: new[] { "CompanyId", "IndustryId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "CompanyIndustries",
                keyColumns: new[] { "CompanyId", "IndustryId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "CompanyIndustries",
                keyColumns: new[] { "CompanyId", "IndustryId" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "CompanyIndustries",
                keyColumns: new[] { "CompanyId", "IndustryId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "CompanyIndustries",
                keyColumns: new[] { "CompanyId", "IndustryId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "CompanyIndustries",
                keyColumns: new[] { "CompanyId", "IndustryId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "CompanyIndustries",
                keyColumns: new[] { "CompanyId", "IndustryId" },
                keyValues: new object[] { 8, 11 });

            migrationBuilder.DeleteData(
                table: "CompanyIndustries",
                keyColumns: new[] { "CompanyId", "IndustryId" },
                keyValues: new object[] { 9, 10 });

            migrationBuilder.DeleteData(
                table: "CompanyIndustries",
                keyColumns: new[] { "CompanyId", "IndustryId" },
                keyValues: new object[] { 10, 11 });

            migrationBuilder.DeleteData(
                table: "CompanyIndustries",
                keyColumns: new[] { "CompanyId", "IndustryId" },
                keyValues: new object[] { 11, 12 });

            migrationBuilder.DeleteData(
                table: "CompanyIndustries",
                keyColumns: new[] { "CompanyId", "IndustryId" },
                keyValues: new object[] { 12, 13 });

            migrationBuilder.DeleteData(
                table: "CompanyIndustries",
                keyColumns: new[] { "CompanyId", "IndustryId" },
                keyValues: new object[] { 13, 12 });

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "IndustryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "InterviewId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "InterviewId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "InterviewId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "InterviewId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "InterviewId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "InterviewId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "InterviewId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "InterviewId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "InterviewId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "InterviewId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "InterviewId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "InterviewId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "InterviewId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Interviews",
                keyColumn: "InterviewId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 8, 7 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 8, 10 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 1, 11 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 1, 12 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 2, 13 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 3, 13 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 6, 13 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 8, 13 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 8, 14 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 5, 15 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 8, 16 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 6, 17 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 8, 17 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 6, 18 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 8, 18 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 8, 19 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 7, 20 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 7, 21 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 8, 22 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 1, 23 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 2, 23 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 3, 23 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 4, 23 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 5, 23 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 6, 23 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 7, 23 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 8, 23 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 9, 23 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 8, 24 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 1, 25 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 3, 25 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 5, 25 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 6, 25 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 1, 26 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 1, 27 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 2, 27 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 3, 27 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 4, 27 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 6, 27 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 7, 27 });

            migrationBuilder.DeleteData(
                table: "PositionMajors",
                keyColumns: new[] { "MajorId", "PositionId" },
                keyValues: new object[] { 8, 27 });

            migrationBuilder.DeleteData(
                table: "AppUserPositions",
                keyColumn: "AppUserPositionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppUserPositions",
                keyColumn: "AppUserPositionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AppUserPositions",
                keyColumn: "AppUserPositionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AppUserPositions",
                keyColumn: "AppUserPositionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AppUserPositions",
                keyColumn: "AppUserPositionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AppUserPositions",
                keyColumn: "AppUserPositionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AppUserPositions",
                keyColumn: "AppUserPositionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AppUserPositions",
                keyColumn: "AppUserPositionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AppUserPositions",
                keyColumn: "AppUserPositionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AppUserPositions",
                keyColumn: "AppUserPositionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AppUserPositions",
                keyColumn: "AppUserPositionId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AppUserPositions",
                keyColumn: "AppUserPositionId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AppUserPositions",
                keyColumn: "AppUserPositionId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AppUserPositions",
                keyColumn: "AppUserPositionId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48da8abf-4c0f-4b2b-8c00-58dac4bceebb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2e5e116-d5fd-45df-a531-aa661fec879c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eafb2ef1-90c8-4e52-8962-ad68ff67512f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0cb96c55-c6ba-4e81-bdc2-209d7b957282");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "133a1335-8c77-48d2-a556-09e94fe742cb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13f522a5-c59c-4c75-b767-6077ca503450");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "182a6b63-09a3-4744-b03b-7b09dde76618");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1bcfd888-c765-449d-a286-bcca98b19c19");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2377e694-030a-4ef6-8590-99f0ccb8c583");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "249f0ae9-9fb9-4d7d-864a-aa058cf6d1c9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30caf059-b889-45c0-bcc8-062f0f57a06d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3358b2db-cdd0-4b15-bd97-c97ae08d172f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3415e8da-751f-4450-8327-6e42ab913dae");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "34f24e25-36a7-4293-b497-ad8329741278");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "39df0958-b951-47ab-8c70-30708af91bf3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b6e8ffc-8aa1-4e52-8c14-d01a3daeb582");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4955ae5a-39a7-4e7f-857e-102d10c26c77");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4ecfc6da-b7a5-4b90-9846-4784ce99a2e2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5449f2bb-06a1-4291-b108-404103418fd6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "57a6f1e7-0d26-428f-aebd-ec233a1ba643");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cb15e84-86ac-4b42-b60f-8989c5a063e3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5f4072f1-4938-499f-9287-503a5f536b76");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60cae427-0d8f-4873-84dd-5e9212a0664c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "677b36c2-c5de-497a-8465-b56fe96af334");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7499a7ad-44e0-40f5-b044-163cc86e8e5f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7573173a-8c71-41f6-a352-5a064aee1dac");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "776ac473-3f9a-4f09-8b4e-0225a72f428c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7781ee93-7275-42a4-8240-0a76a05fd402");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7adb64f0-0d74-4449-b469-daa8799f20b4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7dbe4c9e-a015-47cb-8098-57a60cfccc4b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81b8a64f-fa24-4cdf-a94d-ab1acd5597f8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b8c27db-812d-47ba-a927-c84b1aacb645");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d64652a-9817-4172-82cd-8d32f42f2db6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f391bcb-df75-475a-a481-4aca008508c9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8fde2dd6-cffe-4dca-b5a1-f3bb2a2d869b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92a565c6-4096-4b59-99c6-aee76311b68a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9457e4ad-c052-4b0d-9a77-f717b44fe246");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a0cec485-38d5-4365-8081-5b285943df45");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ab89fdf5-cbd2-49c3-b01f-025ae7f9e046");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac036877-901d-464a-b02e-494acf94ad4d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aded3147-1b49-44da-a7d0-765912bdaf37");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b1f980d2-eeea-400a-8c88-a7793ac59e82");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b1faccab-3207-418b-9e44-4a78ed008612");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4dc7510-7624-4329-a270-2487e28692e8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6f1c0f1-5bca-4677-b4ac-59df9694b308");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb2caa99-1ced-4c4d-b197-178257ce2e5f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc30683e-b23d-4dfa-ac61-a6eb24670952");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c43a68a0-4e1e-4b6b-a60e-7689d2b8ee85");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5506eb1-7594-4e74-bac7-04ecf82cca5f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb86ec9e-bc98-4973-aa47-bba78cfab53b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc1fbb3a-6ba8-400a-b00c-88d70619c5ef");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ccfe848a-ff30-4948-a9bb-4494f5ef7442");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd2971ad-feae-4428-9e1a-d564b8cb8610");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce61ea89-8818-44ae-8b16-6366761a6313");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d56aa3bd-b1c7-4edb-9186-ffb1971348aa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "daab1bfe-16da-42f4-b553-5747b916d7e1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbbf9288-ae29-4d22-a1cd-8a4fe86ebf50");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dd8698f5-ffee-41a8-b5e7-89647e015669");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddf4e679-1d22-45c7-b332-c3955d8b798a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df8f08ba-e7e0-467a-a048-dbf9f75b19ce");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e51b4197-c122-49c1-ab25-5a4716a73e33");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e841f6c0-ad73-4c41-88bf-3b70e014f8ca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ea76119b-5ded-497f-a4fb-7091bd52d82a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef563ec2-99e3-4aa0-b9c9-3bc6deac215f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f9424b1d-fb39-47d4-b3ce-0d2e48bb5e78");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc557e69-6813-435f-b1f2-233dddfca80e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc9db39e-6880-41ba-b723-2daff5dc03f2");

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "IndustryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "IndustryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "IndustryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "IndustryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "IndustryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "IndustryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "IndustryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "IndustryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "IndustryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "IndustryId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "IndustryId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "IndustryId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "IndustryId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "MajorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "MajorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "MajorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "MajorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "MajorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "MajorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "MajorId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "MajorId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "MajorId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1066cc51-a1ab-4767-a91f-7459610a7092");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "112c0553-9717-4894-9590-7246e414e899");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "523f552e-c26f-432c-9bd5-66a4464db93e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5993c6c2-b79c-40ac-8e69-d1e26794c0a8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6631fef5-5287-4ca2-abd7-4621ad392c86");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69cb26a9-9508-46c0-bc6e-fa217aa75a13");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b4f4718-f143-4d36-b210-6e4924931d87");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d65d32c-4ed3-4ba9-a72e-4491f5df921b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7fa66b0-4aed-4409-afff-272b8aaa2907");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4d90733-3e62-4b97-926a-54561fb63ae3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eac2f179-0bc8-406c-acba-49812724b40d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec3ba1cd-24de-4012-865b-c8cd4e59dac4");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 10);
        }
    }
}
