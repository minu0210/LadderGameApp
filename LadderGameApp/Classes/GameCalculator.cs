
using System.Diagnostics;

namespace LadderGameApp.Classes
{
    internal class GameCalculator
    {
        private static int[] allResult;

        public static int[] AllResult { get => allResult; set => allResult = value; }

        internal int LadderCalc(int selectIndex)
        { 
            LegType[,] ladderArray = Ladder.LadderArray;

            for (int legIndex = 0; legIndex < ladderArray.GetLength(0); legIndex++)
            {
                if (ladderArray[legIndex, selectIndex] == LegType.R)
                {
                    if (selectIndex <= ladderArray.GetLength(1))
                    {
                        selectIndex++;
                    }
                }
                else if (ladderArray[legIndex, selectIndex] == LegType.L)
                {
                    if (selectIndex <= ladderArray.GetLength(1))
                    {
                        selectIndex--;
                    }
                }
            }
            int result = selectIndex;

            return result;
        }

        internal void AllCalc(User user)
        {
            int[] allResult = new int[user.Count];

            for(int i = 0; i < user.Count; i++)
            {
                allResult[i] = LadderCalc(i);
            }
            
            AllResult = allResult;
        }
    }
}
