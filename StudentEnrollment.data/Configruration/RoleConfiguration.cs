using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentEnrollment.data.Configruration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                 new IdentityRole
                 {   Id = "dc185118-0e12-461f-b720-1bbb8b1b4389",
                     Name = "Administrator",
                     NormalizedName ="ADMINISTRATOR"
                 },
                 new IdentityRole
                 {
                     Id = "a5e61d01-375a-45da-aabf-fe2583d68062",
                     Name = "User",
                     NormalizedName = "USER"
                 }
                );
        }
    }
}
