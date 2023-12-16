using LadderGameApp.Classes;
using LadderGameApp.LadderControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace LadderGameApp
{
    /// <summary>
    /// ResultPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ResultPage : Page
    {
        public ResultPage()
        {
            InitializeComponent();

            PrintResult();

            MainButton.Click += MainButton_Click;
            BackButton.Click += BackButton_Click;
        }

        private void PrintResult()
        {
            // 결과화면 세팅
            for (int i = 0; i < GameCalculator.AllResult.Length; i++)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content = $"{LadderControls.LadderControl.NameList[i]} => {LadderControls.LadderControl.ResultList[GameCalculator.AllResult[i]]}";

                ResultList.Items.Add(listBoxItem);
            }
        }

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            // 데이터 초기화 후 처음으로
            Navigator.MovePage(NavigationService, new MainPage());

            LadderControl.NameList.Clear();
            LadderControl.ResultList.Clear();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // 데이터 보존 후 이전으로
            NavigationService.GoBack();
            GamePage.IsStarted = true;
        }
    }
}
