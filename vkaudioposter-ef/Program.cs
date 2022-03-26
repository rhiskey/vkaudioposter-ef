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
            server = DotNetEnv.Env.GetString("DB_SERVER");
            user = DotNetEnv.Env.GetString("DB_USER");
            pass = DotNetEnv.Env.GetString("DB_PASSWORD");
            db = DotNetEnv.Env.GetString("DB_NAME");
            connStr = $"Server={server};Database={db};User Id={user};Password={pass};MultipleActiveResultSets=true";
        }
        private static void Main(string[] args)
        {
            LoadConfig();

            //InsertData(false);
            //CreateStoredProceduresViewsAndFunctions(false);
            //RunTests();

            //PrintDataAsync();
        }


        // Seed
        //public static void InsertData(bool isFirstTime)
        //{
        //    using var context = new AppContext();
        //    if (isFirstTime)
        //        context.Database.EnsureDeleted();

        //    // Creates the database if not exists
        //    context.Database.EnsureCreated();

        //    var p1 = new Playlist
        //    {
        //        PlaylistId = "spotify:playlist:37i9dQZF1DWUbycBFSWTh7",
        //        PlaylistName = "Deephouse Delight",
        //        //Mood = 7
        //    };
        //    var p2 = new Playlist
        //    {
        //        PlaylistId = "spotify:playlist:37i9dQZF1DWUq3wF0JVtEy",
        //        PlaylistName = "Shuffle Syndrome",
        //        //Mood = 8
        //    };
        //    context.Playlists.AddRange(p1, p2);

        //    var cp1 = new ConsolePhotostock { Url = "https://www.deviantart.com/topic/photo-manipulation" };
        //    var cp2 = new ConsolePhotostock { Url = "https://www.deviantart.com/topic/digital-art" };
        //    context.Photostocks.AddRange(cp1, cp2);

        //    var pt1 = new PostedTrack
        //    {
        //        Trackname = "Martin Garrix - Animals (remix)",
        //        Date = DateTime.Now,
        //        Playlist = p1
        //    };
        //    var pt2 = new PostedTrack
        //    {
        //        Trackname = "Disturbed - On my own",
        //        Date = DateTime.Now,
        //        Playlist = p2,
        //    };
        //    context.PostedTracks.AddRange(pt1, pt2);

        //    var pp1 = new PostedPhoto
        //    {
        //        Url = "https://test.jpg/",
        //    };
        //    context.PostedPhotos.Add(pp1);

        //    var ut1 = new UnfoundTrack { Trackname = "KVPV - Inferno", Playlist = p1 };
        //    var ut2 = new UnfoundTrack { Trackname = "AC/DC - Paradise", Playlist = p2 };
        //    context.UnfoundTracks.AddRange(ut1, ut2);

        //    var xpath = new ParserXpath { Xpath = "//*[@id=\"root\"]/div[1]/div/div/div/article/div/div[2]/div/div", XpathInner = "" };
        //    context.ParserXpaths.Add(xpath);
        //    // Saves changes
        //    context.SaveChanges();
        //}

        //private static async System.Threading.Tasks.Task PrintDataAsync()
        //{
        //    using var context = new AppContext();
        //    var playlists = await context.Playlists.ToListAsync();
        //    foreach (var playlist in playlists)
        //    {
        //        var data = new StringBuilder();
        //        data.AppendLine($"ID: {playlist.Id}");
        //        data.AppendLine($"Name: {playlist.PlaylistName}");
        //        data.AppendLine($"PlaylistId: {playlist.PlaylistId}");
        //        Console.WriteLine(data.ToString());
        //    }

        //    var postedTracks = context.PostedTracks.Include(p => p.Playlist);
        //    Console.WriteLine("---------Found Tracks:---------");
        //    foreach (var track in postedTracks)
        //    {
        //        var data = new StringBuilder();
        //        data.AppendLine($"ID: {track.Id}");
        //        data.AppendLine($"Name: {track.Trackname}");
        //        data.AppendLine($"Playlist: {track.Playlist.PlaylistName}");
        //        Console.WriteLine(data.ToString());
        //    }

        //    var unfoundTracks = context.UnfoundTracks.Include(p => p.Playlist);
        //    Console.WriteLine("----------Unfound Tracks:---------");
        //    foreach (var track in unfoundTracks)
        //    {
        //        var data = new StringBuilder();
        //        data.AppendLine($"ID: {track.Id}");
        //        data.AppendLine($"Name: {track.Trackname}");
        //        data.AppendLine($"Playlist: {track.Playlist.PlaylistName}");
        //        Console.WriteLine(data.ToString());
        //    }

        //}
    }
}
