namespace LadderGameApp.Classes
{
    public class UserInput : Model.MainModel
    {
        private int ladderCount = 2;
        private int selectIndex;

        public int LadderCount
        {
            get => ladderCount;
            set
            {
                if (ladderCount != value)
                {
                    ladderCount = value;
                    OnPropertyChanged("LadderCount");
                }
            }
        }
        public int SelectIndex { get => selectIndex; set => selectIndex = value; }
    }
}