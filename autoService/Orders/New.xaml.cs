using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Логика взаимодействия для New.xaml
    /// </summary>
    public partial class New : Window
    {
        ObservableCollection<component> components { get; set; }
        ObservableCollection<SelectAmenities> selectAmenities { get; set; }

        public New()
        {
            InitializeComponent();
            Clients.ItemsSource = MainWindow.context.Client.ToList();
            selectAmenities = new ObservableCollection<SelectAmenities>(MainWindow.context.Amenities.Select(i => new SelectAmenities { Amenities = i, IsSelect = false }));
            Amenities.ItemsSource = selectAmenities;
            components = new ObservableCollection<component>();
            this.tableComponent.ItemsSource = components;
            LoadType();
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            if (Clients.SelectedItem is Client client &&
                !Car.Text.Equals("") &&
                !Comment.Text.Equals(""))
            {
                var order = new Order
                {
                    Car = Car.Text,
                    Client = client.Id,
                    Manager = MainWindow.Manager.Id,
                    Comment = Comment.Text
                };
                MainWindow.context.Order.Add(order);
                MainWindow.context.SaveChanges();
                MainWindow.context.AmenitiesOrder.AddRange(selectAmenities.Where(i =>i.IsSelect).Select(i => new AmenitiesOrder { Amenities = i.Amenities.Id, Order = order.Id }));
                MainWindow.context.SaveChanges();
                foreach (var component in components)
                {
                    MainWindow.context.component.Find(component.Id).Order = order.Id; 
                }
                MainWindow.context.SaveChanges();
                DialogResult = true;
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (Component.SelectedItem is Type type)
            {
                components.Add(type.component.FirstOrDefault());
                LoadType();
            }
        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            if (tableComponent.SelectedItem is component component)
            {
                components.Remove(component);
                LoadType();
            }
        }

        private class SelectAmenities
        {
            public Amenities Amenities { get; set; }
            public bool IsSelect { get; set; }
        }

        private void LoadType()
        {
            Component.ItemsSource = MainWindow.context.Type.Where(i => i.component.Where(j => j.Order == null).Any() /* && i.component.Where(j =>!components.ToList().Select(h =>h.Id).Contains(j.Id)).Any()*/).ToList();
            SetPrice();
        }

        private void SetPrice()
        {
            this.Price.Text = (components.Distinct().Sum(i => i.Type1.Price) + selectAmenities.Where(i =>i.IsSelect).Sum(i => i.Amenities.Price)).ToString();
        }

        private void Check(object sender, RoutedEventArgs e)
        {
            SetPrice();
        }
    }
}
