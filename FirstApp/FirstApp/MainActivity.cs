using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using firstApp;

namespace firstApp {
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity :AppCompatActivity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            base.SetContentView(Resource.Layout.activity_main);

            var initalNumber = 0;

            var textView = FindViewById<TextView>(Resource.Id.textView1);
            var increaseButton = FindViewById<Button>(Resource.Id.increase_btn);
            var decreaseButton = FindViewById<Button>(Resource.Id.decrease_btn);
            var calculatorButton = FindViewById<Button>(Resource.Id.calculator_btn);
            var webButton = FindViewById<Button>(Resource.Id.webButton);
            var essentialsButton = FindViewById<Button>(Resource.Id.essentials_btn);
            var toListActivityButton = FindViewById<Button>(Resource.Id.toListButton);

            textView.Text = initalNumber.ToString();

            decreaseButton.Click += delegate {
                initalNumber--;
                textView.Text = initalNumber.ToString();
            };
            increaseButton.Click += delegate {
                initalNumber++;
                textView.Text = initalNumber.ToString();
            };



            calculatorButton.Click += delegate {
                Intent intent = new Intent(this, typeof(CalculatorActivity));
                StartActivity(intent);

            };


            webButton.Click += delegate {
                Intent intent = new Intent(this, typeof(WebActivity));
                intent.PutExtra(Constants.AddressKey, Constants.DefaultUrlToLoad);
                StartActivity(intent);
            };


            essentialsButton.Click += delegate {
                Intent intent = new Intent(this, typeof(EssentialsActivity));
                StartActivity(intent);
            };

            toListActivityButton.Click += delegate {
                Intent intent = new Intent(this, typeof(SampleListActivity));
                StartActivity(intent);
            };
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}