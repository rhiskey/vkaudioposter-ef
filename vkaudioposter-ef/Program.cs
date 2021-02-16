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
            Console.WriteLine("Test Stored Procedures:\n");
            SP_CheckTrackInPosted cTIP = new SP_CheckTrackInPosted();
            cTIP.CreateProcedure();
            cTIP.TestProcedure("Martin Garrix - Animals", null, null, 1);

            SP_CheckTrackInUnfound cTIU = new SP_CheckTrackInUnfound();
            cTIU.CreateProcedure();
            cTIU.TestProcedure("AC/DC - Thunderstruck", null, null, 2);

            SP_InsertFoundTrack iFT = new SP_InsertFoundTrack();
            iFT.CreateProcedure();
            iFT.TestProcedure("AC/DC - Highway To Hell2", null, DateTime.Now, 2);

            SP_InsertUnfoundTrack iUT = new SP_InsertUnfoundTrack();
            iUT.CreateProcedure();
            iUT.TestProcedure("Kean Dysso - TRFN", null, DateTime.Now, 1);

            SP_SelectAllPostedTracksByStyle sAPTBS = new SP_SelectAllPostedTracksByStyle();
            sAPTBS.CreateProcedure();
            sAPTBS.TestProcedure(null, null, null, 1);

            SP_SelectUnfoundTracksByStyle sUTBS = new SP_SelectUnfoundTracksByStyle();
            sUTBS.CreateProcedure();
            sUTBS.TestProcedure(null, null, null, 2);

            Console.WriteLine("\nTest Views:\n");
            VW_AllPlaylists aP = new VW_AllPlaylists();
            aP.CreateView();
            aP.TestView();

            VW_GetAllPostedTracks gAPT = new VW_GetAllPostedTracks();
            gAPT.CreateView();
            gAPT.TestView();

            VW_LastAddedTrack lAT = new VW_LastAddedTrack();
            lAT.CreateView();
            lAT.TestView();

            VW_LastPostedTrack lPT = new VW_LastPostedTrack();
            lPT.CreateView();
            lPT.TestView();

            VW_LastPublishedTracks lPTs = new VW_LastPublishedTracks();
            lPTs.CreateView();
            lPTs.TestView();

            VW_MakeGenresFromDB mG = new VW_MakeGenresFromDB();
            mG.CreateView();
            mG.TestView();

            VW_PostedTracksCount pTC = new VW_PostedTracksCount();
            pTC.CreateView();
            pTC.TestView();

            //// Dont need anymore - only for WEB
            //VW_StyleCountChart sCS = new VW_StyleCountChart();
            //sCS.CreateView();
            //sCS.TestView();

            VW_SelectDateFromPostedTracks sDFPT = new VW_SelectDateFromPostedTracks();
            sDFPT.CreateView();
            sDFPT.TestView();

            Console.WriteLine("\nTest Functions:\n");
            FUNC_GetLastDateFromPostedTracks gLDFPT = new FUNC_GetLastDateFromPostedTracks();
            gLDFPT.CreateFunction();
            gLDFPT.TestFunction();
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
