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
using SearcherSummary.Common.Helpers;
using SearcherSummary.Model;
using SearcherSummary.Model.Model;
using SearcherSummary.ViewModels;

namespace SearcherSummary.Views
{
    /// <summary>
    /// Interaction logic for Summaries.xaml
    /// </summary>
    public partial class Summaries : Window
    {

        private ViewModelSummaries _viewModelSummaries;

        public Summaries()
        {
            InitializeComponent();
            dgResume.MouseDoubleClick += DgResumeOnMouseDoubleClick;
        }


        public void SetDataContext(ViewModelSummaries viewModel)
        {
            _viewModelSummaries = viewModel;
            this.DataContext = _viewModelSummaries;
        }


        private void DgResumeOnMouseDoubleClick(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            var selectedResume = dgResume.SelectedItem as Resume;

            if (selectedResume == null)
            {
                return; 
            }

            var resumeView = new ResumeView();
            resumeView.Url = ResumeHelper.ResolveAbsoluteUrl(selectedResume.Url);
            resumeView.Show();
        }

    }
}
