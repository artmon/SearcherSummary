﻿using System;
using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace SearcherSummary.Common.Helpers
{
    public static class HtmlDocumentHelper
    {

        public static HtmlDocument LoadHtmlDocument(Uri uri)
        {
            HtmlDocument resultat = new HtmlDocument();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Timeout = (int)new TimeSpan(0, 1, 30).TotalMilliseconds;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";

            WebResponse response = request.GetResponse();

            using (System.IO.Stream stream = response.GetResponseStream())
            using (System.IO.StreamReader streamReader = new System.IO.StreamReader(stream, Encoding.UTF8))
            {
                string source = streamReader.ReadToEnd();
                source = WebUtility.HtmlDecode(source);
                resultat.LoadHtml(source);
            }

            return resultat;
        }

    }
}
