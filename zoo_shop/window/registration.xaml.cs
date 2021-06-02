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
using static zoo_shop.classi.ValidationClass;

namespace zoo_shop.window
{
    /// <summary>
    /// Логика взаимодействия для registration.xaml
    /// </summary>
    public partial class registration : Window
    {
        public registration()
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

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            string logBD = context.Employee.Where(i => i.Login == txtLogin.Text.ToString()).Select(j => j.Login).FirstOrDefault();

            if (txtSname.Text == "" || txtName.Text == ""  || txtLogin.Text == "" || pswPassword.Password == "" || gender.Text == "" || birth.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else if (logBD != null)
            {
                MessageBox.Show("Логин уже используется!");
            }
            else if (ValidateFIO(txtName.Text, txtSname.Text) == false)
            {
                MessageBox.Show("Имя или фамилия содержат недопустимые символы (В этих полях может присутсвовать только кирилица)", "Регистрация абоента", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (ValidateBirth(birth.SelectedDate.Value) == false)
            {
                MessageBox.Show("На данный момент вы еще не родились!", "Регистрация абоента", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
           
            else
            {

                MessageBoxResult result = MessageBox.Show(
                    txtSname.Text + " " +
                    txtName.Text + "\n" +
                    "Логин:  " + txtLogin.Text + "\n" +
                    "Пароль:  " + pswPassword.Password + "\n", "Создать пользователя:", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    if (gender.Text == "Женский")
                    {
                       var date = birth.SelectedDate.Value.Date.ToShortDateString();
                        string g = "Ж";
                        context.Employee.Add(new Employee()
                        {
                            Login = txtLogin.Text.ToString(),
                            Password = pswPassword.Password.ToString(),
                            Surname = txtSname.Text.ToString(),
                            Name = txtName.Text.ToString(),
                            Gend = g.ToString(),
                            Birth = birth.SelectedDate.Value,
                            idRole = 1

                        });
                        context.SaveChanges();
                    }
                    else if (gender.Text == "Мужской")
                    {
                        string g = "М";
                        context.Employee.Add(new Employee()
                        {
                            Login = txtLogin.Text.ToString(),
                            Password = pswPassword.Password.ToString(),
                            Surname = txtSname.Text.ToString(),
                            Name = txtName.Text.ToString(),
                            Gend = g.ToString(),
                            Birth = birth.SelectedDate.Value,
                            idRole = 1

                        });
                        context.SaveChanges();
                    }
                    else
                    {
                        string g = "N";
                        context.Employee.Add(new Employee()
                        {
                            Login = txtLogin.Text.ToString(),
                            Password = pswPassword.Password.ToString(),
                            Surname = txtSname.Text.ToString(),
                            Name = txtName.Text.ToString(),
                            Gend = g.ToString(),
                            Birth = birth.SelectedDate.Value,
                            idRole = 1

                        });
                        context.SaveChanges();
                    }                
                    autoriz autoriz = new autoriz();
                    this.Hide();
                    autoriz.ShowDialog();
                }
            }
        }
    }
}
