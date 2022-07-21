using System;
using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectEulerDataContracts
{
    public partial class Solution
    {
        public Solution()
        {
        }

        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProblemId { get; set; }
        public int Version { get; set; }
        public string Description { get; set; }
        public string Answer { get; set; }
        public int TestRunElapsedTime {get;set;}
    }
}
