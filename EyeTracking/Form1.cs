using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using System.Drawing.Imaging;
using System.Threading;
using System.IO;
//using Emgu.CV.CvEnum;           // usual Emgu CV imports     //
//using Emgu.CV.UI;
using AForge;
using AForge.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using Point = System.Drawing.Point;

namespace EyeTracking
{
    public partial class Form1 : Form
    {
        //VideoCapture capture;

        public Form1()
        {
            InitializeComponent();
        }

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        private void ChooseCamera_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                ChooseCamera.Items.Add(filterInfo.Name);
            ChooseCamera.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[ChooseCamera.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += new NewFrameEventHandler(VideoCaptureDevice_NewFrame);
            videoCaptureDevice.Start();
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            /*CameraView.Image = (Bitmap)eventArgs.Frame.Clone();*/
            CameraView.SizeMode = PictureBoxSizeMode.StretchImage;
            Bitmap _bitmapSourceImage = (Bitmap)eventArgs.Frame.Clone();
            BlobDetection(_bitmapSourceImage);
            CameraView.Image = _bitmapSourceImage;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice.IsRunning == true)
                videoCaptureDevice.Stop();
        }
        private Bitmap BlobDetection(Bitmap _bitmapSourceImage)
        {
            Grayscale _grayscale = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap _bitmapGreyImage = _grayscale.Apply(_bitmapSourceImage);
            DifferenceEdgeDetector _differenceEdgeDetector = new DifferenceEdgeDetector();
            Bitmap _bitmapEdgeImage = _differenceEdgeDetector.Apply(_bitmapGreyImage);
            Threshold _threshold = new Threshold(40);
            Bitmap _bitmapBinaryImage = _threshold.Apply(_bitmapEdgeImage);

            BlobCounter _blobCounter = new BlobCounter();
            _blobCounter.MinWidth = 10;
            _blobCounter.MinHeight = 10;
            _blobCounter.FilterBlobs = true;
            _blobCounter.ProcessImage(_bitmapBinaryImage);
            Blob[] _blobPoints = _blobCounter.GetObjectsInformation();
            Graphics _g = Graphics.FromImage(_bitmapSourceImage);
            SimpleShapeChecker _shapeChecker = new SimpleShapeChecker();
            for (int i = 0; i < _blobPoints.Length; i++)
            {
                List<IntPoint> _edgePoint = _blobCounter.GetBlobsEdgePoints(_blobPoints[i]);
                AForge.Point _center;
                float _radius;
                if (_shapeChecker.IsCircle(_edgePoint, out _center, out _radius))
                {
                    string _shapeString = "" + _shapeChecker.CheckShapeType(_edgePoint);
                    System.Drawing.Font _font = new System.Drawing.Font("28 Days Later", 16);
                    System.Drawing.SolidBrush _brush = new System.Drawing.SolidBrush(System.Drawing.Color.Transparent);
                    Pen _pen = new Pen(Color.Red);
                    _pen.Width = 2;
                    int x = (int)_center.X;
                    int y = (int)_center.Y;
                    _g.DrawString(_shapeString, _font, _brush, x, y);
                    _g.DrawEllipse(_pen, (float)(_center.X - _radius),
                                         (float)(_center.Y - _radius),
                                         (float)(_radius * 2),
                                         (float)(_radius * 2));
                }
            }
            return _bitmapSourceImage;
        }
    }
}



