using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace ServiceSample
{
    [Activity(Label = "BindServiceActivity")]
    public class BindServiceActivity : AppCompatActivity, IServiceConnection
    {
        private Count counter;
        private CountBinder binder;
        private bool isConnected;

        public void OnServiceConnected(ComponentName name, IBinder service)
        {
            binder = (CountBinder)service;

            isConnected = binder != null;

            if (isConnected)
            {
                counter = binder.Service;
                Toast.MakeText(this, "Service Connected", ToastLength.Short).Show();
            }
            else
            {
                counter = null;
                Toast.MakeText(this, "Service Not Connected", ToastLength.Short).Show();
            }
        }

        public void OnServiceDisconnected(ComponentName name)
        {
            counter = null;
            binder = null;
            isConnected = false;

            Toast.MakeText(this, "Service Disconnected", ToastLength.Short).Show();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.bind_service);

            isConnected = false;
            binder = null;

            Button buttonStartBind = (Button)FindViewById(Resource.Id.buttonStartBind);
            Button buttonStopBind = (Button)FindViewById(Resource.Id.buttonStopBind);
            Button buttonGetCounter = (Button)FindViewById(Resource.Id.buttonGetCount);

            buttonStartBind.Click += OnButtonStartBindClicked;
            buttonStopBind.Click += OnButtonStopBindClicked;
            buttonGetCounter.Click += OnButtonGetCounterClicked;
        }

        protected override void OnStop()
        {
            base.OnStop();
            UnbindConnection();
        }

        private void UnbindConnection()
        {
            if (binder != null)
            {
                binder = null;
                counter = null;
                UnbindService(this);
                Toast.MakeText(this, "Unbind Service", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Service is already unbind", ToastLength.Short).Show();
            }
        }

        private void OnButtonGetCounterClicked(object sender, EventArgs e)
        {
            if (counter != null)
            {
                Toast.MakeText(this, "Count: " + counter.GetCount(), ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Problems to access the service", ToastLength.Short).Show();
            }
        }

        private void OnButtonStopBindClicked(object sender, EventArgs e)
        {
            UnbindConnection();
        }

        private void OnButtonStartBindClicked(object sender, EventArgs e)
        {
            BindService(new Intent(this, typeof(CountService)), this, Bind.AutoCreate);
            Toast.MakeText(this, "Bind Service", ToastLength.Short).Show();
        }
    }
}