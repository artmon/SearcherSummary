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

        private decimal _salaryLower;

        public decimal SalaryLower
        {
            get { return _salaryLower; }
            set
            {
                if (_salaryLower != value)
                {
                    _salaryLower = value;
                    RaisePropertyChanged("SalaryLower");
                }            
            }
        }

        private decimal _salaryUpper;

        public decimal SalaryUpper
        {
            get { return _salaryUpper; }
            set
            {
                if (_salaryUpper != value)
                {
                    _salaryUpper = value;
                    RaisePropertyChanged("SalaryUpper");
                }
            }
        }

        private decimal _salaryMax;

        public decimal SalaryMax
        {
            get { return _salaryMax; }
            set
            {
                if (_salaryMax != value)
                {
                    _salaryMax = value;
                    RaisePropertyChanged("SalaryMax");
                }
            }
        }

        public RelayCommand SearchCommand { get; set; }

        public ViewModelSummaries()
        {
            
        }

        public ViewModelSummaries(ObservableCollection<Resume> resumes)
        {
            Resumes = resumes;
            SalaryUpper = Resumes.Max(r => r.Salary).GetValueOrDefault(0);
            SalaryMax = SalaryUpper;

            
            SearchCommand = new RelayCommand(Search);
        }


        private void Search(object parameter)
        {
            var filter = new ResumeSearchParameters();


            filter.Header = parameter as string;

            filter.SalaryLower = SalaryLower;
            filter.SalaryUpper = SalaryUpper;

            Resumes = new ObservableCollection<Resume>(SearchService.GetAllResumeByFilter(filter));
        }
    }
}
