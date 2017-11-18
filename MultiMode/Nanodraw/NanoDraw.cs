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

namespace MultiMode.Nanodraw
{
    public partial class NanoDraw : Form
    {
        public NanoDraw()
        {
            InitializeComponent();
        }
        public void add_line_path() {
        }
        public void delete_line_path()
        {

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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        //  public addpattern(List<>)
    }
}
