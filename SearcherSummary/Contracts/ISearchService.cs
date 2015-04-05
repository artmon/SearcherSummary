﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearcherSummary.Model;

namespace SearcherSummary.Contracts
{
    public interface ISearchService
    {
        void Search(string url);

        List<Resume> GetAllResume();

        List<Resume> GetAllResumeByFilter(string filter);
    }
}