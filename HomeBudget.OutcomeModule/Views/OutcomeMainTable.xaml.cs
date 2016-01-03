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
    }
}
