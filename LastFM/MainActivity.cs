using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using RestSharp;

namespace LastFM
{
    [Activity(Label = "LastFM", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.btnSearch);

            
            

            button.Click += delegate { RestSharpTest(); };




        }
       

        public void RestSharpTest()
        {
            var stringSearch = FindViewById<EditText>(Resource.Id.editText);
            RestClient client = new RestClient("http://ws.audioscrobbler.com");
            RestRequest request = new RestRequest("/2.0/?method=artist.getinfo&artist=" + stringSearch.Text.ToString() + "&api_key=afbf8aee5d75a3b96e60c2a5f465993c");
            IRestResponse<Artist> resp = client.Execute<Artist>(request);
            Artist artist = new Artist { Name = resp.Data.Name, Image = resp.Data.Image, Bio = resp.Data.Bio, Mbid = null, Url = null };

            
            ////Skriver ut i labels
            TextView Name = FindViewById<TextView>(Resource.Id.txtName);
            Name.SetText(artist.Name, null);

            TextView Bio = FindViewById<TextView>(Resource.Id.txtBio);
            Bio.SetText(artist.Bio.Summary.ToString(), null);


        }

       

        

    

       
   

    }
}

