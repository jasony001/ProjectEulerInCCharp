using System;
using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectEulerDataContracts
{
    public partial class SolutionCode
    {
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SolutionId { get; set; }
        public int LineNumber { get; set; }
        public string Code { get; set; }
    }
}
