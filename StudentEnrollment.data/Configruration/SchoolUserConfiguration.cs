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
                     Email = "r.brownamory@sky.com",
                     NormalizedEmail = "R.BROWNAMORY@SKY.COM",
                     NormalizedUserName = "R.BROWNAMORY@SKY.COM",
                     UserName = "r.brownamory@sky.com",
                     FristName ="Ray Carl",
                     LastName = "Brown-Amory",
                     PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                     EmailConfirmed= true
                 },
                 new SchoolUser
                 {
                     Id = "7dc2c507-1718-4ca2-8b99-507ad5f821b8",
                     Email = "n.brownamory@sky.com",
                     NormalizedEmail = "R.BROWNAMORY@SKY.COM",
                     NormalizedUserName = "N.BROWNAMORY@SKY.COM",
                     UserName = "n.brownamory@sky.com",
                     FristName = "Nelson",
                     LastName = "Brown-Amory",
                     PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                     EmailConfirmed = true
                 }
                );
        }
    }
}
