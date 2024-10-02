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

namespace GIADoneForShow
{
    /// <summary>
    /// Логика взаимодействия для ClientOrderWindow.xaml
    /// </summary>
    public partial class ClientOrderWindow : Window
    {
        private Client _client;
        private EquipmentRepairEntities _context = new EquipmentRepairEntities();
        public ClientOrderWindow(Client client)
        {
            InitializeComponent();
            _client = client;
            var orders = _context.GetContext().Order.Where(x => x.clientId == _client.id).ToList();
            dataGridOrder.ItemsSource = orders;
        }

        private void editOrderButton_Click(object sender, RoutedEventArgs e)
        {
            ClientAddOrderWinfow clientOW = new ClientAddOrderWinfow(_client, (sender as Button).DataContext as Order);
            clientOW.Show();
            Close();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void addOrder_Click(object sender, RoutedEventArgs e)
        {
            ClientAddOrderWinfow clientOW = new ClientAddOrderWinfow(_client, null);
            clientOW.Show();
            Close();
        }
    }
}
