using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using MultiMode.Nanoman;

namespace MultiMode.Nanomanipulation
{
    public partial class AutoDetect : Form
    {
        //dataArr：从AFM原始文件读取的图像数据构成的矩阵
        double [,] _dataArr;
        /// <summary>
        /// maxValue:dataArr所有数据中的最大值
        /// minValue:dataArr所有数据中的最小值
        /// edgeThreshold:sobel算子边缘识别的阈值
        /// AFM 图像尺寸：xSize为x轴方向尺寸，ySize为y轴方向尺寸。单位为微米(um)
        /// </summary>
        private double _maxValue, _minValue, _edgeThreshold;
        public static double _xSize = 0, _ySize = 0;
        // pictureType:显示图像的格式（灰度、彩虹、铁红色等）
        public static string pictureType;
        // 区分软纳米线与硬纳米线的阈值
        public static double softOrStiff;
        // sampsInline：AFM图像数据一行的数据个数
        // numberOfLines：AFM图像数据行数
        public static int _sampsInLine, _numberOfLines;
        //imageShow: 用于图像显示的对象
        private DisplayImage imageShow = new DisplayImage();
        //matirx：用于矩阵运算的对象
        //morphology: 用于图像形态学操作的对象
        private MorphologyTransform morphology = new MorphologyTransform();
        //linesFit:用于纳米线线性拟合的对象
        private LinearFit linesFit = new LinearFit();
        //用于图像由灰度变为伪彩色的对象
        private GreyToColor gToC = new GreyToColor();
        //全部纳米线信息
        public static List<Nanowires> allWires = new List<Nanowires>();
        //greyImage灰度图像,colorImage伪彩色图像
        public Bitmap greyImage, colorImage;
        //鼠标目前的位置坐标
        private PointF currentPoint = new Point(0, 0), pointFor_showPictureBox , _currentPointOfshowPicB;
        //鼠标取点使能，取点时光标变为十字
        private bool _readyToMove, _getshowPictureBoxDistance;
        //取点模式 选取新的纳米线，或者确定目标位置
        private int _getPointMode;
        //障碍物的List
        public static List<int[,]> Barriers = new List<int[,]>();
        //纳米线列表信息类
        ListMessage listOfWires = new ListMessage();
        // 手动添加纳米线的段数
        private int numberOfSegments, staticNumber;
        // 手动添加纳米线的点集
        PointF[] newPoints;
        //路径规划顺序
        public static OrderPlanning order;

        public AutoDetect()
        {
            InitializeComponent();

            SizeArrange();

            pictureType = "Iron";//在开启软件时显示图像的模式为铁红
            _edgeThreshold = 100;//在开启软件时边缘识别的阈值为100
            softOrStiff = 5;//开启软件时判断纳米线为软硬的长径比阈值为5
            Initial();//初始化
           
            //初始化路径参数
            SavePath.Initial(
                80, 0.2,
                200, 10,
                0.02, 0.1,
                0.1, 0.02);
            SavePath.isSet = false;

            ///如果存在其他实验中已经打开图像，则直接打开该图像
            if (ModeSelect.AFMPicturePath != null)
            {
                string str = ModeSelect.AFMPicturePath;
                ImageDataExtraction imDataEx = new ImageDataExtraction();
                _dataArr = imDataEx.DataExtract(str);//提取原始图像的数据
                _maxValue = imDataEx.maxValue;//图像数据最大值
                _minValue = imDataEx.minValue;//图像数据最小值
                _sampsInLine = imDataEx.sampsInLine;//图像每行数据个数
                _numberOfLines = imDataEx.numberOfLines;//图像数据行数
                greyImage = imageShow.Imshow(_dataArr, _minValue, _maxValue);//从原始图像数据计算灰度图像
                _xSize = imDataEx.scanSize;//图像x轴方向大小
                _ySize = imDataEx.scanSize * (double)imDataEx.numberOfLines / (double)imDataEx.sampsInLine;//图像y方向大小
                RenewPicture();//刷新picturebox中显示的图像  
                currentFigureToolStripMenuItem.Enabled = true;
            }
            else
            {
                currentFigureToolStripMenuItem.Enabled = false;
                planPanel.Enabled = false;
            }

        }

        /// <summary>
        /// 设置各个控件位置和尺寸
        /// </summary>
        private void SizeArrange()
        {
            picturePanel.Location = new Point(20, 50);
            picturePanel.Size = new Size(500, 500);

            picturePanel1.Location = new Point(550, 50);
            picturePanel1.Size = new Size(500, 500);

            Ymax.Location = new Point(525, 50);
            Y0.Location = new Point(525, 298);
            Ymin.Location = new Point(525, 496);

            MXmin.Location = new Point(550, 550);
            MXmax.Location = new Point(1035, 550);
            MX0.Location = new Point(790, 550);

            planPanel.Location = new Point(1060, 50);
        }

        /// <summary>
        /// 初始化函数
        /// </summary>
        private void Initial()
        {
            planPanel.Enabled = true;//使能planPannel
            nanowiresList.Items.Clear();//清空list内显示内容
            newPoints = null;//鼠标取点内容清空
            _getPointMode = 0;//取点模式设置为0，即不做任何事
            allWires = new List<Nanowires>(0);//纳米线信息清空
            _readyToMove = false;//取消准备移动
            _getshowPictureBoxDistance = false;//清选取距离标志
            reselectLastPoint.Enabled = false;//删除上一个菜单禁用
            reselect.Enabled = false;//删除全部菜单禁用
            apply.Enabled = false;//准备完毕菜单禁用
            abandon.Enabled = false;//退出菜单禁用
            identify.Enabled = true;//识别按钮使能
            addNewLine.Enabled = true;//添加新的纳米线按钮使能
            deleteButton.Enabled = true;//删除按钮使能
            compute.Enabled = false;//计算按钮禁用
            setTarget.Enabled = false;//确定目标位置按钮禁用
            clearShowPicBox.Enabled = false; //clearShowPicBox上下文菜单禁用
            nanowiresList.SelectionMode = SelectionMode.MultiExtended;//NanowiresList选择模式为多选
            orderTextBox.Text = null;//清空顺序文本内容
            simulateToolStripMenuItem.Enabled = false;//动态显示右键菜单禁用
            displayPictureBox.Visible = false;
            currentFigureToolStripMenuItem.Enabled = true;
            planPanel.Enabled = true;
        }

        /// <summary>
        /// 打开文件并显示图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //读取初始文件路径
            string str;
            FileStream fs = new FileStream("AFM FigurePath.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            str = sr.ReadLine();
            sr.Close();
            fs.Close();

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件，这里每次只能打开一张AFM图像文件
            dialog.Title = "Please select a file";
            dialog.Filter = "All files(*.*)|*.*";
            dialog.InitialDirectory = str;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Initial();
                string file = dialog.FileName;

                //imDataEx：用于从文件中抽取数据的对象
                ImageDataExtraction imDataEx = new ImageDataExtraction();
                _dataArr = imDataEx.DataExtract(file);//提取原始图像的数据
                if (imDataEx.isAFMFile)
                {
                    ModeSelect.AFMPicturePath = dialog.FileName;

                    _maxValue = imDataEx.maxValue;//图像数据最大值
                    _minValue = imDataEx.minValue;//图像数据最小值
                    _sampsInLine = imDataEx.sampsInLine;//图像每行数据个数
                    _numberOfLines = imDataEx.numberOfLines;//图像数据行数
                    greyImage = imageShow.Imshow(_dataArr, _minValue, _maxValue);//从原始图像数据计算灰度图像
                    _xSize = imDataEx.scanSize;//图像x轴方向大小
                    _ySize = imDataEx.scanSize * (double)imDataEx.numberOfLines / (double)imDataEx.sampsInLine;//图像y方向大小
                    RenewPicture();//刷新picturebox中显示的图像
                    //刷新初始文件路径
                    str = dialog.FileName;
                    StreamWriter sw= new StreamWriter("AFM FigurePath.txt");
                    sw.WriteLine(str.Substring(0, str.LastIndexOf('\\')));
                    sw.Close();
                }            
            }
        }

        /// <summary>
        /// 刷新showPictureBox和movePictureBox中的图像
        /// </summary>
        private void RenewPicture()
        {
            //picturePanel.Width = 500;
            //picturePanel.Height = 500;
            //picturePanel1.Width = 500;
            //picturePanel1.Height = 500;
            ///////////////////设置PictureBox的大小，宽度为650像素固定值
            showPictureBox.Size = new Size(picturePanel.Width, picturePanel.Width / (_sampsInLine / _numberOfLines));
            showPictureBox.Location= new Point (0, picturePanel.Height / 2 - (int)(picturePanel.Width / (_sampsInLine / _numberOfLines) / 2));
            movePictureBox.Size = new Size(picturePanel.Width, picturePanel.Width / (_sampsInLine / _numberOfLines));
            movePictureBox.Location = new Point(0, picturePanel.Height / 2 - (int)(picturePanel.Width / (_sampsInLine / _numberOfLines) / 2));
            colorImage = gToC.PGrayToColor(greyImage, pictureType);
            showPictureBox.BackgroundImage = imageShow.ResizeImage(colorImage, movePictureBox.Width, movePictureBox.Width * _numberOfLines / _sampsInLine);
            movePictureBox.Image = colorImage;
            ////////////////////坐标轴信息标注////////////////////////
            MXmax.Text = Convert.ToString(_xSize / 2);
            MXmin.Text = "-" + Convert.ToString(_xSize / 2);
            Ymax.Text = Convert.ToString(_ySize / 2);
            Ymin.Text = "-" + Convert.ToString(_ySize / 2);
            Ymax.Location = new Point(Ymax.Location.X, picturePanel.Location.Y + showPictureBox.Location.Y);
            Ymin.Location = new Point(Ymin.Location.X, picturePanel.Location.Y + picturePanel.Height - showPictureBox.Location.Y - Ymin.Height);
            /////////////////////////////////////////////////////////
        }

        /// <summary>
        /// 菜单栏Parameter下Picture按下回调函数：图像显示模式设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// File菜单栏下Reset按下回调函数：是否复位图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (greyImage != null)
            {
                if (MessageBox.Show("Sure to reset the picture?", "Tips", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    RenewPicture();//刷新图像
                    Initial();//初始化
                }
            }            
        }

        /// <summary>
        /// Identify按钮按下回调函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Identify_Click(object sender, EventArgs e)
        {
            int[,] arrayTrans;
            List<int[,]> skeleton = new List<int[,]>();
            List<PointF[]> points = new List<PointF[]>();

            //pB.Value = 0;
            //pB.Value = 10;

            morphology.Reset();//形态学处理初始化，索引值位置设置为初始点[0,0]
            Barriers = new List<int[,]>();//保存障碍物的信息
            arrayTrans = imageShow.GetMatric(_dataArr, _minValue, _maxValue);//获得整数类型的图像数据
            //pB.Value = 20;
            skeleton = morphology.MainDetect(arrayTrans, _edgeThreshold);//图像形态学提取骨架
            //pB.Value = 60;
            points = linesFit.MainDetect(skeleton);//对全部骨架进行直线拟合
            //pB.Value = 80;

            allWires = new List<Nanowires>(0);
            //获取全部纳米线的信息
            foreach (PointF[] a in points)
            {
                int n = points.IndexOf(a);
                Nanowires wire = new Nanowires(_dataArr, a, skeleton[n], _sampsInLine, _xSize);
                allWires.Add(wire);
            }

            movePictureBox.Image = imageShow.ShowSamples(allWires, greyImage, pictureType, _numberOfLines);//显示识别结果

            RefreshNanowiresList(listOfWires.GetMessage(allWires));//NanowireList刷新
        }

        /// <summary>
        /// Parameter->Egde->Sobel
        /// sobel边缘识别算法阈值调整参数设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SobelThreshold edgeForm = new SobelThreshold();//新建边缘识别对话框
            edgeForm.StartPosition = FormStartPosition.CenterParent;
            edgeForm.trackBar.Value = (int)_edgeThreshold;
            edgeForm.tvalue.Text = Convert.ToString(_edgeThreshold);
            edgeForm.tvalue.ReadOnly = true;
            edgeForm.ShowDialog();
            if (edgeForm.refresh)
            {
                _edgeThreshold = (double)edgeForm.trackBar.Value;//刷新边缘识别的阈值
            }
            edgeForm.Dispose();//释放edgeForm内存，清除对话框
        }

        /// <summary>
        /// File->Close
        /// 图像显示关闭，关闭文件，清空全部变量，恢复软件启动状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to exit?", "Tips", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Dispose();
            }
        }

        /// <summary>
        /// 刷新NanowiresList内容
        /// </summary>
        /// <param name="list"></param>
        private void RefreshNanowiresList(List<string> list)
        {
            nanowiresList.Items.Clear();//先清空
            //再逐条添加
            for (int i=0;i<list.Count;i++)
                nanowiresList.Items.Add(list[i]);
        }

        /// <summary>
        /// movePictureBox 内鼠标移动时间相应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void movePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_getPointMode > 0)//如果取点模式有意义，激活光标为十字
            {
                movePictureBox.Cursor = Cursors.Cross;//光标为十字
                currentPoint = new Point(e.X, e.Y);//刷新当前点的坐标     
            }   
            else
                movePictureBox.Cursor = Cursors.Default;//否则光标默认
            //取点模式为设置纳米线最终的移动位置，且已经选中了一个点，刷新图像显示，跟随光标移动目标纳米线围绕已经确定的点旋转
            if (_getPointMode == 2 && numberOfSegments == 0)
            {
                movePictureBox.Invalidate();
            }
        }

        /// <summary>
        /// movePictureBox鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void movePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (_getPointMode == 1)//取点模式为选取新的纳米线
            {
                if (e.Button == MouseButtons.Left)//鼠标左击完成取点操作
                {
                    if (numberOfSegments >= 0)
                    {
                        if (reselectLastPoint.Enabled == false)//鼠标点下证明有取点，如果deleteLast菜单选项未被激活则激活deleteLast和deleteAll菜单选项
                        {
                            reselectLastPoint.Enabled = true;
                            reselect.Enabled = true;
                        }
                        numberOfSegments -= 1;//需要继续取点的个数减1
                        //currentPoint = new Point(e.X, e.Y);//刷新当前保存点的位置
                        GetRealPoints();//获取真实坐标
                        newPoints = MatrixOperations.Appendix(newPoints, currentPoint);//添加新的点
                        movePictureBox.Image = imageShow.ShowSamples(allWires, greyImage, pictureType, _numberOfLines, newPoints);//刷新图像显示
                        if (numberOfSegments < 0)//选取全部点后激活ready菜单选项
                            apply.Enabled = true;
                    }
                }
            }
            else if (_getPointMode == 2)
            {
                if (e.Button == MouseButtons.Left)//鼠标左击完成取点操作
                {
                    if (numberOfSegments >= 0)
                    {
                        if (reselectLastPoint.Enabled == false)
                        {
                            reselectLastPoint.Enabled = true;
                            reselect.Enabled = true;
                        }
                        currentPoint = new Point(e.X, e.Y);
                        //第一个点为鼠标点击的落下点，第二个点需要计算
                        if (numberOfSegments == 1)
                        {
                            newPoints = MatrixOperations.Appendix(newPoints, currentPoint);
                        }
                        else
                        {
                            double l =allWires[nanowiresList.SelectedIndex].length* _sampsInLine/ _xSize / 1000;
                            PointF another = MathCalculate.GetPointToShow(newPoints[0].X, newPoints[0].Y, l, currentPoint, (double)movePictureBox.Width / (double)_sampsInLine);
                            newPoints = MatrixOperations.Appendix(newPoints, another);
                        }
                        numberOfSegments -= 1;
                        if (numberOfSegments < 0)
                            apply.Enabled = true;
                    }
                }
            }
        }
        /// <summary>
        /// 鼠标取点并不对应图中真正的点，这是由于图像显示有缩放的过程，这个函数获取实际像素位置
        /// </summary>
        private void GetRealPoints()
        {
           //X,Y等比例缩放，Y值关于X轴为对称轴对调
            currentPoint.X = currentPoint.X / movePictureBox.Width * _sampsInLine;
            currentPoint.Y = currentPoint.Y / movePictureBox.Width * _sampsInLine;
            currentPoint.Y = _numberOfLines - 1 - currentPoint.Y;
        }
        //这是有输入的情况，用在纳米线目标位置的确定函数中
        private PointF  GetRealPoints(PointF p)
        {
            p.X = p.X / movePictureBox.Width * _sampsInLine;
            p.Y = p.Y / movePictureBox.Width * _sampsInLine;
            p.Y = _numberOfLines - 1 - p.Y;
            return p;
        }

        /// <summary>
        /// AddNewLine 按钮按下响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewLine_Click(object sender, EventArgs e)
        {
            numberOfSegments = 0;
            BendTimes form = new BendTimes();//获取所要新添加纳米线的线段个数
            form .StartPosition = FormStartPosition.CenterParent;//居中显示
            form.ShowDialog();//打开添加新纳米线对话框
            if (form.value > 0)
            {
                numberOfSegments = form.value;//确定需要添加的段数
                staticNumber = form.value;//这个参数赋值过后不会改变，用于后续的比较
                _getPointMode = 1;//鼠标取点模式设置为1，即选取新纳米线的模式
                abandon.Enabled = true;
            }
            form.Dispose();//清除form，释放内存   
        }

        /// <summary>
        /// 软硬纳米线判断阈值调整
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void softStiffThresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoftOrStiff form = new SoftOrStiff(softOrStiff);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
            form.Dispose();
            listOfWires.RefreshWires(allWires);//刷新全部纳米线的信息
            RefreshNanowiresList(listOfWires.GetMessage(allWires));//刷新NanowiresList显示内容
        }

        /// <summary>
        /// 删除按钮按下删除选择的纳米线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (nanowiresList.SelectedIndices.Count > 0)
            {
                int l = nanowiresList.SelectedIndices.Count;
                int[] indexOfItems = new int[l];

                for (int i = 0; i < l; i++)//获取被选中删除的纳米线索引
                    indexOfItems[i] = nanowiresList.SelectedIndices[i];

                listOfWires.Delete(allWires, indexOfItems);//删除选中的纳米线
                RefreshNanowiresList(listOfWires.GetMessage(allWires));//刷新NanowiresList显示的内容
                movePictureBox.Image = imageShow.ShowSamples(allWires, greyImage, pictureType, _numberOfLines);//刷新movePictureBox显示的图像
            }  
        }

        /// <summary>
        /// 上下文菜单 MouseGetPoint -> Delete Last
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteLastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newPoints = MatrixOperations.CutLast(newPoints);//减掉上一个选取的点
            numberOfSegments += 1;//需要选取的点的个数加一
            apply.Enabled = false;//ready菜单选项禁用
            if (_getPointMode == 1)//添加新样条模式
            {
                movePictureBox.Image = imageShow.ShowSamples(allWires, greyImage, pictureType, _numberOfLines, newPoints);//刷新图像显示
                if (numberOfSegments == staticNumber)//如果不能继续删除点了，则deleteAll,deleteLast菜单选项禁用
                {
                    reselect.Enabled = false;
                    reselectLastPoint.Enabled = false;
                }
            }
            else if (_getPointMode == 2)//确定目标位置模式
            {
                if (numberOfSegments == 1)//不能继续删除了
                {
                    movePictureBox.Image = null;//清空图像显示
                    reselect.Enabled = false;
                    reselectLastPoint.Enabled = false;
                }
            }
            
        }

        /// <summary>
        /// 上下文菜单 MouseGetPoint -> Ready 对所选纳米线满意，添加为新纳米线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ready_Click(object sender, EventArgs e)
        {
            if (_getPointMode == 1)
            {
                addNewLine.Enabled = true;//添加纳米线按钮使能
                identify.Enabled = true;
                deleteButton.Enabled = true;
                apply.Enabled = false;//ready菜单不使能
                abandon.Enabled = false;//exit菜单不使能
                reselectLastPoint.Enabled = false;//deleteLast菜单不使能
                reselect.Enabled = false;//deleteAll菜单不使能
                _getPointMode = 0;
                Nanowires newWire = new Nanowires(_dataArr, newPoints, _sampsInLine, _xSize);//添加新的纳米线信息
                newPoints = null;
                allWires.Add(newWire);//加入allWires列表
                RefreshNanowiresList(listOfWires.GetMessage(allWires));//刷新list显示
            }
            else if (_getPointMode == 2)
            {
                apply.Enabled = false;//ready菜单不使能
                abandon.Enabled = false;//exit菜单不使能
                reselectLastPoint.Enabled = false;//deleteLast菜单不使能
                reselect.Enabled = false;//deleteAll菜单不使能
                _getPointMode = 0;
                //给对应的纳米线设置目标位置
                allWires[nanowiresList.SelectedIndex].SetTarget(GetRealPoints(newPoints[0]),GetRealPoints(newPoints[1]));
                //改变movePictureBox背景图像的显示
                movePictureBox.Image = null;
                movePictureBox.BackgroundImage = imageShow.ResizeImage(imageShow.ShowSamples(allWires, greyImage, _numberOfLines),
                    movePictureBox.Width, movePictureBox.Width * _numberOfLines / _sampsInLine);
                newPoints = null;
                setTarget.Enabled = false;//setTarget按钮禁用
                bool okToRule = true;
                foreach (Nanowires wire in allWires)
                {
                    if (!wire.targetWire.getValue)
                    {
                        okToRule = false;
                        break;
                    }       
                }
                if (okToRule)
                    compute.Enabled = true;
            }
            
        }

        /// <summary>
        /// 上下文菜单 MouseGetPoint -> Delete All 删除全部选取的点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteAll_Click(object sender, EventArgs e)
        {
            apply.Enabled = false;//ready菜单选项禁用
            reselectLastPoint.Enabled = false;//deleteLast菜单选项禁用
            reselect.Enabled = false;//deleteAll菜单选项禁用
            newPoints = null;
            if (_getPointMode == 1)
            {
                numberOfSegments = staticNumber;//取点的个数置位
                movePictureBox.Image = imageShow.ShowSamples(allWires, greyImage, pictureType, _numberOfLines, newPoints);//刷新图像
            }
            else if (_getPointMode == 2)
            {  
                numberOfSegments = 1;//取点的个数置位
                movePictureBox.Image = null;//清空图像显示
            }
            
        }

        /// <summary>
        /// NanowiresList 鼠标右键确定下拉菜单的使能情况
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NanowiresList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (nanowiresList.SelectedIndices.Count != 1)//没有选取任何点的时候全部singleWireMove菜单禁用
                    singleWireMove.Enabled = false;
                else 
                    singleWireMove.Enabled = true;
            }
        }

        /// <summary>
        /// 属性菜单点击函数 SingleWireMove -> Properties
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void propertiesMenu(object sender, EventArgs e)
        {
            ChangeWireProperties form = new ChangeWireProperties();
            form.StartPosition = FormStartPosition.CenterParent;
            form.Initial(nanowiresList.SelectedIndices[0]);
            form.ShowDialog();
            if (form.refresh)//对选中纳米线的信息进行更新
            {
                allWires[nanowiresList.SelectedIndices[0]].diameter = Convert.ToDouble(form.textBox.Text);//更新直径
                allWires[nanowiresList.SelectedIndices[0]].softOrStiff = form.SoftOrStiff.Text;//更新soft或stiff性质
                allWires[nanowiresList.SelectedIndices[0]].GetDivision();//重新计算长径比
                allWires[nanowiresList.SelectedIndices[0]].SetRotatingPointPosition(Convert.ToDouble(form.rotationPivot.Text));
                RefreshNanowiresList(listOfWires.GetMessage(allWires));//刷新NanowiresList显示内容
            }
            form.Dispose();//form删除，释放内存
        }
        /// <summary>
        /// 上下文菜单 MouseGetPoint -> exit 放弃该次取样
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit_Click(object sender, EventArgs e)
        {
            apply.Enabled = false;//ready菜单选项禁用
            reselectLastPoint.Enabled = false;//deleteLast菜单选项禁用
            reselect.Enabled = false;//deleteAll菜单选项禁用
            abandon.Enabled = false;//exit菜单选项禁用
            newPoints = null;//清空全部已经选取的点
            if (_getPointMode == 1)//取点模式为确定新纳米线
            {
                addNewLine.Enabled = true;//addNewLine按钮使能
                identify.Enabled = true;//identify按钮使能
                deleteButton.Enabled = true;//deleteButton按钮使能

                movePictureBox.Image = imageShow.ShowSamples(allWires, greyImage, pictureType, _numberOfLines);//刷新图像
            }
            else if (_getPointMode == 2)//取点模式为确定目标位置
            {
                setTarget.Enabled = false;//setTarget按钮使能

                movePictureBox.Image = null;//清空图像显示
            }
            _getPointMode = 0;//取点模式为不取点
        }

        /// <summary>
        /// setTarget 按钮被按下执行的函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setTarget_Click(object sender, EventArgs e)
        {
            numberOfSegments = 1;//设置获取线的段数为1，因为确定目标位置均为单一线段

            _getPointMode = 2;//表示目前取点的模式为选定目标位置
            abandon.Enabled = true;//退出菜单使能，表示可以退出该次纳米线目标位置的确定
            compute.Enabled = false;//路径规划计算按钮禁用

            allWires[nanowiresList.SelectedIndex].ClearTarget();//对于选中的纳米线清除已经确定的目标位置，因为此时点下按钮后需要对该纳米线选定新的目标位置
            //清空前景图像Image，刷新movePictureBox的背景图像
            movePictureBox.Image = null;
            movePictureBox.BackgroundImage = imageShow.ResizeImage(imageShow.ShowSamples(allWires, greyImage, _numberOfLines),
                movePictureBox.Width, movePictureBox.Width * _numberOfLines / _sampsInLine);

            orderTextBox.Text = null;
            simulateContextMenuStrip.Enabled = false;
            
        }

        /// <summary>
        /// movePictureBox图像重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void movePictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (_getPointMode == 2 && numberOfSegments <= 0)//在取点模式为确定目标位置且已经取好一个点的情况执行
            {
                Pen p = new Pen(Color.White, 3);
                double l = allWires[nanowiresList.SelectedIndex].length * _sampsInLine / _xSize / 1000;
                if (currentPoint != newPoints[0])//一定要在新点和旋转中心不等时候操作
                {
                    PointF another = MathCalculate.GetPointToShow(newPoints[0].X, newPoints[0].Y, l, currentPoint, (double)movePictureBox.Width / (double)_sampsInLine);
                    e.Graphics.DrawLine(p, newPoints[0].X, newPoints[0].Y, another.X, another.Y);//画选定的纳米线长度的白色线
                }
            }
        }

        /// <summary>
        /// NanowiresList 索引变化回调函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NanowiresList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_readyToMove == true)//如果目前处在确定纳米线目标位置的状态，激活设置目标位置的按钮
            {
                setTarget.Enabled = true;
            }
        }

        /// <summary>
        /// showPictureBox鼠标按下回调函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//鼠标左击有效
            {
                if (showPictureBox.BackgroundImage != null)//图像显示内容不为空有效，即已经打开了一张图像文件
                {
                    clearShowPicBox.Enabled = true;
                    _getshowPictureBoxDistance = true;
                    pointFor_showPictureBox = new Point(e.X, e.Y);
                }
            }
        }

        /// <summary>
        /// showPictureBox鼠标抬起回调函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _getshowPictureBoxDistance = false;
        }

        /// <summary>
        /// showPictureBox鼠标移动回调函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            _currentPointOfshowPicB = new Point(e.X, e.Y);
            if (_getshowPictureBoxDistance)
            {
                showPictureBox.Invalidate();//刷新图像
            }
        }

        /// <summary>
        /// showPictureBox paint函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (_getshowPictureBoxDistance)
            {
                Pen p = new Pen(Color.White, 1);
                e.Graphics.DrawEllipse(p, pointFor_showPictureBox.X - 2, pointFor_showPictureBox.Y - 2, 4, 4);
                double distance;
                if (_currentPointOfshowPicB != pointFor_showPictureBox)//一定要在新点和旋转中心不等时候操作
                {
                    distance = MathCalculate.GetDistance(_currentPointOfshowPicB, pointFor_showPictureBox) / showPictureBox.Width * _xSize;//计算选定点的实际距离,单位um
                    e.Graphics.DrawLine(p, pointFor_showPictureBox.X, pointFor_showPictureBox.Y, _currentPointOfshowPicB.X, _currentPointOfshowPicB.Y);//画选定距离的白色线
                    e.Graphics.DrawString(distance.ToString("0.00") + " um", new Font("宋体", 8), new SolidBrush(Color.White),
                        (_currentPointOfshowPicB.X + pointFor_showPictureBox.X) / 2, (_currentPointOfshowPicB.Y + pointFor_showPictureBox.Y) / 2);//标注距离
                }
            }
        }

        /// <summary>
        /// 标签页选择变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void operationMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (operationMode.SelectedIndex == 0)
            {
                nanowiresList.SelectionMode = SelectionMode.MultiExtended;
                movePictureBox.Image = imageShow.ShowSamples(allWires, greyImage, pictureType, _numberOfLines);
            }
            else if(operationMode.SelectedIndex == 1)
            {
                if (allWires.Count > 0)
                {
                    nanowiresList.SelectionMode = SelectionMode.One;
                    compute.Enabled = false;//规划按钮禁用
                    orderTextBox.Text = null;//清空顺序文本内容
                    simulateToolStripMenuItem.Enabled = false;//动态显示右键菜单禁用
                    exportPathToolStripMenuItem.Enabled = false;//保存路径按钮禁用

                    bool bendWireFound = false;//表示是否发现有弯折的纳米线
                    foreach (Nanowires wire in allWires)
                    {
                        wire.ClearTarget();//清除已经有目标位置纳米线的目标位置
                                           //设置每个纳米线调直后的初始位置
                        if (wire.points.GetLength(0) == 2)//初始状态为直线
                        {
                            wire.SetStart();
                        }
                        else if (wire.points.GetLength(0) == 3)//初始状态为一次弯折
                        {
                            bendWireFound = true;
                            double[] result = new double[4];
                            result = MathCalculate.GetStraight(wire.points[0], wire.points[1], wire.points[2], allWires.IndexOf(wire));
                            wire.SetStart(result);
                        }
                        else if (wire.points.GetLength(0) == 4)//初始状态为两次弯折
                        {
                            bendWireFound = true;
                            double[] result = new double[4];
                            result = MathCalculate.GetStraight(wire.points[0], wire.points[1], wire.points[2], wire.points[3], allWires.IndexOf(wire));
                            wire.SetStart(result);
                        }//至多只有两次弯折
                    }
                    movePictureBox.Image = null;//清空movePictureBox的图像
                    movePictureBox.BackgroundImage = imageShow.ResizeImage(imageShow.ShowSamples(allWires, greyImage, _numberOfLines),
                        movePictureBox.Width, movePictureBox.Width * _numberOfLines / _sampsInLine);//设置movePictureBox的背景图像，因为Image需要用来选择纳米线的最终位置
                    if (bendWireFound)
                        MessageBox.Show("Bent wires are found!");//如果发现弯曲的纳米线，messagebox给出提示信息
                    else
                        MessageBox.Show("No bent wire is found!");//如果没有发现弯曲的纳米线，messagebox给出提示信息
                    _readyToMove = true;//表示全部纳米线已经调直完毕，可以准备选定位置进行移动     
                } 
            }
        }

        private void displayToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PictureMode pictureForm = new PictureMode();
            pictureForm.StartPosition = FormStartPosition.CenterParent;
            pictureForm.textFill(pictureType);
            pictureForm.ShowDialog();
            if (pictureForm.refresh && movePictureBox.Image != null)
            {
                RenewPicture();//刷新图像
                if (_readyToMove)//如果已经可以移动，开始选定位置
                {
                    movePictureBox.Image = null;//清空movePictureBox的图像
                    movePictureBox.BackgroundImage = imageShow.ResizeImage(imageShow.ShowSamples(allWires, greyImage, _numberOfLines),
                        movePictureBox.Width, movePictureBox.Width * _numberOfLines / _sampsInLine);//设置movePictureBox的背景图像，因为Image需要用来选择纳米线的最终位置
                }
                else //未选定位置，只进行识别步骤或未进行任何步骤
                {
                    movePictureBox.Image = imageShow.ShowSamples(allWires, greyImage, pictureType, _numberOfLines);
                }
            }
            pictureForm.Dispose();
        }

        /// <summary>
        /// 上下文菜单 clearShowPicBox -> Clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPictureBox.Image = null;//清空图像
            clearShowPicBox.Enabled = false;//上下文菜单 clearShowPicBox禁用
        }

        /// <summary>
        /// Compute 按钮按下回调函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void compute_Click(object sender, EventArgs e)
        {
            pB.Value = 0;
            order = new OrderPlanning(allWires.Count);
            pB.Value = 10;
            order.GetMoveStrategy();
            pB.Value = 90;
            FillInOrderTextBox();
            pB.Value = 100;
        }

        /// <summary>
        /// 填充顺序文本框内容
        /// </summary>
        private void FillInOrderTextBox()
        {
            string s = " ";
            if (order.findResult)
            {
                simulateToolStripMenuItem.Enabled = true;
                for (int i = 0; i < order.order.GetLength(0); i++)
                    s = s + Convert.ToString(order.order[i] + 1) + ' ';
                exportPathToolStripMenuItem.Enabled = true;
                simulateContextMenuStrip.Enabled = true;
            }
            else
            {
                simulateToolStripMenuItem.Enabled = false;
                s = s + "null ";
            }
            orderTextBox.Text = s;
        }

        /// <summary>
        /// 动态显示纳米线移动过程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simulateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pen pr = new Pen(Color.Red, 3);
            Pen pb = new Pen(Color.White, 3);
            Pen py = new Pen(Color.Yellow, 1);
            Graphics g;
                
            foreach (Nanowires w in allWires)
            {
                w.SetPresent();
                g = Graphics.FromImage(colorImage);
                g.DrawLine(pb, w.targetWire.firstPoint.X, _numberOfLines - 1 - w.targetWire.firstPoint.Y, w.targetWire.secondPoint.X, _numberOfLines - 1 - w.targetWire.secondPoint.Y);
                g.DrawLine(pr, w.presentWire.firstPoint.X, _numberOfLines - 1 - w.presentWire.firstPoint.Y, w.presentWire.secondPoint.X, _numberOfLines - 1 - w.presentWire.secondPoint.Y);
            }
            displayPictureBox.Image = colorImage;
            colorImage = gToC.PGrayToColor(greyImage, pictureType);
            displayPictureBox.Visible = true;
            Thread.Sleep(500);
            for (int i = 0; i < order.pushOrderForPath.Count; i++)
            {
                allWires[order.pushOrderForPath[i].index].SetPresent(order.pushOrderForPath[i].targetWire);
                g = Graphics.FromImage(colorImage);
                if (order.pushOrderForPath[i].isRotate)
                {
                    if (allWires[order.pushOrderForPath[i].index].rotatingPointPosition != 1)
                    {
                        float r = (float)MathCalculate.GetDistance(order.pushOrderForPath[i].presentWire.rotatePoint, order.pushOrderForPath[i].presentWire.firstPoint);
                        g.DrawArc(py, order.pushOrderForPath[i].presentWire.rotatePoint.X - r,
                            _numberOfLines - 1 - order.pushOrderForPath[i].presentWire.rotatePoint.Y - r, 2 * r, 2 * r,

                            MathCalculate.GetAngleDirection(order.pushOrderForPath[i].presentWire.firstPoint,
                            order.pushOrderForPath[i].presentWire.rotatePoint, MathCalculate.GetPointAfterVector(
                            order.pushOrderForPath[i].presentWire.rotatePoint, new PointF(1, 0))) *
                            (float)(MathCalculate.GetAngle(order.pushOrderForPath[i].presentWire.firstPoint,
                            order.pushOrderForPath[i].presentWire.rotatePoint, MathCalculate.GetPointAfterVector(
                            order.pushOrderForPath[i].presentWire.rotatePoint, new PointF(1, 0))) / Math.PI * 180),

                            MathCalculate.GetAngleDirection(order.pushOrderForPath[i].targetWire.firstPoint,
                            order.pushOrderForPath[i].presentWire.rotatePoint, order.pushOrderForPath[i].presentWire.firstPoint) *
                            (float)(MathCalculate.GetAngle(order.pushOrderForPath[i].targetWire.firstPoint,
                            order.pushOrderForPath[i].presentWire.rotatePoint, order.pushOrderForPath[i].presentWire.firstPoint) / Math.PI * 180)
                            );
                    }

                    if (allWires[order.pushOrderForPath[i].index].rotatingPointPosition != 0)
                    {
                        float r = (float)MathCalculate.GetDistance(order.pushOrderForPath[i].presentWire.rotatePoint, order.pushOrderForPath[i].presentWire.secondPoint);
                        g.DrawArc(py, order.pushOrderForPath[i].presentWire.rotatePoint.X - r,
                            _numberOfLines - 1 - order.pushOrderForPath[i].presentWire.rotatePoint.Y - r, 2 * r, 2 * r,

                            MathCalculate.GetAngleDirection(order.pushOrderForPath[i].presentWire.secondPoint,
                            order.pushOrderForPath[i].presentWire.rotatePoint, MathCalculate.GetPointAfterVector(
                            order.pushOrderForPath[i].presentWire.rotatePoint, new PointF(1, 0))) *
                            (float)(MathCalculate.GetAngle(order.pushOrderForPath[i].presentWire.secondPoint,
                            order.pushOrderForPath[i].presentWire.rotatePoint, MathCalculate.GetPointAfterVector(
                            order.pushOrderForPath[i].presentWire.rotatePoint, new PointF(1, 0))) / Math.PI * 180),

                            MathCalculate.GetAngleDirection(order.pushOrderForPath[i].targetWire.secondPoint,
                            order.pushOrderForPath[i].presentWire.rotatePoint, order.pushOrderForPath[i].presentWire.secondPoint) *
                            (float)(MathCalculate.GetAngle(order.pushOrderForPath[i].targetWire.secondPoint,
                            order.pushOrderForPath[i].presentWire.rotatePoint, order.pushOrderForPath[i].presentWire.secondPoint) / Math.PI * 180));
                    }
                    
                }
                else
                {
                    g.DrawLine(py, order.pushOrderForPath[i].presentWire.firstPoint.X, _numberOfLines - 1 - order.pushOrderForPath[i].presentWire.firstPoint.Y,
                        order.pushOrderForPath[i].targetWire.firstPoint.X, _numberOfLines - 1 - order.pushOrderForPath[i].targetWire.firstPoint.Y);
                    g.DrawLine(py, order.pushOrderForPath[i].presentWire.secondPoint.X, _numberOfLines - 1 - order.pushOrderForPath[i].presentWire.secondPoint.Y,
                        order.pushOrderForPath[i].targetWire.secondPoint.X, _numberOfLines - 1 - order.pushOrderForPath[i].targetWire.secondPoint.Y);
                }
                foreach (Nanowires w in allWires)
                {
                    g.DrawLine(pb, w.targetWire.firstPoint.X, _numberOfLines - 1 - w.targetWire.firstPoint.Y, w.targetWire.secondPoint.X, _numberOfLines - 1 - w.targetWire.secondPoint.Y);
                    g.DrawLine(pr, w.presentWire.firstPoint.X, _numberOfLines - 1 - w.presentWire.firstPoint.Y, w.presentWire.secondPoint.X, _numberOfLines - 1 - w.presentWire.secondPoint.Y);
                }
                
                displayPictureBox.Refresh();
                Thread.Sleep(1000);
                colorImage = gToC.PGrayToColor(greyImage, pictureType);
                if (i == order.pushOrderForPath.Count - 1)
                {
                    foreach (Nanowires w in allWires)
                    {
                        g = Graphics.FromImage(colorImage);
                        g.DrawLine(pr, w.presentWire.firstPoint.X, _numberOfLines - 1 - w.presentWire.firstPoint.Y, w.presentWire.secondPoint.X, _numberOfLines - 1 - w.presentWire.secondPoint.Y);
                    }
                    displayPictureBox.Refresh();
                    Thread.Sleep(1000);
                    colorImage = gToC.PGrayToColor(greyImage, pictureType);
                }
            }
 
            displayPictureBox.Visible = false;
            
        }


        /// <summary>
        /// 绘图操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void displayPictureBox_Paint(object sender, PaintEventArgs e)
        {
            displayPictureBox.Image = colorImage;
        }

        /// <summary>
        /// 保存路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavePath.PathGenerate();

            string str;
            FileStream fs = new FileStream("SavePath.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            str = sr.ReadLine();
            sr.Close();
            fs.Close();

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "(*.txt)|*.txt|(*.*)|*.*";
            sfd.AddExtension = true;
            sfd.InitialDirectory = str;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                fs = new FileStream(sfd.FileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                try
                {
                    foreach (double data in SavePath.manipulationPath)
                        sw.WriteLine(data.ToString("0.000"));
                    sw.Flush();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    sw.Close();
                    fs.Close();
                }

                //刷新路径保存进程提示栏内的信息
                int steps = SavePath.manipulationPath.Count / 6;
                pathSavedStripStatusLabel.Text = "Path saved at " + System.DateTime.Now.ToString() + " with " + steps.ToString() + " steps.";

                Pen py = new Pen(Color.Yellow, 1);
                Graphics g;
                g = Graphics.FromImage(colorImage);
                displayPictureBox.Image = colorImage;
                displayPictureBox.Visible = true;

                for (int i = 0; i < SavePath.manipulationPathForShow.Count; i += 2)
                {
                    g.DrawLine(py, SavePath.manipulationPathForShow[i], SavePath.manipulationPathForShow[i + 1]);
                    displayPictureBox.Refresh();
                    Thread.Sleep(5);
                }
                Thread.Sleep(1000);
                displayPictureBox.Visible = false;

                colorImage = gToC.PGrayToColor(greyImage, pictureType);
                //刷新初始文件路径
                str = sfd.FileName;
                sw = new StreamWriter("SavePath.txt");
                sw.WriteLine(str.Substring(0, str.LastIndexOf('\\')));
                sw.Close();

            }        
        }

        private void pathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PathParameter form = new PathParameter();
            form.StartPosition = FormStartPosition.CenterParent;
            form.SetValue();
            form.ShowDialog();
            form.Dispose();
        }

        /// <summary>
        /// 保存当前movePictureBox的图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str;
            FileStream fs = new FileStream("SavePicture.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            str = sr.ReadLine();
            sr.Close();
            fs.Close();

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "(*.bmp)|*.bmp|(*.*)|*.*";
            sfd.AddExtension = true;
            sfd.InitialDirectory = str;

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                if (movePictureBox.Image == null)
                {
                    Bitmap bmp = new Bitmap(movePictureBox.BackgroundImage);
                    bmp.Save(sfd.FileName);
                }
                else
                {
                    Bitmap bmp = new Bitmap(movePictureBox.Image);
                    bmp.Save(sfd.FileName);
                }

                StreamWriter sw = new StreamWriter("SavePicture.txt");
                str = sfd.FileName;
                sw.WriteLine(str.Substring(0, str.LastIndexOf('\\')));
                sw.Close();
            }
            
        }

        /// <summary>
        /// 更换实验为手动添加路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void traditionalNanomanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PushByHand form = new PushByHand();
            this.Dispose();
            form.ShowDialog();
            Application.Exit();
        }

    }
}
