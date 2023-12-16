using System.Windows;
using System.Windows.Media.Imaging;

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

            Uri iconUri = new Uri(@"./Resources/ladder.ico", UriKind.Relative);
            Icon = BitmapFrame.Create(iconUri);

            Loaded += Window_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainFr.Content = new MainPage();
        }
    }
}