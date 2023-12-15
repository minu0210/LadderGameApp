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
            ((UserInput)DataContext).LadderCount--;
            UserCount.Text = ((UserInput)DataContext).LadderCount.ToString();

            if (((UserInput)DataContext).LadderCount <= 2)
            {
                MinusButton.Visibility = Visibility.Hidden;
            }
            else
            {
                PlusButton.Visibility = Visibility.Visible;
            }
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            ((UserInput)DataContext).LadderCount++;
            UserCount.Text = ((UserInput)DataContext).LadderCount.ToString();

            if (((UserInput)DataContext).LadderCount >= 20)
            {
                PlusButton.Visibility = Visibility.Hidden;
            }
            else
            {
                MinusButton.Visibility = Visibility.Visible;
            }
        }
    }
}
