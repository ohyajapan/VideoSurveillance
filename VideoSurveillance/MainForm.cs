using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using AForge.Vision.Motion;
using Accord.Video;
using Accord.Video.DirectShow;
using Accord.Video.FFMPEG;

namespace VideoSurveillance
{
    public partial class MainForm : Form
    {
        private readonly VideoCaptureDevice camera;
        private readonly VideoFileWriter videoWriter;
        private readonly MotionDetector motionDetector;
        private readonly Properties.Settings settings = Properties.Settings.Default;
        private const string videoFileName = "video.mp4";

        public MainForm()
        {
            InitializeComponent();

            videoWriter = new VideoFileWriter();
            camera = new VideoCaptureDevice();

            var detector = new TwoFramesDifferenceDetector(true);
            motionDetector = new MotionDetector(detector, new MotionAreaHighlighting());
        }

        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            if (camera.IsRunning)
            {
                MessageBox.Show("カメラが作動中です", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (settings.CameraId == string.Empty)
            {
                MessageBox.Show("カメラが選択されていません", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (settings.VideoOutputDirectory == string.Empty)
            {
                MessageBox.Show("動画出力先フォルダが設定されていません", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!Directory.Exists(settings.VideoOutputDirectory))
            {
                var message = $"動画出力先フォルダ {settings.VideoOutputDirectory} が存在しません";
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            camera.Source = settings.CameraId;
            var videoResolution = Array.Find(camera.VideoCapabilities, (c) => c.FrameSize == settings.VideoFrameSize);
            if (videoResolution == null)
            {
                MessageBox.Show("カメラ設定が無効です。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            camera.VideoResolution = videoResolution;
            camera.NewFrame += new NewFrameEventHandler(Camera_NewFrame);
            camera.PlayingFinished += new PlayingFinishedEventHandler(Camera_PlayingFinished);

            var videoFilePath = Path.Combine(settings.VideoOutputDirectory, videoFileName);
            videoWriter.Open(videoFilePath,
                videoResolution.FrameSize.Width,
                videoResolution.FrameSize.Height,
                videoResolution.AverageFrameRate,
                VideoCodec.MPEG4);

            camera.Start();

            startButton.Enabled = false;
            stopButton.Enabled = true;
            settingButton.Enabled = false;
            cameraSelectionButton.Enabled = false;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (camera.IsRunning)
            {
                camera.NewFrame -= new NewFrameEventHandler(Camera_NewFrame);
                camera.SignalToStop();
            }

            startButton.Enabled = true;
            stopButton.Enabled = false;
            settingButton.Enabled = true;
            cameraSelectionButton.Enabled = true;
        }

        private void Camera_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            using (var frame1 = eventArgs.Frame.Clone() as Bitmap)
            using (var frame2 = eventArgs.Frame.Clone() as Bitmap)
            {
                var motionLevel = motionDetector.ProcessFrame(frame1);
                Invoke(new Action(() =>
                {
                    motionLevelLabel.Text = motionLevel.ToString("f4");
                    pictureBox.Image = frame1.Clone() as Bitmap;
                }));

                videoWriter.WriteVideoFrame(frame2);
            }
        }

        private void Camera_PlayingFinished(object sender, ReasonToFinishPlaying reason)
        {
            Invoke(new Action(() =>
            {
                pictureBox.Image = null;
                motionLevelLabel.Text = string.Empty;
            }));

            if (videoWriter.IsOpen)
            {
                videoWriter.Close();
            }
        }

        private void SettingButton_Click(object sender, EventArgs e)
        {
            using (var form = new SettingForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    settings.VideoOutputDirectory = form.VideoOutputDirectory;
                    settings.Save();
                }
            }
        }

        private void CameraSelectionButton_Click(object sender, EventArgs e)
        {
            using (var form = new VideoCaptureDeviceForm())
            {
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                if (settings.CameraId != string.Empty)
                {
                    form.VideoDeviceMoniker = settings.CameraId;
                    form.CaptureSize = settings.VideoFrameSize;
                }

                if (form.ShowDialog() == DialogResult.OK)
                {
                    settings.CameraId = form.VideoDeviceMoniker;
                    settings.VideoFrameSize = form.VideoDevice.VideoResolution.FrameSize;
                    settings.Save();
                }
            }
        }
    }
}
