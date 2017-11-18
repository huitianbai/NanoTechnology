using System.Windows.Forms;
using System.Drawing;

namespace MultiMode.Nanomanipulation
{
    class MatrixOperations
    {
        /// <summary>
        /// 二值矩阵取反
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int[,] Not(int[,] input)
        {
            int W, H;
            W = input.GetLength(0);
            H = input.GetLength(1);
            int[,] output=new int[W, H];
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    if (input[i, j] == 0)
                        output[i, j] = 255;
                    else
                        output[i, j] = 0;
                }
            }
            return output;
        }

        /// <summary>
        /// 矩阵相加
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns></returns>
        public static int[,] Add(int[,] input1, int[,] input2)
        {
            int W, H;
            if ((input1.GetLength(0) != input2.GetLength(0)) || (input1.GetLength(1) != input2.GetLength(1)))
            {
                MessageBox.Show("Dimensions are not equal !");
                return null;
            }
            else
            {
                W = input1.GetLength(0);
                H = input1.GetLength(1);
                int[,] output = new int[W, H];
                for (int i = 0; i < W; i++)
                {
                    for (int j = 0; j < H; j++)
                    {
                        output[i, j] = input1[i, j] + input2[i, j];
                    }
                }
                return output;
            }
        }

        /// <summary>
        /// 矩阵相减
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns></returns>
        public static int[,] Minus(int[,] input1, int[,] input2)
        {
            int W, H;
            if ((input1.GetLength(0) != input2.GetLength(0)) || (input1.GetLength(1) != input2.GetLength(1)))
            {
                MessageBox.Show("Dimensions are not equal !");
                return null;
            }
            else
            {
                W = input1.GetLength(0);
                H = input1.GetLength(1);
                int[,] output = new int[W, H];
                for (int i = 0; i < W; i++)
                {
                    for (int j = 0; j < H; j++)
                    {
                        output[i, j] = input1[i, j] - input2[i, j];
                    }
                }
                return output;
            }

        }

        /// <summary>
        /// 矩阵最后一行附加
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int[,] Appendix(int[,] a, int[] b)
        {
            if (a == null)
            {
                a = new int[1, b.GetLength(0)];
                for (int j = 0; j < b.GetLength(0); j++)
                {
                    a[0, j] = b[j];
                }
                return a;
            }
            else 
            {
                int[,] result = new int[a.GetLength(0) + 1, a.GetLength(1)];
                for (int i = 0; i < a.GetLength(0) + 1; i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        if (i == a.GetLength(0))
                        {
                            result[i, j] = b[j];
                        }
                        else
                            result[i, j] = a[i, j];
                    }
                }
                return result;
            }
        }

        public static int[] Appendix(int[] a, int b)
        {
            if (a == null)
            {
                a = new int[1] { b };
                return a;
            }
            else
            {
                int[] result = new int[a.GetLength(0) + 1];
                for (int i = 0; i < a.GetLength(0) + 1; i++)
                {
                    if (i == a.GetLength(0))
                    {
                        result[i] = b;
                    }
                    else
                        result[i] = a[i];      
                }
                return result;
            }
        }


        /// <summary>
        /// 矩阵最后一行附加 矩阵列数为2
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int[,] Appendix(int[,] a, int a1, int a2)
        {
            if (a == null)
            {
                a = new int[1, 2] { { a1, a2 } };
                //a[0, 0] = a1;
                //a[0, 1] = a2;
                return a;
            }
            else
            {
                int[,] result = new int[a.GetLength(0) + 1, a.GetLength(1)];
                for (int i = 0; i < a.GetLength(0) + 1; i++)
                {
                    if (i == a.GetLength(0))
                    {
                        result[i, 0] = a1;
                        result[i, 1] = a2;
                    }
                    else 
                    {
                        result[i, 0] = a[i, 0];
                        result[i, 1] = a[i, 1];
                    }
                }
                return result;
            }
        }

        public static PointF[] Appendix(PointF[] points, PointF newPoint)
        {
            if (points == null)
            {
                points = new PointF[1] { newPoint };
                return points;
            }
            else
            {
                PointF[] a = new PointF[points.GetLength(0) + 1];
                for (int i = 0; i < points.GetLength(0) + 1; i++)
                {
                    if (i == points.GetLength(0))
                        a[i] = newPoint;
                    else
                        a[i] = points[i];
                }
                return a;
            }
        }

        /// <summary>
        /// 矩阵最后一行附加
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double[,] Appendix(double[,] a, double[] b)
        {
            if (a == null)
            {
                a = new double[1, b.GetLength(0)];
                for (int j = 0; j < b.GetLength(0); j++)
                {
                    a[0, j] = b[j];
                }
                return a;
            }
            else
            {
                double[,] result = new double[a.GetLength(0) + 1, a.GetLength(1)];
                for (int i = 0; i < a.GetLength(0) + 1; i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        if (i == a.GetLength(0))
                        {
                            result[i, j] = b[j];
                        }
                        else
                            result[i, j] = a[i, j];
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// 索引转换为矩阵
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[,] IndexToMatrix(int[,] array)
        {
            int[,] greyImage = new int[array[0, 0], array[0, 1]];
            for (int i = 0; i < array[0, 0]; i++)
            {
                for (int j = 0; j < array[0, 1]; j++)
                {
                    greyImage[i, j] = 0;
                }
            }
            for (int i = 1; i < array.GetLength(0); i++)
            {
                greyImage[array[i, 0], array[i, 1]] = 255;
            }
            return greyImage;
        }

        /// <summary>
        /// 矩阵转换为索引
        /// </summary>
        /// <param name="greyImage"></param>
        /// <returns></returns>
        public static int[,] MatrixToIndex(int[,] greyImage)
        {
            int[,] index = null;
            int[] a = new int[2];
            a[0] = greyImage.GetLength(0);
            a[1] = greyImage.GetLength(1);
            index = Appendix(index, a);
            for (int i = 0; i < greyImage.GetLength(0); i++)
            {
                for (int j = 0; j < greyImage.GetLength(1); j++)
                {
                   if ( greyImage[i, j] == 255 )
                   {
                       a[0] = i; a[1] = j;
                       index = Appendix(index, a);
                   }
                }
            }

            return index;
        }

        /// <summary>
        /// 在矩阵中寻找索引
        /// </summary>
        /// <param name="arr"></param>列数为2的矩阵。arr[i,0]为横坐标，arr[i,1]为纵坐标
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool FindIndex(int[,] arr, int[] index)
        {
            if (arr != null)
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (arr[i, 0] == index[0] && arr[i, 1] == index[1])
                    {
                        return true;
                    }
                }
                return false;
            }
            else { return false; }
            
        }

        /// <summary>
        /// 矩阵行的切片运算
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>起始行（计算在内）
        /// <param name="end"></param>终止行（计算在内）
        /// <returns></returns>
        public static int[,] Slice(int[,] array, int start, int end)
        {
            int[,] result = new int[end - start + 1, 2];
            for (int i = 0; i < end - start + 1; i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    result[i, j] = array[i + start, j];
                }
            }
            return result;
        }
        public static int[] Slice(int[] array, int start, int end)
        {
            int[] result = new int[end - start + 1];
            for (int i = 0; i < end - start + 1; i++)
            {
                result[i] = array[i + start];
            }
            return result;
        }

        /// <summary>
        /// Point 数组去掉最后一个元素
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static PointF[] CutLast(PointF[] points)
        {
            if ( points == null )
            {
                return null;
            }
            else if (points.GetLength(0) <= 1)
            {
                return null;
            }
            else 
            {
                PointF[] a = new PointF[points.GetLength(0) - 1];
                for (int i = 0; i < points.GetLength(0) - 1; i++)
                    a[i] = points[i];
                return a;
            }            
        }

        /// <summary>
        /// int数组去掉最后一个元素
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int[] CutLast(int[] p)
        {
            if (p == null)
            {
                return null;
            }
            else if (p.GetLength(0) <= 1)
            {
                return null;
            }
            else
            {
                int[] a = new int[p.GetLength(0) - 1];
                for (int i = 0; i < p.GetLength(0) - 1; i++)
                    a[i] = p[i];
                return a;
            }
        }

        /// <summary>
        /// 计算数值在数组中出现的次数
        /// </summary>
        /// <param name="m"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetTimesValueAppear(int[] m, int value)
        {
            int count = 0;
            if (m == null)
                return 0;
            else
                for (int i = 0; i < m.GetLength(0); i++)
                    if (m[i] == value)
                        count += 1;
            return count;
        }

        /// <summary>
        /// wire类起点终点 转换为Point
        /// </summary>
        /// <param name="wire"></param>
        /// <param name="_numberOfLines"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static PointF[] GetPointFromArr(Nanowires wire, int _numberOfLines, int mode)
        {
            PointF[] p = null;
            if (mode == 1)
            {
                p = new PointF[2];
                p[0].X = wire.startWire.firstPoint.X;
                p[0].Y = _numberOfLines - 1 - wire.startWire.firstPoint.Y;
                p[1].X = wire.startWire.secondPoint.X;
                p[1].Y = _numberOfLines - 1 - wire.startWire.secondPoint.Y;
            }
            else if (mode == 2)
            {
                p = new PointF[wire.points.GetLength(0)];
                for (int i = 0; i < wire.points.GetLength(0); i++)
                {
                    p[i].X = wire.points[i].X;
                    p[i].Y = _numberOfLines - 1 - wire.points[i].Y;
                }
            }
            else if (mode == 3)
            {
                p = new PointF[2];
                p[0].X = wire.targetWire.firstPoint.X;
                p[0].Y = _numberOfLines - 1 - wire.targetWire.firstPoint.Y;
                p[1].X = wire.targetWire.secondPoint.X;
                p[1].Y = _numberOfLines - 1 - wire.targetWire.secondPoint.Y;
            }
            return p;
        }



    }
}
