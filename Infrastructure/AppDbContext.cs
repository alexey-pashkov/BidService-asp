using Microsoft.EntityFrameworkCore;
using Domain;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        DbSet<BidCreator> bidCreators = null!;
        DbSet<Bid> bids = null!;
        DbSet<Reviewer> reviewers = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bid>();
            modelBuilder.Entity<Reviewer>();
            modelBuilder.Entity<BidCreator>();
        }


    }
}
