using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MultiMode.Nanomanipulation
{
    /// <summary>
    /// 数学计算类
    /// </summary>
    class MathCalculate
    {
        /// <summary>
        /// 计算两点之间的距离
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
        }
        public static double GetDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
        }
        public static double GetDistance(int x1, int y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
        }
        public static double GetDistance(PointF p1, PointF p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
        public static double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        /// <summary>
        /// 计算两直线交点
        /// </summary>
        /// <param name="line1"></param最小二乘拟合后的直线斜率和截距信息>
        /// <param name="line2"></param最小二乘拟合后的直线斜率和截距信息>
        /// <returns></returns>
        public static double[] GetIntersectionPoint(double[] line1, double[] line2)
        {
            double[] point = new double[2];
            if (line1[0] == 0 && line2[0] != 0)
            {
                point[0] = line1[1];
                point[2] = (line1[1] - line2[1]) / line2[2];
                return point;
            }
            else if (line2[0] == 0 && line1[0] != 0)
            {
                point[0] = line2[1];
                point[2] = (line2[1] - line1[1]) / line1[2];
                return point;
            }
            else if (line1[0] == 0 && line2[0] == 0)
            {
                return null;
            }
            else if (line1[2] == 0 && line2[2] == 0)
            {
                return null;
            }
            else 
            {
                point[0] = -(line2[1] - line1[1]) / (line2[2] - line1[2]);
                point[1] = (line1[1] * line2[2] - line2[1] * line1[2]) / (line2[2] - line1[2]);
                return point;
            }
            
        }

        /// <summary>
        /// 已知一条直线和直线外一点求直线外一点到直线的垂线与直线的交点
        /// </summary>
        /// <param name="line"></param最小二乘拟合后的直线斜率和截距信息>
        /// <param name="x"></param点的横坐标>
        /// <param name="y"></param点的纵坐标>
        /// <returns></returns>
        public static double[] GetIntersectionPoint(double[] line, double x, double y)
        {
            double[] point = new double[2];
            if (line[0] == 0)
            {
                point[0] = line[1];
                point[1] = y;
                return point;
            }
            else if (line[2] == 0)
            {
                point[0] = x;
                point[1] = line[1];
                return point;
            }
            else
            {
                double[] a = new double[3] { 1, x / line[2] + y, -1 / line[2] };
                point = GetIntersectionPoint(line, a);
                return point;
            }
        }

        /// <summary>
        /// 已知两点计算两点确定的直线
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static double[] GetKandB(PointF point1, PointF point2)
        {
            double[] kAndb = new double[3];
            if (point1.X - point2.X != 0)
            {
                kAndb[0] = 1;
                kAndb[2] = (double)(point1.Y - point2.Y) / (double)(point1.X - point2.X);
                kAndb[1] = (double)point1.Y - (double)point1.X * kAndb[2];
            }
            else
            {
                kAndb[0] = 0;
                kAndb[2] = 0;
                kAndb[1] = point1.X;
            }
            return kAndb;
        }

        /// <summary>
        /// 返回最大值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Max(int a, int b)
        {
            if (a >= b) return a;
            else return b;
        }

        public static float Max(float a, float b)
        {
            if (a >= b) return a;
            else return b;
        }

        /// <summary>
        /// 返回最小值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Min(int a, int b)
        {
            if (a >= b) return b;
            else return a;
        }
        public static double Min(double a, double b)
        {
            if (a >= b) return b;
            else return a;
        }

        /// <summary>
        /// 弯折样条调直计算
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        //对于有一段弯曲的情况
        public static double[] GetStraight(PointF p1, PointF p2, PointF p3, int index)
        {
            double k;
            double[] result = new double[4];
            if (GetDistance(p1.X, p1.Y, p2.X, p2.Y) >= GetDistance(p2.X, p2.Y, p3.X, p3.Y))
            {
                k = GetDistance(p2.X, p2.Y, p3.X, p3.Y) / GetDistance(p1.X, p1.Y, p2.X, p2.Y);
                result[0] = p1.X;
                result[1] = p1.Y;
                result[2] = GetOneStraightPoint(p1, p2, k)[0];
                result[3] = GetOneStraightPoint(p1, p2, k)[1];
                AutoDetect.allWires[index].bulkingStiffen.Add(new List<PointF>(3) { p3, p2, new PointF((float)result[2], (float)result[3]) });
            }
            else
            {
                k = GetDistance(p1.X, p1.Y, p2.X, p2.Y) / GetDistance(p2.X, p2.Y, p3.X, p3.Y);
                result[0] = GetOneStraightPoint(p3, p2, k)[0];
                result[1] = GetOneStraightPoint(p3, p2, k)[1];
                result[2] = p3.X;
                result[3] = p3.Y;
                AutoDetect.allWires[index].bulkingStiffen.Add(new List<PointF>(3) { p1, p2, new PointF((float)result[0], (float)result[1]) });
            }
            return result;
        }
        //对于有两段弯折的情况
        public static double[] GetStraight(PointF p1, PointF p2, PointF p3, PointF p4, int index)
        {
            double k;
            double[] mp;
            double[] result = new double[4];
            if (GetDistance(p1.X, p1.Y, p2.X, p2.Y) >= GetDistance(p3.X, p3.Y, p4.X, p4.Y))
            {
                k = GetDistance(p3.X, p3.Y, p4.X, p4.Y) / GetDistance(p2.X, p2.Y, p3.X, p3.Y);
                mp = GetOneStraightPoint(p2, p3, k);
                AutoDetect.allWires[index].bulkingStiffen.Add(new List<PointF>(3) { p4, p3, new PointF((float)mp[0], (float)mp[1]) });
                if (GetDistance(p1.X, p1.Y, p2.X, p2.Y) >= GetDistance(p2.X, p2.Y, mp[0], mp[1]))
                {
                    result[0] = p1.X;
                    result[1] = p1.Y;
                    k = GetDistance(p2.X, p2.Y, mp[0], mp[1]) / GetDistance(p1.X, p1.Y, p2.X, p2.Y);
                    result[2] = GetOneStraightPoint(p1, p2, k)[0];
                    result[3] = GetOneStraightPoint(p1, p2, k)[1];
                    AutoDetect.allWires[index].bulkingStiffen.Add(new List<PointF>(3) { new PointF((float)mp[0], (float)mp[1]), p2, new PointF((float)result[2], (float)result[3]) });
                }
                else 
                {
                    k = GetDistance(p1.X, p1.Y, p2.X, p2.Y) / GetDistance(p2.X, p2.Y, mp[0], mp[1]);
                    result[0] = GetOneStraightPoint(mp, p2, k)[0];
                    result[1] = GetOneStraightPoint(mp, p2, k)[1];
                    result[2] = mp[0];
                    result[3] = mp[1];
                    AutoDetect.allWires[index].bulkingStiffen.Add(new List<PointF>(3) { p1, p2, new PointF((float)result[0], (float)result[1]) });
                }
            }
            else
            {
                k = GetDistance(p1.X, p1.Y, p2.X, p2.Y) / GetDistance(p2.X, p2.Y, p3.X, p3.Y);
                mp = GetOneStraightPoint(p3, p2, k);
                AutoDetect.allWires[index].bulkingStiffen.Add(new List<PointF>(3) { p1, p2, new PointF((float)mp[0], (float)mp[1]) });
                if (GetDistance(p3.X, p3.Y, mp[0], mp[1]) >= GetDistance(p3.X, p3.Y, p4.X, p4.Y))
                {
                    k = GetDistance(p3.X, p3.Y, p4.X, p4.Y) / GetDistance(p3.X, p3.Y, mp[0], mp[1]);
                    result[0] = mp[0];
                    result[1] = mp[1];
                    result[2] = GetOneStraightPoint(mp, p3, k)[0];
                    result[3] = GetOneStraightPoint(mp, p3, k)[1];
                    AutoDetect.allWires[index].bulkingStiffen.Add(new List<PointF>(3) { p4, p3, new PointF((float)result[2], (float)result[3]) });
                }
                else
                {
                    k = GetDistance(p3.X, p3.Y, mp[0], mp[1]) / GetDistance(p3.X, p3.Y, p4.X, p4.Y);
                    result[0] = GetOneStraightPoint(p4, p3, k)[0];
                    result[1] = GetOneStraightPoint(p4, p3, k)[1];
                    result[2] = p4.X;
                    result[3] = p4.Y;
                    AutoDetect.allWires[index].bulkingStiffen.Add(new List<PointF>(3) { new PointF((float)mp[0], (float)mp[1]), p3, new PointF((float)result[0], (float)result[1]) });
                }
            }
            return result;
        }

        /// <summary>
        /// 有弯折的纳米线计算调直后 计算被调直点的坐标
        /// </summary>
        /// <param name="p1"></param> 不需要被调直的点 
        /// <param name="p2"></param> 调直的旋转中心
        /// <param name="k"></param> 被调直的线段长度与未被调直部分的比例
        /// <returns></returns>
        public static double[] GetOneStraightPoint(PointF p1, PointF p2, double k)
        {
            double[] result = new double[2];
            result[0] = k * (p2.X - p1.X) + p2.X;
            result[1] = k * (p2.Y - p1.Y) + p2.Y;
            return result;
        }
        public static double[] GetOneStraightPoint(double[] p1, PointF p2, double k)
        {
            double[] result = new double[2];
            result[0] = k * (p2.X - p1[0]) + p2.X;
            result[1] = k * (p2.Y - p1[1]) + p2.Y;
            return result;
        }
        public static double[] GetOneStraightPoint(PointF p1, double[] p2, double k)
        {
            double[] result = new double[2];
            result[0] = k * (p2[0] - p1.X) + p2[0];
            result[1] = k * (p2[1] - p1.Y) + p2[1];
            return result;
        }

        /// <summary>
        /// 获取用来动态显示的坐标， 用于选定纳米线目标位置的过程中
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="l"></param>
        /// <param name="p"></param>
        /// <param name="prop"></param>
        /// <returns></returns>
        public static PointF GetPointToShow(float x, float y, double l, PointF p, double prop)
        {
            PointF a = new PointF();
            double distance = GetDistance(x, y, p.X, p.Y);
            l = l * prop;
            double k = l / distance;
            a.X = (float)(k * (p.X - x)) + x;
            a.Y = (float)(k * (p.Y - y)) + y;
            return a;
        }

        /// <summary>
        /// 计算两个向量之间的夹角(弧度)
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static double GetAngle(PointF vector1, PointF vector2)
        {
            return Math.Acos((vector1.X * vector2.X + vector1.Y * vector2.Y) / 
                Math.Sqrt(Math.Pow(vector1.X, 2) + Math.Pow(vector1.Y, 2)) / Math.Sqrt(Math.Pow(vector2.X, 2) + Math.Pow(vector2.Y, 2))); 
        }
        public static double GetAngle(PointF p1, PointF m, PointF p2)
        {
            PointF vector1 = new PointF(p1.X - m.X, p1.Y - m.Y);
            PointF vector2 = new PointF(p2.X - m.X, p2.Y - m.Y);
            return Math.Acos((vector1.X * vector2.X + vector1.Y * vector2.Y) /
                Math.Sqrt(Math.Pow(vector1.X, 2) + Math.Pow(vector1.Y, 2)) / Math.Sqrt(Math.Pow(vector2.X, 2) + Math.Pow(vector2.Y, 2)));
        }

        /// <summary>
        /// 已知纳米线起点和终点及旋转中心的位置，计算旋转中心的坐标
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="prop"></param>
        /// <returns></returns>
        public static PointF GetRotationPoint(PointF p1, PointF p2 , float prop)
        {
            return new PointF(prop * p1.X + (1 - prop) * p2.X, prop * p1.Y + (1 - prop) * p2.Y);
        }

        /// <summary>
        /// 获得纳米线由初始位置旋转的两种情况
        /// </summary>
        /// <returns></returns>
        public static Nanowires.Wire[] GetTwoRotatedWires(double length, PointF p1, PointF p2 ,float prop)
        {
            Nanowires.Wire[] result;
            double[] k = GetKandB(p1, p2);
            if (k[0] == 0)
            {
                result = new Nanowires.Wire[2]{
                    new Nanowires.Wire(new PointF((float)(p1.X + length * (1 - prop)), p1.Y), new PointF((float)(p1.X - length * prop), p1.Y)),
                    new Nanowires.Wire(new PointF((float)(p1.X - length * (1 - prop)), p1.Y), new PointF((float)(p1.X + length * prop), p1.Y))
                };
            }
            else if (k[0] == 1 && k[2] == 0)
            {
                result = new Nanowires.Wire[2]{
                    new Nanowires.Wire(new PointF(p1.X, (float)(p1.Y + length * (1 - prop))), new PointF(p1.X, (float)(p1.Y - length * prop))),
                    new Nanowires.Wire(new PointF(p1.X, (float)(p1.Y - length * (1 - prop))), new PointF(p1.X, (float)(p1.Y + length * prop)))
                };
            }
            else
            {
                double k1 = -1 / k[2];
                double lx = length / Math.Sqrt(1 + k1 * k1), ly = length / Math.Sqrt(1 + k1 * k1) * k1;
                result = new Nanowires.Wire[2]{
                    new Nanowires.Wire(new PointF((float)(p1.X + (1 - prop) * lx), (float)(p1.Y + (1 - prop) * ly)), new PointF((float)(p1.X - prop * lx), (float)(p1.Y - prop * ly))),
                    new Nanowires.Wire(new PointF((float)(p1.X - (1 - prop) * lx), (float)(p1.Y - (1 - prop) * ly)), new PointF((float)(p1.X + prop * lx), (float)(p1.Y + prop * ly)))
                };
            }
            return result;
        }

        /// <summary>
        /// 获取正确的旋转后的纳米线 旋转方向有两个，选择旋转角度小于90度的策略
        /// </summary>
        /// <param name="wire"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Nanowires.Wire GetCorrectWire(Nanowires.Wire wire, Nanowires.Wire[] p)
        {
            if (MathCalculate.GetAngle(new PointF(p[0].firstPoint.X - p[0].secondPoint.X, p[0].firstPoint.Y - p[0].secondPoint.Y),
                new PointF(wire.firstPoint.X - wire.secondPoint.X, wire.firstPoint.Y - wire.secondPoint.Y)) > Math.PI / 2)
                return p[1];
            else
                return p[0];
        }

        /// <summary>
        /// 获取推移过后的纳米线位置
        /// </summary>
        /// <param name="wire"></param>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Nanowires.Wire GetWireAfterPush(Nanowires.Wire wire, PointF vector)
        {
            return new Nanowires.Wire(new PointF(wire.firstPoint.X + vector.X, wire.firstPoint.Y + vector.Y),
                new PointF(wire.secondPoint.X + vector.X, wire.secondPoint.Y + vector.Y));
        }

        public static double GetLineLength(PointF[] point)
        {
            double l = 0;
            for (int i = 0; i < point.GetLength(0) - 1; i++)
            {
                l += MathCalculate.GetDistance(point[i].X, point[i].Y, point[i + 1].X, point[i + 1].Y);
            }
            return l;
        }

        /// <summary>
        /// 计算矩形的面积
        /// </summary>
        /// <param name="w1"></param>
        /// <param name="w2"></param>
        /// <returns></returns>
        public static double GetRectangleArea(Nanowires.Wire w1, Nanowires.Wire w2)
        {
            return MathCalculate.GetDistance(w1.firstPoint, w1.secondPoint) * MathCalculate.GetDistance(w1.firstPoint, w2.firstPoint);
        }

        /// <summary>
        /// 计算三角形面积(海伦公式)
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <returns></returns>
        public static double GetTriangleArea(PointF p1, PointF p2, PointF p3)
        {
            double a = MathCalculate.GetDistance(p1, p2);
            double b = MathCalculate.GetDistance(p2, p3);
            double c = MathCalculate.GetDistance(p3, p1);
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        /// <summary>
        /// 计算纳米线旋转角度的方向 顺时针方向返回 -1  逆时针方向返回 1 满足右手螺旋定则
        /// </summary>
        /// <returns></returns>
        public static int GetAngleDirection(PointF p1, PointF m, PointF p2)
        {
            PointF vector1 = new PointF(p1.X - m.X, p1.Y - m.Y);
            PointF vector2 = new PointF(p2.X - m.X, p2.Y - m.Y);
            double a = vector1.X * vector2.Y - vector2.X * vector1.Y;
            if (a > 0)
                return 1;
            else
                return -1;
        }

        /// <summary>
        /// 计算有方向的角度，顺时针方向角度为负，逆时针方向角度为正，满足右手定则
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="m"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static double GetAngleWithDirection(PointF p1, PointF m, PointF p2)
        {
            PointF vector1 = new PointF(p1.X - m.X, p1.Y - m.Y);
            PointF vector2 = new PointF(p2.X - m.X, p2.Y - m.Y);
            double a = vector1.X * vector2.Y - vector2.X * vector1.Y;
            if (a > 0)
                return GetAngle(p1, m, p2);
            else
                return -GetAngle(p1, m, p2);
        }

        public static double GetAngleWithDirection(PointF m, PointF p2)
        {
            PointF p1 = new PointF(m.X + 1, m.Y);
            PointF vector1 = new PointF(p1.X - m.X, p1.Y - m.Y);
            PointF vector2 = new PointF(p2.X - m.X, p2.Y - m.Y);
            double a = vector1.X * vector2.Y - vector2.X * vector1.Y;
            if (a > 0)
                return GetAngle(p1, m, p2);
            else
                return -GetAngle(p1, m, p2);
        }

        /// <summary>
        /// 获得经过向量变换后点的坐标
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static PointF GetPointAfterVector(PointF p1, PointF vector)
        {
            return new PointF(p1.X + vector.X, p1.Y + vector.Y);
        }

    }
}
