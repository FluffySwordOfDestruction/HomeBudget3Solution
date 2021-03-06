﻿using System;
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
using HomeBudget.OutcomeModule;
using HomeBudget.Common;
using Autofac;
using HomeBudgetDAL;
using HomeBudget.OutcomeModule.ViewModels;
using System.Data.Entity;

namespace HomeBudget3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static IContainer Container {get; set;}
        public MainWindow()
        {
            InitializeComponent();
            ShowMenu();
            RegisterServices();

            //MainRegion.Children.Add(new OutcomeMainView());
        }

        private void RegisterServices()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<HomeBudgetEntities>().As<DbContext>();
            builder.RegisterType<OutcomeService>().As<IOutcomeService>();
            builder.RegisterType<OutcomeMainTableViewModel>();
            builder.RegisterType<OutcomeMainTable>();

            builder.RegisterType<OutcomeFilters>();

            Container = builder.Build();
        }

        private void ShowMenu()
        {
            NavigationController controller = new NavigationController();
            controller.ExitApp = () => Application.Current.Shutdown();
            controller.ShowOutcomes = () => 
            {
                MainRegion.Children.Clear();
                MainRegion.Children.Add(new OutcomeMainView(Container));
            };

            MainRegion.Children.Clear();
            MainRegion.Children.Add(new Menu(controller));
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowMenu();
        }
    }
}
