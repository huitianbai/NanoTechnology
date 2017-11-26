using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiMode.Nanomanipulation
{
    public partial class SoftOrStiff : Form
    {
        public SoftOrStiff(double value)
        {
            InitializeComponent();
            textBox.Text = Convert.ToString(value);
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (this.textBox.Text != "")
                AutoDetect.softOrStiff = Convert.ToDouble(this.textBox.Text);
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (textBox.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(textBox.Text, out oldf);
                    b2 = float.TryParse(textBox.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }


    }
}
