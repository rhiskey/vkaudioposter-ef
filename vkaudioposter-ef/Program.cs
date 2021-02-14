using System;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using vkaudioposter_ef.parser;
//using vkaudioposter_ef.Model;


namespace vkaudioposter_ef
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertData();
            PrintData();
        }


        private static void InsertData()
        {
            using (var context = new PlaylistContext())
            {
                context.Database.EnsureDeleted();
                // Creates the database if not exists
                context.Database.EnsureCreated();

                var p1= new Playlist{ PlaylistId = "spoty:134636", PlaylistName = "Club Hits"};
                var p2 = new Playlist { PlaylistId = "spoty:13463145", PlaylistName = "Metall Charhe" };
                context.Playlists.AddRange(p1, p2);
                //context.Playlists.Add(playlist);

                context.Database.ExecuteSqlRaw(@"CREATE 
                                            VIEW parser_ef.vw_all_playlists AS 
                                            SELECT `Playlists`.`id` AS `id`
                                            `Playlists`.`Playlist_ID` AS `Playlist_ID`, 
                                            `Playlists`.`Playlist_Name` AS `Playlist_Name`,
                                            `Playlists `.`Mood` AS `Mood`,
                                            FROM Playlists
                                            ORDER BY `Playlists`.`Mood`, `Playlists`.`Playlist_Name`
                                              ");

                //// Adds some books
                //context.Book.Add(new Book
                //{
                //    ISBN = "978-0544003415",
                //    Title = "The Lord of the Rings",
                //    Author = "J.R.R. Tolkien",
                //    Language = "English",
                //    Pages = 1216,
                //    Publisher = publisher
                //});
                //context.Book.Add(new Book
                //{
                //    ISBN = "978-0547247762",
                //    Title = "The Sealed Letter",
                //    Author = "Emma Donoghue",
                //    Language = "English",
                //    Pages = 416,
                //    Publisher = publisher
                //});

                // Saves changes
                context.SaveChanges();
            }
        }

        private static void PrintData()
        {
            using (var context = new PlaylistContext())
            {
                //var books = context.Book
                //  .Include(p => p.Publisher);

                var playlists = context.AllPlaylists;

                foreach (var playlist in playlists)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"ID: {playlist.PlaylistId}");
                    data.AppendLine($"Name: {playlist.PlaylistName}");
                    Console.WriteLine(data.ToString());
                }
            }
        }
    }
}
