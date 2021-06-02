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
    /// Логика взаимодействия для delivery.xaml
    /// </summary>
    public partial class delivery : Window
    {
        public delivery()
        {
            InitializeComponent();
        }

        public Employee user { get; private set; }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            start_catal start_Catal = new start_catal(user);
            this.Hide();
            start_Catal.ShowDialog();
        }
    }
}
