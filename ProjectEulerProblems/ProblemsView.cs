using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace ProjectEulerProblems
{
    public partial class ProblemsView : Form
    {
        private const string ProjectEulerBaseUrl = "https://projecteuler.net";

        private WebsiteManager _websiteManager = new WebsiteManager();
        private SolutionsCache _solutionsCache = new SolutionsCache();
        private HashSet<int> _problemIdsFromWebsite = new HashSet<int>();
        private Dictionary<int, string> _problemUrlsKeyedByListViewRow = new Dictionary<int, string>();

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
                    double solution;
                    if (!_solutionsCache.TryGetSolutionFromCache(problem.ProblemId, out solution))
                    {
                        solution = problem.GetSolution();
                    }
                    ProblemsListView.Items[problem.ProblemId - 1].SubItems.Add(solution.ToString());
                    _solutionsCache.SaveSolutionToCache(problem.ProblemId, solution);
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
                        ProblemsListView.Items.Add(lvi);
                        _problemUrlsKeyedByListViewRow.Add(ProblemsListView.Items.Count - 1, data.Details);
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
                string problemUrl = _websiteManager.GetProblemUrl(tableRow);
                string problemDetails = _websiteManager.ExtractProblemDetailsFromTableRow(problemUrl);

                _problemIdsFromWebsite.Add(int.Parse(id));

                return new ProblemData(id, description, problemDetails);
            }
            return null;
        }

        private void ProblemsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var hit = ProblemsListView.HitTest(new System.Drawing.Point(e.X, e.Y));
            var item = hit.Item;
            if (item != null)
            {
                ShowProblemDetailsRtbFromIndex(item.Index);
            }
        }

        private void ProblemsListView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (ProblemsListView.SelectedItems.Count == 1)
                {
                    int index = ProblemsListView.SelectedIndices[0];
                    ShowProblemDetailsRtbFromIndex(index);
                }
            }
        }

        private void ShowProblemDetailsRtbFromIndex(int index)
        { 
            string problemDetails = _problemUrlsKeyedByListViewRow[index];
            ProblemRichTextBox.Text = problemDetails;
            ProblemRichTextBox.Visible = true;
        }
    }
}
