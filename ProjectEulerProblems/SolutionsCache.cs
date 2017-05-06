using System.Collections.Generic;
using System.IO;

namespace ProjectEulerProblems
{
    public class SolutionsCache
    {
        private const string SolutionsCacheFolder = "./Cache";
        private const string SolutionsCacheFile = "./Cache/SolutionsCache.txt";

        private Dictionary<int, double> _problemsWithSolutions = new Dictionary<int, double>();

        public SolutionsCache()
        {
            if (File.Exists(SolutionsCacheFile))
            {
                string[] lines = File.ReadAllLines(SolutionsCacheFile);
                foreach (string line in lines)
                {
                    string[] splitter = line.Split(';');
                    _problemsWithSolutions.Add(int.Parse(splitter[0]), double.Parse(splitter[1]));
                }
            }
        }

        internal void SaveSolutionToCache(int problemId, double solution)
        {
            if (!Directory.Exists(SolutionsCacheFolder))
            {
                Directory.CreateDirectory(SolutionsCacheFolder);
            }

            if (!File.Exists(SolutionsCacheFile))
            {
                File.Create(SolutionsCacheFile).Close();
            }

            if (!_problemsWithSolutions.ContainsKey(problemId))
            {
                _problemsWithSolutions.Add(problemId, solution);
                File.AppendAllLines(SolutionsCacheFile, new string[] { $"{problemId};{solution}" });
            }
        }

        internal bool TryGetSolutionFromCache(int problemId, out double solution)
        {
            solution = 0;
            if (_problemsWithSolutions.ContainsKey(problemId))
            {
                solution = _problemsWithSolutions[problemId];
                return true;
            }
            return false;
        }
    }
}
