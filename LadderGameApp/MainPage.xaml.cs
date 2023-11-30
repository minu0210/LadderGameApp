using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// MainPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainPage : Page
    {
        
        public MainPage()
        {

            InitializeComponent();

            DataContext = new User();


        }
        private void MoveGamePageBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigator.MovePage(NavigationService, new GamePage((User)DataContext));
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            if (((User)DataContext).Count <= 2) return;
            ((User)DataContext).Count--;
            UserCount.Text = ((User)DataContext).Count.ToString();
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            if (((User)DataContext).Count >= 20) return;
            ((User)DataContext).Count++;
            UserCount.Text = ((User)DataContext).Count.ToString();
        }


    }
}
