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
    /// Логика взаимодействия для Leaderboard.xaml
    /// </summary>
    public partial class Leaderboard : Window
    {
        CrossZeroEntities context = new CrossZeroEntities();
        public Leaderboard(string user)
        {
            InitializeComponent();
            Scores[] scores = context.Scores.OrderByDescending(u => u.Wins).ThenByDescending(u => u.Draws).ThenBy(u => u.Defeats).ToArray();

            for (int i = 0; i < 7; i++)
            {
                Label curr_user = (Label)this.FindName($"user_{i + 1}_label");
                Label curr_wins = (Label)this.FindName($"wins_{i + 1}_label");
                Label curr_draws = (Label)this.FindName($"draws_{i + 1}_label");
                Label curr_loses = (Label)this.FindName($"loses_{i + 1}_label");

                curr_user.Content = scores[i].Username;
                curr_wins.Content = scores[i].Wins;
                curr_draws.Content = scores[i].Draws;
                curr_loses.Content = scores[i].Defeats;
            }

            var our_user = scores.Where(u => u.Username == user).FirstOrDefault();
            if (user != "Неизвестный")
            {
                place_user_label.Content = $"{ Array.IndexOf(scores, our_user) + 1}/{scores.Length}";
                user_current_label.Content = $"{our_user.Username}(вы)";
                wins_user_label.Content = our_user.Wins;
                loses_user_label.Content = our_user.Defeats;
                draws_user_label.Content = our_user.Draws;
            }
        }

        private void To_main_btn_Click(object sender, RoutedEventArgs e)
        {
            if (user_current_label.Content.ToString() != "")
            {
                string user = user_current_label.Content.ToString();
                User_menu use = new User_menu(user.Substring(0,user.Length-4));
                this.Hide();
                use.ShowDialog();
            }
            else
            {
                MainWindow mainw = new MainWindow();
                this.Hide();
                mainw.ShowDialog();
            }
        }
    }
}
