using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentEnrollment.data.Configruration
{
    internal class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                 new IdentityUserRole<string>
                 {
                     RoleId = "dc185118-0e12-461f-b720-1bbb8b1b4389",
                     UserId = "1a5eebf5-f9a2-4261-8b66-3d89414ed7ec"
                 },

                 new IdentityUserRole<string>
                 {
                     RoleId = "a5e61d01-375a-45da-aabf-fe2583d68062",
                     UserId = "7dc2c507-1718-4ca2-8b99-507ad5f821b8"
                 }

                );
        }
    }
}
