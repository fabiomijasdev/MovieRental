using System.Windows.Input;
using MovieRentalUI.Commands;
using MovieRentalUI.Models;

namespace MovieRentalUI.ViewModel
{
    public class AddCustomerViewModel
    {
        public ICommand AddCustomerCommand { get; set; }

        public AddCustomerViewModel()
        {
            AddCustomerCommand = new RelayCommand(AddCustomer, CanAddCustomer);

        }
        

        public int Id { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }

        private bool CanAddCustomer(object obj)
        {
            return true;
        }

        private void AddCustomer(object obj)
        {
            CustomerManager.AddCustomer(new Customer { Name = Name, Birthday = Birthday });
        }
    }
}
