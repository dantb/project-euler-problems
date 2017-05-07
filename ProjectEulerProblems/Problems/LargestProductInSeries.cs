using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerProblems
{
    public class LargestProductInSeries : IProblem
    {
        const string Series = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016" +
            "9848018694788518438586156078911294949545950173795833195285320880551112540698747158523863050715693290" +
            "9632952274430435576689664895044524452316173185640309871112172238311362229893423380308135336276614282" +
            "8064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921" +
            "9016997208880937766572733300105336788122023542180975125454059475224352584907711670556013604839586446" +
            "7063244157221553975369781797784617406495514929086256932197846862248283972241375657056057490261407972" +
            "9686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674" +
            "8139191231628245861786645835912456652947654568284891288314260769004224219022671055626321111109370544" +
            "2175069416589604080719840385096245544436298123098787992724428490918884580156166097919133875499200524" +
            "0636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823" +
            "257530420752963450";

        public int ProblemId { get { return 8; } }

        public double GetSolution()
        {
            List<string> splitAroundZeros = Series.Split('0').Where(s => s.Length >= 13).ToList();
            HashSet<double> products = new HashSet<double>();

            foreach (string digits in splitAroundZeros)
            {
                List<int> rollingList = new List<int>();

                //initialise rolling list with first 13
                double product = 1;
                for (int i = 0; i < 13; i++)
                {
                    int value = int.Parse(digits[i].ToString());
                    product *= value;
                    rollingList.Add(value);
                }

                products.Add(product);

                //now loop through chunks of 13, dividing by first and multiplying by next
                //update rolling list to remove the first and add the last
                int indexToInclude = 13;
                while (indexToInclude < digits.Length)
                {
                    product /= rollingList[0];
                    int value = int.Parse(digits[indexToInclude].ToString());
                    product *= value;
                    products.Add(product);
                    rollingList.Add(value);
                    rollingList.RemoveAt(0);
                    indexToInclude++;
                }
            }          

            double answer = products.Max();
            return answer;
        }
    }
}
