using System.Collections.ObjectModel;

namespace MovieRentalUI.Models;

public class CustomerManager
{
    public static ObservableCollection<Customer> _dataBaseCustomer = new ObservableCollection<Customer>()
    {
        new Customer {Id = 1, Name = "Manoel", Birthday = "15/02/1980" },
        new Customer {Id = 2, Name = "Maria", Birthday = "27/11/1992" },
        new Customer {Id = 3, Name = "Ines", Birthday = "02/09/1999" },
        new Customer {Id = 4, Name = "Pedro", Birthday = "11/08/1986" },

    };

    public static ObservableCollection<Customer> GetCustomers()
    {
        return _dataBaseCustomer;
    }

    public static void AddCustomer(Customer customer)
    {

        var id = _dataBaseCustomer.OrderByDescending(x => x.Id).First().Id + 1;
        customer.Id = id;
        _dataBaseCustomer.Add(customer);
    }

}
