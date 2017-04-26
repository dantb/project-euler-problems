using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace ProjectEulerProblems
{
    public partial class ProblemsView : Form
    {
        private const string ProjectEulerBaseUrl = "https://projecteuler.net";

        private HashSet<int> _problemIdsFromWebsite = new HashSet<int>();

        public ProblemsView()
        {
            InitializeComponent();
            for (int i = 0; i < ProblemsListView.Columns.Count; i++)
            {
                ProblemsListView.Columns[i].Width = -2;
            }


            HtmlNode tableNode = GetHtmlTableFromWebsite();

            LoadProblemsIntoListViewAndAddToProblemsSet(tableNode);

            RunSolutionsToSolvedProblemsAndAddToView();
        }

        private void RunSolutionsToSolvedProblemsAndAddToView()
        {
            foreach (var problem in ProblemManager.Problems)
            {
                if (_problemIdsFromWebsite.Contains(problem.ProblemId))
                {
                    double solution = problem.GetSolution();
                    ProblemsListView.Items[problem.ProblemId - 1].SubItems.Add(solution.ToString());
                }
            }
        }

        private string ExtractProblemDetailsFromTableRow(HtmlNode tableRow)
        {
            List<HtmlNode> rowContents = tableRow.SelectNodes("td").ToList();
            string problemHref = rowContents[1].SelectSingleNode("a").GetAttributeValue("href", "");

            string websiteContents = "";
            using (WebClient client = new WebClient())
            {
                websiteContents = client.DownloadString(ProjectEulerBaseUrl + "/" + problemHref);
            }

            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(websiteContents);
            List<HtmlNode> des = html.DocumentNode.Descendants().Where(x => x.Name == "div").ToList();

            HtmlNode problemDetailsNode =
                des.FirstOrDefault(x => x.HasAttributes && x.Attributes.Count(y => y.Value == "problem_content") == 1);
            string problemDetails = problemDetailsNode.InnerText;

            return problemDetails;
        }

        private void LoadProblemsIntoListViewAndAddToProblemsSet(HtmlNode tableNode)
        {
            foreach (HtmlNode tableRow in tableNode.SelectNodes("tr"))
            {
                if (tableRow.Line > tableNode.Line + 1)
                {
                    List<HtmlNode> cellContents = tableRow.SelectNodes("th|td").ToList();
                    string id = cellContents[0].InnerText;
                    string description = cellContents[1].InnerText;
                    ListViewItem lvi = new ListViewItem(id);
                    lvi.SubItems.Add(description);
                    ProblemsListView.Items.Add(lvi);

                    _problemIdsFromWebsite.Add(int.Parse(id));

                    //string problemDetails = ExtractProblemDetailsFromTableRow(tableRow);
                }
            }
        }

        private HtmlNode GetHtmlTableFromWebsite()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //extract website contents
            string websiteContents = "";
            using (WebClient client = new WebClient())
            {
                websiteContents = client.DownloadString(ProjectEulerBaseUrl + "/archives");
            }

            //Get table node
            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(websiteContents);
            HtmlNode tableNode = html.DocumentNode.Descendants()
                .First(x => x.Name == "table" && x.Id == "problems_table");
            return tableNode;
        }
    }
}
