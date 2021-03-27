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

namespace firstApp.Models {
    public class Car {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int KW { get; set; }
        public int Image { get; set; }
    }
}