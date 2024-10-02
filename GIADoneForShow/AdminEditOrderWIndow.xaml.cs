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
    /// Логика взаимодействия для AdminEditOrderWIndow.xaml
    /// </summary>
    public partial class AdminEditOrderWIndow : Window
    {

        private Employee _employee;
        private Order _order;
        private EquipmentRepairEntities _context = new EquipmentRepairEntities();

        public AdminEditOrderWIndow(Employee employee, Order order)
        {
            InitializeComponent();
            _employee = employee;
            _order = order;
            var eqTypes = _context.GetContext().EquipmentType.ToList();
            var eqModels = _context.GetContext().EquipmentModel.ToList();
            var deffects = _context.GetContext().Deffect.ToList();
            var statuses = _context.GetContext().Status.ToList();
            var priorites = _context.GetContext().Priority.ToList();
            var employees = _context.GetContext().Employee.Where(x => x.isAdmin == false).ToList();

            foreach (var eqType in eqTypes)
            {
                eqTypeCB.Items.Add(eqType.name);
            }
            foreach (var eqModel in eqModels)
            {
                eqModelCB.Items.Add(eqModel.name);
            }
            foreach (var deffect in deffects)
            {
                deffectCB.Items.Add(deffect.name);
            }
            foreach (var status in statuses)
            {
                statusCB.Items.Add(status.name);
            }
            foreach (var priority in priorites)
            {
                priorityCB.Items.Add(priority.name);
            }
            foreach (var emp in employees)
            {
                empIdCB.Items.Add(emp.surname + " " + emp.name + " " + emp.patronymic);
            }

            eqTypeCB.SelectedIndex = 0;
            eqModelCB.SelectedIndex = 0;
            deffectCB.SelectedIndex = 0;
            statusCB.SelectedIndex = 0;
            priorityCB.SelectedIndex = 0;

            if (_order != null)
            {
                eqTypeCB.SelectedIndex = _order.equipmentTypeId + 1;
                eqModelCB.SelectedIndex = _order.equipmentModelId + 1;
                deffectCB.SelectedIndex = _order.deffectId + 1;
                serialNumberTB.Text = _order.equipmentSerial.ToString();
                descriptionTB.Text = _order.description.ToString();

                try
                {
                    statusCB.SelectedIndex = int.Parse(_order.statusId.ToString()) + 1;
                    priorityCB.SelectedIndex = int.Parse(_order.priorityId.ToString()) + 1;
                    empIdCB.SelectedIndex = int.Parse(_order.employeeId.ToString()) - 1;
                }
                catch (Exception ex)
                {
                    statusCB.SelectedIndex = 0;
                    priorityCB.SelectedIndex = 0;
                    empIdCB.SelectedIndex = 0;
                }

            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                _order.statusId = statusCB.SelectedIndex + 1;
                _order.priorityId = priorityCB.SelectedIndex + 1;
                _order.employeeId = _context.GetContext().Employee.Where(x => x.surname + " " + x.name + " " + x.patronymic == empIdCB.Text).FirstOrDefault().id;
                _context.GetContext().SaveChanges();
                MessageBox.Show("Внесено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Source);
            }

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            AdminOrderWindow adminOrderWindow = new AdminOrderWindow(_employee);
            adminOrderWindow.Show();
            Close();
        }
    }
}
