using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerProblems
{
    public class LargestPalindromeProduct : IProblem
    {
        public int ProblemId { get { return 4; } }

        public double GetSolution()
        {
            HashSet<int> products = new HashSet<int>();

            for (int i = 100; i < 999; i++)
            {
                if (i % 10 == 0)
                {
                    //can't start in 0
                    continue;
                }
                for (int j = 100; j < 999; j++)
                {
                    if (j % 10 == 0)
                    {
                        //can't start in 0
                        continue;
                    }
                    products.Add(i * j);
                }
            }

            HashSet<int> palindromes = new HashSet<int>();
            foreach (int prod in products)
            {
                Stack<char> stack = new Stack<char>();
                Queue<char> queue = new Queue<char>();
                foreach (char ch  in prod.ToString())
                {
                    stack.Push(ch);
                    queue.Enqueue(ch);
                }
                while (stack.Count > 0)
                {
                    char popped = stack.Pop();
                    char dequeued = queue.Dequeue();
                    if (popped != dequeued)
                    {
                        //not palindrome
                        break;
                    }                    
                }
                if (stack.Count == 0)
                {
                    //got to end, is a palindrome
                    palindromes.Add(prod);
                }
            }

            return palindromes.Max();
        }
    }
}
