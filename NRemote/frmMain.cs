using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace NRemote
{
    public partial class frmMain : Form
    {
        bool CaptureStart = false;
        public frmMain()
        {
            InitializeComponent();
            停止ToolStripMenuItem.Enabled = false;
            this.Text += $" <Ver:{Application.ProductVersion}>";
        }

 
        private void 開始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmSetting();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CaptureStart = true;
                backgroundWorker1.RunWorkerAsync();
                停止ToolStripMenuItem.Enabled = true;
                開始ToolStripMenuItem.Enabled = false;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            using (var capture = new VideoCapture())
            {
                //カメラの起動　
                capture.Open(Properties.Settings.Default.CameraID);

                if (!capture.IsOpened())
                {
                    throw new Exception("capture initialization failed");
                }

                Mat mat = new Mat();
                while (CaptureStart)
                {
                    try
                    {

                        capture.Read(mat);
                        if (mat.Empty())
                        {
                            continue;
                        }

                        if (mat.Size().Width > 0)
                        {
                            pictureBox1.Image = BitmapConverter.ToBitmap(mat);
                        }
                        Task.Delay(100);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }

        private void 停止ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaptureStart = false;
            停止ToolStripMenuItem.Enabled = false;
            開始ToolStripMenuItem.Enabled = true;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            if (CaptureStart)
            {
                pictureBox1.Cursor = Cursors.Cross;
            }
            else
            {
                pictureBox1.Cursor = Cursors.Default;
            }
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
#if DEBUG == false
            if (CaptureStart == false) return;
#endif
        }

        private void frmMain_KeyUp(object sender, KeyEventArgs e)
        {
#if DEBUG == false
            if (CaptureStart == false) return;
#endif
            Debug.WriteLine(e.KeyValue.ToString() );
        }
    }
}
