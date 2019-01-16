using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Java.Lang;

namespace ServiceSample
{
    [Service(Name = "com.ServiceSample.CountService")]
    class CountService : Service, IRunnable, Count
    {
        protected int count;
        public static bool active;
        private Handler h;

        public override void OnCreate()
        {
            base.OnCreate();

            active = true;

            h = new Handler();
            h.Post(this);

            Log.Debug("Counter Service", "OnCreate");
        }

        public override void OnDestroy()
        {
            Log.Debug("Counter Service", "OnDestroy");
            Binder = null;
            active = false;

            base.OnDestroy();
        }

        public IBinder Binder { get; private set; }

        public override IBinder OnBind(Intent intent)
        {
            Log.Debug("Counter Service", "OnBind");

            this.Binder = new CountBinder(this);
            return this.Binder;
        }

        public override bool OnUnbind(Intent intent)
        {
            Log.Debug("Counter Service", "OnUnbind");

            return base.OnUnbind(intent);
        }

        public void Run()
        {
            if (active)
            {
                Log.Debug("Counter Service", "Count: " + count);
                count++;

                h.PostDelayed(this, 1000);
            }
            else
            {
                count = 0;
                Log.Debug("Counter Service", "Service End!!");

                StopSelf();
            }
        }

        public int GetCount()
        {
            return count;
        }

        private void SetInterval()
        {
            try { Thread.Sleep(1000); }
            catch (InterruptedException e) { e.PrintStackTrace(); }
        }
    }
}