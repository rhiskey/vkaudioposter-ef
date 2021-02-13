using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using vkaudioposter_ef.Entities;

namespace vkaudioposter_ef
{
    class Program
    {
        static void Main(string[] args)
        {
            DotNetEnv.Env.TraversePath().Load();
            // добавление данных
            using (ApplicationContext db = new ApplicationContext())
            {
                Playlist playlist1 = new Playlist { Playlist_ID = "spoty:1221214", Playlist_Name = "Metall" };
                Playlist playlist2 = new Playlist { Playlist_ID = "spoty:93203523", Playlist_Name = "Club" };

                db.Playlists.AddRange(playlist1, playlist2);
                db.SaveChanges();
            }
            // получение данных
            using (ApplicationContext db = new ApplicationContext())
            {
                var playlists = db.Playlists.ToList();
                Console.WriteLine("Список объектов:");
                foreach (Playlist p in playlists)
                {
                    Console.WriteLine($"{p.id}.{p.Playlist_ID} - {p.Playlist_Name}");
                }
            }
        }
    }
    public class ApplicationContext : DbContext
    {
        public DbSet<Playlist> Playlists { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var server = DotNetEnv.Env.GetString("SERVER");
            var user = DotNetEnv.Env.GetString("USER");
            var pass = DotNetEnv.Env.GetString("PASSWORD");
            var db = DotNetEnv.Env.GetString("DATABASE");

            optionsBuilder.UseMySql(
                "server="+ server + ";user="+ user + ";password="+ pass + ";database="+ db + ";",
                new MySqlServerVersion(new Version(8, 0, 11))
            );
        }
    }
}
