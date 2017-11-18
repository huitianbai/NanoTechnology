using System;
using System.Windows.Forms;
using MultiMode.Nanomanipulation;
using MultiMode.Nanoman;

namespace MultiMode
{
    public partial class ModeSelect : Form
    {
        public static string AFMPicturePath;
        public ModeSelect()
        {
            InitializeComponent();
            AFMPicturePath = null;
        }

        private void load_Click(object sender, EventArgs e)
        {
            if (nanomanipulation.Checked)
            {
                AutoDetect form = new AutoDetect();
                this.Visible = false;
                form.ShowDialog();
                form.Dispose();

                Application.Exit();
            }
            else if (nanoman.Checked)
            {
                PushByHand form = new PushByHand();
                this.Visible = false;
                form.ShowDialog();
                form.Dispose();

                Application.Exit();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
