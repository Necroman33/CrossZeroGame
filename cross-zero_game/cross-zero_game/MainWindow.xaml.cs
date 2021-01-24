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

namespace cross_zero_game
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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

        private void Auth_btn_Click(object sender, RoutedEventArgs e)
        {
            Autorization auth = new Autorization();
            auth.Owner = this;
            this.Hide();
            auth.ShowDialog();
        }

        private void Register_btn_Click(object sender, RoutedEventArgs e)
        {
            Registration registr = new Registration();
            registr.Owner = this;
            this.Hide();
            registr.ShowDialog();
        }

        private void Score_btn_Click(object sender, RoutedEventArgs e)
        {
            Leaderboard lead = new Leaderboard(username_label.Content.ToString());
            lead.Owner = this;
            this.Hide();
            lead.ShowDialog();
        }
    }
}
