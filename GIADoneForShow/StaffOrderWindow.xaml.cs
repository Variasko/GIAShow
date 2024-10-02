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
    /// Логика взаимодействия для StaffOrderWindow.xaml
    /// </summary>
    public partial class StaffOrderWindow : Window
    {

        private Employee _employee;
        private EquipmentRepairEntities _context = new EquipmentRepairEntities();
        public StaffOrderWindow(Employee employee)
        {
            InitializeComponent();
            _employee = employee;
            var orders = _context.GetContext().Order.Where(x => x.employeeId == _employee.id).ToList();
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
            StaffEditOrderWinfow staffEditOrderWinfow = new StaffEditOrderWinfow(_employee, (sender as Button).DataContext as Order);
            staffEditOrderWinfow.Show();
            Close();
        }
    }
}
