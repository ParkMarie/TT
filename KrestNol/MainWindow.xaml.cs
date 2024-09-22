using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KrestNol
{
  
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool playerCross = true;
        string playerSymbol = "X";
        string aiSymbol = "O";

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Button[] buttons = new Button[] { Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9 };

            foreach (Button button in buttons)
            {
                button.IsEnabled = true;
                button.Content = "";
            }

            StartBtn.Content = "Сброс";

            if (playerCross)
            {
                playerSymbol = "X";
                aiSymbol = "O";
            }
            else
            {
                playerSymbol = "O";
                aiSymbol = "X";
            }

            if (!playerCross)
            {
                AI(playerCross);
            }
        }

        private void AllCenterButtons_Click(object sender, RoutedEventArgs e)
        {
            if ((string)(sender as Button).Content == "")
            {
                (sender as Button).Content = playerSymbol;

                bool victory = ForVictory(true);
                bool noTie = ForTie();

                if (victory || noTie)
                {
                    Reset();
                    return;
                }

                AI(false);

                victory = ForVictory(false);
                noTie = ForTie();

                if (victory || noTie)
                {
                    Reset();
                }
            }
        }

        private void AI(bool isPlayer)
        {
            Button[] buttons = new Button[] { Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9 };
            int stop = 0;

            do
            {
                int choice = random.Next(buttons.Length);

                if ((string)buttons[choice].Content == "")
                {
                    buttons[choice].Content = aiSymbol;
                    break;
                }

                stop++;

            } while (stop <= 10);
        }

        Random random = new Random();

        private bool ForVictory(bool isPlayer)
        {
            Button[] buttons = new Button[] { StartBtn, Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9 };

            for (int i = 0; i < 7; i += 3)
            {
                if (buttons[1 + i].Content == buttons[2 + i].Content &&
                    buttons[2 + i].Content == buttons[3 + i].Content &&
                    (string)buttons[1 + i].Content != "")
                {
                    if (isPlayer)
                    {
                        MessageBox.Show("Вы выиграли! Ура, ПобЕдА!", "Поздравляю!", MessageBoxButton.OK);
                    }
                    else
                    {
                        MessageBox.Show("Компьютер выиграл! Вы лОшарик)", "Ну ты чего, попробуй ещё раз.", MessageBoxButton.OK);


                    }
                    return true;

                }

            }

            for (int i = 0; i < 3; i++)
            {
                if (buttons[1 + i].Content == buttons[4 + i].Content &&
                    buttons[4 + i].Content == buttons[7 + i].Content &&
                    (string)buttons[1 + i].Content != "")
                {
                    if (isPlayer)
                    {
                        MessageBox.Show("Вы выиграли! Ура, ПобЕдА!", "Поздравляю!", MessageBoxButton.OK);
                    }
                    else
                    {
                        MessageBox.Show("Компьютер выиграл! Вы лОшарик)", "Ну ты чего, попробуй ещё раз.", MessageBoxButton.OK);
                    }

                    return true;
                }
            }

            if (buttons[1].Content == buttons[5].Content &&
                buttons[5].Content == buttons[9].Content &&
                (string)buttons[1].Content != "")
            {
                if (isPlayer)
                {
                    MessageBox.Show("Вы выиграли! Ура, ПобЕдА!", "Поздравляю!", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("Компьютер выиграл! Вы лОшарик)", "Ну ты чего, попробуй ещё раз.", MessageBoxButton.OK);
                }

                return true;
            }

            if (buttons[3].Content == buttons[5].Content &&
                buttons[5].Content == buttons[7].Content &&
                (string)buttons[3].Content != "")
            {
                if (isPlayer)
                {
                    MessageBox.Show("Вы выиграли! Ура, ПобЕдА!", "Поздравляю!", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("Компьютер выиграл! Вы лОшарик)", "Ну ты чего, попробуй ещё раз.", MessageBoxButton.OK);
                }

                return true;
            }

            return false;
        }

        private bool ForTie()
        {
            Button[] buttons = new Button[] { StartBtn, Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9 };

            foreach (Button button in buttons)
            {
                if ((string)button.Content == "")
                {
                    return false;
                }
            }

            MessageBox.Show("Ничья!", "Игра окончена", MessageBoxButton.OK);
            return true;
        }

        private void Reset()
        {
            Button[] buttons = new Button[] { Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9 };

            foreach (Button button in buttons)
            {
                button.Content = "";
                button.IsEnabled = true;
            }

            StartBtn.Content = "Начать";
            playerCross = !playerCross;

        }
    }
}