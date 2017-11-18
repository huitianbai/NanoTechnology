using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MultiMode.Nanoman
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
                p1 = new PointF((float)((SavePath.handPath[i].X + PushByHand._xSize / 2) / PushByHand._xSize * PushByHand._sampsInLine),
                    (float)(PushByHand._numberOfLines - (SavePath.handPath[i].Y + PushByHand._ySize / 2) / PushByHand._ySize * PushByHand._numberOfLines));
                p2 = new PointF((float)((SavePath.handPath[i + 1].X + PushByHand._xSize / 2) / PushByHand._xSize * PushByHand._sampsInLine),
                    (float)(PushByHand._numberOfLines - (SavePath.handPath[i + 1].Y + PushByHand._ySize / 2) / PushByHand._ySize * PushByHand._numberOfLines));

                g.DrawLine(myPen, p1, p2);
            }

            return image;
        }
    }
}
