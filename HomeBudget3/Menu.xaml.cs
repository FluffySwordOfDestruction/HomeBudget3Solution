using HomeBudget.Common;
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

namespace HomeBudget3
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        NavigationController navigation = null;
        public Menu(NavigationController navController)
        {
            InitializeComponent();
            navigation = navController;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (navigation.ExitApp != null)
                navigation.ExitApp();            
        }

        private void OutcomesButton_Click(object sender, RoutedEventArgs e)
        {
            if (navigation.ShowOutcomes != null)
                navigation.ShowOutcomes();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            if (navigation.ShowSettings != null)
                navigation.ShowSettings();
        }

        private void CategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            if (navigation.ShowCategories != null)
                navigation.ShowCategories();
        }

        private void ReportsButton_Click(object sender, RoutedEventArgs e)
        {
            if(navigation.ShowReports != null)
                navigation.ShowReports();
        }

        private void IncomeButton_Click(object sender, RoutedEventArgs e)
        {
            if(navigation.ShowIncome != null)
            navigation.ShowIncome();
        }

        private void SettingsButton_MouseEnter(object sender, MouseEventArgs e)
        {
            SettingTitle.Visibility = Visibility.Visible;
        }

        private void SettingsButton_MouseLeave(object sender, MouseEventArgs e)
        {
            SettingTitle.Visibility = Visibility.Collapsed;
        }

        private void OutcomesButton_MouseEnter(object sender, MouseEventArgs e)
        {
            OutcomesTitle.Visibility = Visibility.Visible;
        }

        private void OutcomesButton_MouseLeave(object sender, MouseEventArgs e)
        {
            OutcomesTitle.Visibility = Visibility.Collapsed;
        }

        private void CategoriesButton_MouseEnter(object sender, MouseEventArgs e)
        {
            CategoriesTitle.Visibility = Visibility.Visible;
        }

        private void CategoriesButton_MouseLeave(object sender, MouseEventArgs e)
        {
            CategoriesTitle.Visibility = Visibility.Collapsed;
        }

        private void ReportsButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ReportsTitle.Visibility = Visibility.Visible;
        }

        private void ReportsButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ReportsTitle.Visibility = Visibility.Collapsed;
        }

        private void IncomeButton_MouseEnter(object sender, MouseEventArgs e)
        {
            IncomesTitle.Visibility = Visibility.Visible;
        }

        private void IncomeButton_MouseLeave(object sender, MouseEventArgs e)
        {
            IncomesTitle.Visibility = Visibility.Collapsed;
        }

        private void ExitButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ExitTitle.Visibility = Visibility.Visible;
        }

        private void ExitButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ExitTitle.Visibility = Visibility.Collapsed;
        }
    }
}
