using Microsoft.EntityFrameworkCore.Migrations;

namespace RevoltSampleWebApp.Data.Migrations
{
    public partial class SeedUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "ID1", "ID2", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6c80fe71-55df-4177-960d-82ad984e4824", 0, "a264943e-6008-4884-ae60-9c92ea27cae6", "admin@testing.cz", true, null, null, false, null, "ADMIN@TESTING.CZ", "ADMIN", "AQAAAAEAACcQAAAAEDDiGOGtRm29t7eQm9ezhMbNkasl3zs3nBLmsQroAKapXMh1Kp/9J2jqqTaLAWr2bA==", null, false, "19f34311-8c8a-4581-b337-5cafc7cb3b53", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "ID1", "ID2", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "22073247-a532-496f-9785-abfc6912bcf1", 0, "31066525-b921-4503-adb3-3604568cffd0", "manager@testing.cz", true, null, null, false, null, "MANAGER@TESTING.CZ", "MANAGER", "AQAAAAEAACcQAAAAEGUnea0vUvwu4z9shavylr6IglOOf8IowY4FeZ9j50MoJeJYOpRgjBDZpRTpT1sZAA==", null, false, "c9729723-904b-4546-b1d4-226736b9fd75", false, "Manager" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22073247-a532-496f-9785-abfc6912bcf1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c80fe71-55df-4177-960d-82ad984e4824");
        }
    }
}
