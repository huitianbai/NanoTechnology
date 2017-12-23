using System;
using System.Windows.Forms;

namespace MultiMode.Nanoman
{
    public partial class PathParameter : Form
    {
        public PathParameter()
        {
            InitializeComponent();
        }

        public void SetValue()
        {
            pushSpeedTextBox.Text = Convert.ToString(SavePath.pushSpeed);
            hangSpeedTextBox.Text = Convert.ToString(SavePath.hangSpeed);
            zStepTextBox.Text = Convert.ToString(SavePath.zStep);
        }


        private void pushSpeedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (hangSpeedTextBox.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(hangSpeedTextBox.Text, out oldf);
                    b2 = float.TryParse(hangSpeedTextBox.Text + e.KeyChar.ToString(), out f);
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

        private void hangSpeedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (hangSpeedTextBox.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(zStepTextBox.Text, out oldf);
                    b2 = float.TryParse(zStepTextBox.Text + e.KeyChar.ToString(), out f);
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

        private void zStepTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (zStepTextBox.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(zStepTextBox.Text, out oldf);
                    b2 = float.TryParse(zStepTextBox.Text + e.KeyChar.ToString(), out f);
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

        private void confirm_Click(object sender, EventArgs e)
        {
            SavePath.Initial(
                Convert.ToDouble(pushSpeedTextBox.Text), Convert.ToDouble(hangSpeedTextBox.Text),
                Convert.ToDouble(zStepTextBox.Text)
                );
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
