﻿using Microsoft.EntityFrameworkCore;
using System;
using vkaudioposter_ef.Model;
using vkaudioposter_ef.parser;
//using vkaudioposter_ef.Model;
//using MySQL.EntityFrameworkCore.Extensions;


namespace vkaudioposter_ef
{
    public partial class AppContext : DbContext
    {
        private static string db_server, db_user, db_password, db_name;
        //private static string connStr;
        //private static int db_port;

        //public AppContext(string server, string user, string password, string database)
        //{
        //    db_server = server;
        //    db_user = user;
        //    db_password = password;
        //    db_name = database;
        //}

        //public AppContext()
        //{
        //}

        //public AppContext(DbContextOptions<AppContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<Playlist> Playlists { get; set; }
        //public DbSet<VwAllPlaylist> AllPlaylists { get; set; }
        public virtual DbSet<ConsolePhotostock> Photostocks { get; set; }
        public virtual DbSet<ParserXpath> ParserXpaths { get; set; }
        public virtual DbSet<PostedTrack> PostedTracks { get; set; }
        public virtual DbSet<UnfoundTrack> UnfoundTracks { get; set; }


        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostedPhoto> PostedPhotos { get; set; }
        /// <summary>
        /// Executes every time when use AppContext
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DotNetEnv.Env.TraversePath().Load();
            db_server = DotNetEnv.Env.GetString("MSSQL_SERVER");
            db_user = DotNetEnv.Env.GetString("MSSQL_USER");
            db_password = DotNetEnv.Env.GetString("MSSQL_PASSWORD");
            db_name = DotNetEnv.Env.GetString("MSSQL_DATABASE_NAME");

            //optionsBuilder.UseMySQL("server=" + db_server + ";user=" + db_user + ";password=" + db_password + ";database=" + db_name + ";");

            //string connstr = DotNetEnv.Env.GetString("MSSQL_CONNSTR");
            string connstr = $"Server={db_server};Database={db_name};User Id={db_user};Password={db_password};MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(connstr);
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
                entity.Property(e => e.Status).HasDefaultValue(1);
                entity.Property(e => e.UpdateDate).HasDefaultValue(DateTime.Now);
            });

            modelBuilder.Entity<ConsolePhotostock>(entity =>
            {
                entity.ToTable("console_Photostocks");
                entity.HasComment("URL list of photostocks");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Url).IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("URL");
                entity.Property(e => e.Status).HasDefaultValue(1);
                entity.Property(e => e.UpdateDate).HasDefaultValue(DateTime.Now);
                //entity.Property(e => e.Xpath).HasMaxLength(1024);
                //entity.Property(e => e.XpathInner).HasMaxLength(1024);
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

                entity.Property(e => e.MediaId);
                entity.Property(e => e.OwnerId);

                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.PostedTracks);
                //.OnDelete(DeleteBehavior.ClientSetNull);

                //entity.Property(e => e.Urls)
                //    .HasConversion(
                //        d => JsonConvert.SerializeObject(d),
                //        s => JsonConvert.DeserializeObject<Dictionary<string, string>>(s)
                //    )
                //    .HasMaxLength(5000);

                ///UNCOMMENT IF WANT TO STORE IN DB
                //entity.Property(e => e.TrackUrls)
                //    .HasConversion(
                //        d => JsonConvert.SerializeObject(d),
                //        s => JsonConvert.DeserializeObject<IList<TrackUrl>>(s)
                //    )
                //    .HasMaxLength(5000);

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
