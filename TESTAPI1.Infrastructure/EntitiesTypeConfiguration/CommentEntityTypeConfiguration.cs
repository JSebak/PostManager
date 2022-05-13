using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TESTAPI1.Domain.Enities.Comment;
using TESTAPI1.Domain.SharedValueObjects;

namespace TESTAPI1.Infrastructure.EntitiesTypeConfiguration
{
    internal class CommentEntityTypeConfiguration: IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> commentConfiguration)
        {
            commentConfiguration.ToTable("Comment");
            commentConfiguration.HasKey(o => o.Id);
            commentConfiguration.Property(t => t.Id)
                .HasColumnType("uniqueidentifier");
            commentConfiguration.Property(t => t.Content)
                .HasConversion<string>(v => v, v => new Content(v))
                .HasColumnType("nvarchar")
                .IsRequired().HasMaxLength(150);
            commentConfiguration.Property(t => t.PostId)
                .IsRequired().HasColumnType("uniqueidentifier");
            commentConfiguration.Property(t => t.CreationDate)
                .HasConversion<DateTime>(v => v, v => new DateTime(v.Year, v.Month, v.Day))
                .IsRequired().HasColumnType("date");
            commentConfiguration.Property(t => t.AuthorId)
                .HasColumnType("uniqueidentifier");
        }
    }
}
