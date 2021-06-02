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
using System.Collections.ObjectModel;
using static zoo_shop.classi.enti;
using static zoo_shop.classi.DataUser;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System.Text.RegularExpressions;

namespace zoo_shop.window
{
    /// <summary>
    /// Логика взаимодействия для catalog.xaml
    /// </summary>
    ///  кек

    public partial class catalog : Window
    {
        ObservableCollection<Producti> productList = new ObservableCollection<Producti>();
        List<Producti> listMaterial = new List<Producti>();

        public Employee user { get; private set; }
        public int Page { get; private set; }

        public catalog()
        {
            InitializeComponent();

            productList = new ObservableCollection<Producti>(context.Producti);
            ListProduct.ItemsSource = productList;
            txtNameEmpl.Text = $" {classi.DataUser.User.Surname} {classi.DataUser.User.Name}";

        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            start_catal start_Catal = new start_catal(user);
            this.Hide();
            start_Catal.ShowDialog();
        }

        private void btnfullprod_Click(object sender, RoutedEventArgs e)
        {
            BrushButton();
            productList = new ObservableCollection<Producti>(context.Producti.Where(i => i.id_prod_categoty == 6 || i.id_prod_categoty == 5 || i.id_prod_categoty == 3 || i.id_prod_categoty == 2 || i.id_prod_categoty == 1));
            ListProduct.ItemsSource = productList;

            btnfullprod.BorderThickness = new Thickness(2);
            btnfullprod.BorderBrush = Brushes.Red;
        }

        private void btnDog_Click(object sender, RoutedEventArgs e)
        {
            BrushButton();
            productList = new ObservableCollection<Producti>(context.Producti.Where(i => i.id_prod_categoty == 1));
            ListProduct.ItemsSource = productList;

            btnDog.BorderThickness = new Thickness(2);
            btnDog.BorderBrush = Brushes.Red;
        }

        private void btnCat_Click(object sender, RoutedEventArgs e)
        {
            BrushButton();
            productList = new ObservableCollection<Producti>(context.Producti.Where(i => i.id_prod_categoty == 2));
            ListProduct.ItemsSource = productList;

            btnCat.BorderThickness = new Thickness(2);
            btnCat.BorderBrush = Brushes.Red;
        }

        private void btnFish_Click(object sender, RoutedEventArgs e)
        {
            BrushButton();
            productList = new ObservableCollection<Producti>(context.Producti.Where(i => i.id_prod_categoty == 5));
            ListProduct.ItemsSource = productList;

            btnFish.BorderThickness = new Thickness(2);
            btnFish.BorderBrush = Brushes.Red;

        }

        private void btnGr_Click(object sender, RoutedEventArgs e)
        {
            BrushButton();
            productList = new ObservableCollection<Producti>(context.Producti.Where(i => i.id_prod_categoty == 3));
            ListProduct.ItemsSource = productList;

            btnGr.BorderThickness = new Thickness(2);
            btnGr.BorderBrush = Brushes.Red;

        }

        private void btnProdPopug_Click(object sender, RoutedEventArgs e)
        {
            BrushButton();
            productList = new ObservableCollection<Producti>(context.Producti.Where(i => i.id_prod_categoty == 6));
            ListProduct.ItemsSource = productList;

            btnProdPopug.BorderThickness = new Thickness(2);
            btnProdPopug.BorderBrush = Brushes.Red;
        }

        public catalog(Employee employee)
        {
            InitializeComponent();

            productList = new ObservableCollection<Producti>(context.Producti);
            ListProduct.ItemsSource = productList;

            txtNameEmpl.Text = employee.Surname + " " + employee.Name;

        }

        void BrushButton()
        {
            btnProdPopug.BorderThickness = new Thickness(0);
            btnGr.BorderThickness = new Thickness(0);
            btnCat.BorderThickness = new Thickness(0);
            btnDog.BorderThickness = new Thickness(0);
            btnFish.BorderThickness = new Thickness(0);
            btnfullprod.BorderThickness = new Thickness(0);

        }



        //private void btnNext_Click(object sender, RoutedEventArgs e)
        //{
        //    if (listMaterial.Count > 0)
        //    {
        //        numPage++;
        //        btn1.Content = (numPage + 1).ToString();
        //        btn2.Content = (numPage + 2).ToString();
        //        btn3.Content = (numPage + 3).ToString();
        //    }
        //}

        //private void btnBack_Click(object sender, RoutedEventArgs e)
        //{
        //    if (numPage > 0)
        //    {
        //        numPage--;
        //        btn1.Content = (numPage + 1).ToString();
        //        btn2.Content = (numPage + 2).ToString();
        //        btn3.Content = (numPage + 3).ToString();
        //    }
        //}

        //private void btn3_Click(object sender, RoutedEventArgs e)
        //{
        //    if (listMaterial.Count > 0)
        //    {
        //        numPage += 2;
        //        btn1.Content = (numPage + 2).ToString();
        //        btn2.Content = (numPage + 3).ToString();
        //        btn3.Content = (numPage + 4).ToString();
        //    }
        //}
        //private void btn2_Click(object sender, RoutedEventArgs e)
        //{
        //    if (listMaterial.Count > 0)
        //    {
        //        numPage++;
        //        btn1.Content = (numPage + 1).ToString();
        //        btn2.Content = (numPage + 2).ToString();
        //        btn3.Content = (numPage + 3).ToString();
        //    }
        //}

        //private void btn1_Click(object sender, RoutedEventArgs e)
        //{
        //    if (listMaterial.Count > 0)
        //    {
        //        numPage++;
        //        btn1.Content = (numPage + 0).ToString();
        //        btn2.Content = (numPage + 2).ToString();
        //        btn3.Content = (numPage + 3).ToString();
        //    }
        //}

        private void txtSearch_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            //ListProduct.ItemsSource = productList.Where(i => i.Name.ToString() == txtSearch.Text);
           
            string txtOrig = txtSearch.Text;
            string upper = txtOrig.ToUpper();
            string lower = txtOrig.ToLower();

            var empFiltered = from Emp in productList
                              let ename = Emp.Name
                              where
                               ename.StartsWith(lower)
                               || ename.StartsWith(upper)
                               || ename.Contains(txtOrig)
                              select Emp;

            ListProduct.ItemsSource = empFiltered;

        }

    }
}
        //private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        //{
        //    AddEditWin addEditWin = new AddEditWin();
        //    this.Opacity = 0.3;
        //    addEditWin.ShowDialog();
        //    this.Opacity = 1;
        //    ListProduct.ItemsSource = new ObservableCollection<Product>(context.Product);

        //}

        //private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        //{
        //    if (ListProduct.SelectedItem is Product product)
        //    {
        //        AddEditWin addEditWin = new AddEditWin(product);
        //        this.Opacity = 0.3;
        //        addEditWin.ShowDialog();
        //        this.Opacity = 1;
        //        ListProduct.ItemsSource = new ObservableCollection<Product>(context.Product);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Запись не выбрана");
        //    }
        //}

        //private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        //{
        //    if (ListProduct.SelectedItem is Product product)
        //    {
        //        var result = MessageBox.Show("Удалить выбранный товар?", "Удаление товара", MessageBoxButton.YesNo, MessageBoxImage.Question);
        //        if (result == MessageBoxResult.Yes)
        //        {
        //            context.Product.Remove(product);
        //            context.SaveChanges();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Запись не выбрана");
        //    }

        //    ListProduct.ItemsSource = new ObservableCollection<Product>(context.Product);

        //}

        //private void ListProduct_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Delete)
        //    {
        //        if (ListProduct.SelectedItem is Product product)
        //        {
        //            var result = MessageBox.Show("Удалить выбранный товар?", "Удаление товара", MessageBoxButton.YesNo, MessageBoxImage.Question);
        //            if (result == MessageBoxResult.Yes)
        //            {
        //                context.Product.Remove(product);
        //                context.SaveChanges();
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Запись не выбрана");
        //        }

        //        ListProduct.ItemsSource = new ObservableCollection<Product>(context.Product);
        //    }
        //}
   