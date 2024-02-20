using BusinessCRM.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для registrationPage1.xaml
    /// </summary>
    public partial class registrationPage1 : Page
    {
        User user;
        public registrationPage1(User userDB)
        {
            InitializeComponent();
            this.user = userDB;
            DataContext = user;
        }
        public static Tuple<string, byte[]> ComputeHash(string plainText, string hashAlgorithm, byte[] saltBytes)
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

                case "SHA256":
                    hash = new SHA256Managed();
                    break;

                default:
                    hash = new SHA256Managed();
                    break;
            }

            // Вычислите хэш-значение нашего обычного текста с добавлением соли.
            byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

            //сама соль
            byte[] hashSalt = hash.ComputeHash(saltBytes);
            string hashSalt2 = Convert.ToBase64String(hashSalt);                   

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
            //return hashValue;

            // Возврат кортежа с хешом |пароля вместе с солью| и отдельно хеша |соли|
            return Tuple.Create(hashValue, saltBytes);
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (user.Id == 0)
            {
                var tyrple = registrationPage1.ComputeHash(tbPass.Text, "SHA256", null);
                user.Password = tyrple.Item1;
                user.Salt = tyrple.Item2;
                byte[] a = user.Salt;
                CoreModel.init().Users.Add(user);
            }
            CoreModel.init().SaveChanges();
            MessageBox.Show("Success!");
            //NavigationService.GoBack();
        }

    }
}
