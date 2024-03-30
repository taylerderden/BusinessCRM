using Microsoft.EntityFrameworkCore;
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

namespace BusinessCRM.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProducts.xaml
    /// </summary>
    public partial class PageProducts : Page
    {
        public PageProducts()
        {
            InitializeComponent();

            IEnumerable<Product> products = CoreModel.init().Products
                .Include(p => p.Category)
                .Include(p => p.SupplierNavigation);
            lvProduct.ItemsSource = products.ToList();

            cbSort.Items.Add("По возрастанию");
            cbSort.Items.Add("По убыванию");
            cbSort.SelectedIndex = 0;

            List<Category> categories = CoreModel.init().Categories.ToList();
            cbFiltr.ItemsSource = categories;
            categories.Insert(0, new Category { Name = "Все категории" });
            cbFiltr.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAddProduct(new Product()));
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lvProduct.SelectedItems.Count < 0)
            {
                MessageBox.Show("Выберите хотя бы 1 товар для редактирования");
            }
            Product productEdit = lvProduct.SelectedItem as Product;
            NavigationService.Navigate(new PageAddProduct(productEdit));
        }
        private void Button_DelClick(object sender, RoutedEventArgs e)
        {
            if (lvProduct.SelectedItems.Count < 0)
            {
                MessageBox.Show("Выберите хотя бы 1 товар для удаления");
            }

            Product prodDel = lvProduct.SelectedItem as Product;
            if (prodDel == null)
                MessageBox.Show("Кликните по товару, которую необходимо удалить и после нажмите на кнопку Удалить");

            if (prodDel != null && MessageBox.Show("Удалить?", "Правда удалить?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CoreModel.init().Products.Remove(prodDel);
                CoreModel.init().SaveChanges();
                update();
            }

        }
        private void update()
        {
            IEnumerable<Product> products = CoreModel.init().Products
                 .Include(p => p.Category)
                 .Include(p => p.SupplierNavigation)
                 .Where(p => p.Name.Contains(tbSearch.Text)
                 || p.Description.Contains(tbSearch.Text)
                 || Convert.ToString(p.Cost).Contains(tbSearch.Text)
                 || Convert.ToString(p.Count).Contains(tbSearch.Text));


            switch (cbSort.SelectedIndex)
            {
                case 0:
                    products = products.OrderBy(p => p.Cost);
                    break;

                case 1:
                    products = products.OrderByDescending(p => p.Cost);
                    break;
            }
            if (cbFiltr.SelectedIndex > 0)
            {
                products = products.Where(p => p.CategoryId == (cbFiltr.SelectedItem as Category).Id);
            }
            lvProduct.ItemsSource = products.ToList();
        }
        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            update();
        }

        private void cbSortChanged(object sender, SelectionChangedEventArgs e)
        {
            update();
        }

        private void cbFiltrChanged(object sender, SelectionChangedEventArgs e)
        {
            update();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            update();
        }
    }
}
