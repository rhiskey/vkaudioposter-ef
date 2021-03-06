﻿using System;
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
        private static bool isFirstTime = true; // If true - drop all procedures and views, functions

        private static void LoadConfig()
        {
            DotNetEnv.Env.TraversePath().Load();
            server = DotNetEnv.Env.GetString("SERVER");
            user = DotNetEnv.Env.GetString("USER");
            pass = DotNetEnv.Env.GetString("PASSWORD");
            db = DotNetEnv.Env.GetString("DATABASE");
            connStr = "server=" + server + ";user=" + user + ";database=" + db + ";port=3306;password=" + pass + "";
        }
        private static void Main2(string[] args)
        {
            LoadConfig();

            InsertData(false);
            //CreateStoredProceduresViewsAndFunctions(false);
            //RunTests();
            PrintDataAsync();
        }

        // Seed
        private static void InsertData(bool isFirstTime)
        {
            using (var context = new AppContext())
            {
                if (isFirstTime)
                    context.Database.EnsureDeleted();

                // Creates the database if not exists
                context.Database.EnsureCreated();

                var p1 = new Playlist
                {
                    PlaylistId = "spoty:1346367",
                    PlaylistName = "EDM"
                };
                var p2 = new Playlist
                {
                    PlaylistId = "spoty:13463145",
                    PlaylistName = "Metall Basics"
                };
                context.Playlists.AddRange(p1, p2);

                var cp1 = new ConsolePhotostock { Url = "https://devianart.com/topic2" };
                context.Photostocks.Add(cp1);

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
                    Playlist = p2
                };
                context.PostedTracks.AddRange(pt1, pt2);

                var ut1 = new UnfoundTrack { Trackname = "KVPV - Inferno", Playlist = p1 };
                var ut2 = new UnfoundTrack { Trackname = "AC/DC - Paradise", Playlist = p2 };
                context.UnfoundTracks.AddRange(ut1, ut2);

                // Saves changes
                context.SaveChanges();
            }
        }
        
        private static void CreateStoredProceduresViewsAndFunctions(bool isFirstTime)
        {
            SP_CheckTrackInPosted cTIP = new SP_CheckTrackInPosted();
            cTIP.CreateProcedure(isFirstTime);

            SP_CheckTrackInUnfound cTIU = new SP_CheckTrackInUnfound();
            cTIU.CreateProcedure(isFirstTime);

            SP_InsertFoundTrack iFT = new SP_InsertFoundTrack();
            iFT.CreateProcedure(isFirstTime);

            SP_InsertUnfoundTrack iUT = new SP_InsertUnfoundTrack();
            iUT.CreateProcedure(isFirstTime);

            SP_SelectAllPostedTracksByStyle sAPTBS = new SP_SelectAllPostedTracksByStyle();
            sAPTBS.CreateProcedure(isFirstTime);

            SP_SelectUnfoundTracksByStyle sUTBS = new SP_SelectUnfoundTracksByStyle();
            sUTBS.CreateProcedure(isFirstTime);

            VW_AllPlaylists aP = new VW_AllPlaylists();
            aP.CreateView(isFirstTime);

            VW_GetAllPostedTracks gAPT = new VW_GetAllPostedTracks();
            gAPT.CreateView(isFirstTime);

            VW_LastAddedTrack lAT = new VW_LastAddedTrack();
            lAT.CreateView(isFirstTime);

            VW_LastPostedTrack lPT = new VW_LastPostedTrack();
            lPT.CreateView(isFirstTime);

            VW_LastPublishedTracks lPTs = new VW_LastPublishedTracks();
            lPTs.CreateView(isFirstTime);

            VW_MakeGenresFromDB mG = new VW_MakeGenresFromDB();
            mG.CreateView(isFirstTime);

            VW_PostedTracksCount pTC = new VW_PostedTracksCount();
            pTC.CreateView(isFirstTime);

            //// Dont need anymore - only for WEB
            //VW_StyleCountChart sCS = new VW_StyleCountChart();
            //sCS.CreateView();

            VW_SelectDateFromPostedTracks sDFPT = new VW_SelectDateFromPostedTracks();
            sDFPT.CreateView(isFirstTime);

            FUNC_GetLastDateFromPostedTracks gLDFPT = new FUNC_GetLastDateFromPostedTracks();
            gLDFPT.CreateFunction(isFirstTime);

        }

        private static void RunTests()
        {
            try
            {
                Console.WriteLine("Test Stored Procedures:\n");
                SP_CheckTrackInPosted cTIP = new SP_CheckTrackInPosted();
                cTIP.TestProcedure("Martin Garrix - Animals", null, null, 1);

                SP_CheckTrackInUnfound cTIU = new SP_CheckTrackInUnfound();
                cTIU.TestProcedure("AC/DC - Thunderstruck", null, null, 2);

                SP_InsertFoundTrack iFT = new SP_InsertFoundTrack();
                iFT.TestProcedure("AC/DC - Highway To Hell2", null, DateTime.Now, 2);

                SP_InsertUnfoundTrack iUT = new SP_InsertUnfoundTrack();
                iUT.TestProcedure("Kean Dysso - TRFN", null, DateTime.Now, 1);

                SP_SelectAllPostedTracksByStyle sAPTBS = new SP_SelectAllPostedTracksByStyle();
                sAPTBS.TestProcedure(null, null, null, 1);

                SP_SelectUnfoundTracksByStyle sUTBS = new SP_SelectUnfoundTracksByStyle();
                sUTBS.TestProcedure(null, null, null, 2);

                Console.WriteLine("\nTest Views:\n");
                VW_AllPlaylists aP = new VW_AllPlaylists();
                aP.TestView();

                VW_GetAllPostedTracks gAPT = new VW_GetAllPostedTracks();
                gAPT.TestView();

                VW_LastAddedTrack lAT = new VW_LastAddedTrack();
                lAT.TestView();

                VW_LastPostedTrack lPT = new VW_LastPostedTrack();
                lPT.TestView();

                VW_LastPublishedTracks lPTs = new VW_LastPublishedTracks();
                lPTs.TestView();

                VW_MakeGenresFromDB mG = new VW_MakeGenresFromDB();
                mG.TestView();

                VW_PostedTracksCount pTC = new VW_PostedTracksCount();
                pTC.TestView();

                //// Dont need anymore - only for WEB
                //VW_StyleCountChart sCS = new VW_StyleCountChart();
                //sCS.TestView();

                VW_SelectDateFromPostedTracks sDFPT = new VW_SelectDateFromPostedTracks();
                sDFPT.TestView();

                Console.WriteLine("\nTest Functions:\n");
                FUNC_GetLastDateFromPostedTracks gLDFPT = new FUNC_GetLastDateFromPostedTracks();
                gLDFPT.TestFunction();
            }
            catch(Exception ex)
            {
                Console.WriteLine("One of the tests failed...");
                Console.WriteLine(ex);
            }
            Console.WriteLine("Tests Passed");
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
