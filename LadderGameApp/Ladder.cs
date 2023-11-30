
using LadderGameApp.LadderControls;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace LadderGameApp
{
    internal class Ladder
    {
        internal static void CreateVerticalLadder(int count, Grid GameGrid, StackPanel GameStackPanel)
        {
            // 세로 사다리 생성
            for (int i = 0; i < count; i++)
            {
                ColumnDefinition gridWidth = new ColumnDefinition();
                gridWidth.Width = new GridLength(1, GridUnitType.Star);
                GameGrid.ColumnDefinitions.Add(gridWidth);

                LadderControl ladderItem = new LadderControl();
                ladderItem.SetValue(Grid.ColumnProperty, i);
                GameGrid.Children.Add(ladderItem);
                GameStackPanel.SetValue(Grid.ColumnSpanProperty, count);
            }
        }
        internal static void CreateHorizontalLadder()
        {
            // 가로 사다리 생성
        }
    }
}