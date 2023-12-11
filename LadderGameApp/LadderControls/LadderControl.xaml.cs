using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LadderGameApp.LadderControls
{
    /// <summary>
    /// Ladder.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LadderControl : UserControl
    {
        private int index;
        private static List<string> nameList = new List<string>();
        private static List<string> resultList = new List<string>();

        private static List<bool> checkTextBoxContent = new List<bool>();

        public int Index { get => index; set => index = value; }
        public static List<string> NameList { get => nameList; set => nameList = value; }
        public static List<string> ResultList { get => resultList; set => resultList = value; }
        public static List<bool> CheckTextBoxContent { get => checkTextBoxContent; set => checkTextBoxContent = value; }

        public LadderControl()
        {
            InitializeComponent();

            NameBox.PreviewMouseLeftButtonDown += NameBox_PreviewMouseLeftButtonDown;
            NameBox.TextChanged += TextBox_TextChanged;
            ResultBox.TextChanged += TextBox_TextChanged;
        }

        internal void StartGame()
        {
            NameBox.IsReadOnly = true;
            NameBox.BorderBrush = Brushes.LightSkyBlue;
            NameBox.BorderThickness = new System.Windows.Thickness(2);
            NameBox.Cursor = Cursors.Hand;

            ResultBox.IsReadOnly = true;
            ResultBox.Cursor = Cursors.Arrow;

            GamePage.IsStarted = true;

            NameList.Add(NameBox.Text);
            ResultList.Add(ResultBox.Text);

        }
        internal void LeaveGame()
        {
            NameBox.IsReadOnly = false;
            ResultBox.IsReadOnly = false;

            GamePage.IsStarted = false;

        }
        internal void CheckTextBox()
        {
            CheckTextBoxContent.Add(string.IsNullOrWhiteSpace(NameBox.Text) ? false : true);
        }
        private void NameBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (GamePage.IsStarted)
            {
                NameBoxMouseDown(sender, new NameBoxMouseDownEventArgs(Index));
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.MaxLength = 10;
        }
        public event EventHandler<NameBoxMouseDownEventArgs> NameBoxMouseDown;

        public class NameBoxMouseDownEventArgs : EventArgs
        {
            private int index;

            public NameBoxMouseDownEventArgs(int index)
            {
                this.Index = index;
            }
            public int Index { get => index; set => index = value; }
        }
    }
}
