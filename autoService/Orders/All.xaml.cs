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

namespace autoService.Orders
{
    /// <summary>
    /// Логика взаимодействия для All.xaml
    /// </summary>
    public partial class All : Page
    {
        public All()
        {
            InitializeComponent();
            LoadAll();
        }

        private void LoadAll() => OrderTable.ItemsSource = MainWindow.context.Order.ToList();

        private void SelectOrder(object sender, MouseButtonEventArgs e)
        {
            if (OrderTable.SelectedItem is Order order)
            {
                new Show(order).ShowDialog();
            }
            
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            if (new New().ShowDialog().Value)
            {
                LoadAll();
            }
        }
    }
}
