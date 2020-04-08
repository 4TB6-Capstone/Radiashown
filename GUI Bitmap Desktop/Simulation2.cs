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

namespace GUI_Bitmap_Desktop
{
    public partial class Simulation2 : Form
    {
        Bitmap sim2Bitmap;
        BackgroundWorker workerThread = null;
        private Thread _backgroundWorkerThread;       

        public Simulation2()
        {
            InitializeComponent();
            InstantiateWorkerThread();

            pictureBox2.Image = pictureBox2.InitialImage;
            pictureBox3.Image = pictureBox3.InitialImage;

        }


        private Bitmap DrawFilledRectangle(int x, int y)
        {
            Bitmap sim2Bitmap = new Bitmap(x, y);
            using (Graphics graph = Graphics.FromImage(sim2Bitmap))
            {
                Rectangle ImageSize = new Rectangle(0, 0, x, y);
                graph.FillRectangle(Brushes.White, ImageSize);
            }

            return sim2Bitmap;
        }


        private void InstantiateWorkerThread()
        {
            workerThread = new BackgroundWorker();
            workerThread.ProgressChanged += WorkerThread_ProgressChanged;
            workerThread.DoWork += WorkerThread_DoWork;
            workerThread.RunWorkerCompleted += WorkerThread_RunWorkerCompleted;
            workerThread.WorkerReportsProgress = true;
            workerThread.WorkerSupportsCancellation = true;
        }

        private void WorkerThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Invoke(new Action(() => pictureBox1.Refresh()));
        }

        private void WorkerThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        void WorkerThread_DoWork(object sender, DoWorkEventArgs e)
        {
            sim2Bitmap = DrawFilledRectangle(1000, 1000);
            pictureBox1.Image = sim2Bitmap;
            
            try 
            {
                _backgroundWorkerThread = Thread.CurrentThread;
                int Ycount = 50;
                int Xcount = 50;

                for (; Ycount < 950; Ycount++)
                {
                    sim2Bitmap.SetPixel(50, Ycount, Color.Black);
                    this.Invoke(new Action(() => pictureBox1.Refresh()));
                    this.Invoke(new Action(() => robotLocation(50,Ycount)));
                }
                
                this.Invoke(new Action(() => radLocation(RandomNumber(550, 600), RandomNumber(550, 600))));

                for (; Xcount < 950; Xcount++)
                {
                    sim2Bitmap.SetPixel(Xcount, 950, Color.Black);
                    this.Invoke(new Action(() => pictureBox1.Refresh()));
                    this.Invoke(new Action(() => robotLocation(Xcount, 950)));
                }

                this.Invoke(new Action(() => radLocation(RandomNumber(550, 600), RandomNumber(550, 600))));

                for (Ycount = 950; Ycount > 50; Ycount--)
                {
                    sim2Bitmap.SetPixel(950, Ycount, Color.Black);
                    this.Invoke(new Action(() => pictureBox1.Refresh()));
                    this.Invoke(new Action(() => robotLocation(950, Ycount)));
                }
                this.Invoke(new Action(() => radLocation(RandomNumber(550, 600), RandomNumber(550, 600))));

                for (Xcount = 950; Xcount > 50; Xcount--)
                {
                    sim2Bitmap.SetPixel(Xcount, 50, Color.Black);
                    this.Invoke(new Action(() => pictureBox1.Refresh()));
                    this.Invoke(new Action(() => robotLocation(Xcount, 50)));
                }
                this.Invoke(new Action(() => radLocation(RandomNumber(550, 600), RandomNumber(550, 600))));

                SweepArea();

            }
            catch (ThreadAbortException)
            {
                // Do clean up here.
            }
        }


        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.BackColor = Color.FromName("Green");
            startButton.Text = "Sweeping";
            startButton.Enabled = false;
            emergencyButton.Visible = true;
            emergencyButton.Enabled = true;
            pathHome.Visible = false;
            //setupButton.Visible = false;

            if (_backgroundWorkerThread != null)
            {
                _backgroundWorkerThread.Resume();
            }
            else
            {
                workerThread.RunWorkerAsync();
            }

        }


        private void emergencyButton_Click(object sender, EventArgs e)
        {
            SuspendBackgroundWorker();
            pathHome.Visible = true;
            emergencyButton.Enabled = false;
            startButton.Enabled = true;
            startButton.Text = "Resume";

        }


        private void pathHome_Click(object sender, EventArgs e)
        {
            startButton.Visible = false;
            emergencyButton.Visible = false;
            using (Graphics graph = Graphics.FromImage(sim2Bitmap))
            {
                Pen redPen = new Pen(Color.Red, 1);
                Point location = pictureBox3.Location;
                int Xcount = location.X;
                int Ycount = location.Y;
                for (; Xcount > 50; Xcount--)
                {
                    this.Invoke(new Action(() => pictureBox1.Refresh()));
                    this.Invoke(new Action(() => robotLocation(Xcount, Ycount)));
                    sim2Bitmap.SetPixel(Xcount, Ycount, Color.Red);
                }
                for (; Ycount > 50; Ycount--)
                {                   
                    this.Invoke(new Action(() => pictureBox1.Refresh()));
                    this.Invoke(new Action(() => robotLocation(Xcount, Ycount)));
                    sim2Bitmap.SetPixel(Xcount, Ycount, Color.Red);
                }

                //graph.DrawLine(redPen, (location.X), (location.Y), 50, 50);
                this.Invoke(new Action(() => pictureBox1.Refresh()));

            }
            pathHome.Visible = false;

        }

        public void SweepArea()
        {
            Point radLocation = pictureBox2.Location;
            int radX = radLocation.X;
            int radY = radLocation.Y;
            
            Point robLocation = pictureBox3.Location;
            int robX = robLocation.X;
            int robY = robLocation.Y;

            for (; robX < radX; robX++)
            {
                this.Invoke(new Action(() => pictureBox1.Refresh()));
                this.Invoke(new Action(() => robotLocation(robX, robY)));
                sim2Bitmap.SetPixel(robX, robY, Color.Yellow);
            }
            for (; robY < radY; robY++)
            {
                this.Invoke(new Action(() => pictureBox1.Refresh()));
                this.Invoke(new Action(() => robotLocation(robX, robY)));
                sim2Bitmap.SetPixel(robX, robY, Color.Yellow);
            }

            for (int Xcount = robX - 100; Xcount < robX + 100; Xcount++)
            {
                for (int Ycount = robY - 100; Ycount < robY + 100; Ycount++)
                {
                    //robotLocation(Xcount, Ycount);
                    if (Xcount % 25 == 0 & Ycount % 25 == 0)
                    {
                        this.Invoke(new Action(() => DrawRadInfo(Xcount, Ycount, RandomNumber(0, 11))));
                        this.Invoke(new Action(() => pictureBox1.Refresh()));
                    }

                }
            }
        }
        public void SuspendBackgroundWorker()
        {
            if (_backgroundWorkerThread != null)
                _backgroundWorkerThread.Suspend();
        }
        public void AbortBackgroundWorker()
        {
            if (_backgroundWorkerThread != null)
                _backgroundWorkerThread.Abort();
        }


        private void DrawRadInfo(int xPos, int yPos, int radLevel)
        {
            var radColour = Brushes.White;
            using (Graphics graph = Graphics.FromImage(sim2Bitmap))
            {
                Rectangle ImageSize = new Rectangle(xPos, yPos, 25, 25);
                if (radLevel < 2)
                {
                    radColour = Brushes.Yellow;
                }
                if (radLevel > 1 & radLevel < 5)
                {
                    radColour = Brushes.Orange;
                }
                if (radLevel > 4 & radLevel < 10)
                {
                    radColour = Brushes.Red;
                }
                if (radLevel > 9)
                {
                    radColour = Brushes.DarkRed;
                }
                graph.FillRectangle(radColour, ImageSize);
            }

        }
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        private void robotLocation(int x, int y)
        {
            pictureBox3.Visible = true;
            pictureBox3.Location = new Point(x, y);
            pictureBox3.Refresh();
        }
        private void radLocation(int x, int y)
        {
            pictureBox2.Visible = true;
            pictureBox2.Location = new Point(x, y);
            pictureBox2.Refresh();
        }
        public void DrawLineInt(int x1, int y1, PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, 50, 50);
        }


    }


}
