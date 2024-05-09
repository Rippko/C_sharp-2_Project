using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>()
        {
            new Customer {Id = 1, FirstName = "Jan", LastName = "Novak", Age = 20}
        };
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;

        }
        private void AddCustomer(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer();
            CustomerForm form = new CustomerForm();

            form.ShowDialog();
            this.Customers.Add(customer);
        }
        private void AnonymizeCustomer(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Customer c = (Customer)btn.DataContext;
            c.FirstName = "**********";
            c.LastName = "**********";
        }
        private void EditCustomer(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Customer c = (Customer)btn.DataContext;
            CustomerForm form = new CustomerForm();
            form.ShowDialog();
        }
        private void DeleteCustomer(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Customer c = (Customer)btn.DataContext;
            this.Customers.Remove(c);
        }
    }
}