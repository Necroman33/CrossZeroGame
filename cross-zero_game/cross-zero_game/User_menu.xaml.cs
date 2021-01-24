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
    /// Логика взаимодействия для User_menu.xaml
    /// </summary>
    public partial class User_menu : Window
    {
        public User_menu(string user)
        {
            InitializeComponent();
            username_label.Content = user;
        }

        private void Play_btn_Click(object sender, RoutedEventArgs e)
        {
            Game game = new Game(username_label.Content.ToString());
            game.Owner = this;
            this.Hide();
            game.ShowDialog();
        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            var response = MessageBox.Show("Вы действительно хотите выйти?", "Выход...",
                                           MessageBoxButton.YesNo);
            if (response == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void User_change_btn_Click(object sender, RoutedEventArgs e)
        {
            var response = MessageBox.Show("Вы действительно хотите выйти из текущего пользователя?", "Смена пользователя",
                                           MessageBoxButton.YesNo);
            if (response == MessageBoxResult.Yes)
            {
                Autorization auth = new Autorization();
                this.Hide();
                auth.ShowDialog();
            }
        }

        private void Score_btn_Click(object sender, RoutedEventArgs e)
        {
            Leaderboard lead = new Leaderboard(username_label.Content.ToString());
            this.Hide();
            lead.ShowDialog();
        }
    }
}
