using System;
using System.Collections.Generic;
using System.Text;

namespace vkaudioposter_ef.StoredProcedures
{
#nullable enable
    interface IStoredProcedure
    {
        public void CreateProcedure(bool isFirstLaunch);
        public void TestProcedure(string trackname, string? style, DateTime? date, int? playlistID);
        //public bool TestProcedure();
    }
}
