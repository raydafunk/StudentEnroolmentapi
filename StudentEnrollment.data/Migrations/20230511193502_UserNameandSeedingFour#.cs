using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentEnrollment.data.Migrations
{
    /// <inheritdoc />
    public partial class UserNameandSeedingFour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a5eebf5-f9a2-4261-8b66-3d89414ed7ec",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12101b03-fde6-4936-8540-89f806e03d46", "rbrownamory@sky.com", "AQAAAAIAAYagAAAAEIc/A7+/nyDbbmEMCeRqRwur5rOd38IoKUrGQfRf9xZViQoBWukxvv6FyhLjvReYQg==", "0aadd117-73e7-435d-8392-1bd047dcd983" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7dc2c507-1718-4ca2-8b99-507ad5f821b8",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1160ccb4-c342-49b3-aeaf-904892a311c5", "nbrownamory@sky.com", "AQAAAAIAAYagAAAAEHf9nuasyYd0q0+Zz5juuEct9d7U/omkmOxRCSzL90t0AnKNQDTs9y2AGfMMM4k2Yw==", "2fb84d9d-cfe0-4c16-8a4d-a8bcad3e160a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a5eebf5-f9a2-4261-8b66-3d89414ed7ec",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76e8beae-a8e1-4c51-85c4-ca380fa5cdc7", "r.brownamory@sky.com", "AQAAAAIAAYagAAAAED5IDArzc/qw8mPzL3RBD1CqKhMt08hA267BBCjmQy8XreAS1wr8+T6UpJ5yvdM9pw==", "2f868b6b-1ebe-4d36-938b-749793187425" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7dc2c507-1718-4ca2-8b99-507ad5f821b8",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9813dadf-9b21-41e2-9721-fc36ea52ca27", "n.brownamory@sky.com", "AQAAAAIAAYagAAAAEPXxiqAzZUjky1J29as1nvpqjiGtW+SkNOVPYNavZYfVcr8ld+mBK8PyWiQ+V6sEpw==", "1dbc35e1-ff01-40c7-8ddd-9dbdd5a4ceb5" });
        }
    }
}
