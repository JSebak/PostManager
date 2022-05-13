using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TESTAPI1.Domain.Enities.User;

namespace TESTAPI1.Infrastructure.EntitiesTypeConfiguration
{
    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> userConfiguration)
        {
            userConfiguration.ToTable("User");
            userConfiguration.HasKey(o => o.Id);
            userConfiguration.Property(t => t.Id).HasColumnType("uniqueidentifier");
            userConfiguration.Property(t => t.Username).HasConversion<string>(v => v,v => new Username(v))
            .IsRequired().HasColumnType("nvarchar").HasMaxLength(20);
            userConfiguration.Property(t => t.Role)
            .IsRequired().HasColumnType("int");
            userConfiguration.Property(t=>t.Password).HasConversion<string>(v => v,v => new Password(v))
                .HasColumnType("nvarchar")
                .HasMaxLength(20).IsRequired();
        }
    }
}
