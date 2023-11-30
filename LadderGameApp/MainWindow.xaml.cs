using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LadderGameApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainFr.Content = new MainPage();
        }
        void CreateVerticalLadders(int playerCount)
        {
            Random r = new Random();
            //해야될 일을 주석으로 달아 놓고.
            //어떤 값을 출력 할 것인지.
            //어떤 연산을 할 것인지.
             for(int i = 0; i < playerCount; i++)
             {
                CreateVerticalLadder(i, r.Next(1000));
            }
        }

        private void CreateVerticalLadder(int i, int v)
        {
            //한 줄을 만든다.
        }
    }
}