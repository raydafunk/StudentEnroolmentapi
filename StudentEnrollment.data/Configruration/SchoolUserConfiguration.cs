using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentEnrollment.data.Configruration
{
    internal class SchoolUserConfiguration : IEntityTypeConfiguration<SchoolUser>
    {
        public void Configure(EntityTypeBuilder<SchoolUser> builder)
        {
            var hasher = new PasswordHasher<SchoolUser>();
            builder.HasData(
                 new SchoolUser
                 {
                     Id = "1a5eebf5-f9a2-4261-8b66-3d89414ed7ec",
                     Email = "rbrownamory@sky.com",
                     NormalizedEmail = "RBROWNAMORY@SKY.COM",
                     NormalizedUserName = "RBROWNAMORY@SKY.COM",
                     UserName = "rbrownamory@sky.com",
                     FristName ="Ray Carl",
                     LastName = "Brown-Amory",
                     PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                     EmailConfirmed= true
                 },
                 new SchoolUser
                 {
                     Id = "7dc2c507-1718-4ca2-8b99-507ad5f821b8",
                     Email = "nbrownamory@sky.com",
                     NormalizedEmail = "NBROWNAMORY@SKY.COM",
                     NormalizedUserName = "NBROWNAMORY@SKY.COM",
                     UserName = "nbrownamory@sky.com",
                     FristName = "Nelson",
                     LastName = "Brown-Amory",
                     PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                     EmailConfirmed = true
                 }
                );
        }
    }
}
