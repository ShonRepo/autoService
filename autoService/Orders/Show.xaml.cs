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
using System.Windows.Shapes;

namespace autoService.Orders
{
    /// <summary>
    /// Логика взаимодействия для Show.xaml
    /// </summary>
    public partial class Show : Window
    {
        public Show(Order order)
        {
            InitializeComponent();
            this.Price.Text = order.Price.ToString();
            this.Car.Text = order.Car;
            this.Client.Text = order.Client1.FullName;
            this.Manager.Text = order.Manager1.FullName;
            this.Amenities.ItemsSource = order.AmenitiesOrder.Select(i => i.Amenities1);
            this.Comment.Text = order.Comment;
            this.Component.ItemsSource = order.component.ToList();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
