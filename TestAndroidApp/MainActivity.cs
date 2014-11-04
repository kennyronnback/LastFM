using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using RestSharp;
using System.Collections.Generic;

namespace TestAndroidApp
{
    [Activity(Label = "TestAndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.button1);

            button.Click += delegate { RestSharpTest(); };

            

            

            

        }


        public void RestSharpTest()
        {

            var client = new RestClient("http://ws.audioscrobbler.com");

            RestRequest request = new RestRequest("/2.0/?method=artist.getinfo&artist=Michael Jackson&api_key=afbf8aee5d75a3b96e60c2a5f465993c");

            IRestResponse<Artist> resp = client.Execute<Artist>(request);

            Artist artist = new Artist { Name = resp.Data.Name, Image = resp.Data.Image, Bio = resp.Data.Bio, Mbid = null, Url = null };
                      
            TextView Name = FindViewById<TextView>(Resource.Id.lblName);
            TextView Bio = FindViewById<TextView>(Resource.Id.lblBio);
                        
            Name.SetText(artist.Name, null);
            Bio.SetText(artist.Bio.YearFormed.ToString(), null);
           
            
        }

        public class image
        {
            public string Size { get; set; }
            public string Value { get; set; }
        }

        public class Biography
        {
            public string Summary { get; set; }
            public string Content { get; set; }
            public int YearFormed { get; set; }
            public DateTime Published { get; set; }
        }

        public class ArtistImageCollection : List<image> { }

        public class Artist
        {
            public string Name { get; set; }
            public string Mbid { get; set; }
            public string Url { get; set; }
            public Biography Bio { get; set; }
            public ArtistImageCollection Image { get; set; }
        }


        
    }
}

