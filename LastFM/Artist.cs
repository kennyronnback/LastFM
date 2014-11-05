using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LastFM
{
    public class Artist
    {
        public string Name { get; set; }
        public string Mbid { get; set; }
        public string Url { get; set; }
        public Biography Bio { get; set; }
        public ArtistImageCollection Image { get; set; }
    }
}