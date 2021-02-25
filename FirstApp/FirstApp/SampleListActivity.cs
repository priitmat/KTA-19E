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
    [Activity(Label = "SampleListActivity")]
    public class SampleListActivity : Activity
    {
        List<Car> items;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.simplelist_layout);

            var listView = FindViewById<ListView>(Resource.Id.listView1);

            items = new List<Car> 
            { 
                new Car { Manufacturer = "Ford", Model = "Focus", KW = 100, Image = Resource.Drawable.ford },
                new Car { Manufacturer = "Volkswagen", Model = "Passat", KW = 45, Image = Resource.Drawable.volkswagen },
                new Car { Manufacturer = "Ford2", Model = "Focus2", KW = 45 },
                new Car { Manufacturer = "Ford3", Model = "Focus3", KW = 67 },
                new Car { Manufacturer = "Ford4", Model = "Focus4", KW = 6, Image = Resource.Drawable.ford },
                new Car { Manufacturer = "Ford5", Model = "Focus5", KW = 1050 },
                new Car { Manufacturer = "Ford6", Model = "Focus6", KW = 74 },
                new Car { Manufacturer = "Ford7", Model = "Focus7", KW = 5, Image = Resource.Drawable.ford },
                new Car { Manufacturer = "Ford8", Model = "Focus8", KW = 86 },
                new Car { Manufacturer = "Ford", Model = "Focus", KW = 100 },
                new Car { Manufacturer = "Volkswagen", Model = "Passat", KW = 45 },
                new Car { Manufacturer = "Ford2", Model = "Focus2", KW = 45 },
                new Car { Manufacturer = "Ford3", Model = "Focus3", KW = 67 },
                new Car { Manufacturer = "Ford4", Model = "Focus4", KW = 6 },
                new Car { Manufacturer = "Ford5", Model = "Focus5", KW = 1050 },
                new Car { Manufacturer = "Ford6", Model = "Focus6", KW = 74 },
                new Car { Manufacturer = "Ford7", Model = "Focus7", KW = 5 },
                new Car { Manufacturer = "Ford8", Model = "Focus8", KW = 86 }
            };

            listView.Adapter = new CarAdapter(this, items);

            listView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                var car = items[args.Position].Manufacturer;
                Toast.MakeText(this, car, ToastLength.Long).Show();
            };

            // Create your application here
        }
    }
}