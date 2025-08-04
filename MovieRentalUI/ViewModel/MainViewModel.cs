using System.Collections.ObjectModel;
using System.Windows.Input;
using MovieRentalUI.Commands;
using MovieRentalUI.Models;
using MovieRentalUI.Views;

namespace MovieRentalUI.ViewModel;

public class MainViewModel
{
    public ObservableCollection<Customer> Customers { get; set; }

    public ICommand ShowWindowCommand { get; set; }
  

    public MainViewModel()
    {
        Customers = CustomerManager.GetCustomers();

        ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindows);
    }

    private bool CanShowWindows(object obj)
    {
        return true;
    }

    private void ShowWindow(object obj)
    {
        var mainWindow = obj as MainWindow;
        AddCustomer addCustomer = new AddCustomer();
        addCustomer.Owner = mainWindow;
        addCustomer.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;

        addCustomer.Show();
    }
}
