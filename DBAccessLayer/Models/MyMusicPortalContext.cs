using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBAccessLayer.Models
{
    public partial class MyMusicPortalContext : DbContext
    {
        public MyMusicPortalContext()
        {
        }

        public MyMusicPortalContext(DbContextOptions<MyMusicPortalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlbumLists> AlbumLists { get; set; }
        public virtual DbSet<ArtistsList> ArtistsList { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<RatingLists> RatingLists { get; set; }
        public virtual DbSet<TrackLists> TrackLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=MyMusicPortal;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumLists>(entity =>
            {
                entity.HasKey(e => e.AlbumId);

                entity.Property(e => e.AlbumId)
                    .HasColumnName("Album_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AlbumName)
                    .HasColumnName("Album_name")
                    .HasMaxLength(50);

                entity.Property(e => e.ArtistId)
                    .HasColumnName("Artist_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasMaxLength(50);

                entity.Property(e => e.GenreId)
                    .HasColumnName("Genre_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Price).HasMaxLength(50);

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.AlbumLists)
                    .HasForeignKey(d => d.ArtistId)
                    .HasConstraintName("FK_AlbumLists_ArtistsList");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.AlbumLists)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK_AlbumLists_Genres");
            });

            modelBuilder.Entity<ArtistsList>(entity =>
            {
                entity.HasKey(e => e.ArtistId);

                entity.Property(e => e.ArtistId)
                    .HasColumnName("Artist_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ArtistName)
                    .HasColumnName("Artist_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("Create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.LastupdateDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasMaxLength(50);
            });

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.HasKey(e => e.GenreId);

                entity.Property(e => e.GenreId)
                    .HasColumnName("Genre_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<RatingLists>(entity =>
            {
                entity.HasKey(e => e.RatingId);

                entity.Property(e => e.RatingId)
                    .HasColumnName("Rating_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AlbumId)
                    .HasColumnName("Album_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("Created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Rating).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TrackId)
                    .HasColumnName("Track_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.RatingLists)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("FK_RatingLists_AlbumLists");
            });

            modelBuilder.Entity<TrackLists>(entity =>
            {
                entity.HasKey(e => e.TrackId);

                entity.Property(e => e.TrackId)
                    .HasColumnName("Track_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AlbumId)
                    .HasColumnName("Album_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Time).HasMaxLength(50);

                entity.Property(e => e.TrackCount).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.TrackLists)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("FK_TrackLists_AlbumLists");
            });
        }
    }
}
