using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MultiMode.Nanomanipulation
{
    /// <summary>
    /// 图像显示类
    /// </summary>
    class DisplayImage
    {
        /// <summary>
        /// double类型原始灰度图像显示
        /// </summary>
        /// <param name="greyImage"></param>
        /// <param name="addValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public Bitmap Imshow(double[,] greyImage,double addValue,double maxValue)
        {
            int i, j;
            int W, H;

            W = greyImage.GetLength(0);
            H = greyImage.GetLength(1);
                        
            Bitmap image = new Bitmap(W, H);
            BitmapData bitmapData1 = image.LockBits(new Rectangle(0, 0, W, H),
                                     ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            unsafe
            {

                byte* imagePointer1 = (byte*)bitmapData1.Scan0;
                int a;
                for (i = 0; i < bitmapData1.Height; i++)
                {
                    for (j = 0; j < bitmapData1.Width; j++)
                    {
                        // write the logic implementation here
                        a = (int)((greyImage[j, bitmapData1.Height - 1 - i] - addValue) * 255 / (maxValue - addValue));
                        imagePointer1[0] = (byte)a;
                        imagePointer1[1] = (byte)a;
                        imagePointer1[2] = (byte)a;
                        imagePointer1[3] = (byte)255;
                        //4 bytes per pixel
                        imagePointer1 += 4;
                    }   //end for j
                    //4 bytes per pixel
                    imagePointer1 += (bitmapData1.Stride - (bitmapData1.Width * 4));
                }//End for i
            }//end unsafe
            image.UnlockBits(bitmapData1);
            return image;// col;
        }      // Display Grey Image

        /// <summary>
        /// int类型灰度图像显示
        /// </summary>
        /// <param name="GreyImage"></param>
        /// <returns></returns>
        public Bitmap Imshow(int[,] GreyImage)
        {
            int i, j;
            int W, H;

            W = GreyImage.GetLength(0);
            H = GreyImage.GetLength(1);

            Bitmap image = new Bitmap(W, H);
            BitmapData bitmapData1 = image.LockBits(new Rectangle(0, 0, W, H),
                                     ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            unsafe
            {

                byte* imagePointer1 = (byte*)bitmapData1.Scan0;

                for (i = 0; i < bitmapData1.Height; i++)
                {
                    for (j = 0; j < bitmapData1.Width; j++)
                    {
                        // write the logic implementation here
                        imagePointer1[0] = (byte)GreyImage[j, bitmapData1.Height - 1 - i];
                        imagePointer1[1] = (byte)GreyImage[j, bitmapData1.Height - 1 - i];
                        imagePointer1[2] = (byte)GreyImage[j, bitmapData1.Height - 1 - i];
                        imagePointer1[3] = (byte)255;
                        //4 bytes per pixel
                        imagePointer1 += 4;
                    }   //end for j
                    //4 bytes per pixel
                    imagePointer1 += (bitmapData1.Stride - (bitmapData1.Width * 4));
                }//End for i
            }//end unsafe
            image.UnlockBits(bitmapData1);
            return image;// col;
        }      // Display Grey Image

        /// <summary>
        /// 原始double类型图像数据转换为int类型数据
        /// 因为原始double数据为图像高度，存在负值，int 类型图像数据为0-255灰度值
        /// </summary>
        /// <param name="greyImage"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public int[,] GetMatric(double[,] greyImage, double minValue, double maxValue)
        {
            int W, H;
            W = greyImage.GetLength(0);
            H = greyImage.GetLength(1);
            int[,] output = new int[W, H];
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    output[i, j] = (int)((greyImage[i, j] - minValue) * 255 / (maxValue - minValue));//保证最高点像素值为255，最低点为0
                }
            }
            return output;
        }

        /// <summary>
        /// 图像缩放
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="newW"></param>
        /// <param name="newH"></param>
        /// <returns></returns>
        public Bitmap ResizeImage(Bitmap bmp, int newW, int newH)
        {
            try
            {
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 图像显示识别结果
        /// </summary>
        /// <param name="allWires"></param>
        /// <param name="greyImage"></param>
        /// <param name="pictureType"></param>
        /// <param name="_numberOfLines"></param>
        /// <param name="newPoints"></param>
        /// <returns></returns>
        public Bitmap ShowSamples(List<Nanowires> allWires, Bitmap greyImage, string pictureType, int _numberOfLines, PointF[] newPoints)
        {
            Bitmap colorImage;
            GreyToColor gToC = new GreyToColor();
            colorImage = gToC.PGrayToColor(greyImage, pictureType);//恢复colorImage为初始伪彩色图像
            Graphics g = Graphics.FromImage(colorImage);//在Bmp上创建一张画布
            Pen myPen = new Pen(Color.Red, 3);//3像素宽度红色画笔

            foreach (Nanowires wire in allWires)
            {
                PointF[] p = new PointF[wire.points.GetLength(0)];
                p = MatrixOperations.GetPointFromArr(wire, _numberOfLines, 2);
                g.DrawLines(myPen, p);//用红色线段按顺序连接每个点（曲线）
                g.DrawString('S' + (allWires.IndexOf(wire) + 1).ToString(), new Font("宋体", 8), new SolidBrush(Color.Yellow), p[0].X, p[0].Y);
            }
            if (newPoints != null)
            {
                for (int i = 0; i < newPoints.GetLength(0); i++)
                    newPoints[i].Y = _numberOfLines - 1 - newPoints[i].Y;
                if (newPoints.GetLength(0) == 1)
                {
                    g.FillRectangle(new SolidBrush(Color.Red), newPoints[0].X, newPoints[0].Y, 3, 3);
                }
                else
                {
                    g.DrawLines(myPen, newPoints);//用红色线段按顺序连接每个点（曲线）
                    g.DrawString('S' + (allWires.Count + 1).ToString(), new Font("宋体", 8), new SolidBrush(Color.Yellow), newPoints[0].X, newPoints[0].Y);
                }
                for (int i = 0; i < newPoints.GetLength(0); i++)
                    newPoints[i].Y = _numberOfLines - 1 - newPoints[i].Y;
            }
            return colorImage;
        }

        public Bitmap ShowSamples(List<Nanowires> allWires, Bitmap greyImage, string pictureType, int _numberOfLines)
        {
            Bitmap colorImage;
            GreyToColor gToC = new GreyToColor();
            colorImage = gToC.PGrayToColor(greyImage, pictureType);//恢复colorImage为初始伪彩色图像
            Graphics g = Graphics.FromImage(colorImage);//在Bmp上创建一张画布
            Pen myPen = new Pen(Color.Red, 3);//3像素宽度红色画笔

            foreach (Nanowires wire in allWires)
            {
                PointF[] p = new PointF[wire.points.GetLength(0)];
                p = MatrixOperations.GetPointFromArr(wire, _numberOfLines, 2);
                g.DrawLines(myPen, p);//用红色线段按顺序连接每个点（曲线）
                g.DrawString('S' + (allWires.IndexOf(wire) + 1).ToString(), new Font("宋体", 8), new SolidBrush(Color.Yellow), p[0].X, p[0].Y);
            }

            return colorImage;
        }

        public Bitmap ShowSamples(List<Nanowires> allWires, Bitmap greyImage, int _numberOfLines)
        {
            Bitmap colorImage;
            GreyToColor gToC = new GreyToColor();
            colorImage = gToC.PGrayToColor(greyImage, AutoDetect.pictureType);//恢复colorImage为初始伪彩色图像
            Graphics g = Graphics.FromImage(colorImage);//在Bmp上创建一张画布
            Pen myPen;//3像素宽度红色画笔
            foreach (Nanowires wire in allWires)
            {
                PointF[] p = new PointF[2];
                myPen = new Pen(Color.Red, 3);
                p = MatrixOperations.GetPointFromArr(wire, _numberOfLines, 1);
                g.DrawLines(myPen, p);//用红色线段按顺序连接每个点（曲线）
                g.DrawString('S' + (allWires.IndexOf(wire) + 1).ToString(), new Font("宋体", 8), new SolidBrush(Color.Yellow), p[0].X, p[0].Y);
                if (wire.targetWire.getValue)
                {
                    myPen = new Pen(Color.White, 3);
                    p = MatrixOperations.GetPointFromArr(wire, _numberOfLines, 3);
                    g.DrawLines(myPen, p);
                    g.DrawString('T' + (allWires.IndexOf(wire) + 1).ToString(), new Font("宋体", 8), new SolidBrush(Color.Green), p[0].X, p[0].Y);
                }
                
            }
            return colorImage;
        }


    }
}