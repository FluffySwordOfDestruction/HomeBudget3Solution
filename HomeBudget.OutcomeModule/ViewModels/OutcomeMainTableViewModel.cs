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
    public class OutcomeMainTableViewModel: IObserver<FilterCriteria>, INotifyPropertyChanged
    {
        public IOutcomeService service;
        private FilterCriteria _criteria = null;

        public List<Outcome> Outcomes = new List<Outcome>();

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }

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
               Outcomes = service.GetOutcomes(_criteria);
               NotifyPropertyChanged("Outcomes");
            }
        }

        public void OnNext(FilterCriteria value)
        {
            _criteria = value;
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
