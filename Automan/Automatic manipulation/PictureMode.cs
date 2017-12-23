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
    public partial class PictureMode : Form
    {
        public bool refresh;
        public PictureMode()
        {
            InitializeComponent();
            this.pictureComboBox.Text = AutoDetect.pictureType;
        }

        private void pictureComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void textFill(string str)
        {
            this.pictureComboBox.Text = str;
        }
        private void Confirm_Click(object sender, EventArgs e)
        {
            AutoDetect.pictureType = this.pictureComboBox.Text;
            refresh = true;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            refresh = false;
            this.Close();
        }

    }
}
