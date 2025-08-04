using System.Windows;
using System.Windows.Controls;
using MovieRentalUI.Models;
using MovieRentalUI.ViewModel;

namespace MovieRentalUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel mainViewModel = new MainViewModel();
            this.DataContext = mainViewModel;

        }

        private void FilterTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CustomerList.Items.Filter = FilterMethod;
        }

        private bool FilterMethod(object obj)
        {
            var customer = (Customer)obj;
            return customer.Name.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is Customer customer)
            {
                var vm = DataContext as MainViewModel;
                vm?.Customers.Remove(customer);
            }

        }
    }
}