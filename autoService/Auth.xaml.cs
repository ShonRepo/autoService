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

namespace autoService
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Enter(object sender, RoutedEventArgs e)
        {
            var Manager = MainWindow.context.Manager.Where(i => i.Login == Login.Text && i.Password == Password.Password);
            if (Manager.Any())
            {
                new MainWindow(Manager.FirstOrDefault()).Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует", "Ошибка");
            }
        }
    }
}
