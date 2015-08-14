using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudgetDAL
{
    public class OutcomeService : IOutcomeService
    {

        public List<Outcome> GetOutcomes(FilterCriteria criteria)
        {
            HomeBudgetEntities context = new HomeBudgetEntities();

            var result = context.Outcomes;

            if (criteria == null)
                return result.OrderByDescending(outcome => outcome.OutcomeID).Take(100).ToList();

             GetOutcomeFromDate(result, criteria);
             GetOutcomeToDate(criteria, result);

            result.Take(10);

            return result.ToList<Outcome>();
        }

        private void GetOutcomeToDate(FilterCriteria criteria, IQueryable<Outcome> query)
        {
            if (criteria.DateTo != null)
                query.Where(outcome => outcome.EntryDate <= criteria.DateTo);
        }

        private void GetOutcomeFromDate(IQueryable<Outcome> query, FilterCriteria criteria)
        {
            if (criteria.DateFrom != null)
                query.Where(outcome => outcome.EntryDate >= criteria.DateFrom);

        }
    }
}
