using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MultiMode.Nanodraw;
using MultiMode.Nanomanipulation;


namespace MultiMode.Nanoman
{
    public partial class PushByHand : Form
    {
        //保存提取的AFM图像数据
        double[,] _dataArr;
        //用于图像显示的对象
        DisplayImage imageShow;
        /// <summary>
        /// 图像各种参数
        /// </summary>
        public static double _maxValue, _minValue, _xSize, _ySize;
        public static int _sampsInLine, _numberOfLines;
        /// <summary>
        /// 灰度图像 与彩色图像
        /// </summary>
        Bitmap greyImage, colorImage;
        //灰度图像转换伪彩色的类
        GreyToColor gToC = new GreyToColor();
        //图像伪彩色模式 这里只有一种“Iron”
        public string pictureType;
        //程序是否在手动路径添加的过程标志
        private bool isAddPathState;
        //表示添加路径所处的阶段 number = 1 表示选取起始点，number = 0 表示选取终止点
        private int number;
        /// <summary>
        /// pivotPoint 起始点在图像内的坐标， endPoint 终止点在图像内的坐标 ，currentPoint 鼠标当前位置的图像坐标 
        /// </summary>
        private PointF pivotPoint, endPoint, currentPoint;
        NanoDraw nanodraw;
      Patternstruct patternstore = new Patternstruct();
        // 
        public enum drawState{
            HANDPUSH = 0,
            DRAWLINE = 1,
            DRAWCIRCLE = 2,
            DRAWARC = 3,
            DRAWCOUNT
        }
        public static drawState mouseSelectMode;


        public PushByHand()
        {
            InitializeComponent();
            Initial();//初始化

            ///初始化保存路径的参数和路径
            SavePath.Initial();
            mouseSelectMode = drawState.DRAWCOUNT;


            ///如果在其他文件中已经打开图像，则直接打开该图像
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
                addPathToolStripMenuItem.Enabled = true;
                pictureToolStripMenuItem.Enabled = true;
            }
        }

        /// <summary>
        /// 切换到自动化纳米操纵界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nanomanipulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoDetect form = new AutoDetect();
            this.Dispose();
            form.ShowDialog();
            
            Application.Exit();//退出软件
        }

        /// <summary>
        /// 初始化函数
        /// </summary>
        private void Initial()
        {
            imageShow = new DisplayImage();
            pictureType = "Iron";//这里只提供一种颜色映射

            pictureToolStripMenuItem.Enabled = false;//保存图片菜单使能

            addPathToolStripMenuItem.Enabled = false;//
            deleteLastToolStripMenuItem.Enabled = false;
            deleteAllToolStripMenuItem.Enabled = false;
            exitToolStripMenuItem.Enabled = false;
            isAddPathState = false;//添加路径菜单禁用
            number = 1;
            SavePath.handPath = new List<PointF>();//清空已经存在的路径
        }

        /// <summary>
        /// 刷新图像
        /// </summary>
        private void RenewPicture()
        {
            ///////////////////设置PictureBox的大小，宽度为500像素固定值
            showPictureBox.Size = new Size(picturePanel.Width, (int)(picturePanel.Width / (_sampsInLine / _numberOfLines)));
            showPictureBox.Location= new Point (0, picturePanel.Height / 2 - (int)(picturePanel.Width / (_sampsInLine / _numberOfLines) / 2));
            
            colorImage = gToC.PGrayToColor(greyImage, pictureType);
            showPictureBox.BackgroundImage = imageShow.ResizeImage(colorImage, showPictureBox.Width, showPictureBox.Width * _numberOfLines / _sampsInLine);
            
            ////////////////////坐标轴信息标注////////////////////////
            Xmax.Text = Convert.ToString(_xSize / 2);
            Xmin.Text = "-" + Convert.ToString(_xSize / 2);
            Ymax.Text = Convert.ToString(_ySize / 2);
            Ymin.Text = "-" + Convert.ToString(_ySize / 2);
            Ymax.Location = new Point(Ymax.Location.X, picturePanel.Location.Y + showPictureBox.Location.Y);
            Ymin.Location = new Point(Ymin.Location.X, picturePanel.Location.Y + picturePanel.Height - showPictureBox.Location.Y - Ymin.Height);
            /////////////////////////////////////////////////////////
            //showPictureBox.Image = 
        }

        /// <summary>
        /// 打开文件
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
                    addPathToolStripMenuItem.Enabled = true;
                    pictureToolStripMenuItem.Enabled = true;

                    //刷新初始文件路径
                    str = dialog.FileName;
                    StreamWriter sw = new StreamWriter("AFM FigurePath.txt");
                    sw.WriteLine(str.Substring(0, str.LastIndexOf('\\')));
                    sw.Close();
                }
                    
            }
        }

        /// <summary>
        /// 复位菜单按下回调函数
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
        /// 保存当前showPictureBox 图像
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
                Bitmap bmp = new Bitmap(showPictureBox.BackgroundImage);//保存背景图像
                bmp.Save(sfd.FileName);

                StreamWriter sw = new StreamWriter("SavePicture.txt");
                str = sfd.FileName;
                sw.WriteLine(str.Substring(0, str.LastIndexOf('\\')));
                sw.Close();
            }
        }

        /// <summary>
        /// 鼠标按下点计算为AFM图像中的实际位置点
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private PointF GetRealPoint(PointF p)
        {
            return new PointF((float)(p.X / showPictureBox.Width * _xSize - _xSize / 2), (float)((showPictureBox.Height - 1 - p.Y) / showPictureBox.Height * _ySize - _ySize / 2));
        }

        private void showPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//鼠标左击完成取点操作
            {
                if (mouseSelectMode == drawState.HANDPUSH)
                {
                    if (number == 1)
                        pivotPoint = new PointF(e.X, e.Y);
                    else if (number == 0)
                    {
                        endPoint = new PointF(e.X, e.Y);
                        SavePath.handPath.Add(GetRealPoint(pivotPoint));
                        SavePath.handPath.Add(GetRealPoint(endPoint));
                        showPictureBox.BackgroundImage = imageShow.ResizeImage(RefreshFigure.BackgroundImageRefresh(colorImage),
                            showPictureBox.Width, showPictureBox.Width * _numberOfLines / _sampsInLine);
                        colorImage = gToC.PGrayToColor(greyImage, pictureType);
                        if (deleteLastToolStripMenuItem.Enabled == false)
                        {
                            deleteLastToolStripMenuItem.Enabled = true;
                            deleteAllToolStripMenuItem.Enabled = true;
                        }
                    }
                    number -= 1;

                    if (number < 0)
                        number = 1;
                }
                else if (mouseSelectMode == drawState.DRAWLINE)
                {
                    if (number == 1)
                        pivotPoint = new PointF(e.X, e.Y);
                    else if (number == 0)
                    {
                        endPoint = new PointF(e.X, e.Y);
                        //NanoDraw.add_line_path(pivotPoint,endPoint);
                        patternstore.patternLine.Add(new PointF[2] { new PointF((float)(pivotPoint.X / showPictureBox.Width * PushByHand._sampsInLine) , (float)(pivotPoint.Y / showPictureBox.Height * PushByHand._numberOfLines)),
                            new PointF((float)(endPoint.X / showPictureBox.Width * PushByHand._sampsInLine) , (float)(endPoint.Y / showPictureBox.Height * PushByHand._numberOfLines))});

                        showPictureBox.BackgroundImage = imageShow.ResizeImage(RefreshFigure.BackgroundImageRefresh(colorImage, (int) mouseSelectMode, patternstore.patternLine),
                                showPictureBox.Width, showPictureBox.Width * _numberOfLines / _sampsInLine);
                        colorImage = gToC.PGrayToColor(greyImage, pictureType);

                    }
                    number -= 1;
                    if (number < 0)
                        number = 1;
                }
                else if (mouseSelectMode == drawState.DRAWCIRCLE)
                {
                    if (number == 1)
                        pivotPoint = new PointF(e.X, e.Y);
                    else if (number == 0)
                    {
                        endPoint = new PointF(e.X, e.Y);
                        patternstore.patternCircle.Add(new PointF[2] { new PointF((float)(pivotPoint.X / showPictureBox.Width * PushByHand._sampsInLine) , (float)(pivotPoint.Y / showPictureBox.Height * PushByHand._numberOfLines)),
                            new PointF((float)(endPoint.X / showPictureBox.Width * PushByHand._sampsInLine) , (float)(endPoint.Y / showPictureBox.Height * PushByHand._numberOfLines))});
                        showPictureBox.BackgroundImage = imageShow.ResizeImage(RefreshFigure.BackgroundImageRefresh(colorImage, (int)mouseSelectMode, patternstore.patternCircle),
                                showPictureBox.Width, showPictureBox.Width * _numberOfLines / _sampsInLine);
                        colorImage = gToC.PGrayToColor(greyImage, pictureType);
                    }
                    number -= 1;
                    if (number < 0)
                        number = 1;
                }
                else if (mouseSelectMode == drawState.DRAWARC)
                {

                }
            }
            

        }

        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseSelectMode != drawState.DRAWCOUNT)
            {
                showPictureBox.Cursor = Cursors.Cross;//光标为十字
                currentPoint = new PointF(e.X, e.Y);
                if (number == 0)
                    showPictureBox.Invalidate();
            }
            else
                showPictureBox.Cursor = Cursors.Default;
        }

        private void nanodrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //showPictureBox.ContextMenu = null; 
            nanodraw = new NanoDraw();
            nanodraw.Show();
        }

        /// <summary>
        /// showPictureBox绘图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.White, 1);
            if (mouseSelectMode == drawState.HANDPUSH)
            {
                if (number <= 0 && isAddPathState)
                {
                    if (currentPoint != pivotPoint)//一定要在新点和旋转中心不等时候操作
                    {
                        e.Graphics.DrawLine(p, pivotPoint.X, pivotPoint.Y, currentPoint.X, currentPoint.Y);//画选定的纳米线长度的白色线
                    }
                }
            }
            else if (mouseSelectMode == drawState.DRAWLINE)
            {
                if (currentPoint != pivotPoint)//一定要在新点和旋转中心不等时候操作
                {
                    e.Graphics.DrawLine(p, pivotPoint.X, pivotPoint.Y, currentPoint.X, currentPoint.Y);//画选定的纳米线长度的白色线
                }
            }
            else if (mouseSelectMode == drawState.DRAWARC)
            {
                //if (currentPoint != pivotPoint)//一定要在新点和旋转中心不等时候操作
                //{
                //    e.Graphics.DrawLine(p, pivotPoint.X, pivotPoint.Y, currentPoint.X, currentPoint.Y);//画选定的纳米线长度的白色线
                //}
            }
            else if (mouseSelectMode == drawState.DRAWCIRCLE)
            {
                if (currentPoint != pivotPoint)//一定要在新点和旋转中心不等时候操作
                {
                    float radius = (float)MathCalculate.GetDistance(pivotPoint, currentPoint);

                    e.Graphics.DrawEllipse(p, pivotPoint.X - radius, pivotPoint.Y - radius, radius * 2, radius * 2);//画圆
                }
            }
           
        }

        /// <summary>
        /// 添加路径菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isAddPathState = true;
            addPathToolStripMenuItem.Enabled = false;
            exitToolStripMenuItem.Enabled = true;
            mouseSelectMode = drawState.HANDPUSH;
        }

        /// <summary>
        /// 退出路径添加过程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addPathToolStripMenuItem.Enabled = true;
            deleteAllToolStripMenuItem.Enabled = false;
            deleteLastToolStripMenuItem.Enabled = false;
            exitToolStripMenuItem.Enabled = false;
            isAddPathState = false;
            number = 1;
            mouseSelectMode = drawState.DRAWCOUNT;
        }

        /// <summary>
        /// 删除全部已经添加的路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteLastToolStripMenuItem.Enabled = false;
            deleteAllToolStripMenuItem.Enabled = false;
            SavePath.handPath = new List<PointF>();
            showPictureBox.BackgroundImage = imageShow.ResizeImage(colorImage, showPictureBox.Width, showPictureBox.Width * _numberOfLines / _sampsInLine);

        }

        /// <summary>
        /// 删除上一次添加的路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteLastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavePath.handPath.RemoveAt(SavePath.handPath.Count - 1);
            SavePath.handPath.RemoveAt(SavePath.handPath.Count - 1);
            if (SavePath.handPath.Count == 0)
            {
                showPictureBox.BackgroundImage = imageShow.ResizeImage(colorImage, showPictureBox.Width, showPictureBox.Width * _numberOfLines / _sampsInLine);
                deleteAllToolStripMenuItem.Enabled = false;
                deleteLastToolStripMenuItem.Enabled = false;
            }
            else
            {
                showPictureBox.BackgroundImage = imageShow.ResizeImage(RefreshFigure.BackgroundImageRefresh(colorImage),
                    showPictureBox.Width, showPictureBox.Width * _numberOfLines / _sampsInLine);
                colorImage = gToC.PGrayToColor(greyImage, pictureType);
            }

        }

        /// <summary>
        /// 保存路径参数设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PathParameter form = new PathParameter();
            form.SetValue();
            form.ShowDialog();
            form.Dispose();
        }

        /// <summary>
        /// 保存路径菜单回调函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void savePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavePath.Save();
            int steps = SavePath.handPath.Count / 2;
            pathSavedStripStatusLabel.Text = "Path saved at " + System.DateTime.Now.ToString() + " with " + steps.ToString() + " steps.";
        }    
    }
}
