using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using vkaudioposter_ef.Functions;
using vkaudioposter_ef.Model;
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
        //private static bool isFirstTime = false; // If true - drop all procedures and views, functions

        /// <summary>
        /// First run (initial) Executes from external
        /// </summary>
        public static void LoadConfig()
        {
            DotNetEnv.Env.TraversePath().Load();
            server = DotNetEnv.Env.GetString("MYSQL_SERVER");
            user = DotNetEnv.Env.GetString("MYSQL_USER");
            pass = DotNetEnv.Env.GetString("MYSQL_PASSWORD");
            db = DotNetEnv.Env.GetString("MYSQL_DATABASE_NAME");
            connStr = "server=" + server + ";user=" + user + ";database=" + db + ";port=3306;password=" + pass + "";


            //connStr = DotNetEnv.Env.GetString("MSSQL_CONNSTR");
        }
        private static void MainEf(string[] args)
        {
            //LoadConfig();

            //InsertData(false);
            //CreateStoredProceduresViewsAndFunctions(false);
            //RunTests();

            //PrintDataAsync();
        }


        // Seed
        public static void InsertData(bool isFirstTime)
        {
            using var context = new AppContext();
            if (isFirstTime)
                context.Database.EnsureDeleted();

            // Creates the database if not exists
            context.Database.EnsureCreated();

            var p1 = new Playlist
            {
                PlaylistId = "spotify:playlist:37i9dQZF1DWUbycBFSWTh7",
                PlaylistName = "Deephouse Delight",
                Mood = 7
            };
            var p2 = new Playlist
            {
                PlaylistId = "spotify:playlist:37i9dQZF1DWUq3wF0JVtEy",
                PlaylistName = "Shuffle Syndrome",
                Mood = 8
            };
            context.Playlists.AddRange(p1, p2);

            var cp1 = new ConsolePhotostock { Url = "https://www.deviantart.com/topic/photo-manipulation" };
            var cp2 = new ConsolePhotostock { Url = "https://www.deviantart.com/topic/digital-art" };
            context.Photostocks.AddRange(cp1, cp2);

            var pt1 = new PostedTrack
            {
                Trackname = "Martin Garrix - Animals (remix)",
                Date = DateTime.Now,
                Playlist = p1
            };
            var pt2 = new PostedTrack
            {
                Trackname = "Disturbed - On my own",
                Date = DateTime.Now,
                Playlist = p2,
            };
            context.PostedTracks.AddRange(pt1, pt2);

            var pp1 = new PostedPhoto
            {
                Url="https://test.jpg/",
            };
            context.PostedPhotos.Add(pp1);

            //var post1 = new Post
            //{
            //    Message = "#EDM",
            //    PublishDate = DateTime.Now,
            //    PostedTracks = { pt1, pt2 },
            //    //PostId = 1,
            //    OwnerId = 1,
            //    PostedPhotos = { pp1 }
            //};
            //context.Posts.Add(post1);

            var ut1 = new UnfoundTrack { Trackname = "KVPV - Inferno", Playlist = p1 };
            var ut2 = new UnfoundTrack { Trackname = "AC/DC - Paradise", Playlist = p2 };
            context.UnfoundTracks.AddRange(ut1, ut2);

            var xpath = new ParserXpath { Xpath = "//*[@id=\"root\"]/div[1]/div/div/div/article/div/div[2]/div/div", XpathInner = "" };
            context.ParserXpaths.Add(xpath);
            // Saves changes
            context.SaveChanges();
        }

        public static void CreateStoredProceduresViewsAndFunctions(bool isFirstTime)
        {
            SP_CheckTrackInPosted cTIP = new();
            cTIP.CreateProcedure(isFirstTime);

            SP_CheckTrackInUnfound cTIU = new();
            cTIU.CreateProcedure(isFirstTime);

            SP_InsertFoundTrack iFT = new();
            iFT.CreateProcedure(isFirstTime);

            SP_InsertUnfoundTrack iUT = new();
            iUT.CreateProcedure(isFirstTime);

            SP_SelectAllPostedTracksByStyle sAPTBS = new();
            sAPTBS.CreateProcedure(isFirstTime);

            SP_SelectUnfoundTracksByStyle sUTBS = new();
            sUTBS.CreateProcedure(isFirstTime);

            VW_AllPlaylists aP = new();
            aP.CreateView(isFirstTime);

            VW_GetAllPostedTracks gAPT = new();
            gAPT.CreateView(isFirstTime);

            VW_LastAddedTrack lAT = new();
            lAT.CreateView(isFirstTime);

            VW_LastPostedTrack lPT = new();
            lPT.CreateView(isFirstTime);

            VW_LastPublishedTracks lPTs = new();
            lPTs.CreateView(isFirstTime);

            VW_MakeGenresFromDB mG = new();
            mG.CreateView(isFirstTime);

            VW_PostedTracksCount pTC = new();
            pTC.CreateView(isFirstTime);

            //// Dont need anymore - only for WEB
            //VW_StyleCountChart sCS = new VW_StyleCountChart();
            //sCS.CreateView();

            VW_SelectDateFromPostedTracks sDFPT = new();
            sDFPT.CreateView(isFirstTime);

            VW_StyleCountChart sCC = new();
            sCC.CreateView(isFirstTime);

            FUNC_GetLastDateFromPostedTracks gLDFPT = new();
            gLDFPT.CreateFunction(isFirstTime);

        }

        private static void RunTests()
        {
            try
            {
                Console.WriteLine("Test Stored Procedures:\n");
                SP_CheckTrackInPosted cTIP = new();
                cTIP.TestProcedure("Martin Garrix - Animals", null, null, 1);

                SP_CheckTrackInUnfound cTIU = new();
                cTIU.TestProcedure("AC/DC - Thunderstruck", null, null, 2);

                SP_InsertFoundTrack iFT = new();
                iFT.TestProcedure("AC/DC - Highway To Hell2", null, DateTime.Now, 2);

                SP_InsertUnfoundTrack iUT = new();
                iUT.TestProcedure("Kean Dysso - TRFN", null, DateTime.Now, 1);

                SP_SelectAllPostedTracksByStyle sAPTBS = new();
                sAPTBS.TestProcedure(null, null, null, 1);

                SP_SelectUnfoundTracksByStyle sUTBS = new();
                sUTBS.TestProcedure(null, null, null, 2);

                Console.WriteLine("\nTest Views:\n");
                VW_AllPlaylists aP = new();
                aP.TestView();

                VW_GetAllPostedTracks gAPT = new();
                gAPT.TestView();

                VW_LastAddedTrack lAT = new();
                lAT.TestView();

                VW_LastPostedTrack lPT = new();
                lPT.TestView();

                VW_LastPublishedTracks lPTs = new();
                lPTs.TestView();

                VW_MakeGenresFromDB mG = new();
                mG.TestView();

                VW_PostedTracksCount pTC = new();
                pTC.TestView();

                //// Dont need anymore - only for WEB
                //VW_StyleCountChart sCS = new VW_StyleCountChart();
                //sCS.TestView();

                VW_SelectDateFromPostedTracks sDFPT = new();
                sDFPT.TestView();


                VW_StyleCountChart sCC = new();
                sCC.TestView();


                Console.WriteLine("\nTest Functions:\n");
                FUNC_GetLastDateFromPostedTracks gLDFPT = new();
                gLDFPT.TestFunction();
            }
            catch (Exception ex)
            {
                Console.WriteLine("One of the tests failed...");
                Console.WriteLine(ex);
            }
            Console.WriteLine("Tests Passed");
        }

        private static async System.Threading.Tasks.Task PrintDataAsync()
        {
            using var context = new AppContext();
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
