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

namespace zoo_shop.window
{
    /// <summary>
    /// Логика взаимодействия для start_catal.xaml
    /// </summary>
    public partial class start_catal : Window
    {
        public start_catal(Employee user)
        {
            InitializeComponent();
        }

        private void katal_Click(object sender, RoutedEventArgs e)
        {

            catalog sale = new catalog();
            this.Hide();
            sale.ShowDialog();
        }

        private void sale_Click(object sender, RoutedEventArgs e)
        {
            sale sale = new sale();
            this.Hide();
            sale.ShowDialog();

        }

        private void entry_Click(object sender, RoutedEventArgs e)
        {
            autoriz autoriz = new autoriz();
            this.Hide();
            autoriz.ShowDialog();

        }

        private void dost_opl_Click(object sender, RoutedEventArgs e)
        {
            delivery delivery = new delivery();
            this.Hide();
            delivery.ShowDialog();

        }

        private void o_magaz_Click(object sender, RoutedEventArgs e)
        {
            info_shop info_Shop = new info_shop();
            this.Hide();
            info_Shop.ShowDialog();

        }

        private void kontact_Click(object sender, RoutedEventArgs e)
        {

            pay_order pay_Order = new pay_order();
            this.Hide();
            pay_Order.ShowDialog();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Вы действительно хотите выйти из приложения?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Close();
            }
        }

      
    }
}
