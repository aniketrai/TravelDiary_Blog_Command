using Microsoft.EntityFrameworkCore;
using TravelDiaries.Blog.Command.Data;

namespace TravelDiary.Blog.Command.Data
{
    public class TravelDiaryContext : DbContext
    {

        DbSet<Post> Posts { get; set; }


        public TravelDiaryContext(DbContextOptions<TravelDiaryContext> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder.Entity<Post>()
                .Property(x => x.Title)
                .HasColumnName("Title")
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Post>()
                .Property(x => x.HtmlTemplete)
                .HasColumnName("HtmlTemplete")
                .IsRequired();


        }

    }
}
