using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using WeatherApp.Services;
using System.Collections.Generic;
using WeatherApp.Models;
using Android.Hardware.Camera2.Params;
using Android.Graphics;

namespace WeatherApp {
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity :AppCompatActivity {
        List<Daily> daily;

        protected override async void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // TODO - pull city from Essentials GPS module to show initial data.
            SetContentView(Resource.Layout.activity_main);
            var dataService = new RemoteDataService();

            var cityEditText = FindViewById<EditText>(Resource.Id.cityTextView);
            var searchButton = FindViewById<Button>(Resource.Id.searchButton);
            var tempTextView = FindViewById<TextView>(Resource.Id.tempTextView);
            var feelsLike = FindViewById<TextView>(Resource.Id.feelslike);
            var weatherImage = FindViewById<ImageView>(Resource.Id.weatherImage);
            var separator = FindViewById<LinearLayout>(Resource.Id.separator);
            var atm = FindViewById<TextView>(Resource.Id.atm);
            var list = FindViewById<ListView>(Resource.Id.listView);



            searchButton.Click += async delegate {

                if(cityEditText.Text == "") {
                    feelsLike.Text = "Please enter a city name";
                }
                else {
                    // TODO - need to close the keyboard programmatically after keypress
                    var data = await dataService.GetCityWeather(cityEditText.Text);

                    tempTextView.Text = $"{data.main.temp} °C";
                    feelsLike.Text = $"Feels like {data.main.feels_like} °C";
                    atm.Text = "Weather atm";
                    separator.SetBackgroundColor(Color.Black);


                    using(var bm = await dataService.GetImageFromUrl($"https://openweathermap.org/img/wn/{data.weather[0].icon}@2x.png"))
                        weatherImage.SetImageBitmap(bm);

                    daily = await dataService.Get7DayWeather(data.coord.lat, data.coord.lon);
                    list.Adapter = new DailyAdapter(this, daily);
                }

            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}