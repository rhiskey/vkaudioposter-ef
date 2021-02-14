using Microsoft.EntityFrameworkCore;
using vkaudioposter_ef.Model;
//using MySQL.EntityFrameworkCore.Extensions;


namespace vkaudioposter_ef
{
    public class PlaylistContext : DbContext
    {
        public DbSet<Playlist> Playlists { get; set; }

        //public DbSet<Publisher> Publisher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DotNetEnv.Env.TraversePath().Load();

            var server = DotNetEnv.Env.GetString("SERVER");
            var user = DotNetEnv.Env.GetString("USER");
            var pass = DotNetEnv.Env.GetString("PASSWORD");
            var db = DotNetEnv.Env.GetString("DATABASE");

            optionsBuilder.UseMySQL("server=" + server + ";user=" + user + ";password=" + pass + ";database=" + db + ";");
            //optionsBuilder.UseMySQL("server=localhost;database=library;user=user;password=password");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Playlist_ID).IsRequired();
                entity.Property(e => e.Playlist_Name).IsRequired();

            });

            //modelBuilder.Entity<Book>(entity =>
            //{
            //    entity.HasKey(e => e.ISBN);
            //    entity.Property(e => e.Title).IsRequired();
            //    entity.HasOne(d => d.Publisher)
            //      .WithMany(p => p.Books);
            //});
        }
    }
}
