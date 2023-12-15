using LadderGameApp.Classes;
using LadderGameApp.LadderControls;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LadderGameApp
{
    /// <summary>
    /// GamePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class GamePage : Page
    {
        private static bool isStarted = false;
        private static bool animationNowPainting = false;

        public static bool IsStarted { get => isStarted; set => isStarted = value; }
        public static bool AnimationNowPainting { get => animationNowPainting; set => animationNowPainting = value; }

        public GamePage(UserInput userInput)
        {
            InitializeComponent();

            // user.Count만큼 사다리 구성
            Ladder ladder = new Ladder();
            foreach (var current in ladder.CreateLadders(userInput.LadderCount))
            {
                current.NameBoxMouseDown += Current_NameBoxMouseDown;
                GameLadderPanel.Children.Add(current);
            }

            GameCalculator gameCalculator = new GameCalculator();
            gameCalculator.AllCalc(userInput);

            StartButton.Click += StartButton_Click;
            ResultButton.Click += ResultButton_Click;
            BackButton.Click += BackButton_Click;

            // 커서 클릭 위치 좌표 구하기
            // PreviewMouseLeftButtonDown += Window_PreviewMouseLeftButtonDown;
        }

        private void Current_NameBoxMouseDown(object? sender, LadderControl.NameBoxMouseDownEventArgs e)
        {
            StartPaintLadderPath(e);
        }

        private async void StartPaintLadderPath(LadderControl.NameBoxMouseDownEventArgs e)
        {
            // 게임이 시작되었으며 애니메이션이 진행중이지 않으면 실행
            if (IsStarted && !animationNowPainting)
            {
                Painter painter = new Painter();
                LineCanvas.Children.Clear();
                animationNowPainting = true;
                foreach (var line in painter.PaintLadderPath(e.Index))
                {
                    PaintLadderPathAnimation(line);
                    LineCanvas.Children.Add(line);

                    await Task.Delay(400);
                }
                animationNowPainting = false;
            }
        }

        private void PaintLadderPathAnimation(Line line)
        {
            DoubleAnimation paintLadderXAnimation = new DoubleAnimation
            {
                From = line.X1,
                To = line.X2,
                Duration = TimeSpan.FromMilliseconds(400)
            };

            DoubleAnimation paintLadderYAnimation = new DoubleAnimation
            {
                From = line.Y1,
                To = line.Y2,
                Duration = TimeSpan.FromMilliseconds(400)
            };

            line.BeginAnimation(Line.X2Property, paintLadderXAnimation);
            line.BeginAnimation(Line.Y2Property, paintLadderYAnimation);
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // LadderControl의 TextBox 체크
            LadderControl.TextBoxCheckContentList.Clear();
            foreach (var child in GameLadderPanel.Children)
            {
                ((LadderControl)child).CheckTextBox();
            }

            // LadderControl의 TextBox의 Text가 null 또는 whitespace가 존재할 경우 실행
            if (LadderControl.TextBoxCheckContentList.Contains(false))
            {
                MessageBox.Show("모든 입력창을 입력해야합니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                foreach (var child in GameLadderPanel.Children)
                {
                    ((LadderControl)child).StartGame();
                }

                Square.Visibility = Visibility.Collapsed;
                ResultButton.Visibility = Visibility.Visible;
                StartButton.Visibility = Visibility.Collapsed;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();

            foreach (var child in GameLadderPanel.Children)
            {
                ((LadderControl)child).LeaveGame();
            }

            LadderControl.NameList.Clear();
            LadderControl.ResultList.Clear();
        }

        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {
            Navigator.MovePage(NavigationService, new ResultPage());
        }
        private void Window_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var point = Mouse.GetPosition(this);
            Debug.WriteLine(point);
        }
    }
}
