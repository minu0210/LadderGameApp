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

        public static bool IsStarted { get => isStarted; set => isStarted = value; }

        public GamePage(UserInput user)
        {
            InitializeComponent();

            // user.Count만큼 사다리 구성
            Ladder ladder = new Ladder();
            foreach (var current in ladder.CreateLadders(user.Count))
            {
                current.NameBoxMouseDown += Current_NameBoxMouseDown;
                GameLadderPanel.Children.Add(current);
            }

            GameCalculator gameCalculator = new GameCalculator();
            gameCalculator.AllCalc(user);

            // 커서 클릭 위치 좌표 구하기
            // PreviewMouseLeftButtonDown += Window_PreviewMouseLeftButtonDown;
        }

        private void Current_NameBoxMouseDown(object? sender, LadderControl.NameBoxMouseDownEventArgs e)
        {
            PaintLadderPath(e);
        }

        private async void PaintLadderPath(LadderControl.NameBoxMouseDownEventArgs e)
        {
            if (IsStarted)
            {
                Painter painter = new Painter();
                LineCanvas.Children.Clear();
                foreach (var line in painter.PaintLadder(e.Index))
                {
                    PaintAnimation(line);
                    LineCanvas.Children.Add(line);

                    await Task.Delay(500);

                }
            }
        }

        private void PaintAnimation(Line line)
        {
            DoubleAnimation paintLadderXAnimation = new DoubleAnimation
            {
                From = line.X1,
                To = line.X2,

                Duration = TimeSpan.FromMilliseconds(500)
            };
            DoubleAnimation paintLadderYAnimation = new DoubleAnimation
            {
                From = line.Y1,
                To = line.Y2,

                Duration = TimeSpan.FromMilliseconds(500)
        };
            line.BeginAnimation(Line.X2Property, paintLadderXAnimation);
            line.BeginAnimation(Line.Y2Property, paintLadderYAnimation);

        }


        private void Start_Click(object sender, RoutedEventArgs e)
        {
            // LadderControl의 TextBox 체크
            LadderControls.LadderControl.CheckTextBoxContent.Clear();
            foreach (var child in GameLadderPanel.Children)
            {
                ((LadderControls.LadderControl)child).CheckTextBox();
            }


            // LadderControl의 모든 TextBox가 null 또는 whitespace가 아닐 경우 실행
            if (!LadderControls.LadderControl.CheckTextBoxContent.Contains(false))
            {
                foreach (var child in GameLadderPanel.Children)
                {
                    ((LadderControls.LadderControl)child).StartGame();
                }

                Square.Visibility = Visibility.Collapsed;
                Result.Visibility = Visibility.Visible;
                Start.Visibility = Visibility.Collapsed;

            }

        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();

            foreach (var child in GameLadderPanel.Children)
            {
                ((LadderControls.LadderControl)child).LeaveGame();
            }

            LadderControls.LadderControl.NameList.Clear();
            LadderControls.LadderControl.ResultList.Clear();
        }


        private void Result_Click(object sender, RoutedEventArgs e)
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
