using HomeBudget.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudgetDAL
{
    public interface IOutcomeService
    {        
        List<Outcome> GetOutcomes(FilterCriteria criteria);
    }
}
