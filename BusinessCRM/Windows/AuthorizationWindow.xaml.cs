using BusinessCRM.DbModel;
using BusinessCRM.Pages;
using BusinessCRM.Windows;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BusinessCRM
{
    public partial class AuthorizationWindow : Window
    {
        User userDB;
        public AuthorizationWindow()
        {
            InitializeComponent();            
        }

        private void textLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbLogin.Focus();
        }

        private void tbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbLogin.Text) && tbLogin.Text.Length > 0)
            {
                textLogin.Visibility = Visibility.Collapsed;
            }
            else
            {
                textLogin.Visibility = Visibility.Visible;
            }
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbPassword.Focus();
        }
        private void tbPassword_TextChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbPassword.Password) && tbPassword.Password.Length > 0)
            {
                textPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPassword.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        //хеширование с солью
        public static string ComputeHash(string plainText, string hashAlgorithm, byte[] saltBytes)
        {
            // Если соль не указана, генерируйте ее на лету.
            if (saltBytes == null)
            {
                // Определите минимальный и максимальный размеры соли.
                int minSaltSize = 4;
                int maxSaltSize = 8;

                // Создать случайное число для размера соли.
                Random random = new Random();
                int saltSize = random.Next(minSaltSize, maxSaltSize);

                // Выделите массив байтов, который будет содержать соль.
                saltBytes = new byte[saltSize];

                // Инициализируйте генератор случайных чисел.
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

                // Заполните соль криптографически сильными значениями байт.
                rng.GetNonZeroBytes(saltBytes);
            }

            // Преобразование обычного текста в массив байтов.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // Выделите массив, который будет содержать обычный текст и соль.
            byte[] plainTextWithSaltBytes =
                    new byte[plainTextBytes.Length + saltBytes.Length];

            // Копирование байтов обычного текста в результирующий массив.
            for (int i = 0; i < plainTextBytes.Length; i++)
                plainTextWithSaltBytes[i] = plainTextBytes[i];

            // Добавление байтов соли к полученному массиву.
            for (int i = 0; i < saltBytes.Length; i++)
                plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];


            HashAlgorithm hash;

            // Убедитесь, что указано имя алгоритма хэширования.
            if (hashAlgorithm == null)
                hashAlgorithm = "";

            // Инициализируйте соответствующий класс алгоритма хэширования.
            switch (hashAlgorithm.ToUpper())
            {
                //case "SHA1":
                //    hash = new SHA1Managed();
                //    break;

                //case "SHA256":
                //    hash = new SHA256Managed();
                //    break;

                //case "SHA384":
                //    hash = new SHA384Managed();
                //    break;

                //case "SHA512":
                //    hash = new SHA512Managed();
                //    break;

                //default:
                //    hash = new MD5CryptoServiceProvider();
                //    break;
                default:
                    hash = new SHA256Managed();
                    break;
            }

            // Вычислите хэш-значение нашего обычного текста с добавлением соли.
            byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

            // Создайте массив, который будет содержать хэш и исходные байты соли.
            byte[] hashWithSaltBytes = new byte[hashBytes.Length +
                                                saltBytes.Length];

            // Копирование хэш-байтов в результирующий массив.
            for (int i = 0; i < hashBytes.Length; i++)
                hashWithSaltBytes[i] = hashBytes[i];

            // Добавление байтов соли к результату.
            for (int i = 0; i < saltBytes.Length; i++)
                hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

            // Преобразование результата в строку в кодировке base64.
            string hashValue = Convert.ToBase64String(hashWithSaltBytes);

            // Возвратите результат.
            return hashValue;
        }
         private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbLogin.Text) && !string.IsNullOrEmpty(tbPassword.Password))
            {             
                try
                {
                    // Create a request for the URL. // проверка подключения к интернету        
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://www.google.ru/");   //сюда любой домен     
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
                    request.Timeout = 10000;

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream ReceiveStream1 = response.GetResponseStream();
                    StreamReader sr = new StreamReader(ReceiveStream1, true);
                    string responseFromServer = sr.ReadToEnd();

                    response.Close();

                    User user = CoreModel.init().Users.FirstOrDefault(p => p.Login == tbLogin.Text);

                    string hashPassDB = user.Password;

                    string plaintext = AuthorizationWindow.ComputeHash(tbPassword.Password, "SHA256", user.Salt);

                    if (hashPassDB == plaintext)
                    {
                        if (user.Role == 1)
                        {
                            AdminWindow window_Admin = new AdminWindow();
                            window_Admin.Show();
                            Hide();
                        }
                        else if (user.Role == 2)
                        {
                            DirectorWindow window_Director = new DirectorWindow();
                            window_Director.Show();
                            Hide();
                        }
                        else if (user.Role == 3)
                        {
                            CashierWindow window_Cashier = new CashierWindow();
                            window_Cashier.Show();
                            Hide();
                        }                      
                    }
                    else
                        MessageBox.Show("Логин или пароль неверные!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Нет подключения к интернету!\nПроверьте ваш фаервол или настройки сетевого подключения!");
                }
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton ==  MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new registrationPage1(new User()));
        }
    }
}
