using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FirstApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstApp
{
    public class CarAdapter : BaseAdapter<Car>
    {
        List<Car> _items;
        Activity _context;

        public CarAdapter(Activity context, List<Car> items)
        {
            _context = context;
            _items = items;
        }

        public override Car this[int position]
        {
            get { return _items[position]; }
        }

        public override int Count
        {
            get { return _items.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = _context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = _items[position].Manufacturer;
            view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = _items[position].Model;
            return view;
        }
    }
}