using HomeBudget.Common;
using HomeBudget.Common.Events;
using HomeBudgetDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.OutcomeModule.ViewModels
{
    public class OutcomeMainTableViewModel: IObserver<FilterCriteria>
    {
        private IOutcomeService service = null;
        private FilterCriteria criteria = null;
        
        public OutcomeMainTableViewModel(IOutcomeService serviceOutcome)
        {
            service = serviceOutcome;
            FilterCriteriaHandler.GetInstance().Subscribe(this);

            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject())) return;
            LoadOutcomes();
        }

        private void LoadOutcomes()
        {
            if (service != null)
            {
                service.GetOutcomes(criteria);
            }
        }

        public void OnNext(FilterCriteria value)
        {
            criteria = value;
            LoadOutcomes();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }
}
