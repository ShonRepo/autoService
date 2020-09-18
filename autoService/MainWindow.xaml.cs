using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace autoService
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static autoServiceEntities context = new autoServiceEntities();

        public static Manager Manager { get; set; }

        public MainWindow(Manager manager)
        {
            InitializeComponent();
            Manager = manager;
            LoadPhoto(manager);
            FullName.Text = Manager.FullName;
        }

        private void LoadPhoto(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Файлы изображений (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            if (openFile.ShowDialog().Value)
            {
                Manager.Phono = File.ReadAllBytes(openFile.FileName);
                context.SaveChanges();
                LoadPhoto(Manager);
            }
        }

        private void LoadPhoto(Manager manager)
        {
            if(!(manager.Phono is null))
                this.Photo.Source = ByteToImage(manager.Phono);
        }

        private BitmapImage ByteToImage(byte[] array)
        {
            using (MemoryStream ms = new MemoryStream(array,0,array.Length))
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = ms;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
                return image;
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            new Auth().Show();
            this.Close();
        }

        private void GoToOrders(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Orders.All());
        }

        private void GoToClient(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Clients.All());
        }

        private void GoToStorage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Component.All());
        }
    }
}
