using Autofac;
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
    /// Interaction logic for OutcomeMainView.xaml
    /// </summary>
    public partial class OutcomeMainView : UserControl 
    {
        public OutcomeMainView(IContainer container)
        {
            InitializeComponent();

            var mainTable = container.Resolve<OutcomeMainTable>();
            var filters = container.Resolve<OutcomeFilters>();

            Grid.SetRow(mainTable, 0);
            Grid.SetColumn(mainTable, 1);
            GridLayout.Children.Add(mainTable);

            Grid.SetRow(filters, 0);
            Grid.SetColumn(filters, 0);
            GridLayout.Children.Add(filters);
            
            
        }
              
    }
}
