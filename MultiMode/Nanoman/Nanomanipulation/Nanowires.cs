using System;
using System.Collections.Generic;
using System.Drawing;

namespace MultiMode.Nanomanipulation
{
    /// <summary>
    /// 纳米线信息存储类
    /// </summary>
    public class Nanowires
    {
        public double diameter, length, division;
        public PointF[] points;
        public int[,] skeleton;
        public string softOrStiff;
        public Wire startWire, targetWire, middleWire, presentWire;
        public List<Wire> progressWires;//移动过程中的全部经过的纳米线位置  
        public bool haveMiddleWire;
        public float rotatingPointPosition;//纳米线移动过程中旋转中心的位置 
        public float stiffPushPosition;//硬纳米线推移位置，用来计算旋转中心
        public List<List<PointF>> bulkingStiffen;//弯曲纳米线调直
        //rotatingPointPosition = 旋转中心与secondPoint的距离 / 纳米线长度

        /// <summary>
        /// wire类 保存线段起点和终点的double类型坐标
        /// </summary>
        public class Wire
        {
            public bool getValue;
            public  PointF firstPoint, secondPoint, rotatePoint;
            public Wire()
            {
                firstPoint = new PointF();
                secondPoint = new PointF();
                rotatePoint = new PointF();
                getValue = false;
            }
            public Wire(Wire a)
            {
                firstPoint = a.firstPoint;
                secondPoint = a.secondPoint;
                rotatePoint = a.rotatePoint;
                getValue = true;
            }
            public Wire(PointF first,PointF second)
            {
                firstPoint = first;
                secondPoint = second;
                rotatePoint = new PointF();
                getValue = true;
            }
            public Wire(PointF first, PointF second, PointF r)
            {
                firstPoint = first;
                secondPoint = second;
                rotatePoint = r;
                getValue = true;
            }
            public Wire(double x1, double y1, double x2, double y2)
            {
                firstPoint.X = (float)x1;
                firstPoint.Y = (float)y1;
                secondPoint.X = (float)x2;
                secondPoint.Y = (float)y2;
                rotatePoint = new PointF();
                getValue = true;
            }

            /// <summary>
            /// 坐标顺序交换
            /// </summary>
            public void exchange(bool a)
            {
                if (a)//考虑纳米线起点和终点的位置关系
                {
                    if (firstPoint.Y < secondPoint.Y)//y坐标大的在前
                    {
                        float x, y;
                        x = secondPoint.X;
                        y = secondPoint.Y;
                        secondPoint = new PointF(firstPoint.X, firstPoint.Y);
                        firstPoint = new PointF(x, y);
                    }
                    else if (firstPoint.Y == secondPoint.Y)
                    {
                        if (firstPoint.X < secondPoint.X)//如果y坐标相等，x坐标大的在前
                        {
                            float x, y;
                            x = secondPoint.X;
                            y = secondPoint.Y;
                            secondPoint = new PointF(firstPoint.X, firstPoint.Y);
                            firstPoint = new PointF(x, y);
                        }
                    }
                }
                else //直接交换
                {
                    float x, y;
                    x = secondPoint.X;
                    y = secondPoint.Y;
                    secondPoint = new PointF(firstPoint.X, firstPoint.Y);
                    firstPoint = new PointF(x, y);
                }
            }

        }

        public Nanowires(double[,] greyImage, PointF[] inPoints, int[,] inSkeleton, int sampsInLine, double scanSize)
        {
            points = inPoints;
            skeleton = inSkeleton;
            diameter = GetDiameter(greyImage, inSkeleton);
            length = MathCalculate.GetLineLength(inPoints) * scanSize * 1000 / sampsInLine;
            division = length / diameter;
            softOrStiff = SoftOrStiffJudge(inPoints, length, diameter);
            startWire = new Wire();
            targetWire = new Wire();
            progressWires = new List<Wire>(0);
            bulkingStiffen = new List<List<PointF>>(0);

            SetRotatingPointPosition();

            haveMiddleWire = false;
        }

        public Nanowires(double[,] greyImage, PointF[] inPoints, int sampsInLine, double scanSize)
        {
            int[,] image = new int[greyImage.GetLength(0), greyImage.GetLength(1)];
            points = inPoints;
            skeleton = GetSkeleton(inPoints, greyImage.GetLength(0), greyImage.GetLength(1));
            diameter = GetDiameter(greyImage, skeleton);
            length = MathCalculate.GetLineLength(inPoints) * scanSize * 1000 / sampsInLine;
            division = length / diameter;
            softOrStiff = SoftOrStiffJudge(inPoints, length, diameter);
            startWire = new Wire();
            targetWire = new Wire();
            progressWires = new List<Wire>(0);
            bulkingStiffen = new List<List<PointF>>(0);

            SetRotatingPointPosition();

            haveMiddleWire = false;
        }

        /// <summary>
        /// 计算长径比
        /// </summary>
        public void GetDivision()
        {
            division = length / diameter;
        }

        /// <summary>
        /// 设置目标线段位置
        /// </summary>
        /// <param name="targetPoint1"></param>
        /// <param name="targetPoint2"></param>
        public void SetTarget(PointF targetPoint1,PointF targetPoint2)
        {
            targetWire = new Wire(targetPoint1, targetPoint2);
            SetProgressWires();
        }
        public void ClearTarget()
        {
            targetWire = new Wire();
            progressWires = new List<Wire>(4);
        }

        /// <summary>
        /// 设置起始线段位置
        /// </summary>
        /// <param name="startPoint1"></param>
        /// <param name="startPoint2"></param>
        public void SetStart()
        {
            startWire = new Wire(points[0], points[1]);
        }
        public void SetStart(double [] result)
        {
            startWire = new Wire(result[0], result[1], result[2], result[3]);
        }

        /// <summary>
        /// 设置纳米线当前位置
        /// </summary>
        public void SetPresent()
        {
            presentWire = startWire;
        }
        public void SetPresent(Wire w)
        {
            presentWire = w;
        }

        /// <summary>
        /// 计算中间全部过程纳米线的位置
        /// </summary>
        public void SetProgressWires()
        {
            startWire.exchange(true);
            PointF p1 = MathCalculate.GetRotationPoint(startWire.firstPoint, startWire.secondPoint, rotatingPointPosition);
            PointF p2 = MathCalculate.GetRotationPoint(targetWire.firstPoint, targetWire.secondPoint, rotatingPointPosition);
            Wire[] m = MathCalculate.GetTwoRotatedWires(MathCalculate.GetLineLength(points), p1, p2, rotatingPointPosition);
            Wire w1 = MathCalculate.GetCorrectWire(startWire, m);
            if (MathCalculate.GetAngle(new PointF(w1.firstPoint.X - w1.secondPoint.X, w1.firstPoint.Y - w1.secondPoint.Y), 
                new PointF(targetWire.firstPoint.X - targetWire.secondPoint.X, targetWire.firstPoint.Y - targetWire.secondPoint.Y)) > Math.PI / 2)
            {
                targetWire.exchange(false);
                p2 = MathCalculate.GetRotationPoint(targetWire.firstPoint, targetWire.secondPoint, rotatingPointPosition);
                m = MathCalculate.GetTwoRotatedWires(MathCalculate.GetLineLength(points), p1, p2, rotatingPointPosition);
                w1 = MathCalculate.GetCorrectWire(startWire, m);
            }
            startWire.rotatePoint = p1;
            targetWire.rotatePoint = p2;
            w1.rotatePoint = p1;
            progressWires = new List<Wire>(4) { 
                new Wire(startWire.firstPoint, startWire.secondPoint ,p1), 
                w1, 
                MathCalculate.GetWireAfterPush(w1, new PointF(p2.X - p1.X, p2.Y - p1.Y)), 
                new Wire(targetWire.firstPoint, targetWire.secondPoint ,p2) };
            progressWires[2].rotatePoint = p2;
        }

        public List<Wire> GetProgressWires(Wire mWire)
        {
            List<Wire> pWires;
            PointF p1 = mWire.rotatePoint;
            PointF p2 = MathCalculate.GetRotationPoint(targetWire.firstPoint, targetWire.secondPoint, rotatingPointPosition);
            Wire[] m = MathCalculate.GetTwoRotatedWires(MathCalculate.GetLineLength(points), p1, p2, rotatingPointPosition);
            Wire w1 = MathCalculate.GetCorrectWire(mWire, m);
            if (MathCalculate.GetAngle(new PointF(w1.firstPoint.X - w1.secondPoint.X, w1.firstPoint.Y - w1.secondPoint.Y),
                new PointF(targetWire.firstPoint.X - targetWire.secondPoint.X, targetWire.firstPoint.Y - targetWire.secondPoint.Y)) > Math.PI / 2)
            {
                targetWire.exchange(false);
                p2 = MathCalculate.GetRotationPoint(targetWire.firstPoint, targetWire.secondPoint, rotatingPointPosition);
                m = MathCalculate.GetTwoRotatedWires(MathCalculate.GetLineLength(points), p1, p2, rotatingPointPosition);
                w1 = MathCalculate.GetCorrectWire(mWire, m);
            }
            targetWire.rotatePoint = p2;
            w1.rotatePoint = p1;
            pWires = new List<Wire>(4) { 
                new Wire(mWire), 
                w1, 
                MathCalculate.GetWireAfterPush(w1, new PointF(p2.X - p1.X, p2.Y - p1.Y)), 
                new Wire(targetWire.firstPoint, targetWire.secondPoint ,p2) };
            pWires[2].rotatePoint = p2;
            return pWires;
        }

        public void SetMiddleWire(PointF p)
        {
            Wire[] m = MathCalculate.GetTwoRotatedWires(MathCalculate.GetLineLength(points), startWire.rotatePoint, p, rotatingPointPosition);
            Wire w1 = MathCalculate.GetCorrectWire(startWire, m);
            middleWire = MathCalculate.GetWireAfterPush(w1, new PointF(p.X - startWire.rotatePoint.X, p.Y - startWire.rotatePoint.Y));
            middleWire.rotatePoint = p;
            haveMiddleWire = true;

        }

        public Wire GetMiddleWire(PointF p)
        {
            Wire[] m = MathCalculate.GetTwoRotatedWires(MathCalculate.GetLineLength(points), startWire.rotatePoint, p, rotatingPointPosition);
            Wire w1 = MathCalculate.GetCorrectWire(startWire, m);
            Wire mWire = MathCalculate.GetWireAfterPush(w1, new PointF(p.X - startWire.rotatePoint.X, p.Y - startWire.rotatePoint.Y));
            mWire.rotatePoint = p;
            return mWire;
        }


        public void SetMiddleWire(Wire w)
        {
            middleWire = w;
            progressWires = GetProgressWires(w);
            haveMiddleWire = true;

        }

        public void SetMiddleWire()
        {
            middleWire = new Wire();
            haveMiddleWire = false;
            SetProgressWires();
        }

        /// <summary>
        /// 手动选取样条的骨架提取
        /// </summary>
        /// <param name="inPoints"></param>
        /// <param name="W"></param>
        /// <param name="H"></param>
        /// <returns></returns>
        private int[,] GetSkeleton(PointF[] inPoints, int W, int H)
        {
            int[,] image = new int[W, H];
            MorphologyTransform mor = new MorphologyTransform();

            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    image[i, j] = 0;
                    for (int m = 0; m < inPoints.GetLength(0) - 1; m++)
                    {
                        if (NearLine(i, j, inPoints[m], inPoints[m + 1]))//判断是否离线段足够近
                        {
                            image[i, j] = 255;
                            break;
                        }
                    } 
                }
            }
            return MatrixOperations.MatrixToIndex(image);
        }

        /// <summary>
        /// 判断像素点[x,y]是否离线段足够近，point1 为线段一端点，point2 为另一端点
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        private bool NearLine(int x, int y, PointF point1, PointF point2)
        {
            double[] kAndb;
            double[] intersectionPoint;
            kAndb = MathCalculate.GetKandB(point1, point2);//计算线段所在直线的斜率和截距
            intersectionPoint = MathCalculate.GetIntersectionPoint(kAndb, (double)x, (double)y);//计算垂足
            if (intersectionPoint[0] >= MathCalculate.Min(point1.X, point2.X) && intersectionPoint[0] <= MathCalculate.Max(point1.X, point2.X) &&
                intersectionPoint[1] >= MathCalculate.Min(point1.Y, point2.Y) && intersectionPoint[1] <= MathCalculate.Max(point1.Y, point2.Y))//如果垂足在线段内部
            {
                if (MathCalculate.GetDistance(x, y, intersectionPoint[0], intersectionPoint[1]) < 1)//到线段距离小于1 表示为骨架点，其他情况均不是
                    return true;
                else
                    return false;
            }
            else return false;
        }


        /// <summary>
        /// 从原始图像数据提取样条直径
        /// </summary>
        /// <param name="greyImage"></param>原始图像矩阵
        /// <param name="index"></param>骨架索引
        /// <returns></returns>
        private double GetDiameter(double[,] greyImage, int[,] index)
        {
            double diameter = 0;
            for (int i = 1; i < index.GetLength(0); i++)
            {
                diameter += greyImage[index[i, 0], index[i, 1]];
            }
            diameter /= index.GetLength(0) - 1;//求平均
            return Math.Abs(diameter);
        }

        /// <summary>
        /// 判断样条为软样条或硬样条
        /// </summary>
        /// <param name="point"></param>
        /// <param name="length"></param>
        /// <param name="diameter"></param>
        /// <returns></returns>
        public string SoftOrStiffJudge(PointF[] point, double length, double diameter)
        {
            if (point.GetLength(0) > 2)
                return "soft";
            else
            {
                if (length / diameter > AutoDetect.softOrStiff)//长径比大于阈值判断为软样条，否则为硬样条
                    return "soft";
                else
                    return "stiff";
            }
        }

        /// <summary>
        /// 获取纳米线旋转的中心
        /// </summary>
        /// <param name="k"></param>
        public void SetRotatingPointPosition()
        {     
            if (string.Equals(softOrStiff, "soft"))
                rotatingPointPosition = 0.5f;//默认旋转中心为纳米线中点
            else
            {
                stiffPushPosition = 0.95f;
                rotatingPointPosition = (float)Math.Abs(stiffPushPosition - Math.Sqrt(stiffPushPosition * stiffPushPosition - stiffPushPosition + 0.5));
            }
        }
        public void SetRotatingPointPosition(double s)
        {
            if (string.Equals(softOrStiff, "soft"))
                rotatingPointPosition = (float)s;//默认旋转中心为纳米线中点
            else
            {
                stiffPushPosition = (float)s;
                rotatingPointPosition = (float)Math.Abs(stiffPushPosition - Math.Sqrt(stiffPushPosition * stiffPushPosition - stiffPushPosition + 0.5));
            }
        }

    }
}
