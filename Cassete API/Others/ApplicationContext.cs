using Cassete_API.Models.Album;
using Cassete_API.Models.Others;
using Microsoft.EntityFrameworkCore;

namespace Cassete_API.Models.User
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        public DbSet<TrackModel> Tracks { get; set; }

        public DbSet<AlbumModel> Albums { get; set; }

        public DbSet<AlbumTrackModel> AlbumTracks { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumTrackModel>()
                .HasKey(t => new { t.TrackId, t.AlbumId });

            modelBuilder.Entity<AlbumTrackModel>()
                .HasOne(sc => sc.TrackModel)
                .WithMany(s => s.AlbumTrackModels)
                .HasForeignKey(sc => sc.TrackId);

            modelBuilder.Entity<AlbumTrackModel>()
                .HasOne(sc => sc.AlbumModel)
                .WithMany(c => c.AlbumTrackModels)
                .HasForeignKey(sc => sc.AlbumId);
        }
    }
}
