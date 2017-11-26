using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiMode;

namespace MultiMode.Nanomanipulation
{
    public partial class ChangeWireProperties : Form
    {
        public bool refresh;
        private string strFormer;
        public ChangeWireProperties()
        {
            InitializeComponent();
            refresh = false;
        }
        public void Initial(int NanowiresListSelectedIndice)
        {
            groupBox1.Text = "Properties of Number " + (NanowiresListSelectedIndice + 1).ToString();//更新form标题
            SoftOrStiff.Text = AutoDetect.allWires[NanowiresListSelectedIndice].softOrStiff;
            strFormer = AutoDetect.allWires[NanowiresListSelectedIndice].softOrStiff;
            rotationPivot.Text = Convert.ToString(AutoDetect.allWires[NanowiresListSelectedIndice].rotatingPointPosition);
            if (AutoDetect.allWires[NanowiresListSelectedIndice].points.GetLength(0) > 2)//如果为有弯折的纳米线，则只能为soft纳米线
            {
                SoftOrStiff.Items.Clear();
                SoftOrStiff.Items.Add("soft");
                SoftOrStiff.Text = "soft";
            }
            textBox.Text = AutoDetect.allWires[NanowiresListSelectedIndice].diameter.ToString("0.0");
            if (string.Equals(AutoDetect.allWires[NanowiresListSelectedIndice].softOrStiff, "stiff"))
            {
                position.Text = "Push position";
                rotationPivot.Items.Clear();
                rotationPivot.Items.Add("0.95");
                rotationPivot.Items.Add("0.05");
                rotationPivot.Text = Convert.ToString(AutoDetect.allWires[NanowiresListSelectedIndice].stiffPushPosition);
            }
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

        private void SoftOrStiff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.Equals(strFormer, SoftOrStiff.SelectedItem))
            {
                if (string.Equals(SoftOrStiff.SelectedItem, "soft"))
                {
                    position.Text = "Rotation pivot";
                    rotationPivot.Text = "0.5";
                    rotationPivot.Items.Clear();
                    rotationPivot.Items.Add("0");
                    rotationPivot.Items.Add("0.5");
                    rotationPivot.Items.Add("1.0");
                }
                else
                {
                    position.Text = "Push position";
                    rotationPivot.Text = "0.95";
                    rotationPivot.Items.Clear();
                    rotationPivot.Items.Add("0.95");
                    rotationPivot.Items.Add("0.05");
                }
                strFormer = SoftOrStiff.Text;
            } 
        }

        private void rotationPivot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (rotationPivot.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(rotationPivot.Text, out oldf);
                    b2 = float.TryParse(rotationPivot.Text + e.KeyChar.ToString(), out f);
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
