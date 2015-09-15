using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Common.Events
{
    public class FilterCriteriaHandler : IObservable<FilterCriteria>
    {
        private List<IObserver<FilterCriteria>> observers;
        private FilterCriteria filterCriteria;

        public FilterCriteriaHandler()
        {
            observers = new List<IObserver<FilterCriteria>>();
            filterCriteria = new FilterCriteria();
        }
        public IDisposable Subscribe(IObserver<FilterCriteria> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
                observer.OnNext(filterCriteria);
            }

            return null;
        }
    }
}
