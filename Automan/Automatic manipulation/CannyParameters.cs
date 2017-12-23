using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autodetect
{
    public partial class CannyParameters : Form
    {
        public float THigh, TLow, sigmaValue;
        public bool refresh;
        public CannyParameters()
        {
            InitializeComponent();
            refresh = false;
        }

        public void textFill(string str1, string str2, string str3, string str4)
        {
            this.TH.Text = str1;
            this.TL.Text = str2;
            this.Sig.Text = str4;
        }

        private void Confirm_Click(object sender, EventArgs e)
        {           
            try
            {
                refresh = true;
                THigh = (float)Convert.ToDouble(this.TH.Text);
                TLow = (float)Convert.ToDouble(this.TL.Text);
                sigmaValue = (float)Convert.ToDouble(this.Sig.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            refresh = false;
            this.Close();
        }
    }
}
