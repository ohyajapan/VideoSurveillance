using System;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using Accord.Video.DirectShow;

namespace VideoSurveillance
{
    public partial class SettingForm : Form
    {
        private readonly Properties.Settings settings = Properties.Settings.Default;

        public string VideoOutputDirectory
        {
            get { return videoOutputDirTextBox.Text; }
        }

        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            videoOutputDirTextBox.Text = settings.VideoOutputDirectory;
        }

        private void videoOutputDirRefButton_Click(object sender, EventArgs e)
        {
            using (var form = new FolderBrowserDialog())
            {
                form.SelectedPath = videoOutputDirTextBox.Text;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    videoOutputDirTextBox.Text = form.SelectedPath;
                }
            }
        }

        private void cameraSettingButton_Click(object sender, EventArgs e)
        {
            using (var form = new VideoCaptureDeviceForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    settings.CameraId = form.VideoDeviceMoniker;
                    settings.VideoFrameSize = form.VideoDevice.VideoResolution.FrameSize;
                }
            }
        }
    }
}
