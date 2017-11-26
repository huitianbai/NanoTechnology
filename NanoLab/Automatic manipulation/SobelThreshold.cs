using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NanoExperiment.Automanipulation
{
    public partial class SobelThreshold : Form
    {
        public bool refresh = false;
        public SobelThreshold()
        {
            InitializeComponent();
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            this.tvalue.Text = Convert.ToString(this.trackBar.Value);
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            refresh = true;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
