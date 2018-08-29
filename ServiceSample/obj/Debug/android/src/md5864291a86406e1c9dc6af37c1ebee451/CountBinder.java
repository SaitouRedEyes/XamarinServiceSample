package md5864291a86406e1c9dc6af37c1ebee451;


public class CountBinder
	extends android.os.Binder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ServiceSample.CountBinder, ServiceSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CountBinder.class, __md_methods);
	}


	public CountBinder ()
	{
		super ();
		if (getClass () == CountBinder.class)
			mono.android.TypeManager.Activate ("ServiceSample.CountBinder, ServiceSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public CountBinder (com.ServiceSample.CounterService p0)
	{
		super ();
		if (getClass () == CountBinder.class)
			mono.android.TypeManager.Activate ("ServiceSample.CountBinder, ServiceSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "ServiceSample.CounterService, ServiceSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
