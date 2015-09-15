using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Common
{
    public class FilterCriteria
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? OutcomeID { get; set; }
        public int? CategoryID { get; set; }
    }
}
