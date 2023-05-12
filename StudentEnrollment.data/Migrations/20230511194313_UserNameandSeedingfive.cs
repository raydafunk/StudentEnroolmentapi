using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentEnrollment.data.Migrations
{
    /// <inheritdoc />
    public partial class UserNameandSeedingfive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a5eebf5-f9a2-4261-8b66-3d89414ed7ec",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f2ca77f-d1cd-4c28-8127-f91be0d58df8", "RBROWNAMORY@SKY.COM", "RBROWNAMORY@SKY.COM", "AQAAAAIAAYagAAAAEJ1FNVYoJmDmHRJQVgxTxvuYM9X4A6L+LYGxVnpruoREyGb1VGswixGyA2f5kphU9A==", "72dda60f-14f7-49d8-aa38-a6552d4fd20f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7dc2c507-1718-4ca2-8b99-507ad5f821b8",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94cd4f7e-01df-4ada-98e0-cccdfcef4398", "NBROWNAMORY@SKY.COM", "NBROWNAMORY@SKY.COM", "AQAAAAIAAYagAAAAENScwNd2Vx3T1Jljs8sZWD2zX07JSEg2IPiH2zBHK93nXriHQ+NVeRcA7jHmX9U7aA==", "ed46aec7-f4c5-4138-9b03-2d34a0d92a12" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a5eebf5-f9a2-4261-8b66-3d89414ed7ec",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12101b03-fde6-4936-8540-89f806e03d46", "R.BROWNAMORY@SKY.COM", "R.BROWNAMORY@SKY.COM", "AQAAAAIAAYagAAAAEIc/A7+/nyDbbmEMCeRqRwur5rOd38IoKUrGQfRf9xZViQoBWukxvv6FyhLjvReYQg==", "0aadd117-73e7-435d-8392-1bd047dcd983" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7dc2c507-1718-4ca2-8b99-507ad5f821b8",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1160ccb4-c342-49b3-aeaf-904892a311c5", "R.BROWNAMORY@SKY.COM", "N.BROWNAMORY@SKY.COM", "AQAAAAIAAYagAAAAEHf9nuasyYd0q0+Zz5juuEct9d7U/omkmOxRCSzL90t0AnKNQDTs9y2AGfMMM4k2Yw==", "2fb84d9d-cfe0-4c16-8a4d-a8bcad3e160a" });
        }
    }
}
