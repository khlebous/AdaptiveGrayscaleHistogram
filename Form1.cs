using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace histogram
{
    public partial class Form1 : Form
    {
        public ToolStripMenuItem tsmi;
        private string CurrentFile;
        BackgroundWorker backgroundWorker1 = new BackgroundWorker();
        private Bitmap imgGrey;
        Bitmap imgGreyTMP;
        Bitmap imgGreyTMP2;
        Bitmap bmp;
        Bitmap bmpGrey;
        public int bottomValue { get; set; } = 0;
        public int topValue { get; set; } = 255;
        public Form1()
        {
            InitializeComponent();
            tsmi = adaptiveToolStripMenuItem;
        }

        private void loadImageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff" + "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CurrentFile = openFileDialog1.FileName.ToString();
                bmp = new Bitmap(Image.FromFile(openFileDialog1.FileName));
                imgGrey = (Bitmap)bmp.Clone();
                pictureBox1.Image = bmp;
            }

            this.MaximumSize = new Size(bmp.Width + 0, bmp.Height + 0);
            this.Width = this.bmp.Width;
            this.Height = this.bmp.Height;
            grayscaleToolStripMenuItem.Enabled = true;
            adaptiveToolStripMenuItem.Enabled = true;
            histogramToolStripMenuItem.Enabled = true;
        }
        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            pictureBox1.Image = (Bitmap)imgGreyTMP2.Clone();
            if (progressBar1.Value > 99)
            {
                backgroundWorker1.Dispose();
                backgroundWorker1 = new BackgroundWorker();
                grayscaleToolStripMenuItem.Enabled = true;
                adaptiveToolStripMenuItem.Enabled = true;
            }
        }
        public void resetToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            //pictureBox1.Image = bmp;
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
                backgroundWorker1.ReportProgress(100);
            }
            else if (bmp != null)
                pictureBox1.Image = bmp;            
            grayscaleToolStripMenuItem.Enabled = true;
            adaptiveToolStripMenuItem.Enabled = true;
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            grayscaleToolStripMenuItem.Enabled = false;
            adaptiveToolStripMenuItem.Enabled = false;
            imgGreyTMP = (Bitmap)imgGrey.Clone();
            for (int i = 0; i < imgGreyTMP.Height; i++)
            {
                for (int j = 0; j < imgGreyTMP.Width; j++)
                {
                    Color pixel = imgGreyTMP.GetPixel(j, i);
                    int colorGrey = Convert.ToInt32(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
                    Color colorOut = Color.FromArgb(colorGrey, colorGrey, colorGrey);
                    imgGreyTMP.SetPixel(j, i, colorOut);
                }
                //Thread.Sleep(20);
                imgGreyTMP2 = (Bitmap)imgGreyTMP.Clone();
                backgroundWorker1.ReportProgress(100 * i / imgGreyTMP.Height + 1);
            }

        }
        private void backgroundWorker1_DoWork2(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            grayscaleToolStripMenuItem.Enabled = false;
            adaptiveToolStripMenuItem.Enabled = false;
            imgGreyTMP = (Bitmap)bmpGrey.Clone();
            int heightD = imgGreyTMP.Height / 2;
            int widthD = imgGreyTMP.Width / 2;
            while (heightD > 0 && widthD > 0)
            {
                if (heightD == 0)
                    heightD = 1;
                if (widthD == 0)
                    widthD = 1;
                for (int i = 0; i < imgGreyTMP.Width; i += widthD)
                {
                    for (int j = 0; j < imgGreyTMP.Height; j += heightD)
                    {
                        Color pixel = bmpGrey.GetPixel(i, j);
                        for (int k = 0; k < widthD && k + i < imgGreyTMP.Width; k++)
                            for (int l = 0; l < heightD && l + j < imgGreyTMP.Height; l++)
                                imgGreyTMP.SetPixel(k + i, j + l, pixel);
                    }
                }
                imgGreyTMP2 = (Bitmap)imgGreyTMP.Clone();
                heightD /= 2;
                widthD /= 2;
                backgroundWorker1.ReportProgress(100 - 100 * heightD / imgGreyTMP.Height - 1);
            }
            backgroundWorker1.ReportProgress(100);
        }

        private void grayscaleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.RunWorkerAsync();
        }
        private void adaptiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bmpGrey = (Bitmap)bmp.Clone();
            for (int i = 0; i < bmpGrey.Height; i++)
            {
                for (int j = 0; j < bmpGrey.Width; j++)
                {
                    Color pixel = bmp.GetPixel(j, i);
                    int colorGrey = Convert.ToInt32(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
                    if (colorGrey > topValue)
                        colorGrey = topValue;
                    else if (colorGrey < bottomValue)
                        colorGrey = bottomValue;
                    Color colorOut = Color.FromArgb(colorGrey, colorGrey, colorGrey);
                    bmpGrey.SetPixel(j, i, colorOut);
                }
            }
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork2;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.RunWorkerAsync();
        }
        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            histogram h = new histogram(this);
            h.ShowDialog(this);
        }
    }

}