using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Common
{
    public class NavigationController
    {       
        public Action ShowOutcomes { get; set; }

        public Action ShowIncome { get; set; }

        public Action ShowCategories { get; set; }

        public Action ShowReports { get; set; }

        public Action ShowSettings { get; set; }

        public Action ExitApp { get; set; }
    }
}
