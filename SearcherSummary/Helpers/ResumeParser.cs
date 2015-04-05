using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using HtmlAgilityPack;
using SearcherSummary.Model;

namespace SearcherSummary.Helpers
{
    public class ResumeParser
    {
        //TODO Сделать проверку на NUll везде

        private static readonly string _today = "Сегодня";
        private static readonly string _yesterday = "Вчера";


        #region ShortResumeParse

        public List<ShortResume> ParseListShortResume(HtmlDocument doc)
        {
            var result = new List<ShortResume>();
            ShortResume resume;

            var resumes = doc.DocumentNode.Descendants("div")
                .Where(
                    x =>
                        x.Attributes["class"] != null &&
                        x.Attributes["class"].Value.Contains("ra-elements-list__item") //&&
                //x.Attributes["data-id"] != null); 
                );
            foreach (var htmlResume in resumes)
            {
                resume = new ShortResume();

                resume.Id = GetId(htmlResume);
                resume.PublicateDate = GetPublicDate(htmlResume);
                resume.ReferenceOnFullVersion = ParseReferenceOnFullVersion(htmlResume);
                resume.ResumeView = htmlResume.InnerHtml;
                //if (!string.IsNullOrEmpty(resume.ReferenceOnFullVersion))
                //{
                //    resume.Id =
                //        resume.ReferenceOnFullVersion.Substring(
                //            resume.ReferenceOnFullVersion.IndexOf("id=", StringComparison.InvariantCulture) + 3);
                //}

                result.Add(resume);
            }

            return result;
        }

        private string GetId(HtmlNode htmlResume)
        {
            if (htmlResume.Attributes["data-id"] == null)
            {
                return null;               
            }

            return htmlResume.Attributes["data-id"].Value;
        }

        private DateTime? GetPublicDate(HtmlNode htmlResume)
        {
            var htmlDate = htmlResume.Descendants("div")
                .FirstOrDefault(
                    x =>
                        x.Attributes["class"] != null &&
                        x.Attributes["class"].Value.Contains("ra-elements-list__date")); 

            var date = GetDate(htmlDate);

            var htmlDateTime = htmlResume.Descendants("div")
                .FirstOrDefault(
                    x =>
                        x.Attributes["class"] != null &&
                        x.Attributes["class"].Value.Contains("ra-elements-list__date-time"));

            var dateTime = GetDate(htmlDateTime);

            if (date.HasValue && dateTime.HasValue)
            {
                date = date.Value.Add(dateTime.Value.TimeOfDay);
            }

            return date;
        }

        private DateTime? GetDate(HtmlNode htmlDate)
        {
            if (htmlDate == null)
            {
                return null;
            }

            var str = htmlDate.InnerText;

            DateTime result;


            if (str.Contains(_today))
            {
                return DateTime.Now.Date;
            }

            if (str.Contains(_yesterday))
            {
                return DateTime.Now.Date.AddDays(-1);
            }

            if (DateTime.TryParse(str, out result))
            {
                return result;
            }

            return null;
        }

        private string ParseReferenceOnFullVersion(HtmlNode htmlResume)
        {
            var htmlRef = htmlResume.Descendants("a")
                    .FirstOrDefault(
                        x =>
                            x.Attributes["class"] != null &&
                            x.Attributes["class"].Value.Contains("ra-elements-list__title__link")); 

            if (htmlRef == null || htmlRef.Attributes["href"] == null )
            {
                return null;
            }

            return htmlRef.Attributes["href"].Value;
        }

        #endregion ShortResumeParse


        public Resume ParseResume(HtmlDocument doc)
        {




            return  new Resume();           
        }
    }
}
