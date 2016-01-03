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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeBudget.OutcomeModule
{
    /// <summary>
    /// Interaction logic for EditOutcome.xaml
    /// </summary>
    public partial class EditOutcome : UserControl
    {
        public EditOutcome()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            DoubleAnimation animation = new DoubleAnimation(500, 0, new Duration(new TimeSpan(1200000)));
            this.BeginAnimation(UserControl.WidthProperty, animation);
            
        }
    }
}
