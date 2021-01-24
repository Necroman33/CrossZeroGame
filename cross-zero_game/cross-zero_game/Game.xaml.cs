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
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        CrossZeroEntities context = new CrossZeroEntities();
        Logic logic = new Logic();
        char[,] arr = new char[3, 3];
        char symbol_u = 'x';
        char symbol_i = 'o';
        char first = 'u';
        public Game(string user)
        {
            InitializeComponent();
            username_label.Content = user;
            var scores = context.Scores.ToList();
            var user_scores = scores.Where(u => u.Username == user).FirstOrDefault();
            if (user != "Неизвестный")
            {
                Wins.Content = user_scores.Wins;
                Loses.Content = user_scores.Defeats;
                Draws.Content = user_scores.Draws;
            }
            else
            {
                Wins.Content = 0;
                Loses.Content = 0;
                Draws.Content = 0;
            }
            restart();
        }

        private void click(Button clicked)
        {
            clicked.Content = symbol_u;
            clicked.IsEnabled = false;

            string ii_turn = logic.turn(arr,symbol_u,symbol_i,first);

            int x = Convert.ToInt32(ii_turn.Substring(4, 1));
            int y = Convert.ToInt32(ii_turn.Substring(6, 1));

            arr[x-1,y-1] = symbol_i;

            Button curr_turn = (Button)this.FindName(ii_turn);

            curr_turn.Content = symbol_i;
            curr_turn.IsEnabled = false;

            result();
        }

        private void result()
        {
            string result = logic.result(arr, symbol_u, symbol_i);
            string user = username_label.Content.ToString();
            if (result != "")
            {
                switch (result)
                {
                    case "Win":
                        block_game();
                        if (user != "Неизвестный")
                        {
                            logic.addPoint(user, result);
                        }
                        Wins.Content = Convert.ToInt32(Wins.Content)+1;
                        MessageBox.Show("Не знаю как, но вы выиграли, скорее всего это моя ошибка)))) ну или вы изменили код чтобы проверить работоспособность функции :)", "Результат игры");
                        break;
                    case "Lose":
                        block_game();
                        if (user != "Неизвестный")
                        {
                            logic.addPoint(user, result);
                        }
                        Loses.Content = Convert.ToInt32(Loses.Content) + 1;
                        MessageBox.Show("Вы проиграли. Если хотите, можете попробовать снова :)", "Результат игры");
                        break;
                    case "Draw":
                        block_game();
                        if (user != "Неизвестный")
                        {
                            logic.addPoint(user, result);
                        }
                        Draws.Content = Convert.ToInt32(Draws.Content) + 1;
                        MessageBox.Show("Ничья, на врятли вы сможете больше:) Если хотите, можете попробовать снова.", "Результат игры");
                        break;
                }
            }
        }

        private void block_game()
        {
            for (var x_ = 0; x_ < 3; x_++)
            {
                for (var y_ = 0; y_ < 3; y_++)
                {
                    Button curr_butn = (Button)this.FindName($"cell{x_ + 1}_{y_ + 1}");
                    curr_butn.IsEnabled = false;
                }
            }
        }

        private void restart()
        {
            if (crossBtn.IsChecked == true)
            {
                symbol_u = 'x';
                symbol_i = 'o';
            }
            else
            {
                symbol_u = 'o';
                symbol_i = 'x';
            }
            if (firstBtn.IsChecked == true)
            {
                first = 'u';
            }
            else
            {
                first = 'i';
            }
            for (var x = 0; x < 3; x++)
            {
                for (var y = 0; y < 3; y++)
                {
                    Button curr_butn = (Button)this.FindName($"cell{x + 1}_{y + 1}");
                    curr_butn.IsEnabled = true;
                    curr_butn.Content = "";
                    arr[x, y] = '0';
                }
            }
            if (first == 'i')
            {
                arr[1, 1] = symbol_i;
                cell2_2.Content = symbol_i;
                cell2_2.IsEnabled = false;
            }
        }

        private void Cell1_1_Click(object sender, RoutedEventArgs e)
        {
            arr[0, 0] = symbol_u;
            click(cell1_1);
        }

        private void Cell1_2_Click(object sender, RoutedEventArgs e)
        {
            arr[0, 1] = symbol_u;
            click(cell1_2);
        }

        private void Cell1_3_Click(object sender, RoutedEventArgs e)
        {
            arr[0, 2] = symbol_u;
            click(cell1_3);
        }

        private void Cell2_1_Click(object sender, RoutedEventArgs e)
        {
            arr[1, 0] = symbol_u;
            click(cell2_1);
        }

        private void Cell2_2_Click(object sender, RoutedEventArgs e)
        {
            arr[1, 1] = symbol_u;
            click(cell2_2);
        }

        private void Cell2_3_Click(object sender, RoutedEventArgs e)
        {
            arr[1, 2] = symbol_u;
            click(cell2_3);
        }

        private void Cell3_1_Click(object sender, RoutedEventArgs e)
        {
            arr[2, 0] = symbol_u;
            click(cell3_1);
        }

        private void Cell3_2_Click(object sender, RoutedEventArgs e)
        {
            arr[2, 1] = symbol_u;
            click(cell3_2);
        }

        private void Cell3_3_Click(object sender, RoutedEventArgs e)
        {
            arr[2, 2] = symbol_u;
            click(cell3_3);
        }

        private void Reset_btn_Click(object sender, RoutedEventArgs e)
        {
            restart();
        }

        private void To_main_btn_Click(object sender, RoutedEventArgs e)
        {
            string user = username_label.Content.ToString();
            if (user != "Неизвестный")
            {
                User_menu use = new User_menu(user);
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
