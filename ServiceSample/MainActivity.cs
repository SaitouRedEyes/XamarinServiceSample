using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Android.Content;
using Android.Util;

namespace ServiceSample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Intent i;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            i = new Intent(this, typeof(CountService));

            Button buttonStartService = (Button)FindViewById(Resource.Id.buttonStartService);
            Button buttonStopService = (Button)FindViewById(Resource.Id.buttonStopService);
            Button buttonBindService = (Button)FindViewById(Resource.Id.buttonBindService);

            buttonStartService.Click += OnButtonStartServiceClicked;
            buttonStopService.Click += OnButtonStopServiceClicked;
            buttonBindService.Click += OnButtonBindServiceClicked;
        }

        private void OnButtonStartServiceClicked(object sender, System.EventArgs e)
        {
            if(!CountService.active)
            {
                StartService(i);
                Toast.MakeText(this, "Start Service", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Service is already running", ToastLength.Short).Show();
            }
        }

        private void OnButtonStopServiceClicked(object sender, System.EventArgs e)
        {
            if (CountService.active)
            {
                StopService(i);
                Toast.MakeText(this, "Stop Service", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Service isn't started", ToastLength.Short).Show();
            }
        }

        private void OnButtonBindServiceClicked(object sender, System.EventArgs e)
        {
            StartActivity(new Intent(this, typeof(BindServiceActivity)));
        }
    }
}