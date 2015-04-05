using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SearcherSummary.Views
{
    /// <summary>
    /// Interaction logic for ResumeView.xaml
    /// </summary>
    public partial class ResumeView : Window
    {
        private string _url;

        public string Url 
        {
            get { return _url; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && !value.Equals(_url))
                {
                    _url = value;
                    webBrowser.Navigate(_url);
                }
            }
        }

        public ResumeView()
        {
            InitializeComponent();
        }
    }
}
