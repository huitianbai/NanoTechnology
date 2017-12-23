using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NanoExperiment.Cutting
{
    class SavePath
    {
        public static List<PointF> handPath;
        public static double zStep, pushSpeed, hangSpeed;

        public static void Initial()
        {
            handPath = new List<PointF>();
            zStep = 0.02;
            pushSpeed = 200;
            hangSpeed = 10;
        }

        public static void Initial(double p, double h, double z)
        {
            pushSpeed = p;
            hangSpeed = h;
            zStep = z;
        }

        public static void Save()
        {
            string str;
            FileStream fs = new FileStream("SavePath.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            str = sr.ReadLine();
            sr.Close();
            fs.Close();

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "(*.txt)|*.txt|(*.*)|*.*";
            sfd.AddExtension = true;
            sfd.InitialDirectory = str;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                fs = new FileStream(sfd.FileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                try
                {
                    sw.WriteLine(zStep.ToString("0.000"));
                    sw.WriteLine(hangSpeed.ToString("0.000"));
                    for (int i = 0; i < handPath.Count; i += 2)
                    {
                        sw.WriteLine(handPath[i].X.ToString("0.000"));
                        sw.WriteLine(handPath[i].Y.ToString("0.000"));
                        sw.WriteLine(pushSpeed.ToString("0.000"));
                        sw.WriteLine(handPath[i + 1].X.ToString("0.000"));
                        sw.WriteLine(handPath[i + 1].Y.ToString("0.000"));
                        sw.WriteLine(hangSpeed.ToString("0.000"));
                    }
                    sw.Flush();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    sw.Close();
                    fs.Close();
                }
                str = sfd.FileName;
                sw = new StreamWriter("SavePath.txt");
                sw.WriteLine(str.Substring(0, str.LastIndexOf('\\')));
                sw.Close();
            }
        }
    }

}

