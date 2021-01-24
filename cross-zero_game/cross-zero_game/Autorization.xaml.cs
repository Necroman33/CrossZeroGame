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

namespace cross_zero_game
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        CrossZeroEntities context = new CrossZeroEntities();
        public Autorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var users = context.Users.ToList();
            var current_user = users.Where(u => u.Username == textBox.Text);
            if (current_user.LongCount() == 1)
            {
                foreach (Users user in current_user)
                {
                    if (user.Password == passwordBox.Password)
                    {
                        string user_login = user.Username;
                        User_menu use = new User_menu(user_login);
                        this.Hide();
                        use.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Вы ввели не верный пароль!","Ошибка!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("Данного пользователя не существует!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void To_main_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainw = new MainWindow();
            this.Hide();
            mainw.ShowDialog();
        }
    }
}
