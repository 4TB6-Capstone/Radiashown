using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronPython.Hosting;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Web;
using System.Drawing.Design;
using System.Threading;

namespace GUI_Bitmap_Desktop
{
    public partial class Radiashown : Form
    {
        Bitmap myBitmap;
        BackgroundWorker workerThread = null;
        private Thread _backgroundWorkerThread;

        public Radiashown()
        {
            InitializeComponent();
            InstantiateWorkerThread();

            pictureBox2.Image = pictureBox2.InitialImage;
            pictureBox3.Image = pictureBox3.InitialImage;
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
            myBitmap = DrawFilledRectangle(1000, 1000);
            pictureBox1.Image = myBitmap;

            try
            {

            }
            catch (ThreadAbortException)
            {

                // Do clean up here.
            }
        }

        private Bitmap DrawFilledRectangle(int xRoom, int yRoom)
        {
            Bitmap myBitmap = new Bitmap(xRoom, yRoom);
            using (Graphics graph = Graphics.FromImage(myBitmap))
            {
                Rectangle ImageSize = new Rectangle(0, 0, xRoom, yRoom);
                graph.FillRectangle(Brushes.White, ImageSize);
            }

            return myBitmap;
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

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.BackColor = Color.FromName("Green");
            startButton.Text = "Sweeping";
            startButton.Enabled = false;
            emergencyButton.Visible = true;
            setupButton.Visible = false;

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
            startButton.BackColor = Color.FromName("FireBrick");
            startButton.Text = "Returning Home";
            startButton.Enabled = true;

            emergencyButton.Visible = false;

        }

        private void home_Click(object sender, EventArgs e)
        {
            startButton.BackColor = Color.FromName("Buttonshadow");
            startButton.Text = "Start Sweep";
            startButton.Enabled = true;

            emergencyButton.Visible = false;
            setupButton.Visible = true;
        }


        private void startScan()
        {
            //Graphics gr = CreateGraphics();
            myBitmap = DrawFilledRectangle(1000, 1000);
            pictureBox1.Image = myBitmap;

            /*ReadData();
            initial = bufferToJpeg();
            pictureBox1.Image = initial;
            var graphics = pictureBox1.CreateGraphics();
            while (true)
            {
                int pos = ReadData();
                Bitmap block = bufferToJpeg();
                graphics.DrawImage(block, BlockX(), BlockY());
            }*/
            

        }

        private void DrawRadInfo(int xPos, int yPos, int radLevel)
        {
            var radColour = Brushes.White;
            using (Graphics graph = Graphics.FromImage(myBitmap))
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
        private void drawPixel(int xPos, int yPos)
        {

            myBitmap.SetPixel(xPos, yPos, Color.Black);
            robotLocation(xPos, yPos);
            pictureBox1.Refresh();

        }
        private void radLocation(int xPos, int yPos)
        {
            pictureBox3.Visible = true;
            pictureBox3.Location = new Point(xPos, yPos);
            pictureBox3.Refresh();
        }
        private void robotLocation(int xPos, int yPos)
        {
            pictureBox2.Visible = true;
            pictureBox2.Location = new Point(xPos, yPos);
            pictureBox2.Refresh();
        }
        private void simButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Simulation2 fsim2 = new Simulation2();
            fsim2.ShowDialog();
            //this.Close();
        }

    }
}

        /*private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = "test";
            // 1) Create engine
            var engine = Python.CreateEngine();

            // 2) Provide script and arguments
            var script = @"getRadAssistData.py";
            var source = engine.CreateScriptSourceFromFile(script);

            // 3) Output redirect
            var eIO = engine.Runtime.IO;

            var results = new MemoryStream();
            eIO.SetOutput(results, Encoding.Default);

            // 4) Execute script
            var scope = engine.CreateScope();
            source.Execute(scope);

            // 5) Display output
            string str(byte[] x) => Encoding.Default.GetString(x);

            Console.WriteLine();
            Console.WriteLine("Results:");
            Console.WriteLine(str(results.ToArray()));


            // Display the pixel format in Label1.
            textBox1.Text = str(results.ToArray());
        }*/

