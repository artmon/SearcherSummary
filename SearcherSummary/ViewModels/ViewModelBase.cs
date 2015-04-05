using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearcherSummary.Contracts;
using SearcherSummary.Helpers;

namespace SearcherSummary.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        internal void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }

        private ISearchService _searchService;

        public ISearchService SearchService
        {
            get
            {
                if (_searchService == null)
                {
                    _searchService = ServiceLocatorManagement.WindsorContainer.Resolve<ISearchService>();
                }

                return _searchService;
            }
        }


    }
}
