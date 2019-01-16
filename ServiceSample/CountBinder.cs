using Android.OS;

namespace ServiceSample
{
    class CountBinder : Binder
    {
        public CountBinder(CountService service)
        {
            this.Service = service;
        }

        public CountService Service { get; private set; }
    }
}