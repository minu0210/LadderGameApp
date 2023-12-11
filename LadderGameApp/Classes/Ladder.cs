using LadderGameApp.LadderControls;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace LadderGameApp.Classes
{
    internal enum LegType
    {
        S,
        R,
        L
    }

    internal class Ladder
    {
        private static LegType[,] ladderArray;
        private int legCount = 10; // 사다리 하나 당 가로 다리 개수

        internal static LegType[,] LadderArray { get => ladderArray; set => ladderArray = value; }
        public int LegCount { get => legCount; set => legCount = value; }

        internal List<LadderControl> CreateLadders(int ladderCount)
        {
            List<LadderControl> ladders = new List<LadderControl>();

            LadderArray = new LegType[legCount, ladderCount]; // 전체 사다리 배열

            for (int ladderIndex = 0; ladderIndex < ladderCount; ladderIndex++)
            {
                // 가로 사다리 구현
                LadderArray = ImplementHorizontalLadder(LadderArray, ladderIndex, ladderCount);

                // ladderItem에 가로 사다리 추가
                LadderControl ladderItem = CreateHorizontalLadder(LadderArray, ladderIndex, ladderCount);

                // legCount만큼 Grid.RowDefinitions 추가
                //RowDefinition gridRowDefinitionHeight = new RowDefinition { Height = new GridLength(1, GridUnitType.Star) };
                //ladderItem.LadderControlGrid.RowDefinitions.Add(gridRowDefinitionHeight);

                // GameLadderPanel에 생성한 ladderItem 추가
                ladders.Add(ladderItem);
                if(ladderIndex == ladderCount-1)
                {
                    ladderItem.Margin = new Thickness(10, 0, 10, 0);
                    Debug.WriteLine("execute");
                }

            }
            return ladders;
        }

        private static LadderControl CreateHorizontalLadder(LegType[,] ladderArray, int ladderIndex, int ladderCount)
        {
            // LadderControl 객체 생성
            LadderControl ladderItem = new LadderControl();
            ladderItem.Index = ladderIndex;

            for (int i = 0; i < ladderArray.GetLength(0); i++)
            {
                if (ladderArray[i, ladderIndex] == LegType.R)
                {
                    RightLadder rightLadder = new RightLadder();
                    ladderItem.LadderControlGrid.Children.Add(rightLadder);
                    rightLadder.SetValue(Grid.RowProperty, i);
                }
                else if (ladderArray[i, ladderIndex] == LegType.L)
                {
                    LeftLadder leftLader = new LeftLadder();
                    ladderItem.LadderControlGrid.Children.Add(leftLader);
                    leftLader.SetValue(Grid.RowProperty, i);
                }
            }

            // TextBox의 TabIndex 설정
            ladderItem.NameBox.TabIndex = ladderIndex;
            ladderItem.ResultBox.TabIndex = ladderIndex + ladderCount;

            return ladderItem;
        }

        internal static LegType[,] ImplementHorizontalLadder(LegType[,] ladderArray, int ladderIndex, int ladderCount)
        {
            // ladderCount만큼 R을 무작위한 위치에 삽입
            InsertRightLegs(ladderArray, ladderIndex, ladderCount);

            // R의 오른쪽에 L을 삽입
            InsertLeftLegs(ladderArray);

            // PrintDimensionalArray(ladderArray);

            return ladderArray;
        }

        private static void InsertRightLegs(LegType[,] ladderArr, int ladderIndex, int ladderCount)
        {
            Random random = new Random();

            int randomLeg = random.Next(2, 5); // 한 사다리의 가로 다리 수
            int[] currentIndexArr = new int[randomLeg];

            for (int j = 0; j < randomLeg; j++)
            {
                int randomIndex = random.Next(1, 9);
                // Debug.WriteLine("randomIndex: " + randomIndex);

                if (ladderIndex < ladderCount - 1)
                {
                    if (currentIndexArr.Contains(randomIndex))
                    {
                        j--;
                    }
                    else
                    {
                        if (ladderArr[randomIndex, ladderIndex] == LegType.L)
                        {
                            j--;
                        }
                        else
                        {
                            ladderArr[randomIndex, ladderIndex] = LegType.R;
                            currentIndexArr[j] = randomIndex;
                        }
                    }
                }
            }
            // PrintArray(currentIndexArr);

        }

        private static void InsertLeftLegs(LegType[,] ladderArr)
        {
            for (int i = 0; i < ladderArr.GetLength(0); i++)
            {
                for (int k = 0; k < ladderArr.GetLength(1) - 1; k++)
                {
                    if (ladderArr[i, k] == LegType.R)
                    {
                        ladderArr[i, k + 1] = LegType.L;
                    }

                }
            }
        }
        internal static void PrintArray(int[] array)
        {
            foreach (int i in array)
            {
                Debug.Write(i + " ");
            }
            Debug.WriteLine("");
        }
        internal static void PrintDimensionalArray(LegType[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Debug.Write(arr[i, j] + " ");
                }
                Debug.WriteLine("");
            }
            Debug.WriteLine("\n============\n");
        }
    }
}