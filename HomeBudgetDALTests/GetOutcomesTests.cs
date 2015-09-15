using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeBudgetDAL;
using HomeBudget.Common;

namespace HomeBudgetDALTests
{
    [TestClass]
    public class GetOutcomesTests
    {
        IOutcomeService service;

        [TestInitialize]
        public void Setup()
        {
            service = OutcomeService.GetDefaultOutcomeService();  
        }

        [TestMethod]
        public void GetOutcomesWithNoFilterCriteria()
        {
            var result = service.GetOutcomes(null);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetOutcomesWithDateFromFilterCriteria()
        {
            FilterCriteria criteria = new FilterCriteria() { DateFrom = new DateTime(2013, 12, 22)};

            var result = service.GetOutcomes(criteria);
            bool allOutcomesOlderThanDate = result.TrueForAll(outcome => outcome.EntryDate >= criteria.DateFrom);
            Assert.AreEqual(allOutcomesOlderThanDate, true);
        }

        [TestMethod]
        public void GetOutcomeWithDateToFilterCriteria()
        {
            FilterCriteria criteria = new FilterCriteria() { DateTo = new DateTime(2013, 12, 22) };

            var result = service.GetOutcomes(criteria);

            bool allOutocomesYoungerthanDate = result.TrueForAll(outcome => outcome.EntryDate <= criteria.DateTo);
            Assert.AreEqual(allOutocomesYoungerthanDate, true);
        }

        [TestMethod]
        public void GetOutcomeByIdReturnOnlyOneResult()
        {
            int outcomeID = 1000;
            FilterCriteria criteria = new FilterCriteria() { OutcomeID = outcomeID };

            var result = service.GetOutcomes(criteria);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(outcomeID, result[0].OutcomeID);
        }


        [TestMethod]
        public void GetOutcomeByIdWithDateFilterSetup()
        {
            int outcomeID = 1000;
            FilterCriteria criteria = new FilterCriteria()
                                            { DateFrom = new DateTime(2013, 12, 22),
                                              DateTo = new DateTime(2014, 12, 22),
                                              OutcomeID = outcomeID
            };

            var result = service.GetOutcomes(criteria);

            Assert.AreEqual(outcomeID, (result[0] as Outcome).OutcomeID);
        }

        [TestMethod]
        public void GetOutcomesUsingCategoryID()
        {
            int categoryId = 3;
            FilterCriteria criteria = new FilterCriteria() { CategoryID = categoryId };

            var result = service.GetOutcomes(criteria);

            bool allHaveTheSameCategory = result.TrueForAll(p => p.CategoryID == categoryId);
            Assert.AreEqual(allHaveTheSameCategory, true);
        }
    }
}
