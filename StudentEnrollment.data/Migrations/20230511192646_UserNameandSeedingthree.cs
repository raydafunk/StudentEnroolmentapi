using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentEnrollment.data.Migrations
{
    /// <inheritdoc />
    public partial class UserNameandSeedingthree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a5eebf5-f9a2-4261-8b66-3d89414ed7ec",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "76e8beae-a8e1-4c51-85c4-ca380fa5cdc7", "AQAAAAIAAYagAAAAED5IDArzc/qw8mPzL3RBD1CqKhMt08hA267BBCjmQy8XreAS1wr8+T6UpJ5yvdM9pw==", "2f868b6b-1ebe-4d36-938b-749793187425", "rbrownamory@sky.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7dc2c507-1718-4ca2-8b99-507ad5f821b8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "9813dadf-9b21-41e2-9721-fc36ea52ca27", "AQAAAAIAAYagAAAAEPXxiqAzZUjky1J29as1nvpqjiGtW+SkNOVPYNavZYfVcr8ld+mBK8PyWiQ+V6sEpw==", "1dbc35e1-ff01-40c7-8ddd-9dbdd5a4ceb5", "nbrownamory@sky.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a5eebf5-f9a2-4261-8b66-3d89414ed7ec",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "41df4bd8-199a-420a-a2d7-8ab2ee64e557", "AQAAAAIAAYagAAAAEOdi1qu5iHu57+mF6jkusnyUuVhLsPF7tvO5KlAvgbWmiiUZrdna1n0i10LL+SvnRw==", "59efe94b-a605-4bc0-bc28-8e53e41bade2", "r.brownamory@sky.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7dc2c507-1718-4ca2-8b99-507ad5f821b8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "93958346-8b7f-41b6-817c-acf22e9167b7", "AQAAAAIAAYagAAAAEJLaUX715Mv+5pRqKVbGJgDPCejMSYR99L3ue1OuH/MUtvRM5Bvk/kYM9MofpNNZ1Q==", "07f3b8b4-0a55-49dc-af4e-c25e247e6aef", "n.brownamory@sky.com" });
        }
    }
}
