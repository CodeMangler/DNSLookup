
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.VBox mainContainer;
	private global::Gtk.HBox inputContainer;
	private global::Gtk.VBox lookupParameterContainer;
	private global::Gtk.HBox lookupDomainContainer;
	private global::Gtk.Entry txtDomain;
	private global::Gtk.ComboBox cmbRecordType;
	private global::Gtk.Entry txtServer;
	private global::Gtk.Button btnLookup;
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	private global::Gtk.TextView txtOutput;
    
	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("DNSLookup");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.mainContainer = new global::Gtk.VBox ();
		this.mainContainer.Name = "mainContainer";
		this.mainContainer.Spacing = 6;
		// Container child mainContainer.Gtk.Box+BoxChild
		this.inputContainer = new global::Gtk.HBox ();
		this.inputContainer.Name = "inputContainer";
		this.inputContainer.Spacing = 6;
		// Container child inputContainer.Gtk.Box+BoxChild
		this.lookupParameterContainer = new global::Gtk.VBox ();
		this.lookupParameterContainer.Name = "lookupParameterContainer";
		this.lookupParameterContainer.Spacing = 6;
		// Container child lookupParameterContainer.Gtk.Box+BoxChild
		this.lookupDomainContainer = new global::Gtk.HBox ();
		this.lookupDomainContainer.Name = "lookupDomainContainer";
		this.lookupDomainContainer.Spacing = 6;
		// Container child lookupDomainContainer.Gtk.Box+BoxChild
		this.txtDomain = new global::Gtk.Entry ();
		this.txtDomain.CanFocus = true;
		this.txtDomain.Name = "txtDomain";
		this.txtDomain.IsEditable = true;
		this.txtDomain.InvisibleChar = '•';
		this.lookupDomainContainer.Add (this.txtDomain);
		global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.lookupDomainContainer [this.txtDomain]));
		w1.Position = 0;
		// Container child lookupDomainContainer.Gtk.Box+BoxChild
		this.cmbRecordType = global::Gtk.ComboBox.NewText ();
		this.cmbRecordType.AppendText (global::Mono.Unix.Catalog.GetString ("ANY"));
		this.cmbRecordType.AppendText (global::Mono.Unix.Catalog.GetString ("A"));
		this.cmbRecordType.AppendText (global::Mono.Unix.Catalog.GetString ("NS"));
		this.cmbRecordType.AppendText (global::Mono.Unix.Catalog.GetString ("MD"));
		this.cmbRecordType.AppendText (global::Mono.Unix.Catalog.GetString ("MF"));
		this.cmbRecordType.AppendText (global::Mono.Unix.Catalog.GetString ("CNAME"));
		this.cmbRecordType.AppendText (global::Mono.Unix.Catalog.GetString ("SOA"));
		this.cmbRecordType.AppendText (global::Mono.Unix.Catalog.GetString ("MB"));
		this.cmbRecordType.AppendText (global::Mono.Unix.Catalog.GetString ("MG"));
		this.cmbRecordType.AppendText (global::Mono.Unix.Catalog.GetString ("MR"));
		this.cmbRecordType.AppendText (global::Mono.Unix.Catalog.GetString ("NULL"));
		this.cmbRecordType.AppendText (global::Mono.Unix.Catalog.GetString ("WKS"));
		this.cmbRecordType.AppendText (global::Mono.Unix.Catalog.GetString ("PTR"));
		this.cmbRecordType.AppendText (global::Mono.Unix.Catalog.GetString ("HINFO"));
		this.cmbRecordType.AppendText (global::Mono.Unix.Catalog.GetString ("MINFO"));
		this.cmbRecordType.AppendText (global::Mono.Unix.Catalog.GetString ("MX"));
		this.cmbRecordType.AppendText (global::Mono.Unix.Catalog.GetString ("TXT"));
		this.cmbRecordType.AppendText (global::Mono.Unix.Catalog.GetString ("AXFR"));
		this.cmbRecordType.AppendText (global::Mono.Unix.Catalog.GetString ("MAILB"));
		this.cmbRecordType.AppendText (global::Mono.Unix.Catalog.GetString ("MAILA"));
		this.cmbRecordType.AppendText (global::Mono.Unix.Catalog.GetString ("SRV"));
		this.cmbRecordType.AppendText (global::Mono.Unix.Catalog.GetString ("AAAA"));
		this.cmbRecordType.CanDefault = true;
		this.cmbRecordType.Name = "cmbRecordType";
		this.cmbRecordType.Active = 0;
		this.lookupDomainContainer.Add (this.cmbRecordType);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.lookupDomainContainer [this.cmbRecordType]));
		w2.Position = 1;
		w2.Expand = false;
		w2.Fill = false;
		this.lookupParameterContainer.Add (this.lookupDomainContainer);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.lookupParameterContainer [this.lookupDomainContainer]));
		w3.Position = 0;
		w3.Expand = false;
		w3.Fill = false;
		// Container child lookupParameterContainer.Gtk.Box+BoxChild
		this.txtServer = new global::Gtk.Entry ();
		this.txtServer.CanFocus = true;
		this.txtServer.Name = "txtServer";
		this.txtServer.Text = global::Mono.Unix.Catalog.GetString ("8.8.8.8");
		this.txtServer.IsEditable = true;
		this.txtServer.InvisibleChar = '•';
		this.lookupParameterContainer.Add (this.txtServer);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.lookupParameterContainer [this.txtServer]));
		w4.Position = 1;
		w4.Expand = false;
		w4.Fill = false;
		this.inputContainer.Add (this.lookupParameterContainer);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.inputContainer [this.lookupParameterContainer]));
		w5.Position = 0;
		// Container child inputContainer.Gtk.Box+BoxChild
		this.btnLookup = new global::Gtk.Button ();
		this.btnLookup.CanFocus = true;
		this.btnLookup.Name = "btnLookup";
		this.btnLookup.UseUnderline = true;
		this.btnLookup.Label = global::Mono.Unix.Catalog.GetString ("Lookup");
		this.inputContainer.Add (this.btnLookup);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.inputContainer [this.btnLookup]));
		w6.Position = 1;
		w6.Expand = false;
		w6.Fill = false;
		this.mainContainer.Add (this.inputContainer);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.mainContainer [this.inputContainer]));
		w7.Position = 0;
		w7.Expand = false;
		w7.Fill = false;
		// Container child mainContainer.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.txtOutput = new global::Gtk.TextView ();
		this.txtOutput.CanFocus = true;
		this.txtOutput.Name = "txtOutput";
		this.GtkScrolledWindow.Add (this.txtOutput);
		this.mainContainer.Add (this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.mainContainer [this.GtkScrolledWindow]));
		w9.Position = 1;
		this.Add (this.mainContainer);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 674;
		this.DefaultHeight = 553;
		this.cmbRecordType.HasDefault = true;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.txtServer.FocusOutEvent += new global::Gtk.FocusOutEventHandler (this.txtServer_LostFocus);
		this.btnLookup.Clicked += new global::System.EventHandler (this.btnLookup_onClick);
	}
}
