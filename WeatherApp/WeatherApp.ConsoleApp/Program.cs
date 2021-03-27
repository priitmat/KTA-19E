using System;
using WeatherApp.Core.Services;

namespace WeatherApp.ConsoleApp
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var dataService = new RemoteDataService();
            
            Console.WriteLine("What city ?");
            var city = Console.ReadLine();
            var data = await dataService.GetCityWeather("city");
            Console.WriteLine($"Temperature is: {data.main.temp}");
        }
    }
}
