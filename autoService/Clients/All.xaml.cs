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

namespace autoService.Clients
{
    /// <summary>
    /// Логика взаимодействия для All.xaml
    /// </summary>
    public partial class All : Page
    {
        public All()
        {
            InitializeComponent();
            LoadAll("");
        }

        private void Search(object sender, TextChangedEventArgs e)
        {
            LoadAll((sender as TextBox).Text);
        }

        private void LoadAll(string search)
        {
            ClientTable.ItemsSource = MainWindow.context.Client.Where(i => i.LastName.Contains(search) || search.Equals("")).ToList();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            
            if (ClientTable.SelectedItem is Client client)
            {
                if (MessageBox.Show("Хотите удалить?","Удаление",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    MainWindow.context.Client.Remove(client);
                    MainWindow.context.SaveChanges();
                    LoadAll("");
                }
            }
            else
            {
                MessageBox.Show("Выберите клиента");
            }
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            if (ClientTable.SelectedItem is Client client)
                if (new Form(client).ShowDialog().Value)
                    LoadAll("");
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            if (new Form().ShowDialog().Value)
                LoadAll("");
        }
    }
}
