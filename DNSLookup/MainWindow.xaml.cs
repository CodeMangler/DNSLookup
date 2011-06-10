using System;
using System.Windows;
using System.Windows.Controls;

namespace CodeMangler.DNSLookup
{
    public partial class MainWindow : Window
    {
        private const string DEFAULT_DNS_SERVER = "8.8.8.8";
        private LookupEngine _lookupEngine;

        public MainWindow()
        {
            InitializeComponent();
            initializeLookupEngine();
//            _lookupEngine = new LookupEngine("124.124.5.140");
//            _lookupEngine = new LookupEngine("124.124.5.141");
//            _lookupEngine = new LookupEngine("8.8.8.8");
        }

        private void btnQuery_Click(object sender, RoutedEventArgs e)
        {
            string query = txtQuery.Text;
            string queryType = cmbQueryType.Text;
            string result = _lookupEngine.Lookup(query, queryType);
            txtResults.Text = result;
        }

        private void txtServer_LostFocus(object sender, RoutedEventArgs e)
        {
            initializeLookupEngine();
        }

        private void initializeLookupEngine()
        {
            try
            {
                _lookupEngine = new LookupEngine(txtServer.Text);
            }
            catch (Exception)
            {
                txtServer.Text = DEFAULT_DNS_SERVER;
                _lookupEngine = new LookupEngine(txtServer.Text);
            }
        }
    }
}
