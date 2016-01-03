using HomeBudget.Common;
using HomeBudget.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeBudget.OutcomeModule
{
    /// <summary>
    /// Interaction logic for OutcomeFilters.xaml
    /// </summary>
    public partial class OutcomeFilters : UserControl
    {
        
        public OutcomeFilters()
        {
            InitializeComponent();            
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            //Filtrujemy
            
            FilterCriteria criteria = GetFilterCriteria();

            FilterCriteriaHandler.GetInstance().SetFilterCriteria(criteria);
            FilterCriteriaHandler.GetInstance().Notify();


        }

        private FilterCriteria GetFilterCriteria()
        {
            FilterCriteria criteria = new FilterCriteria();

            if (CbCategory.SelectedIndex > -1)
                criteria.CategoryID = Convert.ToInt32(CbCategory.SelectedValue);

            return criteria;
        }
    }
}
