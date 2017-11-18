using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;

namespace MultiMode.Nanomanipulation
{
    /// <summary>
    /// 图像数据读取类
    /// </summary>
    class ImageDataExtraction
    {
        string nextLine;//一行字符串
        int dataOffset, dataLength, bytesPerPixel;//dataOffset:数据位置;dataLength:数据长度
        public int sampsInLine, numberOfLines;//sampsInLine：图像每行包含的数据个数；numberOfLines：图像行数
        double hardValue, softValue;
        public double scanSize;//图像行实际尺寸
        public double minValue, maxValue;//图像数据最小值和最大值
        public bool isAFMFile;

        public ImageDataExtraction()
        {
            minValue = 0;
            maxValue = 0;
            isAFMFile = true;
        }

        /// <summary>
        /// 字符串查找，返回第一次索引
        /// </summary>
        /// <param name="sr"></param>
        /// <param name="findStr"></param>
        /// <returns></returns>
        private int HeaderFind(StreamReader sr, String findStr)
        {
            nextLine = sr.ReadLine();
            if (nextLine != null)
                return nextLine.IndexOf(findStr);
            else
                return -2;
        }

        public double [,] DataExtract(String fileName)
        {
            StreamReader sr = new StreamReader(@fileName);
            int indexOfStr;
            int processNum = 0;
            // soft value 提取
            while (processNum == 0)
            {
                indexOfStr = HeaderFind(sr, "\\@Sens. ZsensSens:");
                if (indexOfStr != -1)
                {
                    if (indexOfStr == -2)
                    {
                        MessageBox.Show("Not an AFM Picture!");
                        isAFMFile = false;
                        break;
                    }                        
                    else
                    {
                        int idxStart = nextLine.LastIndexOf(" ");
                        String str;
                        nextLine = nextLine.Substring(0, idxStart);
                        idxStart = nextLine.LastIndexOf(" ");
                        str = nextLine.Substring(idxStart, nextLine.Length - idxStart);
                        //MessageBox.Show(str);
                        softValue = Convert.ToDouble(str);
                        processNum += 1;
                    }
                }
            }
            //data offset 提取
            while (processNum == 1)
            {
                indexOfStr = HeaderFind(sr, "\\Data offset:");
                if (indexOfStr != -1)
                {         
                    processNum += 1;
                    //MessageBox.Show(nextLine.Substring(13));
                    dataOffset = Convert.ToInt32(nextLine.Substring(13));
                }
            }
            // data length 提取
            while (processNum == 2)
            {
                indexOfStr = HeaderFind(sr, "\\Data length:");
                if (indexOfStr != -1)
                {
                    processNum += 1;
                    //MessageBox.Show(nextLine.Substring(14));
                    dataLength = Convert.ToInt32(nextLine.Substring(14));
                }
            }
            // bytesPerPixel 提取
            while (processNum == 3)
            {
                indexOfStr = HeaderFind(sr, "\\Bytes/pixel:");
                if (indexOfStr != -1)
                {
                    processNum += 1;
                    //MessageBox.Show(nextLine.Substring(14));
                    bytesPerPixel = Convert.ToInt32(nextLine.Substring(14));
                }
            }
            // sampsInLine 提取
            while (processNum == 4)
            {
                indexOfStr = HeaderFind(sr, "\\Samps/line:");
                if (indexOfStr != -1)
                {
                    processNum += 1;
                    //MessageBox.Show(nextLine.Substring(13));
                    sampsInLine = Convert.ToInt32(nextLine.Substring(13));
                    numberOfLines = dataLength / sampsInLine / bytesPerPixel;
                }
            }
            //scan size 提取
             while (processNum == 5)
            {
                indexOfStr = HeaderFind(sr, "\\Scan Size:");
                if (indexOfStr != -1)
                {
                    int idxStart = nextLine.LastIndexOf(" ");
                    String str;
                    nextLine = nextLine.Substring(0, idxStart);
                    idxStart = nextLine.LastIndexOf(" ");
                    str = nextLine.Substring(idxStart, nextLine.Length - idxStart);
                    //MessageBox.Show(str);
                    scanSize = Convert.ToDouble(str);                   
                    processNum += 1;
                }
            }
            // hard value 提取
            while (processNum == 6)
            {
                indexOfStr = HeaderFind(sr, "\\@2:Z scale:");
                if (indexOfStr != -1)
                {
                    int idxStart = nextLine.LastIndexOf(" ");
                    String str;
                    nextLine = nextLine.Substring(0, idxStart);
                    idxStart = nextLine.LastIndexOf(" ");
                    str = nextLine.Substring(idxStart, nextLine.Length-idxStart);
                    //MessageBox.Show(str);
                    hardValue = Convert.ToDouble(str);
                    hardValue = hardValue / 65536;
                    processNum += 1;
                }
            }
            //image data 提取
            sr.Close();
            if (processNum == 7)
            {
                double[,] dataArr = new double[sampsInLine, numberOfLines];
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                Int16 byt;
                fs.Seek(dataOffset, SeekOrigin.Begin);
                for (int i = 0; i < numberOfLines; i++)
                {
                    for (int j = 0; j < sampsInLine; j++)
                    {
                        byt = br.ReadInt16();//2字节为一个数据
                        if (Convert.ToDouble(byt) * hardValue * softValue < minValue)
                            minValue = Convert.ToDouble(byt) * hardValue * softValue;
                        if (Convert.ToDouble(byt) * hardValue * softValue > maxValue)
                            maxValue = Convert.ToDouble(byt) * hardValue * softValue;
                        dataArr[j, i] = Convert.ToDouble(byt) * hardValue * softValue;
                    }
                }
                fs.Close();
                return dataArr;//返回原始图像数据               
             }
            return null;
        }
    }
}