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

namespace ServiceSample
{
    [Activity(Label = "BindServiceActivity")]
    public class BindServiceActivity : Activity, IServiceConnection
    {
        private Counter counter;
        private CountBinder binder;
        private bool isConnected;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.BindService);

            isConnected = false;
            binder = null;

            Button buttonStartBind = (Button)FindViewById(Resource.Id.buttonStartBind);
            Button buttonStopBind = (Button)FindViewById(Resource.Id.buttonStopBind);
            Button buttonGetCounter = (Button)FindViewById(Resource.Id.buttonGetCounter);

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

        private void OnButtonStartBindClicked(object sender, System.EventArgs e)
        {
            BindService(new Intent(this, typeof(CounterService)), this, Bind.AutoCreate);
            Toast.MakeText(this, "Bind Service", ToastLength.Short).Show();
        }

        private void OnButtonStopBindClicked(object sender, System.EventArgs e)
        {
            UnbindConnection();
        }

        private void OnButtonGetCounterClicked(object sender, System.EventArgs e)
        {
            if(counter != null)
            {
                Toast.MakeText(this, "Count: " + counter.Count(), ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Problems to access the service", ToastLength.Short).Show();
            }
        }

        public void OnServiceConnected(ComponentName name, IBinder service)
        {
            binder = (CountBinder)service;

            isConnected = binder != null;

            if(isConnected)
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
    }
}