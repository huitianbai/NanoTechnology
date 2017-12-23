using System;
using System.Collections.Generic;
using System.Drawing;

namespace NanoExperiment.Automanipulation
{
    public class OrderPlanning
    {
        public int[] reachPosition;//纳米线移动情况，-1表示没移动，0 表示移动到中间位置， 1 表示移动到目标位置
        private PointF[,] middlePointsArr;//所有被选中作为桩的点
        public bool findResult;//是否找到结果的标志
        public int[] order;//最终结果

        /// <summary>
        /// allPossibleResults 例：
        /// [] [1] [1 3] [1 3 4] [1 3 4 2]
        ///    [2] [2 1] [2 1 3]
        ///        [2 3]
        /// </summary>
        List<List<int[]>> allPossibleResults = new List<List<int[]>>(0);//记录全部可能的中间过程

        /// <summary>
        /// noMovedMatrix表示全部纳米线都没有移动的时候矩阵情况
        /// allMovedMatrix表示全部纳米线在目标位置的情况
        /// </summary>
        int[,] noMovedMatrix, allMovedMatrix;

        //参与移动的纳米线的数量
        int numberOfNanowires;

        // 中间结果
        MiddlePosition middleResult;

        //保存路径信息
        public List<PathMessage> pushOrderForPath;

        /// <summary>
        /// 初始条件下所有纳米线都没有移动
        /// </summary>
        /// <param name="length"></param>
        public OrderPlanning(int length)
        {
            //复位中间位置
            foreach (Nanowires w in AutoDetect.allWires)
                w.SetMiddleWire();

            reachPosition = new int[length];
            numberOfNanowires = length;//初始化纳米线的数目
            ResetReachPosition();//复位到达位置信息数组
            SetInitialMovedMatirx();//初始化移动矩阵
            findResult = false;//表示没有算出结果
            order = null;//清空顺序
            middleResult = new MiddlePosition();//中间位置信息初始化
            pushOrderForPath = new List<PathMessage>();//生成路径信息初始化
        }


        /// <summary>
        /// 获取中间位置信息的类
        /// </summary>
        public class MiddlePosition
        {
            public List<List<int[]>> possibleResults = new List<List<int[]>>(0);//该中间位置条件下可以移动的全部可能情况列表
            public Nanowires.Wire middleWire;//中间位置信息
            public int index;//纳米线索引
            public double distanceAdded;//在该条件下增加的需要移动的距离
            public bool getValue;//表示是否获取中间位置

            public MiddlePosition(int[] a, Nanowires.Wire mWire, int indexOfWire, double d)
            {
                //possibleResults 表示新添加中间位置后全部的可能移动情况
                possibleResults = new List<List<int[]>>(1) { new List<int[]>(1) { MatrixOperations.Appendix(a, indexOfWire) }};
                //中间位置信息
                middleWire = mWire;
                //被选中中间位置纳米线的索引
                index = indexOfWire;
                //增加的移动距离
                distanceAdded = d;
                //表示已经获取中间位置
                getValue = true;
            }
            public MiddlePosition()
            {
                getValue =false;//并未获得任何中间位置信息
            }
            
        }

        /// <summary>
        /// 表示路径信息的类
        /// </summary>
        public class PathMessage
        {
            //需要移动的初始位置及终止位置
            public Nanowires.Wire presentWire, targetWire;
            //被移动的纳米线索引
            public int index;
            //是否是旋转
            public bool isRotate;
            public PathMessage(Nanowires.Wire w1, Nanowires.Wire w2, int n, bool r)
            {
                presentWire = w1;//路径的起始位置
                targetWire = w2;//路径的终止位置
                index = n;//纳米线索引
                isRotate = r;//旋转或推移判断
            }
        }


        /// <summary>
        /// 操纵策略计算
        /// </summary>
        public void GetMoveStrategy()
        {
            allPossibleResults = new List<List<int[]>>(1) { new List<int[]>(1) { null } };//初始化allPossibleResults
            int l;//表示进行路径规划的轮次
            List<int[]> a;//每轮次获得的结果

            while (true)
            {
                l = allPossibleResults.Count - 1;
                a = GetNewPossibleWays(allPossibleResults[l]);
                if (l == numberOfNanowires || a.Count == 0)//算出结果或无法继续计算即无解
                    break;
                else
                    allPossibleResults.Add(a);
            }

            if (allPossibleResults.Count != numberOfNanowires + 1)
            {
                SetMiddlePoints();//设置全部作为中间位置的桩点
                middleResult = new MiddlePosition();//初始化中间位置
                //对于每一种中间可的移动情况，均做一次计算
                for (int i = 0; i < allPossibleResults.Count; i++)
                    for (int j = 0; j < allPossibleResults[i].Count; j++)
                    {
                        SetOneMiddleWire(allPossibleResults[i][j]);
                    }
                if (middleResult.getValue)//如果计算有解
                { 
                    findResult = true;//表示算出结果
                    AutoDetect.allWires[middleResult.index].SetMiddleWire(middleResult.middleWire);//设置中间位置
                    order = middleResult.possibleResults[middleResult.possibleResults.Count - 1][0];//给出最终顺序
                }
            }
            else//不需要寻找中间位置就有解的情况
            {
                findResult = true;
                order = allPossibleResults[numberOfNanowires][0];
            }

            if(findResult)
            {
                //路径信息的保存
                pushOrderForPath = new List<PathMessage>(0);
                for (int i = 0; i < order.GetLength(0); i++)
                    if (MatrixOperations.GetTimesValueAppear(order, order[i]) == 1)//如果数字i只出现一次，即索引为i的纳米线不需要中间位置
                        PathMessageAdd(order[i]);
                    else//有中间位置的纳米线
                        if (i == 0||MatrixOperations.GetTimesValueAppear(MatrixOperations.Slice(order, 0, i - 1), order[i]) == 0)
                        {
                            Nanowires.Wire w = new Nanowires.Wire(
                                new PointF(middleResult.middleWire.firstPoint.X + AutoDetect.allWires[order[i]].startWire.rotatePoint.X - middleResult.middleWire.rotatePoint.X,
                                middleResult.middleWire.firstPoint.Y + AutoDetect.allWires[order[i]].startWire.rotatePoint.Y - middleResult.middleWire.rotatePoint.Y), 
                                new PointF(middleResult.middleWire.secondPoint.X + AutoDetect.allWires[order[i]].startWire.rotatePoint.X - middleResult.middleWire.rotatePoint.X,
                                middleResult.middleWire.secondPoint.Y + AutoDetect.allWires[order[i]].startWire.rotatePoint.Y - middleResult.middleWire.rotatePoint.Y),
                                AutoDetect.allWires[order[i]].startWire.rotatePoint);
                            pushOrderForPath.Add(new PathMessage(AutoDetect.allWires[order[i]].startWire, w, order[i], true));
                            pushOrderForPath.Add(new PathMessage(w, middleResult.middleWire, order[i],  false));
                        }
                        else
                            PathMessageAdd(order[i]);

            }
        }


        /// <summary>
        /// 获取进一步可能的继续推动的纳米线
        /// </summary>
        /// <param name="m"></param>
        public void GetPossibleResults(MiddlePosition m)
        {
            int l;
            List<int[]> a;
            while (true)
            {
                l = m.possibleResults.Count - 1;
                a = GetNewPossibleWays(m.possibleResults[l]);
                if (a.Count == 0)
                    break;
                else
                    m.possibleResults.Add(a);
            }
        }

        /// <summary>
        /// 设置中间位置
        /// </summary>
        /// <param name="present"></param>
        private void SetOneMiddleWire(int[] present)
        {
            MiddlePosition possible = new MiddlePosition();
            Nanowires.Wire startWire, middleWire, targetWire;//临时存放当前找到的中间位置及其对应的起始位置和目标位置

            //对每一个没有移动过的纳米线寻找中间位置
            for (int n = 0; n < numberOfNanowires; n++)
                if (MatrixOperations.GetTimesValueAppear(present, n) == 0)//只能移动没有出现过的纳米线，已经出现过的纳米线表示已经移动到目标位置
                {
                    for (int i = 0; i < middlePointsArr.GetLength(0); i++)
                    {
                        for (int j = 0; j < middlePointsArr.GetLength(1); j++)
                        {
                            startWire = AutoDetect.allWires[n].startWire;
                            targetWire = AutoDetect.allWires[n].targetWire;
                            middleWire = AutoDetect.allWires[n].GetMiddleWire(middlePointsArr[i, j]);

                            SetReachPosition(present);//设置到达信息

                            if (CanMove(startWire, middleWire, targetWire, n, reachPosition))
                            {
                                AutoDetect.allWires[n].SetMiddleWire(middleWire);
                                SetInitialMovedMatirx();
                                double d = MathCalculate.GetDistance(startWire.rotatePoint, middleWire.rotatePoint)
                                    + MathCalculate.GetDistance(middleWire.rotatePoint, targetWire.rotatePoint) - MathCalculate.GetDistance(startWire.rotatePoint, targetWire.rotatePoint);
                                possible = new MiddlePosition(present, middleWire, n, d);
                                GetPossibleResults(possible);
                                if (middleResult.getValue)
                                {
                                    if (possible.possibleResults[possible.possibleResults.Count - 1][0] != null
                                        && possible.possibleResults[possible.possibleResults.Count - 1][0].GetLength(0) == numberOfNanowires + 1
                                        && possible.distanceAdded < middleResult.distanceAdded)
                                        middleResult = possible;
                                }
                                else if (possible.possibleResults[possible.possibleResults.Count - 1][0] != null
                                        && possible.possibleResults[possible.possibleResults.Count - 1][0].GetLength(0) == numberOfNanowires + 1)
                                    middleResult = possible;
                                AutoDetect.allWires[n].SetMiddleWire();
                                //SetInitialMovedMatirx();
                            }
                        }
                    }

                }
        }

        //路径信息的添加
        private void PathMessageAdd(int index)
        {
            pushOrderForPath.Add(new PathMessage(AutoDetect.allWires[index].progressWires[0], AutoDetect.allWires[index].progressWires[1], index, true));
            pushOrderForPath.Add(new PathMessage(AutoDetect.allWires[index].progressWires[1], AutoDetect.allWires[index].progressWires[2], index, false));
            pushOrderForPath.Add(new PathMessage(AutoDetect.allWires[index].progressWires[2], AutoDetect.allWires[index].progressWires[3], index, true));
        }


        

        /// <summary>
        /// 复位各纳米线到达位置的标志，即全部在起点
        /// </summary>
        public void ResetReachPosition()
        {
            for (int i = 0; i < numberOfNanowires; i++)
                reachPosition[i] = -1;
        }

        /// <summary>
        /// 设置纳米线到达位置的标志
        /// </summary>
        /// <param name="w"></param>
        public void SetReachPosition(int[] w)
        {
            ResetReachPosition();//调整位置信息为全部在起始位置
            if (w != null)
                for (int i = 0; i < w.GetLength(0); i++)
                {
                    if (AutoDetect.allWires[w[i]].haveMiddleWire && MatrixOperations.GetTimesValueAppear(w, w[i]) == 1)
                        reachPosition[w[i]] = 0;
                    else
                        reachPosition[w[i]] = 1;
                }      
        }

        

        

        /// <summary>
        /// 判断寻找样条的新位置是否可以移动
        /// </summary>
        /// <param name="startWire"></param>
        /// <param name="middleWire"></param>
        /// <param name="targetWire"></param>
        /// <param name="num"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        private bool CanMove(Nanowires.Wire startWire, Nanowires.Wire middleWire,Nanowires.Wire targetWire , int num, int[] condition)
        {
            Nanowires.Wire w = new Nanowires.Wire(MathCalculate.GetWireAfterPush(middleWire, 
                new PointF(startWire.rotatePoint.X - middleWire.rotatePoint.X, startWire.rotatePoint.Y - middleWire.rotatePoint.Y)));
            w.rotatePoint = startWire.rotatePoint;
            for (int i = 0; i < condition.GetLength(0); i++)
            {
                if(i != num)
                {
                    if (condition[i] == -1)
                    {
                        if (InWireRotatingfield(AutoDetect.allWires[i].startWire, startWire, w))
                            return false;
                        if (InWirePushingfield(AutoDetect.allWires[i].startWire, w, middleWire))
                            return false;
                    }
                    else if (condition[i] == 0)
                    {
                        if (InWireRotatingfield(AutoDetect.allWires[i].middleWire, startWire, w))
                            return false;
                        if (InWirePushingfield(AutoDetect.allWires[i].middleWire, w, middleWire))
                            return false;
                    }
                    else
                    {
                        if (InWireRotatingfield(AutoDetect.allWires[i].targetWire, startWire, w))
                            return false;
                        if (InWirePushingfield(AutoDetect.allWires[i].targetWire, w, middleWire))
                            return false;
                        List<Nanowires.Wire> progressWires = AutoDetect.allWires[num].GetProgressWires(middleWire);
                        if (InWireMovingField(AutoDetect.allWires[i].targetWire, progressWires) == 1)
                            return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 提取特定的中间移动过程
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private int[] PickUpCertainMethod(int i,int j)
        {
            return allPossibleResults[i][j];
        }

        /// <summary>
        /// 设置全部中间位置的点
        /// </summary>
        private void SetMiddlePoints()
        {
            int x = (int)AutoDetect._xSize + 1;
            int y = (int)AutoDetect._ySize + 1;
            float dx = (float)AutoDetect._sampsInLine / x;
            float dy = (float)AutoDetect._numberOfLines / y;
            middlePointsArr = new PointF[ x - 1, y - 1];
            for (int i = 0; i < x - 1; i++)
                for (int j = 0; j < y - 1; j++)
                    middlePointsArr[i, j] = new PointF((i + 1) * dx, (j + 1) * dy);
        }

        /// <summary>
        /// 获取新的可能移动的纳米线
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        public List<int[]> GetNewPossibleWays(List<int[]> w)
        {
            List<int[]> result = new List<int[]>(0);
            int[,] mat;
            for (int m = 0; m < w.Count; m++)
            {
                SetReachPosition(w[m]);
                mat = GetMoveMatrix();
                if (GetWireMovable(mat) != null)
                    foreach (int n in GetWireMovable(mat))
                        result.Add(MatrixOperations.Appendix(w[m], n));   
            }
            return result;
        }

        /// <summary>
        /// 获取可以继续移动的纳米线
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int[] GetWireMovable(int[,] matrix)
        {
            bool sum;
            int[] result = null;
            for (int j = 0; j < numberOfNanowires; j++)
            {
                sum = true;
                for (int i = 0; i < numberOfNanowires; i++)
                {
                    if (matrix[i, j] != 0)
                    {
                        sum = false;
                        break;
                    }     
                }
                if (sum)
                    result = MatrixOperations.Appendix(result, j);
            }
            return result;
        }

        /// <summary>
        /// 计算移动矩阵
        /// </summary>
        /// <returns></returns>
        public int[,] GetMoveMatrix()
        {
            int[,] matrix = new int[numberOfNanowires, numberOfNanowires];
            for (int i = 0; i < numberOfNanowires; i++)
                for (int j = 0; j < numberOfNanowires; j++)
                    if (i == j)
                        matrix[i, j] = 0;
                    else if (reachPosition[j] == 1 && i != j)
                        matrix[i, j] = -1;
                    else if (reachPosition[i] == 1 && reachPosition[j] != 1)
                        matrix[i, j] = allMovedMatrix[i, j];
                    else
                    {
                        if (noMovedMatrix[j, i] == 1 && allMovedMatrix[j, i] == 1)
                            matrix[i, j] = -1;
                        else
                            matrix[i, j] = noMovedMatrix[i, j];
                    }
            return matrix;
        }

        public void SetInitialMovedMatirx()
        {
            noMovedMatrix = new int[numberOfNanowires, numberOfNanowires];
            allMovedMatrix = new int[numberOfNanowires, numberOfNanowires];
            for (int i = 0; i < numberOfNanowires; i++)
                for (int j = 0; j < numberOfNanowires; j++)
                    if (i == j)
                    {
                        noMovedMatrix[i, j] = 0;
                        allMovedMatrix[i, j] = 0;
                    }
                    else
                    {
                        if (AutoDetect.allWires[i].haveMiddleWire)
                        {
                            noMovedMatrix[i, j] = InWireMovingField(AutoDetect.allWires[i].middleWire, AutoDetect.allWires[j].progressWires);
                            allMovedMatrix[i, j] = InWireMovingField(AutoDetect.allWires[i].targetWire, AutoDetect.allWires[j].progressWires);
                        }
                        else
                        {
                            noMovedMatrix[i, j] = InWireMovingField(AutoDetect.allWires[i].startWire, AutoDetect.allWires[j].progressWires);
                            allMovedMatrix[i, j] = InWireMovingField(AutoDetect.allWires[i].targetWire, AutoDetect.allWires[j].progressWires);
                        }
                        
                    }

        }

        /// <summary>
        /// 判断纳米线是否经过其他纳米线移动的区域
        /// </summary>
        /// <param name="wire"></param>
        /// <param name="progressWires"></param>
        /// <returns></returns>
        public int InWireMovingField(Nanowires.Wire wire, List<Nanowires.Wire> progressWires)
        {
            if (InWirePushingfield(wire, progressWires[1], progressWires[2]) || 
                InWireRotatingfield(wire, progressWires[0], progressWires[1]) || 
                InWireRotatingfield(wire, progressWires[2], progressWires[3]))
                return 1;
            return 0;
        }

        /// <summary>
        /// 判断纳米线是否经过矩形内部
        /// </summary>
        /// <param name="wire"></param>
        /// <param name="startWire"></param>
        /// <param name="targetWire"></param>
        /// <returns></returns>
        public bool InWirePushingfield(Nanowires.Wire wire, Nanowires.Wire startWire, Nanowires.Wire targetWire)
        {
            int k = (int)MathCalculate.GetDistance(wire.firstPoint, wire.secondPoint);
            float stepX = (wire.secondPoint.X - wire.firstPoint.X) / k;
            float stepY = (wire.secondPoint.Y - wire.firstPoint.Y) / k;
            for (int i = 0; i <= k;i++ )
            {
                if (PointInSquare(new PointF(wire.firstPoint.X + i * stepX, wire.firstPoint.Y + i * stepY), startWire, targetWire))
                    return true;
            }
            return false;
        }
        
        /// <summary>
        /// 判断纳米线是否经过其他纳米线旋转过程的区域
        /// </summary>
        /// <param name="wire"></param>
        /// <param name="startWire"></param>
        /// <param name="targetWire"></param>
        /// <returns></returns>
        public bool InWireRotatingfield(Nanowires.Wire wire, Nanowires.Wire startWire, Nanowires.Wire targetWire)
        {
            int k = (int)MathCalculate.GetDistance(wire.firstPoint, wire.secondPoint);
            float stepX = (wire.secondPoint.X - wire.firstPoint.X) / k;
            float stepY = (wire.secondPoint.Y - wire.firstPoint.Y) / k;
            for (int i = 0; i <= k; i++)
            {
                if (PointInSector(new PointF(wire.firstPoint.X + i * stepX, wire.firstPoint.Y + i * stepY), 
                    startWire.firstPoint, startWire.rotatePoint, targetWire.firstPoint))
                    return true;
                if (PointInSector(new PointF(wire.firstPoint.X + i * stepX, wire.firstPoint.Y + i * stepY),
                    startWire.secondPoint, startWire.rotatePoint, targetWire.secondPoint))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 判断点是否在矩形内部
        /// </summary>
        /// <param name="p"></param>
        /// <param name="startWire"></param>
        /// <param name="targetWire"></param>
        /// <returns></returns>
        private bool PointInSquare(PointF p, Nanowires.Wire startWire, Nanowires.Wire targetWire)
        {
            double s1 = MathCalculate.GetRectangleArea(startWire, targetWire);
            double s2 = MathCalculate.GetTriangleArea(p, startWire.firstPoint, startWire.secondPoint) 
                + MathCalculate.GetTriangleArea(p, startWire.secondPoint, targetWire.secondPoint) 
                + MathCalculate.GetTriangleArea(p, targetWire.secondPoint, targetWire.firstPoint) 
                + MathCalculate.GetTriangleArea(p, targetWire.firstPoint, startWire.firstPoint);
            if (Math.Abs(s2 - s1) < 0.01)
                return true;
            return false;
        }

        /// <summary>
        /// 判断点是否在扇形内
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p1"></param>
        /// <param name="m"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        private bool PointInSector(PointF p, PointF p1, PointF m, PointF p2)
        {
            if (p1 == m || m == p2)
                return false;
            else
                if (MathCalculate.GetDistance(p, m) <= MathCalculate.GetDistance(p1, m) &&
                    MathCalculate.GetAngleDirection(p1, m, p2) == MathCalculate.GetAngleDirection(p1, m, p) &&
                    Math.Abs(MathCalculate.GetAngle(p1, m, p2)) >= Math.Abs(MathCalculate.GetAngle(p, m, p2)))
                    return true;
            return false;
        }


    }
}
