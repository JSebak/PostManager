using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TESTAPI1.Domain.Enities.Comment;
using TESTAPI1.Domain.Enities.Post;
using TESTAPI1.Domain.Enities.User;
using TESTAPI1.Domain.SharedValueObjects;
using TESTAPI1.Infrastructure.Configurations;
using TESTAPI1.Infrastructure.EntitiesTypeConfiguration;

namespace TESTAPI1.Infrastructure.Repositories
{
    public class PostsContext:DbContext
    {
        public PostsContext()
        {
        }

        public PostsContext(DbContextOptions<PostsContext> options) : base(options)
        {
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CommentEntityTypeConfiguration());
        }

        

    }
}
