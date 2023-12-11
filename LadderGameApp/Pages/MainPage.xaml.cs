using System.Windows;
using System.Windows.Controls;
using LadderGameApp.Classes;

namespace LadderGameApp
{
    /// <summary>
    /// MainPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainPage : Page
    {

        public MainPage()
        {
            InitializeComponent();

            DataContext = new UserInput();

            MinusButton.Click += MinusButton_Click;
            PlusButton.Click += PlusButton_Click;
            MoveGamePageButton.Click += MoveGamePageButton_Click;
        }
        private void MoveGamePageButton_Click(object sender, RoutedEventArgs e)
        {
            Navigator.MovePage(NavigationService, new GamePage((UserInput)DataContext));
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            if (((UserInput)DataContext).LadderCount <= 2)
            {
                MessageBox.Show("2 이상 20 이하의 수만 선택 가능합니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                ((UserInput)DataContext).LadderCount--;
                UserCount.Text = ((UserInput)DataContext).LadderCount.ToString();
            }
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            if (((UserInput)DataContext).LadderCount >= 20)
            {
                MessageBox.Show("2 이상 20 이하의 수만 선택 가능합니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                ((UserInput)DataContext).LadderCount++;
                UserCount.Text = ((UserInput)DataContext).LadderCount.ToString();
            }
        }
    }
}
