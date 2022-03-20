using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using OpenCvSharp;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge;
using System.Drawing.Imaging;
using System.Threading;
using System.IO;

namespace EyeTracking
{
    
    class CircleDetect
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
}