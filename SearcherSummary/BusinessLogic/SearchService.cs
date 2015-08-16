using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using SearcherSummary.Contracts;
using SearcherSummary.DataAccess;
using SearcherSummary.Helpers;
using SearcherSummary.Model;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;


namespace SearcherSummary.BusinessLogic
{
    public class SearchService : ISearchService
    {

        #region fields

        private IDataAccessService _dataAccessService;
        private IResumeService _resumeService;
        
        #endregion 


        public SearchService(IDataAccessService dataAccessService, IResumeService resumeService)
        {
            _dataAccessService = dataAccessService;
            _resumeService = resumeService;
        }

        public void Search(string url, Action<int> setProgress)
        {
            var uri = new Uri(url);

            setProgress(10);

            HtmlDocument htmlDocument = HtmlDocumentHelper.LoadHtmlDocument(uri);

            setProgress(30);

            var html = htmlDocument.DocumentNode.InnerHtml;

            //Информация о резюме на странице хранится как Json в виде List = {<информация>} 
            //Достаем строку  "{<информация>}"
            var indexList = html.IndexOf("LIST");
            var indexStart = html.IndexOf('{', indexList);
            var indexEnd = html.IndexOf("};", indexList) + 1;
            var length = indexEnd - indexStart;

            string jsonResume = html.Substring(indexStart, length);
            var resumesJson = JObject.Parse(jsonResume);

            setProgress(40);

            var resumes = _resumeService.ParseResume(resumesJson);

            setProgress(90);

            _dataAccessService.SaveResumes(resumes);

            setProgress(100);
        }

        
        public List<Resume> GetAllResume()
        {
            return _dataAccessService.GetAllResumes();
        }

        public List<Resume> GetAllResumeByFilter(ResumeSearchParameters filter)
        {
            return _dataAccessService.GetAllResumeByFilter(filter);
        }


    }
}
