﻿using LadderGameApp.Classes;
using System;
using System.Collections.Generic;
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
    /// ResultPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ResultPage : Page
    {
        public ResultPage()
        {
            InitializeComponent();

            PrintResult();
        }

        private void PrintResult()
        {
            // 결과화면 세팅

            for(int i=0; i<GameCalculator.AllResult.Length; i++)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content = $"{i} => {GameCalculator.AllResult[i]}";

                ResultList.Items.Add(listBoxItem);

            }






/*            LadderControls.LadderControl ladderControl = new LadderControls.LadderControl();
            string selectName = ladderControl.NameBox.Text;

            User user = new User();
            int[] results = new int[user.Count];*/
            /*for(int i=0; i<user.Count; i++)
            {
                results[i] = GameCalculator.LadderCalc(User.SelectIndex);
                Debug.WriteLine($"{i} => {results[i]}");
            }*/
        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            // 데이터 초기화 후 처음으로 => 새 MainPage로 이동
            Navigator.MovePage(NavigationService, new MainPage());
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            // 데이터 보존 후 이전으로 => GoBack()
            NavigationService.GoBack();
        }
    }
}