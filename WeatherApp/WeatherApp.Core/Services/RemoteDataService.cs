using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using WeatherApp.Core.Models;

namespace WeatherApp.Core.Services
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

        public async Task<byte[]> GetImageFromUrl(string url)
        {
            using (var client = new HttpClient())
            {
                var msg = await client.GetAsync(url);
                if (msg.IsSuccessStatusCode)
                {
                    var byteArray = await msg.Content.ReadAsByteArrayAsync();
                    return byteArray;
                }
            }
            return null;
        }
    }
}