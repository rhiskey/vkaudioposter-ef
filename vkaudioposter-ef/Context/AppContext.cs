﻿using Microsoft.EntityFrameworkCore;
using vkaudioposter_ef.parser;
//using vkaudioposter_ef.Model;
//using MySQL.EntityFrameworkCore.Extensions;


namespace vkaudioposter_ef
{
    public partial class AppContext : DbContext
    {
        private static string db_server = vkaudioposter_ef.Program.server;
        private static string db_user = vkaudioposter_ef.Program.user;
        private static string db_password = vkaudioposter_ef.Program.pass;
        private static string db_name = vkaudioposter_ef.Program.db;
        public AppContext(string server, string user, string password, string database)
        {
            db_server = server;
            db_user = user;
            db_password = password;
            db_name = database;
        }
        public AppContext()
        {
        }

        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Playlist> Playlists { get; set; }
        //public DbSet<VwAllPlaylist> AllPlaylists { get; set; }
        public virtual DbSet<ConsolePhotostock> Photostocks { get; set; }
        public virtual DbSet<PostedTrack> PostedTracks { get; set; }
        public virtual DbSet<UnfoundTrack> UnfoundTracks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=" + db_server + ";user=" + db_user + ";password=" + db_password + ";database=" + db_name + ";");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.PlaylistName, "Playlist_Name").IsUnique();
                entity.Property(e => e.PlaylistId)
                    .HasMaxLength(45)
                    .HasColumnName("Playlist_ID");
                entity.Property(e => e.PlaylistName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Playlist_Name");
            });

            modelBuilder.Entity<ConsolePhotostock>(entity =>
            {
                entity.ToTable("console_Photostocks");
                entity.HasComment("URL list of photostocks");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Url).IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<PostedTrack>(entity =>
            {
                //entity.ToTable("PostedTracks");
                entity.HasComment("Published tracks info");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Trackname).IsUnique();
                //entity.Property(e => e.Style).IsRequired();
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.Trackname)
                    .IsRequired()
                    .HasMaxLength(150);


                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.PostedTracks);
                    //.OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<UnfoundTrack>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Trackname)
                    .IsUnique();
                entity.Property(e => e.Trackname).IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("trackname");
                //entity.Property(e => e.Style).IsRequired();
                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.UnfoundTracks);
            });
        }
    }
}
