using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NanoExperiment.Automanipulation
{
    class SavePath
    {
        /// <summary>
        /// 生成路径需要的一系列参数
        /// </summary>
        public static double e, q, pushStep, t, pushSpeed, hangSpeed, probeRadius, zStep, zVelocity;
        /// <summary>
        /// 对于任意新打开的图像是否调整过参数
        /// </summary>
        public static bool isSet;
        //
        private static Nanowires.Wire startWire, targetWire;
        //
        public static List<double> manipulationPath;
        public static List<PointF> manipulationPathForShow;

        //设置参数
        public static void Initial(
            double eValue, double qValue, 
            double pushSpeedValue, double hangSpeedValue,  
            double zStepValue, double pushStepValue, 
            double tValue, double probeRadiusValue,
            double zVelocityValue)
        {
            e = eValue;
            q = qValue;
            pushStep = pushStepValue;
            t =tValue;
            pushSpeed = pushSpeedValue;
            hangSpeed = hangSpeedValue;
            probeRadius = probeRadiusValue;
            zStep = zStepValue;
            zVelocity = zVelocityValue;
        }

        public static void PathGenerate()
        {
            manipulationPath = new List<double>(2) { zStep, hangSpeed };
            manipulationPathForShow = new List<PointF>();
            SaveSoftStraighthenPath();
            for (int i = 0; i < AutoDetect.order.pushOrderForPath.Count; i++)
            {
                GetRealPosition(i);
                if (string.Equals(AutoDetect.allWires[AutoDetect.order.pushOrderForPath[i].index].softOrStiff, "soft") && AutoDetect.order.pushOrderForPath[i].isRotate)
                    SaveSoftRotatePath(AutoDetect.order.pushOrderForPath[i].index,
                        -MathCalculate.GetAngleWithDirection(
                        AutoDetect.order.pushOrderForPath[i].presentWire.firstPoint,
                        AutoDetect.order.pushOrderForPath[i].presentWire.secondPoint,
                        AutoDetect.order.pushOrderForPath[i].targetWire.firstPoint,
                        AutoDetect.order.pushOrderForPath[i].targetWire.secondPoint));
                else if(string.Equals(AutoDetect.allWires[AutoDetect.order.pushOrderForPath[i].index].softOrStiff, "soft") && !AutoDetect.order.pushOrderForPath[i].isRotate)
                    SaveSoftPushPath(AutoDetect.order.pushOrderForPath[i].index);
                else if(string.Equals(AutoDetect.allWires[AutoDetect.order.pushOrderForPath[i].index].softOrStiff, "stiff") && AutoDetect.order.pushOrderForPath[i].isRotate)
                    SaveStiffRotatePath(AutoDetect.order.pushOrderForPath[i].index, -MathCalculate.GetAngleWithDirection(
                        AutoDetect.order.pushOrderForPath[i].presentWire.firstPoint, 
                        AutoDetect.order.pushOrderForPath[i].presentWire.secondPoint, 
                        AutoDetect.order.pushOrderForPath[i].targetWire.firstPoint,
                        AutoDetect.order.pushOrderForPath[i].targetWire.secondPoint));
                else if (string.Equals(AutoDetect.allWires[AutoDetect.order.pushOrderForPath[i].index].softOrStiff, "stiff") && !AutoDetect.order.pushOrderForPath[i].isRotate)
                    SaveStiffPushPath(AutoDetect.order.pushOrderForPath[i].index);
            }
        }

        /// <summary>
        /// 获取真实坐标位置
        /// </summary>
        /// <param name="index"></param>
        private static void GetRealPosition(int index)
        {
            PointF pf = new PointF((float)(AutoDetect.order.pushOrderForPath[index].presentWire.firstPoint.X / AutoDetect._sampsInLine * AutoDetect._xSize  - AutoDetect._xSize / 2),
                (float)(AutoDetect.order.pushOrderForPath[index].presentWire.firstPoint.Y / AutoDetect._numberOfLines * AutoDetect._ySize  - AutoDetect._ySize / 2));
            PointF pr = new PointF((float)(AutoDetect.order.pushOrderForPath[index].presentWire.rotatePoint.X / AutoDetect._sampsInLine * AutoDetect._xSize - AutoDetect._xSize / 2),
                (float)(AutoDetect.order.pushOrderForPath[index].presentWire.rotatePoint.Y / AutoDetect._numberOfLines * AutoDetect._ySize - AutoDetect._ySize / 2));
            PointF ps = new PointF((float)(AutoDetect.order.pushOrderForPath[index].presentWire.secondPoint.X / AutoDetect._sampsInLine * AutoDetect._xSize - AutoDetect._xSize / 2),
                (float)(AutoDetect.order.pushOrderForPath[index].presentWire.secondPoint.Y / AutoDetect._numberOfLines * AutoDetect._ySize - AutoDetect._ySize / 2));
            startWire = new Nanowires.Wire(pf, ps, pr);
            pf = new PointF((float)(AutoDetect.order.pushOrderForPath[index].targetWire.firstPoint.X / AutoDetect._sampsInLine * AutoDetect._xSize - AutoDetect._xSize / 2),
                (float)(AutoDetect.order.pushOrderForPath[index].targetWire.firstPoint.Y / AutoDetect._numberOfLines * AutoDetect._ySize - AutoDetect._ySize / 2));
            pr = new PointF((float)(AutoDetect.order.pushOrderForPath[index].targetWire.rotatePoint.X / AutoDetect._sampsInLine * AutoDetect._xSize - AutoDetect._xSize / 2),
                (float)(AutoDetect.order.pushOrderForPath[index].targetWire.rotatePoint.Y / AutoDetect._numberOfLines * AutoDetect._ySize - AutoDetect._ySize / 2));
            ps = new PointF((float)(AutoDetect.order.pushOrderForPath[index].targetWire.secondPoint.X / AutoDetect._sampsInLine * AutoDetect._xSize - AutoDetect._xSize / 2),
                (float)(AutoDetect.order.pushOrderForPath[index].targetWire.secondPoint.Y / AutoDetect._numberOfLines * AutoDetect._ySize - AutoDetect._ySize / 2));
            targetWire = new Nanowires.Wire(pf, ps, pr);
        }

        private static void GetRealPosition(int index, PointF[] newPoints)
        {
            Nanowires.Wire w = new Nanowires.Wire(newPoints[0], newPoints[1]);

            PointF pf = new PointF((float)(AutoDetect.allWires[index].startWire.firstPoint.X / AutoDetect._sampsInLine * AutoDetect._xSize - AutoDetect._xSize / 2),
                (float)(AutoDetect.allWires[index].startWire.firstPoint.Y / AutoDetect._numberOfLines * AutoDetect._ySize - AutoDetect._ySize / 2));
            PointF pr = new PointF((float)(AutoDetect.allWires[index].startWire.rotatePoint.X / AutoDetect._sampsInLine * AutoDetect._xSize - AutoDetect._xSize / 2),
                (float)(AutoDetect.allWires[index].startWire.rotatePoint.Y / AutoDetect._numberOfLines * AutoDetect._ySize - AutoDetect._ySize / 2));
            PointF ps = new PointF((float)(AutoDetect.allWires[index].startWire.secondPoint.X / AutoDetect._sampsInLine * AutoDetect._xSize - AutoDetect._xSize / 2),
                (float)(AutoDetect.allWires[index].startWire.secondPoint.Y / AutoDetect._numberOfLines * AutoDetect._ySize - AutoDetect._ySize / 2));
            startWire = new Nanowires.Wire(pf, ps, pr);
            pf = new PointF((float)(w.firstPoint.X / AutoDetect._sampsInLine * AutoDetect._xSize - AutoDetect._xSize / 2),
                (float)(w.firstPoint.Y / AutoDetect._numberOfLines * AutoDetect._ySize - AutoDetect._ySize / 2));
            
            ps = new PointF((float)(w.secondPoint.X / AutoDetect._sampsInLine * AutoDetect._xSize - AutoDetect._xSize / 2),
                (float)(w.secondPoint.Y / AutoDetect._numberOfLines * AutoDetect._ySize - AutoDetect._ySize / 2));
            targetWire = new Nanowires.Wire(pf, pr);
        }


        /// <summary>
        /// 计算soft推移的deltaX
        /// </summary>
        /// <param name="ev"></param>
        /// <param name="qv"></param>
        /// <param name="h"></param>
        /// <param name="dy"></param>
        /// <returns></returns>
        private static double GetDeltaxForPush(double ev, double qv, double h, double dy)
        {
            return h * Math.Sqrt(Math.Sqrt(384 * ev * dy * 0.0484 / qv)) * (1 - Math.Sqrt(1 - Math.Sqrt(0.05))) / 1000;
        }

        /// <summary>
        /// 弯曲纳米线调直
        /// </summary>
        private static void SaveSoftStraighthenPath()
        {
            foreach (Nanowires w in AutoDetect.allWires)
            {
                int index = AutoDetect.allWires.IndexOf(w);
                if (w.bulkingStiffen.Count > 0)
                {
                    foreach (List<PointF> p in w.bulkingStiffen)
                        SaveBulkStiffen(p, index);
                }
            }

        }


        /// <summary>
        /// 计算单次弯曲纳米线调直路径
        /// </summary>
        /// <param name="p"></param>
        /// <param name="index"></param>
        private static void SaveBulkStiffen(List<PointF> p, int index)
        {
            PointF startPoint = new PointF((float)(p[0].X / AutoDetect._sampsInLine * AutoDetect._xSize - AutoDetect._xSize / 2), 
                (float)(p[0].Y / AutoDetect._numberOfLines * AutoDetect._ySize - AutoDetect._ySize / 2));
            PointF pivotPoint = new PointF((float)(p[1].X / AutoDetect._sampsInLine * AutoDetect._xSize - AutoDetect._xSize / 2),
                (float)(p[1].Y / AutoDetect._numberOfLines * AutoDetect._ySize - AutoDetect._ySize / 2));
            PointF endPoint = new PointF((float)(p[2].X / AutoDetect._sampsInLine * AutoDetect._xSize - AutoDetect._xSize / 2),
                (float)(p[2].Y / AutoDetect._numberOfLines * AutoDetect._ySize - AutoDetect._ySize / 2));

            double l = MathCalculate.GetDistance(startPoint, pivotPoint);
            double r = AutoDetect.allWires[index].diameter / 2 / 1000;

            double stepAngle = 2 * Math.Asin(pushStep / 2 / l);
            double angle = MathCalculate.GetAngleWithDirection(startPoint, pivotPoint, endPoint);
            int sig = angle > 0 ? 1 : -1;
            int m = (int)Math.Ceiling(Math.Abs(angle) / stepAngle);
            stepAngle = angle / m;

            double x = pivotPoint.X;
            double y = pivotPoint.Y;
            double afa = MathCalculate.GetAngleWithDirection(startPoint, pivotPoint, new PointF(pivotPoint.X + 1, pivotPoint.Y));

            double deltax = GetDeltaxForPush(e, q, AutoDetect.allWires[index].diameter, pushStep * 1000);
            int n = (int)Math.Ceiling(l / deltax);

            double thisPointX, thisPointY;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    thisPointX = l - j * deltax;
                    thisPointY = -sig * (r + probeRadius + t);
                    manipulationPath.Add(thisPointX * Math.Cos(afa) + thisPointY * Math.Sin(afa) + x);
                    manipulationPath.Add(-thisPointX * Math.Sin(afa) + thisPointY * Math.Cos(afa) + y);
                    manipulationPath.Add(pushSpeed);

                    manipulationPathForShow.Add(new PointF((float)((manipulationPath[manipulationPath.Count - 3] + AutoDetect._xSize / 2) / AutoDetect._xSize * AutoDetect._sampsInLine),
                        (float)(AutoDetect._numberOfLines - 1 - (manipulationPath[manipulationPath.Count - 2] + AutoDetect._ySize / 2) / AutoDetect._ySize * AutoDetect._numberOfLines)));

                    thisPointX = (l - j * deltax) * Math.Cos(stepAngle) + sig * (r + probeRadius) * Math.Sin(stepAngle);
                    thisPointY = (l - j * deltax) * Math.Sin(stepAngle) - sig * (r + probeRadius) * Math.Cos(stepAngle);
                    manipulationPath.Add(thisPointX * Math.Cos(afa) + thisPointY * Math.Sin(afa) + x);
                    manipulationPath.Add(-thisPointX * Math.Sin(afa) + thisPointY * Math.Cos(afa) + y);
                    if(j == n-1)
                        manipulationPath.Add(hangSpeed);
                    else
                        manipulationPath.Add(pushSpeed);

                    manipulationPathForShow.Add(new PointF((float)((manipulationPath[manipulationPath.Count - 3] + AutoDetect._xSize / 2) / AutoDetect._xSize * AutoDetect._sampsInLine),
                        (float)(AutoDetect._numberOfLines - 1 - (manipulationPath[manipulationPath.Count - 2] + AutoDetect._ySize / 2) / AutoDetect._ySize * AutoDetect._numberOfLines)));
                }
                afa -= stepAngle;
            }
        }

        /// <summary>
        /// 生成软纳米线平行推移路径
        /// </summary>
        /// <param name="index"></param>
        private static void SaveSoftPushPath(int index)
        {
            double r = AutoDetect.allWires[index].diameter / 2 / 1000;

            double deltay = pushStep;
            double d = MathCalculate.GetDistance(startWire.firstPoint, targetWire.firstPoint);
            int m = (int)Math.Ceiling(d / deltay);
            deltay = d / m;

            double deltax = GetDeltaxForPush(e, q, AutoDetect.allWires[index].diameter, deltay * 1000);
            double l = MathCalculate.GetDistance(startWire.firstPoint, startWire.secondPoint);
            int n = (int)Math.Ceiling(l / deltax);
            deltax = l / n;

            double x = startWire.firstPoint.X;
            double y = startWire.firstPoint.Y;
            double afa = MathCalculate.GetAngleWithDirection(startWire.secondPoint, startWire.firstPoint, 
                new PointF(startWire.firstPoint.X + 1, startWire.firstPoint.Y));
            int sig = MathCalculate.GetAngleDirection(startWire.secondPoint, startWire.firstPoint, targetWire.firstPoint); 

            double thisPointX, thisPointY;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    thisPointY = sig * (-(r + probeRadius + t) + deltay * i);
                    if (i % 2 == 0)
                        thisPointX = j * deltax;
                    else
                        thisPointX = (n - j) * deltax;
                   
                    manipulationPath.Add(thisPointX * Math.Cos(afa) + thisPointY * Math.Sin(afa) + x);
                    manipulationPath.Add(-thisPointX * Math.Sin(afa) + thisPointY * Math.Cos(afa) + y);
                    manipulationPath.Add(pushSpeed);

                    manipulationPathForShow.Add(new PointF((float)((manipulationPath[manipulationPath.Count - 3] + AutoDetect._xSize / 2) / AutoDetect._xSize * AutoDetect._sampsInLine),
                        (float)(AutoDetect._numberOfLines - 1 - (manipulationPath[manipulationPath.Count - 2] + AutoDetect._ySize / 2) / AutoDetect._ySize * AutoDetect._numberOfLines)));

                    thisPointY = sig * (-(r + probeRadius) + deltay * (i + 1));
                    manipulationPath.Add(thisPointX * Math.Cos(afa) + thisPointY * Math.Sin(afa) + x);
                    manipulationPath.Add(-thisPointX * Math.Sin(afa) + thisPointY * Math.Cos(afa) + y);

                    if (i == m - 1 && j == n)
                        manipulationPath.Add(hangSpeed);
                    else
                        manipulationPath.Add(pushSpeed);

                    manipulationPathForShow.Add(new PointF((float)((manipulationPath[manipulationPath.Count - 3] + AutoDetect._xSize / 2) / AutoDetect._xSize * AutoDetect._sampsInLine),
                        (float)(AutoDetect._numberOfLines - 1 - (manipulationPath[manipulationPath.Count - 2] + AutoDetect._ySize / 2) / AutoDetect._ySize * AutoDetect._numberOfLines)));

                }
            }
        }

        /// <summary>
        /// 保存软纳米线旋转的路径
        /// </summary>
        /// <param name="index"></param>
        private static void SaveSoftRotatePath(int index,double angle)
        {
            Nanowires.Wire temporaryWire = new Nanowires.Wire(startWire);
            int sig = angle >= 0 ? 1 : -1;

            double l = AutoDetect.allWires[index].length/1000;
            double l1 = AutoDetect.allWires[index].length / 1000 * (1 - AutoDetect.allWires[index].rotatingPointPosition);
            double l2 = AutoDetect.allWires[index].length / 1000 * AutoDetect.allWires[index].rotatingPointPosition;
            double r = AutoDetect.allWires[index].diameter / 2 / 1000;

            double stepAngle = 2 * Math.Asin(pushStep / l);
            int m = (int)Math.Ceiling(Math.Abs(angle) / stepAngle);
            stepAngle = angle / m;
            double deltax = GetDeltaxForPush(e, q, AutoDetect.allWires[index].diameter, pushStep * 1000);
            int n1 = (int)Math.Ceiling(l1 / deltax);
            int n2 = (int)Math.Ceiling(l2 / deltax);

            PointF relativePointF, relativePointS;

            relativePointF = new PointF((float)((1 - Math.Cos(stepAngle)) * l1), (float)(l1 * Math.Sin(stepAngle)));
            relativePointS = new PointF((float)(l1 + l2 * Math.Cos(stepAngle)), (float)(-l2 * Math.Sin(stepAngle)));

            double x, y, afa;

            double thisPointX, thisPointY;

            for (int i = 0; i < m; i++)
            {
                x = temporaryWire.firstPoint.X;
                y = temporaryWire.firstPoint.Y;
                afa = MathCalculate.GetAngleWithDirection(temporaryWire.secondPoint, temporaryWire.firstPoint,
                    new PointF(temporaryWire.firstPoint.X + 1, temporaryWire.firstPoint.Y));

                for (int j = 0; j < n1; j++)
                {
                    thisPointX = j * deltax;
                    thisPointY = -sig * (r + probeRadius + t);
                    manipulationPath.Add(thisPointX * Math.Cos(afa) + thisPointY * Math.Sin(afa) + x);
                    manipulationPath.Add(-thisPointX * Math.Sin(afa) + thisPointY * Math.Cos(afa) + y);
                    manipulationPath.Add(pushSpeed);

                    manipulationPathForShow.Add(new PointF((float)((manipulationPath[manipulationPath.Count - 3] + AutoDetect._xSize / 2) / AutoDetect._xSize * AutoDetect._sampsInLine),
                        (float)(AutoDetect._numberOfLines - 1 - (manipulationPath[manipulationPath.Count - 2] + AutoDetect._ySize / 2) / AutoDetect._ySize * AutoDetect._numberOfLines)));

                    thisPointX = l1 - (l1 - j * deltax) * Math.Cos(stepAngle) - sig * (r + probeRadius) * Math.Sin(stepAngle);
                    thisPointY = (l1 - j * deltax) * Math.Sin(stepAngle) - sig * (r + probeRadius) * Math.Cos(stepAngle);
                    manipulationPath.Add(thisPointX * Math.Cos(afa) + thisPointY * Math.Sin(afa) + x);
                    manipulationPath.Add(-thisPointX * Math.Sin(afa) + thisPointY * Math.Cos(afa) + y);
                    if (j == n1 - 1)
                        manipulationPath.Add(hangSpeed);
                    else
                        manipulationPath.Add(pushSpeed);

                    manipulationPathForShow.Add(new PointF((float)((manipulationPath[manipulationPath.Count - 3] + AutoDetect._xSize / 2) / AutoDetect._xSize * AutoDetect._sampsInLine),
                        (float)(AutoDetect._numberOfLines - 1 - (manipulationPath[manipulationPath.Count - 2] + AutoDetect._ySize / 2) / AutoDetect._ySize * AutoDetect._numberOfLines)));

                }

                for (int j = 0; j < n2; j++)
                {
                    thisPointX = l - j * deltax;
                    thisPointY = sig * (r + probeRadius + t);
                    manipulationPath.Add(thisPointX * Math.Cos(afa) + thisPointY * Math.Sin(afa) + x);
                    manipulationPath.Add(-thisPointX * Math.Sin(afa) + thisPointY * Math.Cos(afa) + y);
                    manipulationPath.Add(pushSpeed);

                    manipulationPathForShow.Add(new PointF((float)((manipulationPath[manipulationPath.Count - 3] + AutoDetect._xSize / 2) / AutoDetect._xSize * AutoDetect._sampsInLine),
                        (float)(AutoDetect._numberOfLines - 1 - (manipulationPath[manipulationPath.Count - 2] + AutoDetect._ySize / 2) / AutoDetect._ySize * AutoDetect._numberOfLines)));

                    thisPointX = l1 + (l2 - j * deltax) * Math.Cos(stepAngle) + sig * (r + probeRadius) * Math.Sin(stepAngle);
                    thisPointY = -(l2 - j * deltax) * Math.Sin(stepAngle) + sig * (r + probeRadius) * Math.Cos(stepAngle);
                    manipulationPath.Add(thisPointX * Math.Cos(afa) + thisPointY * Math.Sin(afa) + x);
                    manipulationPath.Add(-thisPointX * Math.Sin(afa) + thisPointY * Math.Cos(afa) + y);
                    if (j == n2 - 1)
                        manipulationPath.Add(hangSpeed);
                    else
                        manipulationPath.Add(pushSpeed);

                    manipulationPathForShow.Add(new PointF((float)((manipulationPath[manipulationPath.Count - 3] + AutoDetect._xSize / 2) / AutoDetect._xSize * AutoDetect._sampsInLine),
                        (float)(AutoDetect._numberOfLines - 1 - (manipulationPath[manipulationPath.Count - 2] + AutoDetect._ySize / 2) / AutoDetect._ySize * AutoDetect._numberOfLines)));

                }

                temporaryWire = new Nanowires.Wire(
                        new PointF((float)(relativePointF.X * Math.Cos(afa) + relativePointF.Y * Math.Sin(afa) + x), (float)(-relativePointF.X * Math.Sin(afa) + relativePointF.Y * Math.Cos(afa) + y)),
                        new PointF((float)(relativePointS.X * Math.Cos(afa) + relativePointS.Y * Math.Sin(afa) + x), (float)(-relativePointS.X * Math.Sin(afa) + relativePointS.Y * Math.Cos(afa) + y))
                        );

            }

        }

        /// <summary>
        /// 保存硬纳米线平移的路径
        /// </summary>
        /// <param name="index"></param>
        private static void SaveStiffPushPath(int index)
        {
            Nanowires.Wire temporaryWire = new Nanowires.Wire(startWire);

            double l = AutoDetect.allWires[index].length / 1000;
            double r = AutoDetect.allWires[index].diameter / 2 /1000;
            int sig = MathCalculate.GetAngleDirection(startWire.secondPoint, startWire.firstPoint, targetWire.firstPoint);

            double stepAngle = Math.PI / 90;
            double deltay = Math.Abs(1 - AutoDetect.allWires[index].rotatingPointPosition * 2) * l * Math.Sin(stepAngle);
            double d = MathCalculate.GetDistance(startWire.firstPoint, targetWire.firstPoint);
            int m = (int)Math.Ceiling(d / deltay);
            deltay = d / m;
            stepAngle = Math.Asin(deltay / (Math.Abs(1 - AutoDetect.allWires[index].rotatingPointPosition * 2) * l));
            stepAngle = sig * stepAngle;

            double k1, k2, p1, p2;
            if (AutoDetect.allWires[index].rotatingPointPosition > 0.5)
            {
                k1 = 1 - AutoDetect.allWires[index].rotatingPointPosition;
                k2 = AutoDetect.allWires[index].rotatingPointPosition;
                p1 = 1 - AutoDetect.allWires[index].stiffPushPosition;
                p2 = AutoDetect.allWires[index].stiffPushPosition;
            }
            else
            {
                k1 = AutoDetect.allWires[index].rotatingPointPosition;
                k2 = 1 - AutoDetect.allWires[index].rotatingPointPosition;
                p1 = AutoDetect.allWires[index].stiffPushPosition;
                p2 = 1 - AutoDetect.allWires[index].stiffPushPosition;
            }

            PointF relative1PointF, relative1PointS, relative2PointF, relative2PointS, relative1PathP1, relative1PathP2, relative2PathP1, relative2PathP2;

            relative1PointF = new PointF((float)((1 - Math.Cos(stepAngle)) * k2 * l), (float)(k2 * l * Math.Sin(stepAngle)));
            relative1PointS = new PointF((float)(k2 * l + k1 * l * Math.Cos(stepAngle)), (float)(-k1 * l * Math.Sin(stepAngle)));
            relative2PointF = new PointF((float)((1 - Math.Cos(stepAngle)) * k1 * l), (float)(-k1 * l * Math.Sin(stepAngle)));
            relative2PointS = new PointF((float)(k1 * l + k2 * l * Math.Cos(stepAngle)), (float)(k2 * l * Math.Sin(stepAngle)));

            relative1PathP1 = new PointF((float)(p2 * l), (float)(sig * (-(r + probeRadius + t))));
            relative1PathP2 = new PointF((float)(k2 * l - (p1 - k1) * l * Math.Cos(stepAngle) - sig * (r + probeRadius) * Math.Sin(stepAngle)), (float)((p1 - k1) * l * Math.Sin(stepAngle) - sig * (r + probeRadius) * Math.Cos(stepAngle)));
            relative2PathP1 = new PointF((float)(p1 * l), (float)(sig * (-(r + probeRadius + t))));
            relative2PathP2 = new PointF((float)(k1 * l + (p1 - k1) * l * Math.Cos(stepAngle) + sig * (r + probeRadius) * Math.Sin(stepAngle)), (float)((p1 - k1) * l * Math.Sin(stepAngle) - sig * (r + probeRadius) * Math.Cos(stepAngle)));

            double x, y, afa;

            for (int i = 0; i < m; i++)
            { 
                if (i % 2 == 0)
                {
                    x = temporaryWire.firstPoint.X;
                    y = temporaryWire.firstPoint.Y;
                    afa = MathCalculate.GetAngleWithDirection(temporaryWire.secondPoint, temporaryWire.firstPoint,
                        new PointF(temporaryWire.firstPoint.X + 1, temporaryWire.firstPoint.Y));
                    manipulationPath.Add(relative1PathP1.X * Math.Cos(afa) + relative1PathP1.Y * Math.Sin(afa) + x);
                    manipulationPath.Add(-relative1PathP1.X * Math.Sin(afa) + relative1PathP1.Y * Math.Cos(afa) + y);
                    manipulationPath.Add(pushSpeed);

                    manipulationPathForShow.Add(new PointF((float)((manipulationPath[manipulationPath.Count - 3] + AutoDetect._xSize / 2) / AutoDetect._xSize * AutoDetect._sampsInLine),
                        (float)(AutoDetect._numberOfLines - 1 - (manipulationPath[manipulationPath.Count - 2] + AutoDetect._ySize / 2) / AutoDetect._ySize * AutoDetect._numberOfLines)));

                    manipulationPath.Add(relative1PathP2.X * Math.Cos(afa) + relative1PathP2.Y * Math.Sin(afa) + x);
                    manipulationPath.Add(-relative1PathP2.X * Math.Sin(afa) + relative1PathP2.Y * Math.Cos(afa) + y);
                    manipulationPath.Add(hangSpeed);

                    manipulationPathForShow.Add(new PointF((float)((manipulationPath[manipulationPath.Count - 3] + AutoDetect._xSize / 2) / AutoDetect._xSize * AutoDetect._sampsInLine),
                        (float)(AutoDetect._numberOfLines - 1 - (manipulationPath[manipulationPath.Count - 2] + AutoDetect._ySize / 2) / AutoDetect._ySize * AutoDetect._numberOfLines)));

                    temporaryWire = new Nanowires.Wire(
                        new PointF((float)(relative1PointF.X * Math.Cos(afa) + relative1PointF.Y * Math.Sin(afa) + x), (float)(-relative1PointF.X * Math.Sin(afa) + relative1PointF.Y * Math.Cos(afa) + y)),
                        new PointF((float)(relative1PointS.X * Math.Cos(afa) + relative1PointS.Y * Math.Sin(afa) + x), (float)(-relative1PointS.X * Math.Sin(afa) + relative1PointS.Y * Math.Cos(afa) + y))
                        );

                    x = temporaryWire.firstPoint.X;
                    y = temporaryWire.firstPoint.Y;
                    afa = MathCalculate.GetAngleWithDirection(temporaryWire.secondPoint, temporaryWire.firstPoint,
                        new PointF(temporaryWire.firstPoint.X + 1, temporaryWire.firstPoint.Y));
                    manipulationPath.Add(relative2PathP1.X * Math.Cos(afa) + relative2PathP1.Y * Math.Sin(afa) + x);
                    manipulationPath.Add(-relative2PathP1.X * Math.Sin(afa) + relative2PathP1.Y * Math.Cos(afa) + y);
                    manipulationPath.Add(pushSpeed);

                    manipulationPathForShow.Add(new PointF((float)((manipulationPath[manipulationPath.Count - 3] + AutoDetect._xSize / 2) / AutoDetect._xSize * AutoDetect._sampsInLine),
                        (float)(AutoDetect._numberOfLines - 1 - (manipulationPath[manipulationPath.Count - 2] + AutoDetect._ySize / 2) / AutoDetect._ySize * AutoDetect._numberOfLines)));

                    manipulationPath.Add(relative2PathP2.X * Math.Cos(afa) + relative2PathP2.Y * Math.Sin(afa) + x);
                    manipulationPath.Add(-relative2PathP2.X * Math.Sin(afa) + relative2PathP2.Y * Math.Cos(afa) + y);
                    if(i == m - 1)
                        manipulationPath.Add(hangSpeed);
                    else
                        manipulationPath.Add(pushSpeed);

                    manipulationPathForShow.Add(new PointF((float)((manipulationPath[manipulationPath.Count - 3] + AutoDetect._xSize / 2) / AutoDetect._xSize * AutoDetect._sampsInLine),
                        (float)(AutoDetect._numberOfLines - 1 - (manipulationPath[manipulationPath.Count - 2] + AutoDetect._ySize / 2) / AutoDetect._ySize * AutoDetect._numberOfLines)));

                    temporaryWire = new Nanowires.Wire(
                        new PointF((float)(relative2PointF.X * Math.Cos(afa) + relative2PointF.Y * Math.Sin(afa) + x), (float)(-relative2PointF.X * Math.Sin(afa) + relative2PointF.Y * Math.Cos(afa) + y)),
                        new PointF((float)(relative2PointS.X * Math.Cos(afa) + relative2PointS.Y * Math.Sin(afa) + x), (float)(-relative2PointS.X * Math.Sin(afa) + relative2PointS.Y * Math.Cos(afa) + y))
                        );

                }
                else 
                {
                    x = temporaryWire.firstPoint.X;
                    y = temporaryWire.firstPoint.Y;
                    afa = MathCalculate.GetAngleWithDirection(temporaryWire.secondPoint, temporaryWire.firstPoint,
                        new PointF(temporaryWire.firstPoint.X + 1, temporaryWire.firstPoint.Y));
                    manipulationPath.Add(relative2PathP1.X * Math.Cos(afa) + relative2PathP1.Y * Math.Sin(afa) + x);
                    manipulationPath.Add(-relative2PathP1.X * Math.Sin(afa) + relative2PathP1.Y * Math.Cos(afa) + y);
                    manipulationPath.Add(pushSpeed);

                    manipulationPathForShow.Add(new PointF((float)((manipulationPath[manipulationPath.Count - 3] + AutoDetect._xSize / 2) / AutoDetect._xSize * AutoDetect._sampsInLine),
                        (float)(AutoDetect._numberOfLines - 1 - (manipulationPath[manipulationPath.Count - 2] + AutoDetect._ySize / 2) / AutoDetect._ySize * AutoDetect._numberOfLines)));

                    manipulationPath.Add(relative2PathP2.X * Math.Cos(afa) + relative2PathP2.Y * Math.Sin(afa) + x);
                    manipulationPath.Add(-relative2PathP2.X * Math.Sin(afa) + relative2PathP2.Y * Math.Cos(afa) + y);
                    manipulationPath.Add(hangSpeed);

                    manipulationPathForShow.Add(new PointF((float)((manipulationPath[manipulationPath.Count - 3] + AutoDetect._xSize / 2) / AutoDetect._xSize * AutoDetect._sampsInLine),
                        (float)(AutoDetect._numberOfLines - 1 - (manipulationPath[manipulationPath.Count - 2] + AutoDetect._ySize / 2) / AutoDetect._ySize * AutoDetect._numberOfLines)));

                    temporaryWire = new Nanowires.Wire(
                        new PointF((float)(relative2PointF.X * Math.Cos(afa) + relative2PointF.Y * Math.Sin(afa) + x), (float)(-relative2PointF.X * Math.Sin(afa) + relative2PointF.Y * Math.Cos(afa) + y)),
                        new PointF((float)(relative2PointS.X * Math.Cos(afa) + relative2PointS.Y * Math.Sin(afa) + x), (float)(-relative2PointS.X * Math.Sin(afa) + relative2PointS.Y * Math.Cos(afa) + y))
                        );

                    x = temporaryWire.firstPoint.X;
                    y = temporaryWire.firstPoint.Y;
                    afa = MathCalculate.GetAngleWithDirection(temporaryWire.secondPoint, temporaryWire.firstPoint,
                        new PointF(temporaryWire.firstPoint.X + 1, temporaryWire.firstPoint.Y));
                    manipulationPath.Add(relative1PathP1.X * Math.Cos(afa) + relative1PathP1.Y * Math.Sin(afa) + x);
                    manipulationPath.Add(-relative1PathP1.X * Math.Sin(afa) + relative1PathP1.Y * Math.Cos(afa) + y);
                    manipulationPath.Add(pushSpeed);

                    manipulationPathForShow.Add(new PointF((float)((manipulationPath[manipulationPath.Count - 3] + AutoDetect._xSize / 2) / AutoDetect._xSize * AutoDetect._sampsInLine),
                        (float)(AutoDetect._numberOfLines - 1 - (manipulationPath[manipulationPath.Count - 2] + AutoDetect._ySize / 2) / AutoDetect._ySize * AutoDetect._numberOfLines)));

                    manipulationPath.Add(relative1PathP2.X * Math.Cos(afa) + relative1PathP2.Y * Math.Sin(afa) + x);
                    manipulationPath.Add(-relative1PathP2.X * Math.Sin(afa) + relative1PathP2.Y * Math.Cos(afa) + y);
                    if (i == m - 1)
                        manipulationPath.Add(hangSpeed);
                    else
                        manipulationPath.Add(pushSpeed);

                    manipulationPathForShow.Add(new PointF((float)((manipulationPath[manipulationPath.Count - 3] + AutoDetect._xSize / 2) / AutoDetect._xSize * AutoDetect._sampsInLine),
                        (float)(AutoDetect._numberOfLines - 1 - (manipulationPath[manipulationPath.Count - 2] + AutoDetect._ySize / 2) / AutoDetect._ySize * AutoDetect._numberOfLines)));

                    temporaryWire = new Nanowires.Wire(
                        new PointF((float)(relative1PointF.X * Math.Cos(afa) + relative1PointF.Y * Math.Sin(afa) + x), (float)(-relative1PointF.X * Math.Sin(afa) + relative1PointF.Y * Math.Cos(afa) + y)),
                        new PointF((float)(relative1PointS.X * Math.Cos(afa) + relative1PointS.Y * Math.Sin(afa) + x), (float)(-relative1PointS.X * Math.Sin(afa) + relative1PointS.Y * Math.Cos(afa) + y))
                        );

                }
            }
        }

        /// <summary>
        /// 保存硬纳米线旋转的路径
        /// </summary>
        /// <param name="index"></param>
        private static void SaveStiffRotatePath(int index, double angle)
        {
            Nanowires.Wire temporaryWire = new Nanowires.Wire(startWire);
            int sig = angle >= 0? 1:-1;

            double l = AutoDetect.allWires[index].length / 1000;
            double r = AutoDetect.allWires[index].diameter / 2 / 1000;
            double stepAngle = Math.PI / 90;
            int m = (int)Math.Ceiling(Math.Abs(angle) / stepAngle);
            stepAngle = angle / m;

            double k1, k2, p1, p2;
            k1 = AutoDetect.allWires[index].rotatingPointPosition;
            k2 = 1 - AutoDetect.allWires[index].rotatingPointPosition;
            p1 = AutoDetect.allWires[index].stiffPushPosition;
            p2 = 1 - AutoDetect.allWires[index].stiffPushPosition;

            PointF relativePointF, relativePointS, relativePathP1, relativePathP2;

            relativePointF = new PointF((float)((1 - Math.Cos(stepAngle)) * k2 * l), (float)(k2 * l * Math.Sin(stepAngle)));
            relativePointS = new PointF((float)(k2 * l + k1 * l * Math.Cos(stepAngle)), (float)(-k1 * l * Math.Sin(stepAngle)));


            relativePathP1 = new PointF((float)(p2 * l), (float)(sig * (-(r + probeRadius + t))));
            relativePathP2 = new PointF((float)(k2 * l - (p1 - k1) * l * Math.Cos(stepAngle) - sig * (r + probeRadius) * Math.Sin(stepAngle)), (float)((p1 - k1) * l * Math.Sin(stepAngle) - sig * (r + probeRadius) * Math.Cos(stepAngle)));

            double x, y, afa;

            for (int i = 0; i < m; i++)
            {
                x = temporaryWire.firstPoint.X;
                y = temporaryWire.firstPoint.Y;
                afa = MathCalculate.GetAngleWithDirection(temporaryWire.secondPoint, temporaryWire.firstPoint,
                        new PointF(temporaryWire.firstPoint.X + 1, temporaryWire.firstPoint.Y));
                manipulationPath.Add(relativePathP1.X * Math.Cos(afa) + relativePathP1.Y * Math.Sin(afa) + x);
                manipulationPath.Add(-relativePathP1.X * Math.Sin(afa) + relativePathP1.Y * Math.Cos(afa) + y);
                manipulationPath.Add(pushSpeed);

                manipulationPathForShow.Add(new PointF((float)((manipulationPath[manipulationPath.Count - 3] + AutoDetect._xSize / 2) / AutoDetect._xSize * AutoDetect._sampsInLine),
                        (float)(AutoDetect._numberOfLines - 1 - (manipulationPath[manipulationPath.Count - 2] + AutoDetect._ySize / 2) / AutoDetect._ySize * AutoDetect._numberOfLines)));

                manipulationPath.Add(relativePathP2.X * Math.Cos(afa) + relativePathP2.Y * Math.Sin(afa) + x);
                manipulationPath.Add(-relativePathP2.X * Math.Sin(afa) + relativePathP2.Y * Math.Cos(afa) + y);
                if (i == m - 1)
                    manipulationPath.Add(hangSpeed);
                else
                    manipulationPath.Add(pushSpeed);

                manipulationPathForShow.Add(new PointF((float)((manipulationPath[manipulationPath.Count - 3] + AutoDetect._xSize / 2) / AutoDetect._xSize * AutoDetect._sampsInLine),
                        (float)(AutoDetect._numberOfLines - 1 - (manipulationPath[manipulationPath.Count - 2] + AutoDetect._ySize / 2) / AutoDetect._ySize * AutoDetect._numberOfLines)));

                temporaryWire = new Nanowires.Wire(
                        new PointF((float)(relativePointF.X * Math.Cos(afa) + relativePointF.Y * Math.Sin(afa) + x), (float)(-relativePointF.X * Math.Sin(afa) + relativePointF.Y * Math.Cos(afa) + y)),
                        new PointF((float)(relativePointS.X * Math.Cos(afa) + relativePointS.Y * Math.Sin(afa) + x), (float)(-relativePointS.X * Math.Sin(afa) + relativePointS.Y * Math.Cos(afa) + y))
                        );

            }
        }

        /// <summary>
        /// 保存平移纳米线的路径
        /// </summary>
        /// <param name="w"></param>
        /// <param name="newPoints"></param>
        public static void SavePushPath(int index, PointF[] newPoints)
        {
            manipulationPath = new List<double>(2) { zStep, hangSpeed };//清空已经存在的路径
            manipulationPathForShow = new List<PointF>();//清空全部存在的路径
            if (AutoDetect.allWires[index].bulkingStiffen.Count > 0)
                foreach (List<PointF> p in AutoDetect.allWires[index].bulkingStiffen)
                    SaveBulkStiffen(p, index);
            GetRealPosition(index, newPoints);
            if (AutoDetect.allWires[index].softOrStiff == "soft")
                SaveSoftPushPath(index);
            else
                SaveStiffPushPath(index);
        }

        /// <summary>
        /// 保存旋转纳米线的路径
        /// </summary>
        /// <param name="index"></param>
        /// <param name="newPoints"></param>
        public static void SaveRotatePath(int index, PointF[] newPoints)
        {
            manipulationPath = new List<double>() { zStep, hangSpeed };//清空已经存在的路径
            manipulationPathForShow = new List<PointF>();//清空全部存在的路径
            if (AutoDetect.allWires[index].bulkingStiffen.Count > 0)
                foreach (List<PointF> p in AutoDetect.allWires[index].bulkingStiffen)
                    SaveBulkStiffen(p, index);
            double angle = MathCalculate.GetAngleWithDirection(AutoDetect.allWires[index].startWire.firstPoint,
                    AutoDetect.allWires[index].startWire.secondPoint, newPoints[0], newPoints[1]);
            GetRealPosition(index, newPoints);
            if (AutoDetect.allWires[index].softOrStiff == "soft")
                SaveSoftRotatePath(index, -angle);
            else
                SaveStiffRotatePath(index, -angle);
        }

        /// <summary>
        /// 保存调直纳米线的路径
        /// </summary>
        /// <param name="index"></param>
        public static void SaveStraightenPath(int index)
        {
            manipulationPath = new List<double>() { zStep, hangSpeed };//清空已经存在的路径
            manipulationPathForShow = new List<PointF>();//清空全部存在的路径
            foreach (List<PointF> p in AutoDetect.allWires[index].bulkingStiffen)
                SaveBulkStiffen(p, index);
        }
    }
}
