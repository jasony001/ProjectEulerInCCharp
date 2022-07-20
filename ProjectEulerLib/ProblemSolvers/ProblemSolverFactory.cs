using System.Reflection;
using System.Collections.Generic;
using System;

namespace ProjectEulerLib
{

    public class ProblemSolverFactory
    {
        public ProblemSolver GetProblem(int problemId)
        {
            string className = $"ProjectEulerLib.Problem{problemId}Solver";

            Type type = Type.GetType(className);
            if (type == null) throw new ArgumentException($"problem {problemId} is not yet defined.");

            object prolemSolver = Activator.CreateInstance(type);
            if (prolemSolver == null) throw new ArgumentException($"problem {problemId} is not yet defined.");

            return (ProblemSolver)prolemSolver;
        }

        public List<string> GetAvailableProblemIdList()
        {
            List<string> problemIdList = new List<string>();

            Assembly assembly = Assembly.GetExecutingAssembly ();
            foreach(Type type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(ProblemSolver)))
                {
                    problemIdList.Add(type.Name.Replace("Problem", "").Replace("Solver", ""));
                }
            }

            return problemIdList;
        }
    }
}