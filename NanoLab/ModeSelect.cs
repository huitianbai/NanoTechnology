using System;
using System.Windows.Forms;
using NanoExperiment.Automanipulation;
using NanoExperiment.Cutting;

namespace NanoExperiment
{
    public partial class ModeSelect : Form
    {
        public static string AFMPicturePath;
        public enum experiment { 
            AUTOMANIPULATION = 0,
            MANUALCUTTING = 1,
            NANODRAW = 2,
            NANOBITMAP = 3,
            NULL
        }
        public static experiment presentExperiment, nextExperiment;

        public ModeSelect()
        {
            InitializeComponent();
            AFMPicturePath = null;
            nextExperiment = experiment.NULL;
        }

        private void load_Click(object sender, EventArgs e)
        {
            if (automanipulation.Checked)
            {
                presentExperiment = experiment.AUTOMANIPULATION;
                nextExperiment = presentExperiment;
                AutoDetect form = new AutoDetect();
                this.Visible = false;
                form.ShowDialog();
                form.Dispose();
                SelectNextExperiment();
                Application.Exit();
            }
            else if (manualCutting.Checked)
            {
                presentExperiment = experiment.MANUALCUTTING;
                nextExperiment = presentExperiment;
                ManualCutting form = new ManualCutting(presentExperiment);
                this.Visible = false;
                form.ShowDialog();
                form.Dispose();
                SelectNextExperiment();
                Application.Exit();
            }
            else if (nanodraw.Checked)
            {
                presentExperiment = experiment.NANODRAW;
                nextExperiment = presentExperiment;
                ManualCutting form = new ManualCutting(presentExperiment);
                this.Visible = false;
                form.ShowDialog();
                form.Dispose();
                SelectNextExperiment();
                Application.Exit();
            }
        }

        private void SelectNextExperiment()
        {
            while (nextExperiment != presentExperiment)
            {
                switch (nextExperiment) {
                    case experiment.AUTOMANIPULATION:
                        presentExperiment = experiment.AUTOMANIPULATION;
                        AutoDetect form = new AutoDetect();
                        this.Visible = false;
                        form.ShowDialog();
                        form.Dispose();
                        break;
                    case experiment.MANUALCUTTING:
                        presentExperiment = experiment.MANUALCUTTING;
                        ManualCutting form1 = new ManualCutting(presentExperiment);
                        this.Visible = false;
                        form1.ShowDialog();
                        form1.Dispose();
                        break;
                    case experiment.NANODRAW:
                        presentExperiment = experiment.NANODRAW;
                        ManualCutting form2 = new ManualCutting(presentExperiment);
                        this.Visible = false;
                        form2.ShowDialog();
                        form2.Dispose();
                        break;
                    case experiment.NANOBITMAP:
                        presentExperiment = experiment.NANOBITMAP;
                        break;
                    default:
                        break;

                }

            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
