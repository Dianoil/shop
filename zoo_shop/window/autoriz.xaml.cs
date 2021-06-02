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
using static zoo_shop.classi.enti;
using static zoo_shop.classi.DataUser;

namespace zoo_shop.window
{
    /// <summary>
    /// Логика взаимодействия для autoriz.xaml
    /// </summary>
    /// Здесь была Юля с гитом -_-
    public partial class autoriz : Window
    {
        public autoriz()
        {
            InitializeComponent();    
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти из приложения?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Employee user = context.Employee
               .ToList().Where(i => i.Login == txtLogin.Text && i.Password == pswPassword.Password)
               .FirstOrDefault(); 

                if (user != null)
                {
                    classi.DataUser.User = user;

                    if (user.idRole == 1)
                    {
                        start_catal actionWin = new start_catal(user);
                        this.Hide();
                        actionWin.ShowDialog();
                    }
                    else if (user.idRole == 2)
                    {
                        MessageBox.Show("Ты же не админ");
                    }
                }
                else
                {
                    MessageBox.Show("Логин или пароль введены неверно");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            registration registration = new registration();
            this.Hide();
            registration.ShowDialog();
        }
    }
}
