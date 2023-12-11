using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using LadderGameApp.Classes;

namespace LadderGameApp.LadderControls
{
    /// <summary>
    /// Ladder.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LadderControl : UserControl
    {
        int index;

        private static bool isFull = true;

        public static bool IsFull { get => isFull; set => isFull = value; }
        public int Index { get => index; set => index = value; }

        public LadderControl()
        {
            InitializeComponent();

        }
        internal void StartGame()
        {
            NameBox.IsReadOnly = true;
            NameBox.Cursor = Cursors.Hand;
            ResultBox.IsReadOnly = true;

            GamePage.IsStarted = true;

            // IsFull = false;

        }
        internal void LeaveGame()
        {
            NameBox.IsReadOnly = false;
            ResultBox.IsReadOnly = false;

            GamePage.IsStarted = false;
        }


        public event EventHandler<NameBoxMouseDownEventArgs> NameBoxMouseDown;
        private void NameBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NameBoxMouseDown(sender, new NameBoxMouseDownEventArgs(Index));

            if (GamePage.IsStarted)
            {
                User user = new User();

                user.SelectIndex = NameBox.TabIndex;
            }
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // GamePage.CheckTextBox();
        }
    }

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
