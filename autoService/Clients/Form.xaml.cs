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

namespace autoService.Clients
{
    /// <summary>
    /// Логика взаимодействия для Form.xaml
    /// </summary>
    public partial class Form : Window
    {
        private Client client { get; set; }

        public Form()
        {
            InitializeComponent();
            client = new Client();
        }

        public Form(Client client)
        {
            InitializeComponent();
            this.client = client;
            FirstName.Text = client.FirstName;
            LastName.Text = client.LastName;
            Phone.Text = client.Number;
            Email.Text = client.Email;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (!FirstName.Text.Equals("") &&
                !LastName.Text.Equals("") &&
                !Phone.Text.Equals("") &&
                !Email.Text.Equals(""))
            {
                client.FirstName = FirstName.Text;
                client.LastName = LastName.Text;
                client.Email = Email.Text;
                client.Number = Phone.Text;
                MainWindow.context.Client.AddOrUpdate(client);
                MainWindow.context.SaveChanges();
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }
    }
}
