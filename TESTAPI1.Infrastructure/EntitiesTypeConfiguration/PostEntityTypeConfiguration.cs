using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TESTAPI1.Domain.Enities.Post;
using TESTAPI1.Domain.SharedValueObjects;

namespace TESTAPI1.Infrastructure.Configurations
{
    public class PostEntityTypeConfiguration: IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> postConfiguration)
        {
            postConfiguration.ToTable("Post");
            postConfiguration.HasKey(o => o.Id);
            postConfiguration.Property(t => t.Id).HasColumnType("uniqueidentifier");
            postConfiguration.Property(t => t.Content).HasConversion<string>(v => v, v => new Content(v))
            .IsRequired().HasColumnType("nvarchar").HasMaxLength(150);
            postConfiguration.Property(t => t.Title).HasConversion<string>(v => v, v => new Title(v))
            .IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            postConfiguration.Property(t => t.Status)
            .IsRequired(false).HasColumnType("bit");
            postConfiguration.Property(t => t.CreationDate).HasConversion<DateTime>(v=>v,v => new DateTime(v.Year, v.Month, v.Day))
            .IsRequired().HasColumnType("date");
            postConfiguration.Property(t => t.AuthorId).IsRequired().HasColumnType("uniqueidentifier");
            postConfiguration.Property(t => t.ApprovalDate).HasConversion<DateTime?>(v => v, v => v.HasValue ? new DateTime(v.Value.Year, v.Value.Month, v.Value.Day) : null)
            .HasColumnType("date").IsRequired(false);
        }
    }
}
