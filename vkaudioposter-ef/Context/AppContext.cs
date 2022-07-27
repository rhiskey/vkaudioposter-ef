using Microsoft.EntityFrameworkCore;
using vkaudioposter_ef.Model;
using vkaudioposter_ef.Model.SpotyVK;

namespace vkaudioposter_ef
{
    public partial class AppContext : DbContext
    {
        private static string db_server, db_user, db_password, db_name;

        public virtual DbSet<VKAccounts> VKAccounts { get; set; }
        public virtual DbSet<FoundTracks> FoundTracks { get; set; }
        public virtual DbSet<SpotyToVkShareBackendConfig> SpotyToVkShareBackendConfigs { get; set; }
        public virtual DbSet<SpotyVKUser> SpotyVKUsers { get; set; }
        public virtual DbSet<AppSettings> AppSettings { get; set; }
        public virtual DbSet<VKParams> VKParams { get; set; }

        /// <summary>
        /// Executes every time when use AppContext
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DotNetEnv.Env.TraversePath().Load();
            db_server = DotNetEnv.Env.GetString("DB_SERVER");
            db_user = DotNetEnv.Env.GetString("DB_USER");
            db_password = DotNetEnv.Env.GetString("DB_PASSWORD");
            db_name = DotNetEnv.Env.GetString("DB_NAME");

            //string connstr = $"Server={db_server};Database={db_name};User Id={db_user};Password={db_password};MultipleActiveResultSets=true";
            //optionsBuilder.UseSqlServer(connstr);
            optionsBuilder.UseNpgsql($"Host={db_server};Database={db_name};Username={db_user};Password={db_password}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // PgSQL
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}
