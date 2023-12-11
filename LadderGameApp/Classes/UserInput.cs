namespace LadderGameApp.Classes
{
    public class UserInput : Model.MainModel
    {

        private int count = 2;
        private int selectIndex;


        public int Count
        {
            get => count;
            set
            {
                if (count != value)
                {
                    count = value;
                    OnPropertyChanged("Count");

                }
            }
        }
        public int SelectIndex { get => selectIndex; set => selectIndex = value; }
    }
}