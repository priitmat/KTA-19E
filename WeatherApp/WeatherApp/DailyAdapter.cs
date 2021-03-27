using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WeatherApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherApp.Services;

using Java.IO;
using Android.Media;
using Android.Graphics;
using Android.Content.Res;

namespace WeatherApp {
    public class DailyAdapter :BaseAdapter<Daily> {
        DateTime _time;
        List<Daily> _items;
        Activity _context;
        RemoteDataService dataService = new RemoteDataService();

        public DailyAdapter(Activity context, List<Daily> items) {
            _context = context;
            _items = items;
        }

        public override Daily this[int position] {
            get { return _items[position]; }
        }

        public override int Count {
            get { return _items.Count; }
        }

        public object ImageSource { get; private set; }

        public override long GetItemId(int position) {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent) {
            View view = convertView;
            if(view == null)
                view = _context.LayoutInflater.Inflate(Resource.Layout.daily_row_layout, null);


            DateTimeOffset dateTimeOffSet = DateTimeOffset.FromUnixTimeSeconds(_items[position].dt);
            _time = dateTimeOffSet.DateTime;


            view.FindViewById<TextView>(Resource.Id.datetime).Text = _time.DayOfWeek.ToString();
            view.FindViewById<TextView>(Resource.Id.date).Text = _time.Date.ToShortDateString();
            view.FindViewById<TextView>(Resource.Id.temperature).Text = _items[position].temp.min.ToString() + " - " + _items[position].temp.max.ToString() + " °C";
            view.FindViewById<TextView>(Resource.Id.feelslike).Text = "Feels like: " + _items[position].feels_like.day.ToString() + " °C";

            var weatherImage = view.FindViewById<ImageView>(Resource.Id.weatherImage);


            var imgName = "a" + _items[position].weather[0].icon;
            int resImage = _context.Resources.GetIdentifier(imgName, "drawable", _context.PackageName);
            weatherImage.SetImageResource(resImage);


            return view;
        }
    }
}