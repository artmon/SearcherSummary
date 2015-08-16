using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using SearcherSummary.Common.Helpers;
using SearcherSummary.Model;
using SearcherSummary.Model.Model;
using SearcherSummary.Views;

namespace SearcherSummary.ViewModels
{
    public class ViewModelMain : ViewModelBase
    {
        public RelayCommand StartSearchCommand { get; set; }
        public RelayCommand ShowSummariesCommand { get; set; }

        private Summaries _summariesView;

        public Summaries SummariesView {
            get
            {
                if (_summariesView == null)
                {
                    _summariesView = new Summaries();
                    _summariesView.Closed += SummariesViewOnClosed;
                }

                return _summariesView;
            }

            set { _summariesView = value; }
        }

        private string _url;

        public string Url
        {
            get { return _url; }
            set
            {
                if (_url != value)
                {
                    _url = value;
                    RaisePropertyChanged("Url");                
                }
            }
        }

        private int _progress;

        public int Progress
        {
            get { return _progress; }
            set
            {
                if (_progress != value)
                {
                    _progress = value;
                    RaisePropertyChanged("Progress");
                }                
            }
        }       

        public ViewModelMain()
        {
            StartSearchCommand = new RelayCommand(StartSearch);
            ShowSummariesCommand = new RelayCommand(ShowSummaries);
            Url = Configuration.DefaultUrl;
        }

        private void StartSearch(object parameter)
        {
            BackgroundWorker bw = new BackgroundWorker();

            bw.DoWork += (delegate
            {
                SearchService.Search(parameter as string, i => Progress = i);
            });

            bw.RunWorkerCompleted += (delegate
            {
                MessageBox.Show("Собрано!", "Уведомление", MessageBoxButton.OK);
                Progress = 0;
            });

            bw.RunWorkerAsync();
        }

        private void ShowSummaries(object parameter)
        {
            var resume = SearchService.GetAllResume();

            var dataContext = new ViewModelSummaries(new ObservableCollection<Resume>(resume));
            SummariesView.SetDataContext( dataContext);

            SummariesView.Show();
            SummariesView.Activate();
        }

        #region Handlers 

        private void SummariesViewOnClosed(object sender, EventArgs eventArgs)
        {
            SummariesView = null;
        }

        #endregion Hanlers 
    }
}
