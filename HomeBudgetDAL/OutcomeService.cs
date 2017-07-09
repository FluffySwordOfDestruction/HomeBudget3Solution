using HomeBudget.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudgetDAL
{
    public class OutcomeService : IOutcomeService
    {
        HomeBudgetEntities context;


        public OutcomeService(DbContext ctx)
        {
            context = ctx as HomeBudgetEntities;
        }
        private OutcomeService()
        {
            context = new HomeBudgetEntities();
        }


        public static OutcomeService GetDefaultOutcomeService()
        {
            return new OutcomeService();
        }

        public List<Outcome> GetOutcomes(FilterCriteria criteria)
        {
            HomeBudgetEntities context = new HomeBudgetEntities();

            IQueryable<Outcome> result = context.Outcomes.AsQueryable<Outcome>();

            if (criteria == null)
                return result.OrderByDescending(outcome => outcome.OutcomeID).Take(100).ToList();

            if (criteria.OutcomeID.HasValue)
                return GetOutcomeById(result, criteria).ToList<Outcome>();

            result = GetOutcomeFromDate(result, criteria);
            result = GetOutcomeToDate(result, criteria);
            result = GetOutcomesWithCategory(result, criteria);

            return result.ToList<Outcome>();
        }

        private IQueryable<Outcome> GetOutcomesWithCategory(IQueryable<Outcome> query, FilterCriteria criteria)
        {
            if (criteria.CategoryID.HasValue)
                return query.Where(outcome => outcome.CategoryID == criteria.CategoryID.Value);

            return query;
        }

        private IQueryable<Outcome> GetOutcomeById(IQueryable<Outcome> query, FilterCriteria criteria)
        {
            if (criteria.OutcomeID.HasValue)
                return query.Where(outcome => outcome.OutcomeID == criteria.OutcomeID.Value);

            return query;
        }

        private IQueryable<Outcome> GetOutcomeToDate(IQueryable<Outcome> query, FilterCriteria criteria)
        {
            if (criteria.DateTo != null)
                return query.Where(outcome => outcome.EntryDate <= criteria.DateTo);

            return query;
        }

        private IQueryable<Outcome> GetOutcomeFromDate(IQueryable<Outcome> query, FilterCriteria criteria)
        {
            if (criteria.DateFrom != null)
                return query.Where(outcome => outcome.EntryDate >= criteria.DateFrom);

            return query;

        }

        public bool SaveOutcome(Outcome outcome)
        {
            context.Outcomes.Add(outcome);
            int result = context.SaveChanges();
            return result > 0;
        }

        public int GetCategoryId(string categoryName)
        {
            if (context == null)
                CreateContext();

            var result = context.Categories.FirstOrDefault(x => x.Name.ToLowerInvariant() == categoryName.ToLowerInvariant());
            return result != null ? result.CategoryID : -1;
        }

        private void CreateContext()
        {
            context = new HomeBudgetEntities();
        }

        public List<Category> GetCategories()
        {
            if (context == null)
                CreateContext();
            return context.Categories.ToList();
        }
    }
}
