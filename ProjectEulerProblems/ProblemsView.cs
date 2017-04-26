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

        private WebsiteManager _websiteManager = new WebsiteManager();
        private HashSet<int> _problemIdsFromWebsite = new HashSet<int>();

        public ProblemsView()
        {
            InitializeComponent();
            for (int i = 0; i < ProblemsListView.Columns.Count; i++)
            {
                ProblemsListView.Columns[i].Width = -2;
            }

            HtmlNode tableNode = _websiteManager.GetHtmlTableFromWebsite();

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

        private void LoadProblemsIntoListViewAndAddToProblemsSet(HtmlNode tableNode)
        {
            if (tableNode != null)
            {
                foreach (HtmlNode tableRow in tableNode.SelectNodes("tr"))
                {
                    ProblemData data = GetProblemDataFromTableRow(tableNode, tableRow);
                    if (data != null)
                    {
                        ListViewItem lvi = new ListViewItem(data.Id);
                        lvi.SubItems.Add(data.Description);
                        lvi.SubItems.Add(data.Details);
                        ProblemsListView.Items.Add(lvi);
                    }
                }
            }
        }

        private ProblemData GetProblemDataFromTableRow(HtmlNode tableNode, HtmlNode tableRow)
        {
            if (tableRow.Line > tableNode.Line + 1)
            {
                List<HtmlNode> cellContents = tableRow.SelectNodes("th|td").ToList();
                string id = cellContents[0].InnerText;
                string description = cellContents[1].InnerText;
                string problemDetails = _websiteManager.ExtractProblemDetailsFromTableRow(tableRow);

                _problemIdsFromWebsite.Add(int.Parse(id));

                return new ProblemData(id, description, problemDetails);
            }
            return null;
        }
    }
}
