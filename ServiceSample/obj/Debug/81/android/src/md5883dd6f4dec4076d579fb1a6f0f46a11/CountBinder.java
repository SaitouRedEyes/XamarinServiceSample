package md5883dd6f4dec4076d579fb1a6f0f46a11;


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
		mono.android.Runtime.register ("ServiceSample.CountBinder, ServiceSample", CountBinder.class, __md_methods);
	}


	public CountBinder ()
	{
		super ();
		if (getClass () == CountBinder.class)
			mono.android.TypeManager.Activate ("ServiceSample.CountBinder, ServiceSample", "", this, new java.lang.Object[] {  });
	}

	public CountBinder (com.ServiceSample.CountService p0)
	{
		super ();
		if (getClass () == CountBinder.class)
			mono.android.TypeManager.Activate ("ServiceSample.CountBinder, ServiceSample", "ServiceSample.CountService, ServiceSample", this, new java.lang.Object[] { p0 });
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
