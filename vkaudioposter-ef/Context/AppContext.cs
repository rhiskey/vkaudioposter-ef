using Microsoft.EntityFrameworkCore;
using vkaudioposter_ef.Model;
using vkaudioposter_ef.parser;


namespace vkaudioposter_ef
{
    public partial class AppContext : DbContext
    {
        private static string db_server, db_user, db_password, db_name;

        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<ConsolePhotostock> Photostocks { get; set; }
        public virtual DbSet<ParserXpath> ParserXpaths { get; set; }
        public virtual DbSet<PostedTrack> PostedTracks { get; set; }
        public virtual DbSet<UnfoundTrack> UnfoundTracks { get; set; }


        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostedPhoto> PostedPhotos { get; set; }

        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<VKAccounts> VKAccounts { get; set; }
        public virtual DbSet<FoundTracks> FoundTracks { get; set; }
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

            string connstr = $"Server={db_server};Database={db_name};User Id={db_user};Password={db_password};MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(connstr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
