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
    public partial class BendTimes : Form
    {
        public int value;
        public BendTimes()
        {
            InitializeComponent();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
                value = 1;
            else if (radioButton2.Checked)
                value = 2;
            else
                value = 3;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            value = 0;
            this.Close();
        }
    }
}
