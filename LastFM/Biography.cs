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
    public class Biography
    {
        public string Summary { get; set; }
        public string Content { get; set; }
        public int YearFormed { get; set; }
        public DateTime Published { get; set; }
    }
}