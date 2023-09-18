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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace BindShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DataGrid myDataGrid;
        public ObservableCollection<Product> Products { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            myDataGrid = dataGrid1;
            Products = new ObservableCollection<Product>();
            Products.Add(new Product { Name = "Milk", Price = 25 });
            Products.Add(new Product { Name = "Bread", Price = 10 });
            myDataGrid.ItemsSource = Products;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Products.Add(new Product { Name = "Cheese", Price = 80 });
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.SelectedItem is Product product)
                Products.Remove(product);
        }
    }
    public class Product : INotifyPropertyChanged
    {
        private string name;
        private decimal price;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }
        public decimal Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
