using System;
using System.Collections.Generic;

namespace ProjectEulerDataContracts
{
    public partial class Problem
    {
        public Problem()
        {
            Solutions = new List<Solution>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long? UpperBound { get; set; }
        public bool? IsClosedOnRight { get; set; }

        public virtual List<Solution> Solutions { get; set; }
    }
}
