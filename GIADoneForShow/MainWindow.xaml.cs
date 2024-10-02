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

namespace GIADoneForShow
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EquipmentRepairEntities _context = new EquipmentRepairEntities();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            string login = loginEnter.Text;
            string password = passwordEnter.Password;

            var users = _context.GetContext().Client;
            var employees = _context.GetContext().Employee;

            foreach (var user in users)
            {
                if (login == user.login && password == user.password)
                {
                    ClientOrderWindow clientOrderWindow = new ClientOrderWindow(user);
                    clientOrderWindow.Show();
                    this.Close();
                }
            }
            foreach (var employee in employees)
            {
                if (login == employee.login && password == employee.password)
                {
                    if (employee.isAdmin == false)
                    {
                    StaffOrderWindow staffOrderWindow = new StaffOrderWindow(employee);
                    staffOrderWindow.Show();
                    Close();
                    }
                    else
                    {
                        AdminOrderWindow adminOrderWindow = new AdminOrderWindow(employee);
                        adminOrderWindow.Show();
                        Close();
                    }
                }
            }

        }
    }
}
