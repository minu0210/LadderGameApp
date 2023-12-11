using System.Diagnostics;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LadderGameApp.Classes
{
    internal class Painter
    {
        internal List<Line> PaintLadder(int index)
        {
            List<Line> lineList = new List<Line>();

            double defaultX = 409.5 - (Ladder.LadderArray.GetLength(1) * 50);
            double defaultY = 50;

            double verticalSize = 19.8;
            double horizontalSize = 100;

            // 사다리의 수가 8개 이상이면 값 고정
            if (Ladder.LadderArray.GetLength(1) >= 8)
            {
                defaultX = 48.5;
                defaultY = 47;

                verticalSize = 19;
                horizontalSize = 100;
            }

            for (int i = 0; i < Ladder.LadderArray.GetLength(0); i++)
            {
                Line line1 = new Line();
                Line line2 = new Line();
                Line line3 = new Line();

                line1.Stroke = Brushes.Red;
                line1.StrokeThickness = 4;
                line1.StrokeStartLineCap = PenLineCap.Round;
                line1.StrokeEndLineCap = PenLineCap.Round;

                line2.Stroke = Brushes.Red;
                line2.StrokeThickness = 4;
                line2.StrokeStartLineCap = PenLineCap.Round;
                line2.StrokeEndLineCap = PenLineCap.Round;

                line3.Stroke = Brushes.Red;
                line3.StrokeThickness = 4;
                line3.StrokeStartLineCap = PenLineCap.Round;
                line3.StrokeEndLineCap = PenLineCap.Round;

                if (Ladder.LadderArray[i, index] == LegType.R)
                {
                    line1.X1 = (index * horizontalSize) + defaultX;
                    line1.X2 = line1.X1;
                    line1.Y1 = defaultY + (i * verticalSize);
                    line1.Y2 = line1.Y1 + verticalSize / 2;
                    lineList.Add(line1);

                    line2.X1 = (index * horizontalSize) + defaultX;
                    line2.X2 = line2.X1 + horizontalSize;
                    line2.Y1 = defaultY + (i * verticalSize) + verticalSize / 2;
                    line2.Y2 = line2.Y1;
                    lineList.Add(line2);

                    line3.X1 = (index * horizontalSize) + defaultX + horizontalSize;
                    line3.X2 = (index * horizontalSize) + defaultX + horizontalSize;
                    line3.Y1 = defaultY + (i * verticalSize) + verticalSize / 2;
                    line3.Y2 = line3.Y1 + verticalSize / 2;
                    lineList.Add(line3);

                    index++;
                }
                else if (Ladder.LadderArray[i, index] == LegType.L)
                {
                    line1.X1 = (index * horizontalSize) + defaultX;
                    line1.X2 = line1.X1;
                    line1.Y1 = defaultY + (i * verticalSize);
                    line1.Y2 = line1.Y1 + verticalSize / 2;
                    lineList.Add(line1);

                    line2.X1 = (index * horizontalSize) + defaultX;
                    line2.X2 = line2.X1 - horizontalSize;
                    line2.Y1 = defaultY + (i * verticalSize) + verticalSize / 2;
                    line2.Y2 = line2.Y1;
                    lineList.Add(line2);

                    line3.X1 = line1.X1 - horizontalSize;
                    line3.X2 = line3.X1;
                    line3.Y1 = defaultY + (i * verticalSize) + verticalSize / 2;
                    line3.Y2 = line3.Y1 + verticalSize / 2;
                    lineList.Add(line3);

                    index--;
                }
                else
                {
                    line1.X1 = (index * horizontalSize) + defaultX;
                    line1.X2 = line1.X1;
                    line1.Y1 = (i * verticalSize) + defaultY;
                    line1.Y2 = line1.Y1 + verticalSize;
                    lineList.Add(line1);
                }
            }
            Debug.WriteLine(defaultX + ", " + defaultY);

            return lineList;
        }

        internal void PaintAnimation()
        {
            DoubleAnimation paintLadder = new DoubleAnimation();
            paintLadder.From = 0.0;
            paintLadder.To = 1.0;

            paintLadder.AccelerationRatio = 1;
            paintLadder.Duration = new System.Windows.Duration(TimeSpan.FromSeconds(1));

            paintLadder.FillBehavior = FillBehavior.HoldEnd;
            paintLadder.AutoReverse = false;
            paintLadder.Completed += new EventHandler(PaintLadder_Completed);

                        
        }

        private void PaintLadder_Completed(object? sender, EventArgs e)
        {
            
        }
    }
}