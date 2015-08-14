using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeBudgetDAL;

namespace HomeBudgetDALTests
{
    [TestClass]
    public class GetOutcomesTests
    {
        IOutcomeService service;

        [TestInitialize]
        public void Setup()
        {
            service = new OutcomeService();  
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

            CollectionAssert.AllItemsAreNotNull(result);
        }

        [TestMethod]
        public void GetOutcomeWithDateToFilterCriteria()
        {

        }
    }
}
