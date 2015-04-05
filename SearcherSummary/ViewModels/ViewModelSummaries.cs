using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearcherSummary.Helpers;
using SearcherSummary.Model;

namespace SearcherSummary.ViewModels
{
    public class ViewModelSummaries: ViewModelBase
    {

        private ObservableCollection<Resume> _resumes;

        public  ObservableCollection<Resume> Resumes
        {
            get { return _resumes; }
            set
            {
                if (_resumes != value)
                {
                    _resumes = value;
                    RaisePropertyChanged("Resumes");
                }
            }
        }

        public RelayCommand SearchCommand { get; set; }

        public ViewModelSummaries()
        {
            SearchCommand = new RelayCommand(Search);
        }


        private void Search(object parameter)
        {
            var filter = parameter as string;

            if (string.IsNullOrWhiteSpace(filter))
            {
                return;
            }

            Resumes = new ObservableCollection<Resume>(SearchService.GetAllResumeByFilter(filter)); 
        }


    }
}
