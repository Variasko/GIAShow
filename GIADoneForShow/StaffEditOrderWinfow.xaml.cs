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
    /// Логика взаимодействия для StaffEditOrderWinfow.xaml
    /// </summary>
    public partial class StaffEditOrderWinfow : Window
    {

        private EquipmentRepairEntities _context = new EquipmentRepairEntities();
        Order _order;
        Employee _employee;

        public StaffEditOrderWinfow(Employee employee, Order order)
        {
            InitializeComponent();
            _order = order;
            _employee = employee;

            var eqTypes = _context.GetContext().EquipmentType.ToList();
            var eqModels = _context.GetContext().EquipmentModel.ToList();
            var deffects = _context.GetContext().Deffect.ToList();
            var statuses = _context.GetContext().Status.ToList();
            var priorites = _context.GetContext().Priority.ToList();

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
                } catch (Exception ex)
                {
                    statusCB.SelectedIndex = 0;
                    priorityCB.SelectedIndex = 0;
                }

            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _order.employeeComment = empCommentTB.Text;
                _order.priorityId = priorityCB.SelectedIndex + 1;
                _order.statusId = statusCB.SelectedIndex + 1;
                _context.GetContext().SaveChanges();
                MessageBox.Show("Внесено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Source);
            }
            
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            StaffOrderWindow staffOrderWindow = new StaffOrderWindow(_employee);
            staffOrderWindow.Show();
            Close();
        }

        private void closeOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _order.statusId = statusCB.SelectedIndex + 1;
                _order.dateEnd = DateTime.Now;
                _context.GetContext().SaveChanges();
                MessageBox.Show("Внесено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Source);
            }
        }
    }
}
