using GameLogic;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lesson21_Game15WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Game game = new Game();
        public MainWindow()
        {
            InitializeComponent();

            for (int n=0, i =0; i< 4; ++i)
            {
                for(int j = 0; j< 4; ++j)
                {
                    int val = game[i, j];
                    if(val!=0)
                    {
                        Button button = GameGrid.Children[n++] as Button;
                        if(button !=  null)
                        {
                            button.Content = val;
                            button.SetValue(Grid.RowProperty, i);
                            button.SetValue(Grid.ColumnProperty, j);
                        }
                    }
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            int col = (int)btn.GetValue(Grid.ColumnProperty);
            int row = (int)btn.GetValue(Grid.RowProperty);
            int val = (int) btn.Content;
            switch (game.CheckAndGo(val))
            {
                case MoveButton.ToDown:
                    ButtonToDown(btn);
                    break;
                case MoveButton.ToUp:
                    ButtonToUp(btn);
                    break;
                case MoveButton.ToLeft:
                    ButtonToLeft(btn);
                    break;
                case MoveButton.ToRight:
                    ButtonToRight(btn);
                    break;
            }
            if(game.IsWin())
            {
                MessageBox.Show("You win!", "Congratulations", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ButtonToUp(Button btn)
        {
            int row = (int)btn.GetValue(Grid.RowProperty);
            ThicknessAnimation animation = new ThicknessAnimation();
            animation.From = new Thickness(0, 150, 0, 0);
            animation.To = new Thickness(0, 0, 0, 150);
            animation.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            btn.SetValue(Grid.RowSpanProperty, 2);
            btn.SetValue(Grid.RowProperty, row - 1);
            animation.FillBehavior = FillBehavior.Stop;
            animation.Completed += (s, ea) =>
            {

                btn.SetValue(Grid.RowSpanProperty, 1);
            };
            btn.BeginAnimation(MarginProperty, animation);
        }

        private void ButtonToDown(Button btn)
        {
            int row = (int)btn.GetValue(Grid.RowProperty);
            ThicknessAnimation animation = new ThicknessAnimation();
            animation.From = new Thickness(0, 0, 0, 150);
            animation.To = new Thickness(0, 150, 0, 0);
            animation.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            btn.SetValue(Grid.RowSpanProperty, 2);
            animation.FillBehavior = FillBehavior.Stop;
            animation.Completed += (s, ea) =>
            {
                btn.SetValue(Grid.RowProperty, row + 1);
                btn.SetValue(Grid.RowSpanProperty, 1);
            };
            btn.BeginAnimation(MarginProperty, animation);
        }

        private void ButtonToRight(Button btn)
        {
            int col = (int)btn.GetValue(Grid.ColumnProperty);
            ThicknessAnimation animation = new ThicknessAnimation();
            animation.From = new Thickness(0, 0, 150, 0);
            animation.To = new Thickness(150, 0, 0, 0);
            animation.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            btn.SetValue(Grid.ColumnSpanProperty, 2);
            animation.FillBehavior = FillBehavior.Stop;
            animation.Completed += (s, ea) =>
            {
                btn.SetValue(Grid.ColumnProperty, col + 1);
                btn.SetValue(Grid.ColumnSpanProperty, 1);
            };
            btn.BeginAnimation(MarginProperty, animation);
        }

        private void ButtonToLeft(Button btn)
        {
            int col = (int)btn.GetValue(Grid.ColumnProperty);
            ThicknessAnimation animation = new ThicknessAnimation();
            animation.From = new Thickness(150, 0, 0, 0);
            animation.To = new Thickness(0, 0, 150, 0);
            animation.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            btn.SetValue(Grid.ColumnSpanProperty, 2);
            btn.SetValue(Grid.ColumnProperty, col - 1);
            animation.FillBehavior = FillBehavior.Stop;
            animation.Completed += (s, ea) =>
            {

                btn.SetValue(Grid.ColumnSpanProperty, 1);
            };
            btn.BeginAnimation(MarginProperty, animation);
        }
    }
}
