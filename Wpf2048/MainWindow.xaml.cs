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

namespace Wpf2048
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
            CreateTiles();
        }

        private void CreateTiles()
        {
            for (int i = 0; i < 4; i++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                FieldView.ColumnDefinitions.Add(colDef);
            }
            for (int i = 0; i < 4; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                FieldView.RowDefinitions.Add(rowDef);
            }
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    Label tile = new Label();
                    Binding binding = new Binding();
                    binding.Source = (ViewModel)DataContext;
                    binding.Path = new PropertyPath("FieldValue");
                    tile.SetBinding(Button.ContentProperty, binding);
                    tile.Style = this.Resources["TilesStyle"] as Style;
                    Grid.SetRow(tile, i);
                    Grid.SetColumn(tile, j);
                    FieldView.Children.Add(tile);
                }
        }

        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    ((ViewModel)DataContext).KeyPressed(ViewModel.Actions.Left);
                    break;
                case Key.Up:
                    ((ViewModel)DataContext).KeyPressed(ViewModel.Actions.Up);
                    break;
                case Key.Right:
                    ((ViewModel)DataContext).KeyPressed(ViewModel.Actions.Right);
                    break;
                case Key.Down:
                    ((ViewModel)DataContext).KeyPressed(ViewModel.Actions.Down);
                    break;
            }
        }
    }
}
