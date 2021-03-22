using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using WeatherApp.Services;
using System.Collections.Generic;
using WeatherApp.Models;

namespace WeatherApp {
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity :AppCompatActivity {
        List<Daily> daily;

        protected override async void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var dataService = new RemoteDataService();

            var cityEditText = FindViewById<EditText>(Resource.Id.cityTextView);
            var searchButton = FindViewById<Button>(Resource.Id.searchButton);
            var tempTextView = FindViewById<TextView>(Resource.Id.tempTextView);
            var weatherImage = FindViewById<ImageView>(Resource.Id.weatherImage);
            var list = FindViewById<ListView>(Resource.Id.listView);



            searchButton.Click += async delegate {
                var data = await dataService.GetCityWeather(cityEditText.Text);

                tempTextView.Text = $"{data.main.temp.ToString()} C";


                using(var bm = await dataService.GetImageFromUrl($"https://openweathermap.org/img/wn/{data.weather[0].icon}@2x.png"))
                    weatherImage.SetImageBitmap(bm);

                daily = await dataService.Get7DayWeather(data.coord.lat, data.coord.lon);
                list.Adapter = new DailyAdapter(this, daily);

            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}