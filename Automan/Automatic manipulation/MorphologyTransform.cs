using System;
using System.Collections.Generic;

namespace NanoExperiment.Automanipulation
{
    /// <summary>
    /// 图像形态学操作类
    /// </summary>
    class MorphologyTransform
    {
        private class SingleSample
        {
            public int[,] greyImage, arrayMessage;
        }

        DisplayImage imageShow = new DisplayImage();//图像显示对象

        int[] index = new int[2] { 0, 0 };//单一样条抽取起点


        /// <summary>
        /// 重置函数，索引至原点，障碍物删除
        /// </summary>
        public void Reset()
        {
            index[0] = 0; 
            index[1] = 0;
        }

        /// <summary>
        /// 识别主要程序
        /// </summary>
        /// <param name="greyImage"></param>灰度图像矩阵
        /// <param name="edgeThreshold"></param>sobel算子边缘识别阈值
        /// <returns></returns>
        public List<int[,]> MainDetect(int[,] greyImage, double edgeThreshold)
        {
            List<int[,]> skeleton= new List<int[,]>();
            List<int[,]> result = new List<int[,]>();//所有单一样条的图像索引信息
            greyImage = SobelEdges(greyImage, edgeThreshold);//sobel边缘识别
            greyImage = HolesFill(greyImage);//孔洞填充
            result = SeparateSamples(greyImage);//单一样条分离
            result = DeleteBucksAndSidelines(result);//删除大样块和靠近边缘位置的样条，这样的物体被认为是障碍物
            foreach (int[,] a in result)
            {
                greyImage = MatrixOperations.IndexToMatrix(a);
                greyImage = ThinnerHilditch(greyImage);//Hilditch细化
                if (!WithBranches(greyImage))//剔除有叠加的样条
                    skeleton = ListAdd(skeleton, MatrixOperations.MatrixToIndex(greyImage));//true 骨架坐标第一行为图像尺寸；false 第一行为骨架尺寸
            }
            return skeleton;
        }

        /// <summary>
        /// 二值图像孔洞填充
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private int[,] HolesFill(int[,] input)
        {
            int[,] output;
            output = BackgroundFill(input);//背景填充
            output = MatrixOperations.Add(MatrixOperations.Not(output), input);//背景填充结果取反与原图相加为最终孔洞填充结果
            return output;
        }

        /// <summary>
        /// 二值图像背景填充
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private int[,] BackgroundFill(int[,] input)
        {
            int[,] output;
            int[] seed = new int[2] { 1, 1 };
            output = Expand(input, 0);//拓展边缘为0
            output = Expand(output, 255);//拓展边缘为1
            output[1, 1] = 255;//种子点像素为白色前景色
            output = ContinuousAreaFill(output, seed, true);//膨胀算法对连续区域进行填充
            output = Reduce(output, 2);//边缘缩减两像素
            return output;
        }

        /// <summary>
        /// 连续区域填充：mode=true 黑变白；mode=false 白变黑
        /// </summary>
        /// <param name="greyImage"></param>
        /// <param name="seed"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        private int[,] ContinuousAreaFill(int[,] greyImage, int[] seed, bool mode)
        {
            int valueFill = 0, valueSet = 255;
            int[,] seeds = new int[1, 2];
            int[,] newSeeds = null;
            if (mode)
            {
                valueFill = 255;
                valueSet = 0;
            }           
            seeds[0, 0] = seed[0]; seeds[0, 1] = seed[1];
            while (seeds != null)
            {
                newSeeds = null;
                for (int i = 0; i < seeds.GetLength(0); i++)
                {
                    if (greyImage[seeds[i, 0] - 1, seeds[i, 1]] == valueSet)
                    {
                        greyImage[seeds[i, 0] - 1, seeds[i, 1]] = valueFill;
                        //seed[0] = seeds[i, 0] - 1;
                        //seed[1] = seeds[i, 1];
                        newSeeds = MatrixOperations.Appendix(newSeeds, seeds[i, 0] - 1, seeds[i, 1]);
                    }
                    if (greyImage[seeds[i, 0] + 1, seeds[i, 1]] == valueSet)
                    {
                        greyImage[seeds[i, 0] + 1, seeds[i, 1]] = valueFill;
                        //seed[0] = seeds[i, 0] + 1;
                        //seed[1] = seeds[i, 1];
                        newSeeds = MatrixOperations.Appendix(newSeeds, seeds[i, 0] + 1, seeds[i, 1]);
                    }
                    if (greyImage[seeds[i, 0], seeds[i, 1] - 1] == valueSet)
                    {
                        greyImage[seeds[i, 0], seeds[i, 1] - 1] = valueFill;
                        //seed[0] = seeds[i, 0];
                        //seed[1] = seeds[i, 1] - 1;
                        newSeeds = MatrixOperations.Appendix(newSeeds, seeds[i, 0], seeds[i, 1] - 1);
                    }
                    if (greyImage[seeds[i, 0], seeds[i, 1] + 1] == valueSet)
                    {
                        greyImage[seeds[i, 0], seeds[i, 1] + 1] = valueFill;
                        //seed[0] = seeds[i, 0];
                        //seed[1] = seeds[i, 1] + 1;
                        newSeeds = MatrixOperations.Appendix(newSeeds, seeds[i, 0], seeds[i, 1] + 1);
                    }
                }
                seeds = RefreshSeeds(newSeeds);
            }
            return greyImage;

        }

        /// <summary>
        /// 返回索引的连续区域填充：mode=true 黑变白；mode=false 白变黑
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="greyImage"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
        private SingleSample ContinuousAreaFill(bool mode, int[,] greyImage, int[] seed)
        {
            SingleSample result = new SingleSample();
            int valueFill = 0, valueSet = 255;
            int[,] seeds = new int[1, 2];
            int[,] newSeeds = null;
            int[] size = new int[2] { greyImage.GetLength(0), greyImage.GetLength(1) };
            greyImage[seed[0], seed[1]] = 0;
            if (mode)
            {
                valueFill = 255;
                valueSet = 0;
                greyImage[seed[0], seed[1]] = 255;
            }
            result.arrayMessage = MatrixOperations.Appendix(result.arrayMessage, size);
            result.arrayMessage = MatrixOperations.Appendix(result.arrayMessage, seed);
            seeds[0, 0] = seed[0]; seeds[0, 1] = seed[1];
            while (seeds != null)
            {
                newSeeds = null;
                for (int i = 0; i < seeds.GetLength(0); i++)
                {
                    if (greyImage[seeds[i, 0] - 1, seeds[i, 1]] == valueSet)
                    {
                        greyImage[seeds[i, 0] - 1, seeds[i, 1]] = valueFill;
                        seed[0] = seeds[i, 0] - 1; seed[1] = seeds[i, 1];
                        result.arrayMessage = MatrixOperations.Appendix(result.arrayMessage, seed);
                        newSeeds = MatrixOperations.Appendix(newSeeds, seed);
                    }
                    if (greyImage[seeds[i, 0] + 1, seeds[i, 1]] == valueSet)
                    {
                        greyImage[seeds[i, 0] + 1, seeds[i, 1]] = valueFill;
                        seed[0] = seeds[i, 0] + 1; seed[1] = seeds[i, 1];
                        result.arrayMessage = MatrixOperations.Appendix(result.arrayMessage, seed);
                        newSeeds = MatrixOperations.Appendix(newSeeds, seed);
                    }
                    if (greyImage[seeds[i, 0], seeds[i, 1] - 1] == valueSet)
                    {
                        greyImage[seeds[i, 0], seeds[i, 1] - 1] = valueFill;
                        seed[0] = seeds[i, 0]; seed[1] = seeds[i, 1] - 1;
                        result.arrayMessage = MatrixOperations.Appendix(result.arrayMessage, seed);
                        newSeeds = MatrixOperations.Appendix(newSeeds, seed);
                    }
                    if (greyImage[seeds[i, 0], seeds[i, 1] + 1] == valueSet)
                    {
                        greyImage[seeds[i, 0], seeds[i, 1] + 1] = valueFill;
                        seed[0] = seeds[i, 0]; seed[1] = seeds[i, 1] + 1;
                        result.arrayMessage = MatrixOperations.Appendix(result.arrayMessage, seed);
                        newSeeds = MatrixOperations.Appendix(newSeeds, seed);
                    }
                }
                seeds = RefreshSeeds(newSeeds);
            }
            result.greyImage = greyImage;
            return result;
        }

        /// <summary>
        /// 图像向四周拓展1像素 拓展像素的值为value
        /// </summary>
        /// <param name="input"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private int[,] Expand(int[,] input,int value)
        {
            int W, H;
            W = input.GetLength(0);
            H = input.GetLength(1);
            int[,] output = new int[W + 2, H + 2];
            for (int i = 0; i < W + 2; i++)
            {
                for (int j = 0; j < H + 2; j++)
                {
                    if (i == 0 || i == W + 1 || j == 0 || j == H + 1)
                    {
                        output[i, j] = value;
                    }
                    else
                    {
                        output[i, j] = input[i - 1, j - 1];
                    }
                }
            }
            return output;
        }

        /// <summary>
        /// 图像从四周缩减number宽像素
        /// </summary>
        /// <param name="input"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        private int[,] Reduce(int[,] input, int number)
        {
            int W, H;
            W = input.GetLength(0);
            H = input.GetLength(1);
            int[,] output = new int[W -2*number, H - 2*number];
            for (int i = 2; i < W -2; i++)
            {
                for (int j = 2; j < H -2; j++)
                {
                    output[i - 2, j - 2] = input[i, j];
                }
            }
            return output;
        }

        private int[,] RefreshSeeds(int[,] input)
        {
            return input;
        }

        /// <summary>
        /// sobel算子边缘识别
        /// </summary>
        /// <param name="grayValues"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        private int[,] SobelEdges(int[,] grayValues, double threshold)
        {
            int W, H;
            double gradX, gradY, grad;
            W = grayValues.GetLength(0);
            H = grayValues.GetLength(1);
            int[,] output = new int[W, H];
            //新建矩阵表示的图像为全部黑色
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    output[i, j] = 0;
                }
            }
            for (int i = 1; i < W - 1; i++)
            {
                for (int j = 1; j < H - 1; j++)
                {
                    gradX = -1 * grayValues[i - 1, j - 1] + 0 * grayValues[i - 1, j] + 1 * grayValues[i - 1, j + 1] +
                              -2 * grayValues[i, j - 1] + 0 * grayValues[i, j] + 2 * grayValues[i, j + 1] +
                              -1 * grayValues[i + 1, j - 1] + 0 * grayValues[i + 1, j] + 1 * grayValues[i + 1, j + 1];

                    gradY = 1 * grayValues[i - 1, j - 1] + 2 * grayValues[i - 1, j] + 1 * grayValues[i - 1, j + 1] +
                              0 * grayValues[i, j - 1] + 0 * grayValues[i, j] + 0 * grayValues[i, j + 1] +
                              -1 * grayValues[i + 1, j - 1] - 2 * grayValues[i + 1, j] - 1 * grayValues[i + 1, j + 1];
   
                    grad = Math.Sqrt(gradX * gradX + gradY * gradY);
                    if (grad > threshold) output[i, j] = 255;//高于阈值的像素点被识别为边缘
                }
            }
            return output;
        }

        /// <summary>
        /// 分离样条：将一张图中多个样条分别提取
        /// </summary>
        /// <param name="greyImage"></param>
        /// <returns></returns>
        private List<int[,]> SeparateSamples(int[,] greyImage)
        {
            List <int[,]> result = new List<int[,]>(); 
            SingleSample a = new SingleSample();
            int[] seed = new int[2];
            while (NewSeedPoint(greyImage))//能够找到白色像素点
            {
                seed[0] = index[0]; seed[1] = index[1];
                a = ContinuousAreaFill(false, greyImage, seed);
                greyImage = a.greyImage;
                result = ListAdd(result, a.arrayMessage);
            }
            return result;
        }

        /// <summary>
        /// 样条分离找寻新的种子点
        /// </summary>
        /// <param name="greyImage"></param>
        /// <returns></returns>
        private bool NewSeedPoint(int[,] greyImage)
        {
            //Figure figure = new Figure();
            //figure.pictureBox.Image = imageShow.Imshow(greyImage);
            //figure.Show();
            for (int i = index[0]; i < greyImage.GetLength(0); i++)
            {
                for (int j = 0; j < greyImage.GetLength(1); j++)
                {
                    if (greyImage[i, j] == 255)
                    {
                        index[0] = i; index[1] = j;
                        return true;
                    }                        
                }
            }
            return false;
        }

        /// <summary>
        /// List附加
        /// </summary>
        /// <param name="input"></param>
        /// <param name="newItem"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 删除大样块及靠近边缘的样品
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private List<int[,]> DeleteBucksAndSidelines(List<int[,]> input)
        {
            for (int i = input.Count - 1; i >= 0; i-- )
            {
                if (IsBuckOrLineNearSides(input[i]))
                {
                    AutoDetect.Barriers = ListAdd(AutoDetect.Barriers, input[i]);
                    input.RemoveAt(i);                 
                }
            }
            return input;
        }

        /// <summary>
        /// 判断是否为样块或靠近边缘的样条
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool IsBuckOrLineNearSides(int[,] item)
        {
            //小于25像素的样品认为是杂物不识别
            if (item.GetLength(0) <= 25)
            {
                return true;
            }
            else
            {
                int xMax=0, yMax=0, xMin=item[0,0], yMin=item[0,1];
                for (int i = 1; i < item.GetLength(0); i++)
                {
                    if (item[i, 0] < xMin) xMin = item[i, 0];
                    if (item[i, 0] > xMax) xMax = item[i, 0];
                    if (item[i, 1] < yMin) yMin = item[i, 1];
                    if (item[i, 1] > yMax) yMax = item[i, 1];
                }
                // 样品像素数大于包含样品的最小矩阵面积的0.7认为是样块而非样条
                if ((double)item.GetLength(0) / (double)((xMax - xMin + 1) * (yMax - yMin + 1)) >= 0.7)
                {
                    return true;
                }
                else if (xMax == item[0, 0] - 2 || xMax == item[0, 0] - 1 || xMin == 0 || xMin == 1 || 
                    yMax == item[0, 1] - 2 || yMax == item[0, 1] - 1 || yMin == 0 || yMin == 1)//靠近边缘：边缘两像素有白色像素
                {
                    return true;
                }
                else { return false; }
            }
        }

        /// <summary>  
        /// Hilditch细化算法  
        /// </summary>  
        /// <param name="input"></param>  
        /// <returns></returns>  
        public int[,] ThinnerHilditch(int[,] input)
        {
            int lWidth = input.GetLength(0);
            int lHidth = input.GetLength(1);

            bool IsModified = true;
            int[] value = new int[9];
            int[] t = new int[2];
            int[,] delete = null;
            //去掉边框像素  
            for (int i = 0; i < lWidth; i++)
            {
                input[i, 0] = 0;
                input[i, lHidth - 1] = 0;
            }
            for (int j = 0; j < lHidth; j++)
            {
                input[0, j] = 0;
                input[lWidth - 1, j] = 0;
            }
            do
            {
                IsModified = false;
                int[,] struct3_3 = new int[3, 3];
                for (int i = 1; i < lWidth; i++)
                {
                    for (int j = 1; j < lHidth; j++)
                    {
                        //条件1必须为黑点  
                        if (input[i, j] != 255) continue;

                        //取3*3领域  
                        for (int m = 0; m < 3; m++)
                        {
                            for (int n = 0; n < 3; n++)
                            {
                                struct3_3[m, n] = input[i - 1 + m, j - 1 + n];
                            }
                        }

                        //复制  
                        value[0] = struct3_3[1, 2] == 255 ? 0 : 1;
                        value[1] = struct3_3[0, 2] == 255 ? 0 : 1;
                        value[2] = struct3_3[0, 1] == 255 ? 0 : 1;
                        value[3] = struct3_3[0, 0] == 255 ? 0 : 1;
                        value[4] = struct3_3[1, 0] == 255 ? 0 : 1;
                        value[5] = struct3_3[2, 0] == 255 ? 0 : 1;
                        value[6] = struct3_3[2, 1] == 255 ? 0 : 1;
                        value[7] = struct3_3[2, 2] == 255 ? 0 : 1;
                        value[8] = value[0];

                        // 条件2：p0,p2,p4,p6 不皆为前景点   
                        if (value[0] == 0 && value[2] == 0 && value[4] == 0 && value[6] == 0) continue;

                        // 条件3: p0~p7至少两个是前景点   
                        int iCount = 0;
                        for (int ii = 0; ii < 8; ii++)
                        {
                            iCount += value[ii];
                        }
                        if (iCount > 6) continue;

                        // 条件4：联结数等于1   
                        if (DetectConnectivity(value) != 1) continue;

                        // 条件5: 假设p2已标记删除，则令p2为背景，不改变p的联结数
                        t[0] = i - 1; t[1] = j;
                        if (MatrixOperations.FindIndex(delete, t))
                        {
                            value[2] = 1;
                            if (DetectConnectivity(value) != 1)
                                continue;
                            value[2] = 0;
                        }
                        // 条件6: 假设p4已标记删除，则令p4为背景，不改变p的联结数 
                        t[0] = i; t[1] = j - 1;
                        if (MatrixOperations.FindIndex(delete, t))
                        {
                            value[4] = 1;
                            if (DetectConnectivity(value) != 1)
                                continue;
                            value[4] = 0;
                        }

                        t[0] = i; t[1] = j;
                        delete = MatrixOperations.Appendix(delete, t);
                        IsModified = true;
                    }
                }
                if (delete != null)
                {
                    input = ThinnerOnce(input, delete);
                    delete = null;
                }
                
            } while (IsModified);

            return input;
        }

        private int DetectConnectivity(int[] value)
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                count += value[2 * i] - value[2 * i] * value[2 * i + 1] * value[2 * i + 2];
            }
            return count;
        }
        /// <summary>
        /// 进行一次图像细化，减薄一层像素
        /// </summary>
        /// <param name="greyImage"></param>
        /// <param name="delete"></param>要删除的像素点
        /// <returns></returns>
        private int[,] ThinnerOnce(int[,] greyImage,int[,] delete)
        {
            for (int i = 0; i < delete.GetLength(0); i++)
            {
                greyImage[delete[i, 0], delete[i, 1]] = 0;
            }
            return greyImage;
        }

        /// <summary>
        /// 判断样条是否有分支
        /// 八联通像素为白色个数为1的点的数目大于两个被识别为有分支的样条
        /// </summary>
        /// <param name="thinResult"></param>
        /// <returns></returns>
        private bool WithBranches(int[,] greyImage)
        {
            int count, iCount = 0;
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
                                    count += 1;
                            }
                        }
                        if (count == 2)
                        {
                            iCount += 1;
                        }
                    }
                }
            }
            if (iCount==2)
                return false;
            else
                return true;
        }

    }
}
