using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace vkaudioposter_ef.parser
{
    public partial class parserContext : DbContext
    {
        public parserContext()
        {
        }

        public parserContext(DbContextOptions<parserContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConsolePhotostock> ConsolePhotostocks { get; set; }
        public virtual DbSet<Photostock> Photostocks { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<PlaylistsAll> PlaylistsAlls { get; set; }
        public virtual DbSet<PlaylistsBackupWithBeatport> PlaylistsBackupWithBeatports { get; set; }
        public virtual DbSet<PostedTrack> PostedTracks { get; set; }
        public virtual DbSet<PostedTracksArchive> PostedTracksArchives { get; set; }
        public virtual DbSet<UnfoundTrack> UnfoundTracks { get; set; }
        public virtual DbSet<VwAllPlaylist> VwAllPlaylists { get; set; }
        public virtual DbSet<VwGetAllPostedTrack> VwGetAllPostedTracks { get; set; }
        public virtual DbSet<VwLastAddedTrack> VwLastAddedTracks { get; set; }
        public virtual DbSet<VwLastPostedTrack> VwLastPostedTracks { get; set; }
        public virtual DbSet<VwLastPublishedTrack> VwLastPublishedTracks { get; set; }
        public virtual DbSet<VwLoadPhotostocksFromDb> VwLoadPhotostocksFromDbs { get; set; }
        public virtual DbSet<VwMakeGenresFromDb> VwMakeGenresFromDbs { get; set; }
        public virtual DbSet<VwPostedTracksCount> VwPostedTracksCounts { get; set; }
        public virtual DbSet<VwSelectDateFromPostedTrack> VwSelectDateFromPostedTracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                DotNetEnv.Env.TraversePath().Load();

                var server = DotNetEnv.Env.GetString("SERVER");
                var user = DotNetEnv.Env.GetString("USER");
                var pass = DotNetEnv.Env.GetString("PASSWORD");
                var db = DotNetEnv.Env.GetString("DATABASE");

                optionsBuilder.UseMySQL("server=" + server + ";user=" + user + ";password=" + pass + ";database=" + db + ";");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConsolePhotostock>(entity =>
            {
                entity.ToTable("console_Photostocks");

                entity.HasComment("Список URL фотостоков для консольного парсера");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("URL");
            });



            modelBuilder.Entity<Photostock>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PhotostockName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Photostock_Name");

                entity.Property(e => e.PhotostockUrl)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("Photostock_Url");
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.HasComment("Плейлисты спотифай + beatport для парсера");

                entity.HasIndex(e => e.PlaylistName, "Playlist_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Photostock)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'none'");

                //entity.Property(e => e.PlaylistAuthor)
                //    .HasMaxLength(50)
                //    .HasColumnName("Playlist_Author")
                //    .HasDefaultValueSql("'none'");

                entity.Property(e => e.PlaylistId)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("Playlist_ID");

                entity.Property(e => e.PlaylistName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Playlist_Name");
            });

            modelBuilder.Entity<PlaylistsAll>(entity =>
            {
                entity.ToTable("Playlists_all");

                entity.HasIndex(e => e.PlaylistName, "Playlist_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                //entity.Property(e => e.PlaylistAuthor)
                //    .IsRequired()
                //    .HasMaxLength(50)
                //    .HasColumnName("Playlist_Author");

                entity.Property(e => e.PlaylistId)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("Playlist_ID");

                entity.Property(e => e.PlaylistName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Playlist_Name");
            });

            modelBuilder.Entity<PlaylistsBackupWithBeatport>(entity =>
            {
                entity.ToTable("Playlists_backup_withBeatport");

                entity.HasIndex(e => e.PlaylistName, "Playlist_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Photostock).HasMaxLength(100);

                entity.Property(e => e.PlaylistAuthor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Playlist_Author");

                entity.Property(e => e.PlaylistId)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("Playlist_ID");

                entity.Property(e => e.PlaylistName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Playlist_Name");
            });

            modelBuilder.Entity<PostedTrack>(entity =>
            {
                entity.HasComment("Опубликованные треки");

                entity.HasIndex(e => e.Trackname, "Trackname")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Style)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Trackname)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<PostedTracksArchive>(entity =>
            {
                entity.ToTable("PostedTracks_archive");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Style)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Trackname)
                    .IsRequired()
                    .HasMaxLength(100);
            });


            modelBuilder.Entity<UnfoundTrack>(entity =>
            {
                entity.HasIndex(e => e.Trackname, "trackname_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Style)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("style");

                entity.Property(e => e.Trackname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("trackname");
            });

            modelBuilder.Entity<VwAllPlaylist>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_all_playlists");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Photostock)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'none'");

                entity.Property(e => e.PlaylistAuthor)
                    .HasMaxLength(50)
                    .HasColumnName("Playlist_Author")
                    .HasDefaultValueSql("'none'");

                entity.Property(e => e.PlaylistId)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("Playlist_ID");

                entity.Property(e => e.PlaylistName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Playlist_Name");
            });

            modelBuilder.Entity<VwGetAllPostedTrack>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_get_all_posted_tracks");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Style)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Trackname)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<VwLastAddedTrack>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_last_added_track");

                entity.Property(e => e.Style)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Trackname)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<VwLastPostedTrack>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_last_posted_track");

                entity.Property(e => e.Style)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Trackname)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<VwLastPublishedTrack>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_last_published_tracks");

                entity.Property(e => e.Style)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Trackname)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<VwLoadPhotostocksFromDb>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_load_photostocks_fromDB");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<VwMakeGenresFromDb>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_make_genres_fromDB");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Photostock)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'none'");

                entity.Property(e => e.PlaylistAuthor)
                    .HasMaxLength(50)
                    .HasColumnName("Playlist_Author")
                    .HasDefaultValueSql("'none'");

                entity.Property(e => e.PlaylistId)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("Playlist_ID");

                entity.Property(e => e.PlaylistName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Playlist_Name");
            });

            modelBuilder.Entity<VwPostedTracksCount>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_posted_tracks_count");

                entity.Property(e => e.Count).HasColumnName("COUNT(*)");
            });
            modelBuilder.Entity<VwSelectDateFromPostedTrack>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_select_date_from_PostedTracks");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
