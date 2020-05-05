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

namespace Wpf2048
{
    /// <summary>
    /// Логика взаимодействия для GameOverWindow.xaml
    /// </summary>
    public partial class GameOverWindow : Window
    {
        public delegate void NewGameClickedHandler();
        public event NewGameClickedHandler NewGameClicked;
        public GameOverWindow()
        {
            InitializeComponent();
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            NewGameClicked?.Invoke();
            this.Close();
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModel)this.Owner.DataContext).ContinueGame();
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            ViewModel.GameStates curGameState = ((ViewModel)this.Owner.DataContext).GameState;
            if (curGameState == ViewModel.GameStates.Fail)
            {
                this.MessageBlock.Text = "Ходов больше нет";
            };
            if (curGameState == ViewModel.GameStates.Win)
            {
                this.MessageBlock.Text = "Победа";
                this.ContinueButton.Visibility = Visibility.Visible;
            };
        }

    }
}
