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
using Java.Lang;
using Android.Util;

namespace ServiceSample
{
    [Service(Name = "com.ServiceSample.CounterService")]
    class CounterService : Service, IRunnable, Counter
    {
        protected int count;
        private bool active;
        private Handler h;

        public IBinder Binder { get; private set; }

        public override void OnCreate()
        {
            base.OnCreate();

            active = true;
            
            h = new Handler();
            h.Post(this);

            Log.Debug("Counter Service", "OnCreate");
        }

        //Retorna a conexão para que o cliente acesse o serviço
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

        //Destrói o serviço e reinicia dados
        public override void OnDestroy()
        {
            Log.Debug("Counter Service", "OnDestroy");
            Binder = null;
            active = false;

            base.OnDestroy();
        }

        //Retorna o contador para o cliente
        public int Count()
        {
            return count;
        }

        //Algoritmo contador
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

        //Para a execução a cada 1 segundo
        private void SetInterval()
        {
            try { Thread.Sleep(1000); }
            catch (InterruptedException e) { e.PrintStackTrace(); }
        }
    }
}