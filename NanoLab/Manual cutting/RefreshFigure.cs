using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NanoExperiment.Automanipulation;

namespace NanoExperiment.Cutting
{
    class RefreshFigure
    {
        public static Bitmap BackgroundImageRefresh(Bitmap image)
        {
            Graphics g = Graphics.FromImage(image);
            Pen myPen = new Pen(Color.White, 1);
            PointF p1, p2;
            for (int i = 0; i < SavePath.handPath.Count; i += 2)
            {
                p1 = new PointF((float)((SavePath.handPath[i].X + ManualCutting._xSize / 2) / ManualCutting._xSize * ManualCutting._sampsInLine),
                    (float)(ManualCutting._numberOfLines - 1 - (SavePath.handPath[i].Y + ManualCutting._ySize / 2) / ManualCutting._ySize * ManualCutting._numberOfLines));
                p2 = new PointF((float)((SavePath.handPath[i + 1].X + ManualCutting._xSize / 2) / ManualCutting._xSize * ManualCutting._sampsInLine),
                    (float)(ManualCutting._numberOfLines - 1 - (SavePath.handPath[i + 1].Y + ManualCutting._ySize / 2) / ManualCutting._ySize * ManualCutting._numberOfLines));

                g.DrawLine(myPen, p1, p2);
            }

            return image;
        }

        public static Bitmap BackgroundImageRefresh(Bitmap image, int type, List<PointF[]> patternLine)
        {
            Graphics g = Graphics.FromImage(image);
            Pen myPen = new Pen(Color.White, 1);
            PointF p1, p2;
            if (type == 1)
            {
                for (int i = 0; i < patternLine.Count; i++)
                {
                    p1 = patternLine[i][0];
                    p2 = patternLine[i][1];

                    g.DrawLine(myPen, p1, p2);
                }
            }
            else if (type == 2)
            {
                for (int i = 0; i < patternLine.Count; i++)
                {
                    p1 = patternLine[i][0];
                    p2 = patternLine[i][1];

                    float radius = (float)MathCalculate.GetDistance(p1, p2);
                    g.DrawEllipse(myPen, p1.X - radius, p1.Y - radius, radius * 2, radius * 2);
                }
            }
            else if (type == 3)
            { }

            return image;
        }
    }
}
