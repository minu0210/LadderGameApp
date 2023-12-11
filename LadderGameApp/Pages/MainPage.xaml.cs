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


        }
        private void MoveGamePageBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigator.MovePage(NavigationService, new GamePage((UserInput)DataContext));
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            if (((UserInput)DataContext).Count <= 2) return;
            ((UserInput)DataContext).Count--;
            UserCount.Text = ((UserInput)DataContext).Count.ToString();
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            if (((UserInput)DataContext).Count >= 20) return;
            ((UserInput)DataContext).Count++;
            UserCount.Text = ((UserInput)DataContext).Count.ToString();
        }


    }
}
