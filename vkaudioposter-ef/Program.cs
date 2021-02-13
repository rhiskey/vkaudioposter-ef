using System;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using vkaudioposter_ef.Model;


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
                // Creates the database if not exists
                context.Database.EnsureCreated();

                // Adds a publisher
                var playlist = new Playlist
                {
                    Playlist_ID = "spoty:134636",
                    Playlist_Name = "Club Hits"
                };
                context.Playlists.Add(playlist);

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
            // Gets and prints all books in database
            using (var context = new PlaylistContext())
            {
                //var books = context.Book
                //  .Include(p => p.Publisher);

                var playlists = context.Playlists;

                foreach (var playlist in playlists)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"ID: {playlist.Playlist_ID}");
                    data.AppendLine($"Name: {playlist.Playlist_Name}");
                    Console.WriteLine(data.ToString());
                }
            }
        }
    }
}
