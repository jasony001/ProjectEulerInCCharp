using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem5Solver : ProblemSolver
    {

        public Problem5Solver() : base()
        {
            Problem.Id = 5;
            Problem.Title = "Smallest multiple";
            Problem.Description =
                "Build factor list, product divided by each number2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.\n"
                    + "\n"
                    + "What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?\n";


            Problem.Solutions.Add(new Solution
            {
                ProblemId = 5,
                Description = "Build factor list, product divided by each number",
                Version = 1,
            });
            Problem.Solutions.Add(new Solution
            {
                ProblemId = 2,
                Description = "Build factor list, foreach number add dividen remainder",
                Version = 2,
            });
        }

        public override string solution1()
        {
            List<long> factors = new List<long>();
            long f = 2;
            long product = 1;

            while (f < 21)
            {
                if (product % f > 0)
                {
                    List<long> tempList = new List<long>(factors);

                    foreach (long uf in tempList)
                    {
                        if (f % uf == 0)
                        {
                            product /= uf;
                            factors.Remove(uf);
                        }
                    }
                    product *= f;
                    factors.Add(f);
                }
                f++;
            }

            return product.ToString();
        }

        public override string solution2()
        {
            long calc = 0;
            long product = 1;

            List<long> fList = new List<long>();

            for (long l = 2; l <= 20; l++)
            {
                long nf = l;
                foreach (long f in fList)
                {
                    calc++;
                    if (nf % f == 0) nf /= f;
                }

                calc++;
                if (nf > 1) fList.Add(nf);
            }


            foreach (long f in fList)
            {
                product *= f;
                calc++;
            }

            return product.ToString();
        }
    }
}
