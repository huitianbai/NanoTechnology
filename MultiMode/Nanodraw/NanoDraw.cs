using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiMode.Nanoman;
using MultiMode.Automanipulation;

namespace MultiMode.Nanodraw
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
            PushByHand.mouseSelectMode = PushByHand.drawState.DRAWLINE;
        }

        private void arc_Click(object sender, EventArgs e)
        {
            PushByHand.mouseSelectMode = PushByHand.drawState.DRAWARC;
        }

        private void circle_Click(object sender, EventArgs e)
        {
            PushByHand.mouseSelectMode = PushByHand.drawState.DRAWCIRCLE;
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
            if (patterndata.patternArc.Count > 0)
            {
                foreach (PointF[] t in patterndata.patternLine)
                {
                    List<PointF> datalist =new List<PointF>(); 
                    double length = MathCalculate.GetDistance(t[0], t[1]);
                    double angle = MathCalculate.GetAngleWithDirection(t[0], t[1]);
                    const double RULE = 0.020;
                    double density = RULE/(PushByHand._xSize/ PushByHand._sampsInLine);
                    for (double i =0; i < length; i++)
                    {
                        PointF temp1 = new PointF((float)i, (float)i+(float)linewidthes/2);
                        PointF temp2 = new PointF((float)i, (float)i - (float)linewidthes / 2);
                        datalist.Add(temp1);
                        datalist.Add(temp2);
                        i = i + density;
                    }
                    
                }
            }
            if (patterndata.patternLine.Count > 0)
            {
            }
            if (patterndata.patternCircle.Count > 0)
            {
            }
        }

        //  public addpattern(List<>)
    }
}
