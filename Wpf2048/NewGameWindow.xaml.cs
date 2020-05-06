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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class NewGameWindow : Window
    {
        public NewGameWindow()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validation.GetHasError(this.HSize) &&
                !Validation.GetHasError(this.VSize) &&
                !Validation.GetHasError(this.TargetValue)
                )
                this.Close();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            this.DataContext = this.Owner.DataContext;
        }
    }
}
