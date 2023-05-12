using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentEnrollment.data.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUsersandRoleAssignments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20749071-0eb7-4ede-a0ae-afc2ce95bc1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ae169f8-f9b1-4ebb-8028-6e469c8ec111");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a5e61d01-375a-45da-aabf-fe2583d68062", null, "User", "USER" },
                    { "dc185118-0e12-461f-b720-1bbb8b1b4389", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBrith", "Email", "EmailConfirmed", "FristName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1a5eebf5-f9a2-4261-8b66-3d89414ed7ec", 0, "c750757c-0957-4ff3-8099-7cb00434b5be", null, "r.brownamory@sky.com", true, "Ray Carl", "Brown-Amory", false, null, "R.BROWNAMORY@SKY.COM", "R.BROWNAMORY@SKY.COM", "AQAAAAIAAYagAAAAEO1ALoMBEiH969EBCvVljZ4njDYhskRDNsITX8WiftFtwpVCPFpisXoSYNIvHgSuKA==", null, false, "04ceac21-cee0-48ab-8831-702e22f56b30", false, "r.brownamory@sky.com" },
                    { "7dc2c507-1718-4ca2-8b99-507ad5f821b8", 0, "47ae1cab-cadc-44b7-b6d5-5094f8e479a6", null, "n.brownamory@sky.com", true, "Nelson", "Brown-Amory", false, null, "R.BROWNAMORY@SKY.COM", "N.BROWNAMORY@SKY.COM", "AQAAAAIAAYagAAAAEP1jbZDodLUIkIprMXaoxnE2qQtGUaV9uhEXELPjtswVj6BOEuQ19HvsFesTCvf1pg==", null, false, "32839676-aa02-418c-b13a-24b48fe5bc34", false, "r.brownamory@sky.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "dc185118-0e12-461f-b720-1bbb8b1b4389", "1a5eebf5-f9a2-4261-8b66-3d89414ed7ec" },
                    { "a5e61d01-375a-45da-aabf-fe2583d68062", "7dc2c507-1718-4ca2-8b99-507ad5f821b8" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dc185118-0e12-461f-b720-1bbb8b1b4389", "1a5eebf5-f9a2-4261-8b66-3d89414ed7ec" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a5e61d01-375a-45da-aabf-fe2583d68062", "7dc2c507-1718-4ca2-8b99-507ad5f821b8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5e61d01-375a-45da-aabf-fe2583d68062");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc185118-0e12-461f-b720-1bbb8b1b4389");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a5eebf5-f9a2-4261-8b66-3d89414ed7ec");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7dc2c507-1718-4ca2-8b99-507ad5f821b8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20749071-0eb7-4ede-a0ae-afc2ce95bc1c", null, "User", "USER" },
                    { "6ae169f8-f9b1-4ebb-8028-6e469c8ec111", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
