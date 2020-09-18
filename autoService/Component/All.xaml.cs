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

namespace autoService.Component
{
    /// <summary>
    /// Логика взаимодействия для All.xaml
    /// </summary>
    public partial class All : Page
    {
        DataGrid DataGrid;

        public All()
        {
            InitializeComponent();
            LoadAll();
        }

        private void CreateComponent(object sender, RoutedEventArgs e)
        {
            if (new Form().ShowDialog().Value)
            {
                LoadAll();
            }
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            if ((DataGrid as DataGrid).SelectedItem is component component)
            {
                if (new Form(component).ShowDialog().Value)
                {
                    LoadAll();
                }
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if ((DataGrid as DataGrid).SelectedItem is component component)
            {
                if (MessageBox.Show("Хотите удалить?","Удалить",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    MainWindow.context.component.Remove(component);
                    MainWindow.context.SaveChanges();
                }
            }
            }

        private void Search(object sender, TextChangedEventArgs e)
        {

        }

        private void LoadAll()
        {
            Types.ItemsSource = MainWindow.context.Type.Where(i=>i.component.Any()).ToList();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid = sender as DataGrid;
        }
    }
}
