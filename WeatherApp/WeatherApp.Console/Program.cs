using System;
using WeatherApp.Core.Services;

namespace WeatherApp.Console
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine(usageText);

            var dataService = new RemoteDataService();
            var data = await dataService.GetCityWeather("tallinn");
            //var city = 
        }
    }
}
