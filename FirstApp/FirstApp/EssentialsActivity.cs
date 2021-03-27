
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;

using Xamarin.Essentials;


namespace firstApp {
    [Activity(Label = "EssentialsActivity")]
    public class EssentialsActivity :Activity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.essentials_layout);
            bool isFlaslightOn = false;



            var flashLightSwitch = FindViewById<Button>(Resource.Id.flash_light_switch);
            var vibrateButton = FindViewById<Button>(Resource.Id.vibtrate_btn);
            var gpsButton = FindViewById<Button>(Resource.Id.gps_btn);

            flashLightSwitch.Click += delegate {

                isFlaslightOn = !isFlaslightOn;
                FlashLightSwitch(isFlaslightOn);
                if(isFlaslightOn) {
                    flashLightSwitch.SetBackgroundColor(Android.Graphics.Color.ParseColor("#EBECEC"));
                }
                else { flashLightSwitch.SetBackgroundColor(Android.Graphics.Color.ParseColor("#BEBEBE")); }



            };

            vibrateButton.Click += delegate {
                vibrate();
            };

            gpsButton.Click += async delegate {
                try {
                    var location = await Geolocation.GetLastKnownLocationAsync();

                    if(location != null) {
                        gpsButton.Text = ($"Latitude: {location.Latitude}, Longitude: {location.Longitude}");
                    }
                }
                catch(FeatureNotSupportedException fnsEx) {
                    // Handle not supported on device exception
                }
                catch(FeatureNotEnabledException fneEx) {
                    // Handle not enabled on device exception
                }
                catch(PermissionException pEx) {
                    // Handle permission exception
                }
                catch(Exception ex) {
                    // Unable to get location
                }
            };
        }



        async void FlashLightSwitch(bool turnOn) {
            if(turnOn) {
                try {
                    // Turn On
                    await Flashlight.TurnOnAsync();

                }
                catch(FeatureNotSupportedException fnsEx) {
                    // Handle not supported on device exception
                }
                catch(PermissionException pEx) {
                    // Handle permission exception
                }
                catch(Exception ex) {
                    // Unable to turn on/off flashlight
                }
            }
            else {
                try {


                    // Turn Off
                    await Flashlight.TurnOffAsync();
                }
                catch(FeatureNotSupportedException fnsEx) {
                    // Handle not supported on device exception
                }
                catch(PermissionException pEx) {
                    // Handle permission exception
                }
                catch(Exception ex) {
                    // Unable to turn on/off flashlight
                }
            }

        }

        void vibrate() {
            try {

                HapticFeedback.Perform(HapticFeedbackType.LongPress);
            }
            catch(FeatureNotSupportedException ex) {
                // Feature not supported on device
            }
            catch(Exception ex) {
                // Other error has occurred.
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
