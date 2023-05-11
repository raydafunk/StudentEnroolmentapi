using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentEnrollment.data.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUsersandRolechangedusernameAssignments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a5eebf5-f9a2-4261-8b66-3d89414ed7ec",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41df4bd8-199a-420a-a2d7-8ab2ee64e557", "AQAAAAIAAYagAAAAEOdi1qu5iHu57+mF6jkusnyUuVhLsPF7tvO5KlAvgbWmiiUZrdna1n0i10LL+SvnRw==", "59efe94b-a605-4bc0-bc28-8e53e41bade2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7dc2c507-1718-4ca2-8b99-507ad5f821b8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "93958346-8b7f-41b6-817c-acf22e9167b7", "AQAAAAIAAYagAAAAEJLaUX715Mv+5pRqKVbGJgDPCejMSYR99L3ue1OuH/MUtvRM5Bvk/kYM9MofpNNZ1Q==", "07f3b8b4-0a55-49dc-af4e-c25e247e6aef", "n.brownamory@sky.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a5eebf5-f9a2-4261-8b66-3d89414ed7ec",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c750757c-0957-4ff3-8099-7cb00434b5be", "AQAAAAIAAYagAAAAEO1ALoMBEiH969EBCvVljZ4njDYhskRDNsITX8WiftFtwpVCPFpisXoSYNIvHgSuKA==", "04ceac21-cee0-48ab-8831-702e22f56b30" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7dc2c507-1718-4ca2-8b99-507ad5f821b8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "47ae1cab-cadc-44b7-b6d5-5094f8e479a6", "AQAAAAIAAYagAAAAEP1jbZDodLUIkIprMXaoxnE2qQtGUaV9uhEXELPjtswVj6BOEuQ19HvsFesTCvf1pg==", "32839676-aa02-418c-b13a-24b48fe5bc34", "r.brownamory@sky.com" });
        }
    }
}
