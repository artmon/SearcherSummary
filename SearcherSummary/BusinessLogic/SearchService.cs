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
using WebKit;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;


namespace SearcherSummary.BusinessLogic
{
    public class SearchService : ISearchService
    {
        //TODO добавить логирование и try catch

        #region fields

        private IDataAccessService _dataAccessService;
        private IResumeService _resumeService;
        
        #endregion 


        public SearchService(IDataAccessService dataAccessService, IResumeService resumeService)
        {
            _dataAccessService = dataAccessService;
            _resumeService = resumeService;
        }

        public void Search(string url)
        {
            var uri = new Uri(url);

            HtmlDocument tradeHtmlDocument = Helpers.HtmlDocumentHelper.LoadHtmlDocument(uri);
 
            //TODO: Сделать RegEx
            var indexList = tradeHtmlDocument.DocumentNode.InnerHtml.IndexOf("LIST");
            var indexAccessToken = tradeHtmlDocument.DocumentNode.InnerHtml.IndexOf("ACCESS_TOKEN");
            var tempStr = tradeHtmlDocument.DocumentNode.InnerHtml.Substring(indexList, indexAccessToken - indexList);

            var indexStart = tempStr.IndexOf('{');
            var indexEnd = tempStr.LastIndexOf('}');

            string jsonResume = tempStr.Substring(indexStart, indexEnd - indexStart + 1);
            dynamic resumesJson = JObject.Parse(jsonResume);

            var resumes = _resumeService.ParseResume(resumesJson);

            _dataAccessService.SaveResumes(resumes);
        }

        
        public List<Resume> GetAllResume()
        {
            return _dataAccessService.GetAllResumes();
        }

        public List<Resume> GetAllResumeByFilter(string filter)
        {
            return _dataAccessService.GetAllResumeByFilter(filter);
        }


    }
}
