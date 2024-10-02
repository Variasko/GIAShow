using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Логика взаимодействия для AdminOrderWindow.xaml
    /// </summary>
    public partial class AdminOrderWindow : Window
    {

        private Employee employee;
        private EquipmentRepairEntities _context = new EquipmentRepairEntities();

        public AdminOrderWindow(Employee employee)
        {
            InitializeComponent();
            var orders = _context.GetContext().Order.ToList();
            dataGridOrder.ItemsSource = orders;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void editOrderButton_Click(object sender, RoutedEventArgs e)
        {
            AdminEditOrderWIndow adminEditOrderWIndow = new AdminEditOrderWIndow(employee, (sender as Button).DataContext as Order);
            adminEditOrderWIndow.Show();
            Close();
        }
    }
}
