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

namespace WeatherApp.Services
{
    public class RemoteDataService
    {
        const string ApiKey = "a519d2565f58343b5f157d056e658aca";
        public async Task<WeatherInfo> GetCityWeather(string city)
        {            
            var client = new HttpClient();
            var response = await client.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={ApiKey}");
            var data = JsonConvert.DeserializeObject<WeatherInfo>(response);
            return data;
        }       
    }
}