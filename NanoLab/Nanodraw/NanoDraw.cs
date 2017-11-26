using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NanoExperiment.Cutting;
using NanoExperiment.Automanipulation;

namespace NanoExperiment.Nanodraw
{
    public partial class NanoDraw : Form
    {
        private uint linenumber;
        private uint circlenumber;
        private uint arcnumber;
        public Patternstruct patterndata;
        public int linewidthes;
        public NanoDraw()
        {
            InitializeComponent();
            linenumber = 1;
            circlenumber = 1;
            arcnumber = 1;
        }
        public TreeNode SearchNode(string name) {
            foreach (TreeNode n in pathTree.Nodes)
            {
                if (n.Text == name)
                {
                    return n;
                }
            }
             return null;
        }
        public void add_line_path(PointF pivot, PointF endpoint) {
            string strtemp = "Line" + linenumber.ToString();
            TreeNode parentNode = SearchNode("Line");
            TreeNode treeNode = new TreeNode();
            treeNode.Name = strtemp;
            treeNode.Text = strtemp;
            treeNode.ContextMenuStrip = contextMenuStrip1;
            parentNode.Nodes.Add(treeNode);
            patterndata.patternLine.Add(new PointF[2] { pivot, endpoint });
        }
        public void add_circle_path(PointF pivot, PointF endpoint)
        {
            string strtemp = "Circle" + circlenumber.ToString();
            TreeNode parentNode = SearchNode("Circle");
            TreeNode treeNode = new TreeNode();
            treeNode.Name = strtemp;
            treeNode.Text = strtemp;
            treeNode.ContextMenuStrip = contextMenuStrip1;
            parentNode.Nodes.Add(treeNode);
            patterndata.patternCircle.Add(new PointF[2] { pivot, endpoint });
        }
        public void add_arc_path(PointF pivot, PointF endpoint)
        {
            string strtemp = "Arc" + circlenumber.ToString();
            TreeNode parentNode = SearchNode("Arc");
            TreeNode treeNode = new TreeNode();
            treeNode.Name = strtemp;
            treeNode.Text = strtemp;
            treeNode.ContextMenuStrip = contextMenuStrip1;
            parentNode.Nodes.Add(treeNode);
            patterndata.patternCircle.Add(new PointF[2] { pivot, endpoint });
        }

        private void line_Click(object sender, EventArgs e)
        {
            Cutting.ManualCutting.mouseSelectMode = Cutting.ManualCutting.drawState.DRAWLINE;
        }

        private void arc_Click(object sender, EventArgs e)
        {
            Cutting.ManualCutting.mouseSelectMode = Cutting.ManualCutting.drawState.DRAWARC;
        }

        private void circle_Click(object sender, EventArgs e)
        {
            Cutting.ManualCutting.mouseSelectMode = Cutting.ManualCutting.drawState.DRAWCIRCLE;
        }

        private void contextMenuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode deletenode = pathTree.SelectedNode;
            string nodename = deletenode.Text;
            if (nodename.Contains("Line"))
            {
                int nodeindex = Convert.ToInt32(nodename.Substring(4));
                linenumber--;
                TreeNode tempnode = SearchNode("Line");
                int i = 0;
                foreach (TreeNode n in tempnode.Nodes) {
                    n.Text = "Line" + i.ToString();
                }
                patterndata.patternLine.RemoveAt(nodeindex);
            }
            else if (nodename.Contains("Circle")) {
                int nodeindex = Convert.ToInt32(nodename.Substring(6));
                circlenumber--;
                TreeNode tempnode = SearchNode("Circle");
                int i = 0;
                foreach (TreeNode n in tempnode.Nodes)
                {
                    n.Text = "Line" + i.ToString();
                }
                patterndata.patternCircle.RemoveAt(nodeindex);
            }
            else if (nodename.Contains("Arc")) {
                int nodeindex = Convert.ToInt32(nodename.Substring(3));
                arcnumber--;
                TreeNode tempnode = SearchNode("Arc");
                int i = 0;
                foreach (TreeNode n in tempnode.Nodes)
                {
                    n.Text = "Line" + i.ToString();
                }
                patterndata.patternCircle.RemoveAt(nodeindex);
            }


            deletenode.Remove();
        }

        private void lineWidthinput_TextChanged(object sender, EventArgs e)
        {
            linewidthes = Convert.ToInt32(lineWidthinput.Text);
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            List<PointF> datalist = new List<PointF>();
            if (patterndata.patternArc.Count > 0)
            {
                foreach (PointF[] t in patterndata.patternLine)
                {
                    
                    double length = MathCalculate.GetDistance(t[0], t[1]);
                    double angle = MathCalculate.GetAngleWithDirection(t[0], t[1]);
                    const double RULE = 0.020;
                    double density = RULE/(Cutting.ManualCutting._xSize/ Cutting.ManualCutting._sampsInLine);
                    double sinangle = Math.Sin(angle);
                    double cosangle = Math.Cos(angle);
                    for (double i =0; i < length; )
                    {
                        PointF temp1 = new PointF((float)i, (float)i+(float)linewidthes/2);
                        double XT = temp1.X * cosangle - temp1.Y * sinangle + t[0].X;
                        double YT = temp1.X * sinangle + temp1.Y * cosangle + t[0].Y;
                        temp1.X = (float)XT;
                        temp1.Y = (float)YT;
                        PointF temp2 = new PointF((float)i, (float)i - (float)linewidthes / 2);
                        XT = temp2.X * cosangle - temp2.Y * sinangle + t[0].X;
                        YT = temp2.X * sinangle + temp2.Y * cosangle + t[0].Y;
                        temp2.X = (float)XT;
                        temp2.Y = (float)YT;
                        datalist.Add(temp1);
                        datalist.Add(temp2);
                        i = i + density;                        
                    }
                    
                }
            }
            if (patterndata.patternCircle.Count > 0)
            {
                foreach (PointF[] t in patterndata.patternCircle)
                {
                    double radius =Math.Sqrt( (t[0].X - t[1].X) * (t[0].X - t[1].X) + (t[0].Y - t[1].Y) * (t[0].Y - t[1].Y));
                    for (double i = 0; i < Math.PI;)
                    {
                        float XT = (float)Math.Cos(i) * (float)(radius + linewidthes / 2) + t[0].X;
                        float YT = (float)Math.Sin(i) * (float)(radius + linewidthes / 2) + t[0].Y;
                        PointF temp1 = new PointF(XT, YT );
                        XT = (float)Math.Cos(i) * (float)(radius - linewidthes / 2) + t[0].X;
                        YT = (float)Math.Sin(i) * (float)(radius - linewidthes / 2) + t[0].Y;
                        PointF temp2 = new PointF(XT, YT); ;
                        i += (Math.PI / 360);
                        datalist.Add(temp1);
                        datalist.Add(temp2);
                    }
                }
            }
            if (patterndata.patternCircle.Count > 0)
            {
            }
        }

        private void NanoDraw_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                //应用程序要求关闭窗口
                case CloseReason.ApplicationExitCall:
                    e.Cancel = false;// 不拦截，响应操作
                    break;
                //自身窗口上的关闭按钮
                case CloseReason.FormOwnerClosing:
                    e.Cancel = true;//拦截，不响应操作
                    break;
                //MDI窗体关闭事件
                case CloseReason.MdiFormClosing:
                    e.Cancel = false;//不拦截，不响应操作
                    break;
                //不明原因的关闭
                case CloseReason.None:
                    break;
                //任务管理器关闭进程
                case CloseReason.TaskManagerClosing:
                    e.Cancel = true;//拦截，
                    break;
                //用户通过UI关闭窗口或者通过Alt+F4关闭窗口
                case CloseReason.UserClosing:
                    e.Cancel = true;//拦截，不响应操作
                    break;
                //操作系统准备关机
                case CloseReason.WindowsShutDown:
                    e.Cancel = false;//不拦截，响应操作
                    break;
                default:
                    break;
            }
        }
        //  public addpattern(List<>)
    }
}
