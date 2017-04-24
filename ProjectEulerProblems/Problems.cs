using System.Net;
using System.Windows.Forms;

namespace ProjectEulerProblems
{
    public partial class Problems : Form
    {
        public Problems()
        {
            InitializeComponent();
            for (int i = 0; i < ProblemsListView.Columns.Count; i++)
            {
                ProblemsListView.Columns[i].Width = -2;
            }

            
            LoadProblemsIntoView();
        }

        private void LoadProblemsIntoView()
        {
            string websiteContents = "";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (WebClient client = new WebClient())
            {
                //TODO - use project euler website to get table of problems into a file locally
                websiteContents = client.DownloadString("https://projecteuler.net/archives");
            }
            EasyProblemManager easyPM = new EasyProblemManager();
            foreach (var problem in easyPM.EasyProblems)
            {
                ListViewItem lvi = new ListViewItem(problem.ProblemId.ToString());
                lvi.SubItems.Add(problem.Title);
                double solution = problem.GetSolution();
                lvi.SubItems.Add(solution.ToString());
                ProblemsListView.Items.Add(lvi);
            }
        }
    }
}
