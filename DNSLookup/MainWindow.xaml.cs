using System.Windows;
using System.Windows.Controls;

namespace CodeMangler.DNSLookup
{
    public partial class MainWindow : Window
    {
        private LookupEngine _lookupEngine;

        public MainWindow()
        {
            InitializeComponent();
//            _lookupEngine = new LookupEngine(txtServer.Text);
            _lookupEngine = new LookupEngine("124.124.5.140");
//            _lookupEngine = new LookupEngine("124.124.5.141");
        }

        private void btnQuery_Click(object sender, RoutedEventArgs e)
        {
            string query = txtQuery.Text;
            string queryType = cmbQueryType.SelectedValue as string;
            string result = _lookupEngine.Lookup(query, queryType);
            txtResults.Text = result;
        }

        private void txtServer_TextChanged(object sender, TextChangedEventArgs e)
        {
            _lookupEngine = new LookupEngine(txtServer.Text);
        }
    }
}
