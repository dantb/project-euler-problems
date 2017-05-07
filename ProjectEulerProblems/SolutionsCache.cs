using System.Collections.Generic;
using System.IO;

namespace ProjectEulerProblems
{
    public class SolutionsCache
    {
        private const string CacheFolder = "./Cache";
        private const string SolutionsCacheFile = "./Cache/SolutionsCache.txt";

        private Dictionary<int, SolutionsCacheData> _problemsWithSolutions;

        public SolutionsCache()
        {
            _problemsWithSolutions = new Dictionary<int, SolutionsCacheData>();
            if (File.Exists(SolutionsCacheFile))
            {
                string[] lines = File.ReadAllLines(SolutionsCacheFile);
                foreach (string line in lines)
                {
                    string[] splitter = line.Split(';');
                    string[] secondSplitter = splitter[1].Split('-');
                    double solution = double.Parse(secondSplitter[0]);
                    double time = double.Parse(secondSplitter[1]);
                    _problemsWithSolutions.Add(int.Parse(splitter[0]), new SolutionsCacheData(solution, time));
                }
            }
        }

        internal void SaveSolutionToCache(int problemId, double solution, double time)
        {
            if (!Directory.Exists(CacheFolder))
            {
                Directory.CreateDirectory(CacheFolder);
            }

            if (!File.Exists(SolutionsCacheFile))
            {
                File.Create(SolutionsCacheFile).Close();
            }

            if (!_problemsWithSolutions.ContainsKey(problemId))
            {
                _problemsWithSolutions.Add(problemId, new SolutionsCacheData(solution, time));
                File.AppendAllLines(SolutionsCacheFile, new string[] { $"{problemId};{solution}-{time}" });
            }
        }

        internal bool TryGetSolutionFromCache(int problemId, out double solution, out double time)
        {
            solution = 0;
            time = 0;
            if (_problemsWithSolutions.ContainsKey(problemId))
            {
                solution = _problemsWithSolutions[problemId].Solution;
                time = _problemsWithSolutions[problemId].SolvingTime;
                return true;
            }
            return false;
        }
    }

    class SolutionsCacheData
    {
        public double Solution;
        public double SolvingTime;

        public SolutionsCacheData(double solution, double time)
        {
            Solution = solution;
            SolvingTime = time;
        }
    }
}
