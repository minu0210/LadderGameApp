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
                // 현재 요소가 R이면 selectIndex++;
                if (ladderArray[legIndex, selectIndex] == LegType.R)
                {
                    if (selectIndex <= ladderArray.GetLength(1))
                    {
                        selectIndex++;
                    }
                }
                // 현재 요소가 L이면 selectIndex--;
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

        // 전체 계산
        internal void AllCalc(UserInput userInput)
        {
            int[] allResult = new int[userInput.LadderCount];

            for(int i = 0; i < userInput.LadderCount; i++)
            {
                allResult[i] = LadderCalc(i);
            }
            
            AllResult = allResult;
        }
    }
}
