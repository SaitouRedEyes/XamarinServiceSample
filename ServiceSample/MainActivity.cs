using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Util;

namespace ServiceSample
{
    [Activity(Label = "ServiceSample", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Intent i;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            i = new Intent(this, typeof(CounterService));

            Button buttonStartService = (Button)FindViewById(Resource.Id.buttonStartService);
            Button buttonStopService = (Button)FindViewById(Resource.Id.buttonStopService);
            Button buttonBindService = (Button)FindViewById(Resource.Id.buttonBindService);

            buttonStartService.Click += OnButtonStartServiceClicked;
            buttonStopService.Click += OnButtonStopServiceClicked;
            buttonBindService.Click += OnButtonBindServiceClicked;
        }

        private void OnButtonStartServiceClicked(object sender, System.EventArgs e)
        {
            if(!isMyServiceRunning(typeof(CounterService)))
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
            if (isMyServiceRunning(typeof(CounterService)))
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

        private bool isMyServiceRunning(System.Type serviceClass)
        {
            ActivityManager manager = (ActivityManager)GetSystemService(ActivityService);

            foreach (ActivityManager.RunningServiceInfo service in manager.GetRunningServices(int.MaxValue))
            {   
                if (service.Service.ClassName.Equals("com." + serviceClass.FullName)) return true;
            }
            return false;
        }
    }
}

