using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для PageAddProduct.xaml
    /// </summary>
    public partial class PageAddProduct : Page
    {
        Product product;
        public PageAddProduct(Product product)
        {
            InitializeComponent();
            this.product = product;
            DataContext = product;

            List<Supplier> suppliers = CoreModel.init().Suppliers.ToList();
            cbSupplier.ItemsSource = suppliers;

            List<Category> categories = CoreModel.init().Categories.ToList();
            cbCategory.ItemsSource = categories;
        }

        private void imageEditClick(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog { Filter = "Jpeg files|*.jpg|All Files|*.*" };
            if (openFile.ShowDialog() == true)
            {
                product.Image = "\\Resources\\Product\\" + new FileInfo(openFile.FileName).Name;
                imgPhoto.Source = new BitmapImage(new Uri("\\Resources\\Product\\" + new FileInfo(openFile.FileName).Name, UriKind.Relative));
            }
        }

        private void Button_SaveClick(object sender, RoutedEventArgs e)
        {
            if (product.Id == 0)
            {
                CoreModel.init().Products.Add(product);
            }

            CoreModel.init().SaveChanges();

            NavigationService.GoBack();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (product.Id != 0)
            {
                CoreModel.init().Entry(product).Reload();
            }
        }
    }
}
