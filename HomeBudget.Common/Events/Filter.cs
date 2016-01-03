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
        private static FilterCriteriaHandler instance = null;

        public static FilterCriteriaHandler GetInstance()
        {
            if (instance == null)
                instance = new FilterCriteriaHandler();

            return instance;
        }
        private FilterCriteriaHandler()
        {
            observers = new List<IObserver<FilterCriteria>>();
            filterCriteria = new FilterCriteria();
        }


        public void ClearFilterCriteria()
        {
            filterCriteria = null;
        }

        public void SetFilterCriteria(FilterCriteria criteria)
        {
            filterCriteria = criteria;
        }
        public IDisposable Subscribe(IObserver<FilterCriteria> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
               // observer.OnNext(filterCriteria);
            }

            return null;
        }

        public void Notify()
        {
            observers.ForEach(observer => observer.OnNext(filterCriteria));
        }
    }
}
