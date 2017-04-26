using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ProjectEulerProblems
{
    /// <summary>
    /// Retrieve problem details from the Project Euler website
    /// </summary>
    public class WebsiteManager
    {
        private const string ProjectEulerBaseUrl = "https://projecteuler.net";

        public HtmlNode GetHtmlTableFromWebsite()
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                //extract website contents
                string websiteContents = "";
                using (WebClient client = new WebClient())
                {
                    websiteContents = client.DownloadString(ProjectEulerBaseUrl + "/archives");
                }

                return ExtractTableNodeFromHtml(websiteContents);
            }
            catch
            {
                return null;
            }
        }

        public string ExtractProblemDetailsFromTableRow(HtmlNode tableRow)
        {
            try
            {
                string problemHref = GetProblemHrefForUrl(tableRow);

                string websiteContents = "";
                using (WebClient client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.ASCII;
                    websiteContents = client.DownloadString(ProjectEulerBaseUrl + "/" + problemHref);
                }

                return ExtractProblemDetailsFromHtml(websiteContents);
            }
            catch
            {
                return string.Empty;
            }
        }

        private HtmlNode ExtractTableNodeFromHtml(string websiteContents)
        {
            //Get table node
            HtmlDocument html = new HtmlDocument();

            html.LoadHtml(websiteContents);
            HtmlNode tableNode = html.DocumentNode.Descendants()
                .First(x => x.Name == "table" && x.Id == "problems_table");
            return tableNode;
        }

        private string ExtractProblemDetailsFromHtml(string websiteContents)
        {
            HtmlDocument html = new HtmlDocument();

            string decoded = HttpUtility.HtmlDecode(websiteContents);


            html.LoadHtml(websiteContents);
            List<HtmlNode> des = html.DocumentNode.Descendants().Where(x => x.Name == "div").ToList();

            HtmlNode problemDetailsNode =
                des.FirstOrDefault(x => x.HasAttributes && x.Attributes.Count(y => y.Value == "problem_content") == 1);
            string problemDetails = problemDetailsNode.InnerText;
            return problemDetails;
        }

        private string GetProblemHrefForUrl(HtmlNode tableRow)
        {
            List<HtmlNode> rowContents = tableRow.SelectNodes("td").ToList();
            string problemHref = rowContents[1].SelectSingleNode("a").GetAttributeValue("href", "");
            return problemHref;
        }
    }
}
