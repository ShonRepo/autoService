using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

namespace autoService.Component
{
    /// <summary>
    /// Логика взаимодействия для Form.xaml
    /// </summary>
    public partial class Form : Window
    {
        private component Component { get; set; }
        public Form()
        {
            InitializeComponent();
            Component = new component();
            Component.DeliveryDate = DateTime.Now;
            LoadData();
        }

        public Form(component component)
        {
            InitializeComponent();
            Component = component;
            LoadData();
            Type.SelectedItem = component.Type1;
            Warehouse.SelectedItem = component.Warehouse1;
            Provider.SelectedItem = component.Provider1;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (Type.SelectedItem is Type type &&
                Warehouse.SelectedItem is Warehouse warehouse &&
                Provider.SelectedItem is Provider provider)
            {
                Component.Type1 = type;
                Component.Warehouse1 = warehouse;
                Component.Provider1 = provider;
                MainWindow.context.component.AddOrUpdate(Component);
                MainWindow.context.SaveChanges();
                DialogResult = true;
            }
        }
        private void LoadData()
        {
            Type.ItemsSource = MainWindow.context.Type.ToList();
            Warehouse.ItemsSource = MainWindow.context.Warehouse.ToList();
            Provider.ItemsSource = MainWindow.context.Provider.ToList();
        }
    }
}
