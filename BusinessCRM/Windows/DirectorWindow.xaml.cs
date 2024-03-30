using BusinessCRM.Pages;
using System.Drawing;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace BusinessCRM.Windows
{
    /// <summary>
    /// Логика взаимодействия для DirectorWindow.xaml
    /// </summary>
    public partial class DirectorWindow : Window
    {
        public DirectorWindow()
        {
            InitializeComponent();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if (e.ChangedButton == MouseButton.Left)
            //{
            //    this.DragMove();
            //}
        }
        private bool IsMaximize = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                //if (IsMaximize)
                //{
                //    this.WindowState = WindowState.Normal;
                //    this.Width = 1280;
                //    this.Height = 780;

                //    IsMaximize = false;
                //}
                //else
                //{
                //    this.WindowState = WindowState.Maximized;

                //    IsMaximize = true;
                //}
            }
            else if (e.ClickCount == 1)
            {
                panelTables.Visibility= Visibility.Hidden;
            }
        }
        private void btnTables_Click(object sender, RoutedEventArgs e)
        {
            btnMainPage.Background = new SolidColorBrush(Colors.Transparent);
            btnMainPage.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(254, 254, 214, 206));
            btnTables.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 255, 255));
            btnTables.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(251, 251, 118, 87));
            panelTables.Visibility = Visibility.Visible;
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new PageProducts());
        }
    }
}
