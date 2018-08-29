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
    //Classe responsável em estabelecer a conexão cliente / serviço
    class CountBinder : Binder
    {
        public CountBinder(CounterService service)
        {
            this.Service = service;
        }

        public CounterService Service { get; private set; }
    }
}