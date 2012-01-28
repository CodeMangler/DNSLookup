using System;
using Gtk;
using CodeMangler.DNSLookup;

public partial class MainWindow: Gtk.Window
{	
	private LookupEngine _engine;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void btnLookup_onClick (object sender, System.EventArgs e)
	{
		if(_engine == null)
			_engine = new LookupEngine (txtServer.Text);
		
		txtOutput.Buffer.Text = _engine.Lookup(txtDomain.Text, cmbRecordType.ActiveText);;
	}

	protected void txtServer_LostFocus (object o, Gtk.FocusOutEventArgs args)
	{
		_engine = new LookupEngine (txtServer.Text);
	}
}
