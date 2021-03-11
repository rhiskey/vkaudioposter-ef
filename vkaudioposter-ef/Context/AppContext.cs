using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using vkaudioposter_ef.parser;
//using vkaudioposter_ef.Model;
//using MySQL.EntityFrameworkCore.Extensions;


namespace vkaudioposter_ef
{
    public partial class AppContext : DbContext
    {
        private static string db_server, db_user, db_password, db_name;
        public static string connStr;
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
        public virtual DbSet<PostedTrack> PostedTracks { get; set; }
        public virtual DbSet<UnfoundTrack> UnfoundTracks { get; set; }

        /// <summary>
        /// Executes every time when use AppContext
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DotNetEnv.Env.TraversePath().Load();
            db_server = DotNetEnv.Env.GetString("MYSQL_SERVER");
            db_user = DotNetEnv.Env.GetString("MYSQL_USER");
            db_password = DotNetEnv.Env.GetString("MYSQL_PASSWORD");
            db_name = DotNetEnv.Env.GetString("MYSQL_DATABASE_NAME");

            connStr = "server=" + db_server + ";user=" + db_user + ";database=" + db_name+ ";port=3306;password=" + db_password + "";
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

                entity.Property(e => e.MediaId);
                entity.Property(e => e.OwnerId);

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
