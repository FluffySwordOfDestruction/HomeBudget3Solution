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

using HomeBudget.Common;
using HomeBudgetDAL;
using HomeBudget.OutcomeModule.ViewModels;
using System.Windows.Media.Animation;

namespace HomeBudget.OutcomeModule
{
    /// <summary>
    /// Interaction logic for OutcomeMainTable.xaml
    /// </summary>
    public partial class OutcomeMainTable : UserControl
    {
        private readonly IOutcomeService service;

        public OutcomeMainTable()
        {
            InitializeComponent();
        }
        public OutcomeMainTable(OutcomeMainTableViewModel context)
        {
            InitializeComponent();

            //service = OutcomeService.GetDefaultOutcomeService();
            this.DataContext = context;//
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ShowNewOutcome();
        }

        private void ShowNewOutcome()
        {
            Panel.SetZIndex(dgOutcomes, 5);
            Panel.SetZIndex(NewOutcomeView, 10);
          
            DoubleAnimation animation = new DoubleAnimation(0,500,new Duration(new TimeSpan(1200000)));
            NewOutcomeView.BeginAnimation(UserControl.WidthProperty, animation);
            this.LayoutGrid.UpdateLayout();
        }

        private void HideNewOutcome()
        {
            Panel.SetZIndex(dgOutcomes, 10);
            Panel.SetZIndex(NewOutcomeView, 5);
            NewOutcomeView.Width = 0;
            this.LayoutGrid.UpdateLayout();
        }
    }
}
