using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using WeatherApp.Models;
using System.Threading.Tasks;
using Android.Graphics;

namespace WeatherApp.Services {
    public class RemoteDataService {
        const string ApiKey = "d673db93de894f42b20900619c789cad";
        public async Task<WeatherInfo> GetCityWeather(string city) {
            var client = new HttpClient();
            var response = await client.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={ApiKey}");
            var data = JsonConvert.DeserializeObject<WeatherInfo>(response);
            return data;
        }

        public async Task Get7DayWeather(double lat, double lon) {
            var client = new HttpClient();
            var response = await client.GetStringAsync($"https://api.openweathermap.org/data/2.5/onecall?lat={lat}&lon={lon}&exclude=current,minutely,hourly,alerts&units=metric&appid={ApiKey}");
            var data = JsonConvert.DeserializeObject<SevenDayWeatherInfo>(response);
            Console.WriteLine(data.daily[0].temp.max);
        }

        public async Task<Bitmap> GetImageFromUrl(string url) {
            using(var client = new HttpClient()) {
                var msg = await client.GetAsync(url);
                if(msg.IsSuccessStatusCode) {
                    using(var stream = await msg.Content.ReadAsStreamAsync()) {
                        var bitmap = await BitmapFactory.DecodeStreamAsync(stream);
                        return bitmap;
                    }
                }
            }
            return null;
        }
    }
}