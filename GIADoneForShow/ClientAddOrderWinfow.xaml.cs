using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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
    /// Логика взаимодействия для ClientAddOrderWinfow.xaml
    /// </summary>
    public partial class ClientAddOrderWinfow : Window
    {
        private Client _client;
        private Order _order;
        private EquipmentRepairEntities _context = new EquipmentRepairEntities();
        public ClientAddOrderWinfow(Client client, Order currentOrder)
        {
            InitializeComponent();
            _client = client;
            _order = currentOrder;

            var eqTypes = _context.GetContext().EquipmentType.ToList();
            var eqModels = _context.GetContext().EquipmentModel.ToList();
            var deffects = _context.GetContext().Deffect.ToList();

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

            eqTypeCB.SelectedIndex = 0;
            eqModelCB.SelectedIndex = 0;
            deffectCB.SelectedIndex = 0;


            if (_order != null )
            {
                eqTypeCB.SelectedIndex = _order.equipmentTypeId + 1;
                eqModelCB.SelectedIndex = _order.equipmentModelId + 1;
                deffectCB.SelectedIndex = _order.deffectId + 1;
                serialNumberTB.Text = _order.equipmentSerial.ToString();
                descriptionTB.Text = _order.description.ToString();
            }

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            ClientOrderWindow clientOrderWindow = new ClientOrderWindow(_client);
            clientOrderWindow.Show();
            Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (_order != null)
                {
                    _order.description = descriptionTB.Text;
                    _order.equipmentTypeId = eqTypeCB.SelectedIndex + 1;
                    _order.equipmentModelId = eqModelCB.SelectedIndex + 1;
                    _order.equipmentSerial = serialNumberTB.Text;
                    _order.deffectId = deffectCB.SelectedIndex + 1;
                    _context.GetContext().SaveChanges();
                    _context.GetContext().SaveChanges();
                    MessageBox.Show("Внесено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    Order newOrder = new Order
                    {
                        dateStart = DateTime.Now,
                        description = descriptionTB.Text,
                        equipmentTypeId = eqTypeCB.SelectedIndex + 1,
                        equipmentModelId = eqModelCB.SelectedIndex + 1,
                        equipmentSerial = serialNumberTB.Text,
                        deffectId = deffectCB.SelectedIndex + 1,
                        clientId = _client.id
                    };
                    
                    _context.GetContext().Order.Add(newOrder);
                    _context.GetContext().SaveChanges();
                    MessageBox.Show("Внесено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Data, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
