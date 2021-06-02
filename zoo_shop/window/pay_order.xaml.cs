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
    /// Логика взаимодействия для pay_order.xaml
    /// </summary>
    public partial class pay_order : Window
    {
        public Employee user { get; private set; }

        public pay_order()
        {
            InitializeComponent();
        }
        private void num_order_GotFocus(object sender, RoutedEventArgs e)
        {
            if (num_order.Text == "_______")
            {
                num_order.Text = "";
            }
        }

        private void num_order_LostFocus(object sender, RoutedEventArgs e)
        {
            if (num_order.Text == "")
            {
                num_order.Text = "_______";
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            start_catal start_Catal = new start_catal(user);
            this.Hide();
            start_Catal.ShowDialog();
        }

        private void pay1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Поздравляем с приобретением нашего товара", "Оплата", MessageBoxButton.OK);
            start_catal start_Catal = new start_catal(user);
            this.Hide();
            start_Catal.ShowDialog();
        }
    }
}