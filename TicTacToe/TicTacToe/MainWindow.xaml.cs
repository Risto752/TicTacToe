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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private MarkType[] mResults;

        private bool mPlayer1Turn;

        private bool mGameEnded;

        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }

        private void NewGame()
        {
            mResults = new MarkType[9];

            for(var i = 0; i < mResults.Length; i++)
            {
                mResults[i] = MarkType.Free;
            }

            mPlayer1Turn = true;

            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            mGameEnded = false;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            if (mGameEnded)
            {
                NewGame();

                return;

            }

            var button = (Button)sender;

            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            Console.WriteLine(row);


            var index = column + (row * 3);


            if(mResults[index] != MarkType.Free)
            {
                return;
            }

            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;

            button.Content = mPlayer1Turn ? "X" : "O";

            if (!mPlayer1Turn)
            {
                button.Foreground = Brushes.Red; 

            }


            mPlayer1Turn ^= true;

            CheckForWinner();
                
        }

        private void CheckForWinner()
        {

          


            // Row 0

           if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                mGameEnded = true;

                button0_0.Background = button1_0.Background = button2_0.Background = Brushes.Green;
            }

            // Row 1

            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                mGameEnded = true;

                button0_1.Background = button1_1.Background = button2_1.Background = Brushes.Green;
            }

            // Row 2

            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                mGameEnded = true;

                button0_2.Background = button1_2.Background = button2_2.Background = Brushes.Green;
            }


            // Column 0

            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                mGameEnded = true;

                button0_0.Background = button0_1.Background = button0_2.Background = Brushes.Green;
            }

            // Column 1

            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                mGameEnded = true;

                button1_0.Background = button1_1.Background = button1_2.Background = Brushes.Green;
            }

            // Column 2

            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                mGameEnded = true;

                button2_0.Background = button2_1.Background = button2_2.Background = Brushes.Green;
            }

            // Diagonal 1

            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                mGameEnded = true;

                button0_0.Background = button1_1.Background = button2_2.Background = Brushes.Green;
            }

            // Diagonal 2

            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                mGameEnded = true;

                button2_0.Background = button1_1.Background = button0_2.Background = Brushes.Green;
            }



            if (!mResults.Any(result => result == MarkType.Free) && mGameEnded != true)
            {
                mGameEnded = true;

                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
               
                    button.Background = Brushes.Orange;
               
                });

            }

        }
    }
}
