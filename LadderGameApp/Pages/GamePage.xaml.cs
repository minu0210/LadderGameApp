using LadderGameApp.Classes;
using LadderGameApp.LadderControls;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace LadderGameApp
{
    /// <summary>
    /// GamePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class GamePage : Page
    {
        private static bool isStarted = false;

        public static bool IsStarted { get => isStarted; set => isStarted = value; }

        public GamePage(User user)
        {
            InitializeComponent();

            Ladder ladder = new Ladder();
            foreach (var current in ladder.CreateLadders(user.Count))
            {
                current.NameBoxMouseDown += Current_NameBoxMouseDown;
                GameLadderPanel.Children.Add(current);
            }
            GameLadderPanel.Children[^1].RenderSize = new Size(100, 297);

            Goal.CheckGoal();

            GameCalculator gameCalculator = new GameCalculator();
            gameCalculator.AllCalc(user);

            // PreviewMouseLeftButtonDown += Window_PreviewMouseLeftButtonDown;
        }

        private void Current_NameBoxMouseDown(object? sender, NameBoxMouseDownEventArgs e)
        {
            // 그리기
            if (IsStarted)
            {
                Painter painter = new Painter();
                LineCanvas.Children.Clear();
                foreach (var line in painter.PaintLadder(e.Index))
                {
                    // PaintAnimation(line);
                    LineCanvas.Children.Add(line);
                }
            }
        }

        private void PaintAnimation(Line line)
        {
            DoubleAnimation paintLadderXAnimation = new DoubleAnimation
            {
                From = line.X1,
                To = line.X2,

                Duration = TimeSpan.FromSeconds(.3)
            };
            DoubleAnimation paintLadderYAnimation = new DoubleAnimation
            {
                From = line.Y1,
                To = line.Y2,

                Duration = TimeSpan.FromSeconds(1)
            };
            line.BeginAnimation(Line.X2Property, paintLadderXAnimation);
            line.BeginAnimation(Line.Y2Property, paintLadderYAnimation);

        }


        private void Start_Click(object sender, RoutedEventArgs e)
        {

            if (LadderControl.IsFull)
            {
                foreach (var child in GameLadderPanel.Children)
                {
                    ((LadderControl)child).StartGame();
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
                ((LadderControl)child).LeaveGame();
            }

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
