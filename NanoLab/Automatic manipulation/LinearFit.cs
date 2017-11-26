using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NanoExperiment.Automanipulation
{
    class LinearFit
    {
        int[] startPoint=new int[2];//骨架起点
        int[] endPoint=new int[2];//骨架终点

        //主要拟合程序
        public List<PointF[]> MainDetect(List<int[,]> skeleton)
        {
            List<PointF[]> finalSkeleton = new List<PointF[]>();
            double[,] interceptAndSlope = null;
            foreach (int[,] a in skeleton)
            {
                interceptAndSlope = SegmentJudge(a);
                finalSkeleton = ListAdd(finalSkeleton,getAllPoints(interceptAndSlope));
            }
            //剔除弯折次数大于2的样条
            if (finalSkeleton != null)
            {
                for (int i = finalSkeleton.Count - 1; i >= 0; i--)
                {
                    if (finalSkeleton[i].GetLength(0) > 3)
                    {
                        AutoDetect.Barriers = ListAdd(AutoDetect.Barriers, skeleton[i]);
                        finalSkeleton.RemoveAt(i);
                        skeleton.RemoveAt(i);
                    }
                }
            }
            return finalSkeleton;
        }

        /// <summary>
        /// 已知单一样条全部分段拟合的斜率和截距，计算相邻交点为最终骨架点
        /// interceptAndSlope：各段斜率和截距信息.
        /// interceptAndSlope[0]:为1拟合过程为y=k*x+b;为0拟合过程为x=k*y+b。这样是为了防止斜率为无穷的情况
        /// interceptAndSlope[1]: b截距
        /// interceptAndSlope[2]: k斜率
        /// Point 为计算得到的各个交点
        /// </summary>
        /// <param name="interceptAndSlope"></param>
        /// <returns></returns>
        private PointF[] getAllPoints(double[,] interceptAndSlope)
        {
            double[] message1=new double[3], message2 = new double[3];
            int num = interceptAndSlope.GetLength(0), j = 0;
            PointF[] points = new PointF[num + 1];
            double[] p = new double[2];

            for (int i = 0; i <= interceptAndSlope.GetLength(0); i++)
            {
                //第一个点的计算是直线和直线外一点做直线的垂线的交点
                //像素起点与第一段拟合直线计算交点
                if (i == 0)
                {
                    message1[0] = interceptAndSlope[i, 0];
                    message1[1] = interceptAndSlope[i, 1];
                    message1[2] = interceptAndSlope[i, 2];
                    p = MathCalculate.GetIntersectionPoint(message1, (double)startPoint[0], (double)startPoint[1]);
                    points[j].X = (float)p[0];
                    points[j].Y = (float)p[1];
                    j += 1;
                }
                //最后一个点的计算是像素终点和最后一段拟合直线计算交点，与第一个点类似
                else if (i == interceptAndSlope.GetLength(0))
                {
                    message1[0] = interceptAndSlope[i - 1, 0];
                    message1[1] = interceptAndSlope[i - 1, 1];
                    message1[2] = interceptAndSlope[i - 1, 2];
                    p = MathCalculate.GetIntersectionPoint(message1, (double)endPoint[0], (double)endPoint[1]);
                    points[j].X = (float)p[0];
                    points[j].Y = (float)p[1];
                    j += 1;
                }
                //中间的点是两条直线计算的交点
                else 
                {
                    message1[0] = interceptAndSlope[i - 1, 0];
                    message1[1] = interceptAndSlope[i - 1, 1];
                    message1[2] = interceptAndSlope[i - 1, 2];
                    message2[0] = interceptAndSlope[i, 0];
                    message2[1] = interceptAndSlope[i, 1];
                    message2[2] = interceptAndSlope[i, 2];
                    p = MathCalculate.GetIntersectionPoint(message1, message2);
                    points[j].X = (float)p[0];
                    points[j].Y = (float)p[1];
                    j += 1;
                }
            }
                return points;
        }

        /// <summary>
        /// 最小二乘法拟合直线
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        private double[] LeastSquareFit(int[,] coordinate)
        {
            int n;
            double k, b, sumX2 = 0, sumX = 0, sumY2 = 0, sumY = 0, sumXY = 0, m;
            double[] interceptAndSlope = new double[3];
            n = coordinate.GetLength(0);
            for (int i = 0; i < coordinate.GetLength(0); i++)
            {
                sumX2 += coordinate[i, 0] * coordinate[i, 0];
                sumX += coordinate[i, 0];
                sumY += coordinate[i, 1];
                sumXY += coordinate[i, 0] * coordinate[i, 1];
            }
            m = (n * sumX2 - sumX * sumX);
            if (m != 0)
            {
                interceptAndSlope[0] = 1;
                b = (sumX2 * sumY - sumX * sumXY) / m;
                k = (n * sumXY - sumX * sumY) / m;
            }//m==0,以y=k*x+b的方式拟合出现斜率为0的情况，改变方式为x=k*y+b
            else 
            {
                for (int i = 0; i < coordinate.GetLength(0); i++)
                {
                    sumY2 += coordinate[i, 1] * coordinate[i, 1];
                }
                interceptAndSlope[0] = 0;
                m = (n * sumY2 - sumY * sumY);
                b = (sumY2 * sumX - sumY * sumXY) / m;
                k = (n * sumXY - sumY * sumX) / m;
            }
            interceptAndSlope[1] = b; interceptAndSlope[2] = k;
            return interceptAndSlope;
        }

        /// <summary>
        /// 分段拟合
        /// </summary>
        /// <param name="skeleton"></param>
        /// <returns></returns>
        private double[,] SegmentJudge(int[,] skeleton)
        {
            double geometryDistance, pixelDistance;
            double[,] interceptAndSlope = null;
            double[] lineMessage;
            bool goNext = false;
            int[,] partSkeleton;

            skeleton = RearrangeSkeleton(MatrixOperations.IndexToMatrix(skeleton));//按照骨架顺序重排骨架
            startPoint[0] = skeleton[0, 0]; startPoint[1] = skeleton[0, 1];//起点坐标
            endPoint[0] = skeleton[skeleton.GetLength(0) - 1, 0]; endPoint[1] = skeleton[skeleton.GetLength(0) - 1, 1];//终点坐标

            do
            {
                goNext = false;//下一次循环终止
                pixelDistance = PixelDistanceCal(skeleton);//计算像素距离
                geometryDistance = MathCalculate.GetDistance(skeleton[0, 0], skeleton[0, 1],
                    skeleton[skeleton.GetLength(0) - 1, 0], skeleton[skeleton.GetLength(0) - 1, 1]);//计算几何距离
                if (pixelDistance < geometryDistance * 1.1)//如果像素距离小于几何距离的1.1倍，则认为由全部像素组成的样条可以拟合为一条直线
                {
                    lineMessage = LeastSquareFit(skeleton);//最小二乘拟合
                    interceptAndSlope = MatrixOperations.Appendix(interceptAndSlope, lineMessage);//记录新的斜率
                }
                else 
                {
                    //若不能认为全部像素组成的样条可以拟合为一条直线，依次从终点像素减少像素重新计算
                    for (int i = 0; i < skeleton.GetLength(0) - 2; i++)
                    {
                        partSkeleton = MatrixOperations.Slice(skeleton, 0, skeleton.GetLength(0) - 2 - i);//提取部分骨架
                        pixelDistance = PixelDistanceCal(partSkeleton);
                        geometryDistance = MathCalculate.GetDistance(partSkeleton[0, 0], partSkeleton[0, 1],
                            partSkeleton[partSkeleton.GetLength(0) - 1, 0], partSkeleton[partSkeleton.GetLength(0) - 1, 1]);

                        if (pixelDistance < geometryDistance * 1.1)//找到像素满足条件，对剩余像素拟合
                        {
                            goNext = true;
                            lineMessage = LeastSquareFit(partSkeleton);
                            interceptAndSlope = MatrixOperations.Appendix(interceptAndSlope, lineMessage);
                            skeleton = MatrixOperations.Slice(skeleton, skeleton.GetLength(0) - 2 - i, skeleton.GetLength(0) - 1);
                            //刷新未被拟合的骨架为新骨架，继续重复运算直到全部像素拟合完毕
                            break;
                        }
                    }
                }
               
            } while (goNext);

            return interceptAndSlope;
        }


        /// <summary>
        /// 重新排列骨架的顺序，使骨架按照走势排列。
        /// 相邻骨架的像素坐标需要满足：x坐标或y坐标相差为1
        /// </summary>
        /// <param name="greyImage"></param>
        /// <returns></returns>
        private int[,] RearrangeSkeleton(int[,] greyImage)
        {
            int[,] skeleton = null;
            int count = 0;
            int[] end = new int[2];
            bool goNext = false;

            for (int i = 1; i < greyImage.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < greyImage.GetLength(1) - 1; j++)
                {
                    if (greyImage[i, j] == 255)
                    {
                        count = 0;
                        for (int m = 0; m < 3; m++)
                        {
                            for (int n = 0; n < 3; n++)
                            {
                                if (greyImage[i + m - 1, j + n - 1] == 255)
                                {
                                    count += 1;
                                }
                            }
                        }
                        if (count == 2)
                        {
                            end[0] = i; end[1] = j;
                            skeleton = MatrixOperations.Appendix(skeleton, end);
                            goNext = true;
                            break;
                        } 
                    }
                }
                if (goNext) break;
            }

            while (goNext)
            {
                goNext = false;
                greyImage[end[0], end[1]] = 0;
                for (int m = 0; m < 3; m++)
                {
                    for (int n = 0; n < 3; n++)
                    {
                        if (greyImage[end[0] + m - 1, end[1] + n - 1] == 255)
                        {
                            end[0] += m - 1;
                            end[1] += n - 1;
                            skeleton = MatrixOperations.Appendix(skeleton, end);
                            goNext = true;
                            break;
                        }
                    }
                    if (goNext) break;
                }
            }
            return skeleton;
        }

        /// <summary>
        /// 像素距离的计算
        /// 像素距离：从头至尾，相邻像素中心连线的距离总和
        /// </summary>
        /// <param name="skeleton"></param>
        /// <returns></returns>
        private double PixelDistanceCal(int[,] skeleton)
        {
            double distance = 0;
            for (int i = 0; i < skeleton.GetLength(0) - 1;i++)
            {
                //若相邻像素有横或纵坐标相邻，则距离加1
                if (skeleton[i, 0] == skeleton[i + 1, 0] || skeleton[i, 1] == skeleton[i + 1, 1]) distance += 1;
                // 否则加根号2，即对角线距离
                else distance += Math.Sqrt(2);
            }
            return distance;
        }

        /// <summary>
        /// 返回增加的点之后的list
        /// </summary>
        /// <param name="input"></param>
        /// <param name="newItem"></param>
        /// <returns></returns>
        private List<PointF[]> ListAdd(List<PointF[]> input, PointF[] newItem)
        {
            input.Add(newItem);
            return input;
        }

        private List<int[,]> ListAdd(List<int[,]> input, int[,] newItem)
        {
            if (input.Count == 0)
            {
                input = new List<int[,]> { newItem };
            }
            else
                input.Add(newItem);
            return input;
        }

    }
}
