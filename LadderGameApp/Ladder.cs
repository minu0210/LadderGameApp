
using LadderGameApp.LadderControls;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Diagnostics;

namespace LadderGameApp
{
    internal class Ladder
    {
        private static int[] ladderTypeCount = new int[10];

        public static int[] LadderTypeCount { get => ladderTypeCount; set => ladderTypeCount = value; }

        internal static void CreateVerticalLadder(int count, StackPanel GameLadderPanel, StackPanel GameStackPanel)
        {
            // 세로 사다리 생성
            for (int i = 0; i < count; i++)
            {
                LadderControl ladderItem = new LadderControl();
                GameLadderPanel.Children.Add(ladderItem);


                CreateHorizontalLadder(ladderItem, count, i);
            }
        }
        public static void CreateHorizontalLadder(LadderControl ladderItem, int count, int i)
        {

            Random random = new Random();

            int ladderCount = 10;
            int randomMin;
            int randomMax;

            // 맨 처음과 맨 마지막 요소의 가로 다리를 밖으로 향하게 않게 랜덤 범위 조정.
            if (i == count - 1)
            {
                randomMin = 5;
                randomMax = 7;
            }

            for (int j = 0; j < ladderCount; j++)
            {

                StaticLadder staticLadder = new StaticLadder();
                LeftLadder leftLadder = new LeftLadder();
                RightLadder rightLadder = new RightLadder();



                // 가로 사다리의 처음과 마지막 요소를 기본 사다리로 추가.
                if (j == 0)
                {
                    ladderItem.LadderControlStackPanel.Children.Add(staticLadder);
                    LadderTypeCount[0] = 0;
                }
                else if (j == 9)
                {
                    ladderItem.LadderControlStackPanel.Children.Add(staticLadder);
                    LadderTypeCount[9] = 0;
                }
                else
                {
                    // 이전 가로 사다리(LadderTypeCount에 저장)와 만날 수 있게 추가.
                    if (LadderTypeCount[j] == 2) // 이전 요소가 leftLadder면
                    {
                        ladderItem.LadderControlStackPanel.Children.Add(staticLadder);
                        LadderTypeCount[j] = 0; // 현재 요소를 staticLadder로
                    }
                    else if (LadderTypeCount[j] == 1) // 이전 요소가 rightLadder면
                    {
                        ladderItem.LadderControlStackPanel.Children.Add(leftLadder);
                        LadderTypeCount[j] = 2; // 현재 요소를 leftLadder로
                    }
                    else if (LadderTypeCount[j] == 0 && i == count - 1)
                    {
                        ladderItem.LadderControlStackPanel.Children.Add(staticLadder);
                    }
                    else
                    {
                        // 랜덤으로 가로 사다리 추가
                        switch (random.Next(0, 2))
                        {
                            case 0:
                                ladderItem.LadderControlStackPanel.Children.Add(staticLadder);
                                LadderTypeCount[j] = 0;
                                break;
                            case 1:
                                ladderItem.LadderControlStackPanel.Children.Add(rightLadder);
                                LadderTypeCount[j] = 1;
                                break;
/*                            case 2:
                                ladderItem.LadderControlStackPanel.Children.Add(leftLadder);
                                LadderTypeCount[j] = 2;
                                break;*/

                            case 3: // i == 0
                                ladderItem.LadderControlStackPanel.Children.Add(staticLadder);
                                LadderTypeCount[j] = 0;
                                break;
                            case 4:
                                ladderItem.LadderControlStackPanel.Children.Add(rightLadder);
                                LadderTypeCount[j] = 1;
                                break;

/*                            case 5: // i == count-1
                                ladderItem.LadderControlStackPanel.Children.Add(staticLadder);
                                LadderTypeCount[j] = 0;
                                break;
                            case 6:
                                ladderItem.LadderControlStackPanel.Children.Add(leftLadder);
                                LadderTypeCount[j] = 2;
                                break;*/
                        }
                    }

                }

            }


        }
    }
}