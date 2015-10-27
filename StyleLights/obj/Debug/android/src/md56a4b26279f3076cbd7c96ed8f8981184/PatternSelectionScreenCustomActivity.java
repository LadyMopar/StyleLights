package md56a4b26279f3076cbd7c96ed8f8981184;


public class PatternSelectionScreenCustomActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("StyleLights.PatternSelectionScreenCustomActivity, StyleLights, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", PatternSelectionScreenCustomActivity.class, __md_methods);
	}


	public PatternSelectionScreenCustomActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == PatternSelectionScreenCustomActivity.class)
			mono.android.TypeManager.Activate ("StyleLights.PatternSelectionScreenCustomActivity, StyleLights, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	java.util.ArrayList refList;
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
