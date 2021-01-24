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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        CrossZeroEntities context = new CrossZeroEntities();
        public Registration()
        {
            InitializeComponent();
        }

        private void To_main_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainw = new MainWindow();
            this.Hide();
            mainw.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var users = context.Users.ToList();
            if (users.Any(u => u.Username == textBox.Text))
            {
                MessageBox.Show("Данное имя пользователя уже используется!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                if (textBox.Text =="")
                {
                    MessageBox.Show("Вы не указали имя пользователя!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    if(passwordBox.Password == "")
                    {
                        MessageBox.Show("Вы не указали пароль!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    else
                    {
                        if (passwordBox.Password!=passwordBox2.Password)
                        {
                            MessageBox.Show("Пароли не совпадают!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                        else
                        {
                            Users user = new Users();

                            user.Username = textBox.Text;
                            user.Password = passwordBox.Password;
                            context.Users.Add(user);

                            Scores userscore = new Scores();

                            userscore.Username = textBox.Text;
                            userscore.Wins = 0;
                            userscore.Defeats = 0;
                            userscore.Draws = 0;
                            context.Scores.Add(userscore);

                            context.SaveChanges();

                            MessageBox.Show("Новый пользователь успешно создан!", "Успех!", MessageBoxButton.OK);

                            MainWindow mainw = new MainWindow();
                            this.Hide();
                            mainw.ShowDialog();
                        }
                    }
                }
            }
        }
    }
}
