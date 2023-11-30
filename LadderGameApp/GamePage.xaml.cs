using LadderGameApp.LadderControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Xml.XPath;
using static LadderGameApp.GamePage;

namespace LadderGameApp
{
    /// <summary>
    /// GamePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class GamePage : Page
    {
        public GamePage(User user)
        {
            InitializeComponent();

            Ladder.CreateVerticalLadder(user.Count, GameGrid, GameStackPanel);
            Ladder.CreateHorizontalLadder();

            Goal.CheckGoal();

            Painter.PaintLadder(Painter.Color);

            GameCalculator.GoalCalc(user.StartIndex);

        }

        private int StartGame(int startIndex)
        {

            return -1;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }






        /*        private void CreateHorizontalLadders(int ladderCount)
                {
                    int regCount = ladderCount * 3;

                    bool[,] ladder = new bool[ladderCount * 3 - 2, regCount * 2 + 1];

                    for (int i = 0; i < ladderCount * 3 - 2; i += 3)
                    {
                        for (int j = 0; j < regCount * 2 + 1; j++)
                        {
                            ladder[i, j] = true;

                        }

                    }

                    ladder[1, 1] = true;
                    ladder[2, 1] = true;

                    for (int i = 0; i < ladderCount * 3 - 2; i++)
                    {

                    }

                }

                private void CreateLadders2(int ladderCount)
                {
                    Random random = new Random();

                    for (int i = 0; i < 30; i++)
                    {
                        int regCount = random.Next((ladderCount - 1) * 2, (ladderCount - 1) * 4);
                        Debug.Write(regCount + " ");
                    }
                }
        */


    }
}
