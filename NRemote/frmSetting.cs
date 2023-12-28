using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NRemote
{
    public partial class frmSetting : Form
    {


        public frmSetting()
        {
            InitializeComponent();
            btnOK.Enabled = false;
            for (int i = 0; i < 10; i++)
            {
                using (var capture = new VideoCapture())
                {
                    capture.Open(i);
                    if (capture.IsOpened())
                    {
                        selCameraID.Items.Add(i);
                    }
                }
            }

            if (selCameraID.Items.Count > 0)
            {
                selCameraID.SelectedItem = Properties.Settings.Default.CameraID;
            }

            selCom.Value = Properties.Settings.Default.COM;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.CameraID = (int)selCameraID.SelectedItem;
            Properties.Settings.Default.COM = (int)selCom.Value ;
            Properties.Settings.Default.Save ();
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void selCameraID_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void selCameraID_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = selCameraID.SelectedItem != null;
        }
    }
}
