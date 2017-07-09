using HomeBudgetDAL;
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
using System.ComponentModel;

namespace HomeBudget.OutcomeModule
{
    /// <summary>
    /// Interaction logic for EditOutcome.xaml
    /// </summary>
    public partial class EditOutcome : UserControl, INotifyPropertyChanged
    {
        public Outcome Outcome;
        private IOutcomeService _service;
        private List<Category> Categories;

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public EditOutcome()
        {
            InitializeComponent();
        }

        public IOutcomeService Service
        {
            get
            {
                if (_service == null) throw new NullReferenceException("Outcome service object is null.");

                return _service;
            }
            set
            {
                _service = value;
                InitializeCategories();
            }
        }

        private void InitializeCategories()
        {
            Categories = Service.GetCategories();
            NotifyPropertyChanged("Categories");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            DoubleAnimation animation = new DoubleAnimation(this.Width, 0, new Duration(TimeSpan.FromSeconds(0.45)));
            this.BeginAnimation(UserControl.WidthProperty, animation);

        }

        public void SetFocus()
        {
            NameTextBox.Focus();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            

                //Save item
                Outcome = new Outcome();
            //if(ValidateCategory())
            //Clear fields
        }
    }
}
