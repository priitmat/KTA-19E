

using Android.App;

using Android.OS;
using Android.Widget;
using static System.Net.Mime.MediaTypeNames;

namespace firstApp {
    [Activity(Label = "CarActivity")]
    public class CarActivity :Activity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            base.SetContentView(Resource.Layout.web_layout);
            var image = FindViewById<ImageView>(Resource.Id.imageView1);
            string picture = Intent.GetStringExtra("image");
            image.setImageResource(picture);





        }



    }
}