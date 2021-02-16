using System;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using vkaudioposter_ef.Functions;
using vkaudioposter_ef.parser;
//using vkaudioposter_ef.Model;
using vkaudioposter_ef.StoredProcedures;
using vkaudioposter_ef.Views;

namespace vkaudioposter_ef
{
    public class Program
    {
        public static string server;
        public static string user;
        public static string pass;
        public static string db;
        public static string connStr;

        private static void LoadConfig()
        {
            DotNetEnv.Env.TraversePath().Load();
            server = DotNetEnv.Env.GetString("SERVER");
            user = DotNetEnv.Env.GetString("USER");
            pass = DotNetEnv.Env.GetString("PASSWORD");
            db = DotNetEnv.Env.GetString("DATABASE");
            connStr = "server=" + server + ";user=" + user + ";database=" + db + ";port=3306;password=" + pass + "";
        }
        static void Main(string[] args)
        {
            LoadConfig();

            InsertData();
            CreateSPandVw();
            //PrintDataAsync();
        }

        // Seed
        private static void InsertData()
        {
            using (var context = new AppContext())
            {
                context.Database.EnsureDeleted();

                // Creates the database if not exists
                context.Database.EnsureCreated();

                var p1 = new Playlist
                {
                    PlaylistId = "spoty:134636",
                    PlaylistName = "Club Hits"
                };
                var p2 = new Playlist
                {
                    PlaylistId = "spoty:13463145",
                    PlaylistName = "Metall Charge"
                };
                context.Playlists.AddRange(p1, p2);

                var cp1 = new ConsolePhotostock { Url = "https://devianart.com/topic" };
                context.Photostocks.Add(cp1);

                var pt1 = new PostedTrack
                {
                    Trackname = "Martin Garrix - Animals",
                    Date = DateTime.Now,
                    Playlist = p1
                };
                var pt2 = new PostedTrack
                {
                    Trackname = "Disturbed - Silence",
                    Date = DateTime.Now,
                    Playlist = p2
                };
                context.PostedTracks.AddRange(pt1, pt2);

                var ut1 = new UnfoundTrack { Trackname = "CPMG - Dddl", Playlist = p1 };
                var ut2 = new UnfoundTrack { Trackname = "AC/DC - Thunderstruck", Playlist = p2 };
                context.UnfoundTracks.AddRange(ut1, ut2);

                // Saves changes
                context.SaveChanges();
            }
        }

        private static void CreateSPandVw()
        {          
            SP_CheckTrackInPosted cTIP = new SP_CheckTrackInPosted();

            SP_CheckTrackInUnfound cTIU = new SP_CheckTrackInUnfound();

            SP_InsertFoundTrack iFT = new SP_InsertFoundTrack();
            iFT.CreateProcedure();
            iFT.TestProcedure("AC/DC - Highway To Hell2", null, DateTime.Now, 2);

            SP_InsertUnfoundTrack iUT = new SP_InsertUnfoundTrack();

            SP_SelectAllPostedTracksByStyle sAPTBS = new SP_SelectAllPostedTracksByStyle();

            SP_SelectUnfoundTracksByStyle sUTBS = new SP_SelectUnfoundTracksByStyle();

            VW_AllPlaylists aP = new VW_AllPlaylists();

            VW_GetAllPostedTracks gAPT = new VW_GetAllPostedTracks();

            VW_LastAddedTrack lAT = new VW_LastAddedTrack();

            VW_LastPostedTrack lPT = new VW_LastPostedTrack();

            VW_LastPublishedTracks lPTs = new VW_LastPublishedTracks();

            VW_MakeGenresFromDB mG = new VW_MakeGenresFromDB();
            mG.CreateView();
            mG.TestView();

            VW_PostedTracksCount pTC = new VW_PostedTracksCount();

            VW_StyleCountChart sCS = new VW_StyleCountChart();

            FUNC_GetLastDateFromPostedTracks gLDFPT = new FUNC_GetLastDateFromPostedTracks();

        }

        private static async System.Threading.Tasks.Task PrintDataAsync()
        {
            using (var context = new AppContext())
            {
                var playlists = await context.Playlists.ToListAsync();
                foreach (var playlist in playlists)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"ID: {playlist.Id}");
                    data.AppendLine($"Name: {playlist.PlaylistName}");
                    data.AppendLine($"PlaylistId: {playlist.PlaylistId}");
                    Console.WriteLine(data.ToString());
                }

                var postedTracks = context.PostedTracks.Include(p => p.Playlist);
                Console.WriteLine("---------Found Tracks:---------");
                foreach (var track in postedTracks)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"ID: {track.Id}");
                    data.AppendLine($"Name: {track.Trackname}");
                    data.AppendLine($"Playlist: {track.Playlist.PlaylistName}");
                    Console.WriteLine(data.ToString());
                }

                var unfoundTracks = context.UnfoundTracks.Include(p => p.Playlist);
                Console.WriteLine("----------Unfound Tracks:---------");
                foreach (var track in unfoundTracks)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"ID: {track.Id}");
                    data.AppendLine($"Name: {track.Trackname}");
                    data.AppendLine($"Playlist: {track.Playlist.PlaylistName}");
                    Console.WriteLine(data.ToString());
                }

                //var lastPublised = postedTracks

            }
        }
    }
}
