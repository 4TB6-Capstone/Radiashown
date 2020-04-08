using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Bitmap_Desktop
{
    public partial class radSim : Form
    {
        Bitmap simBitmap;
        public radSim()
        {
            InitializeComponent();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void startSim()
        {
            //Graphics gr = CreateGraphics();
            simBitmap = DrawFilledRectangle(1000, 1000);
            pictureBox1.Image = simBitmap;
            //Bitmap robotIcon = new Bitmap("C:/Users/Marilyn/Desktop/Engineering 5/4TB6/Icon/moon-rover50.png");
            //pictureBox2.Image = robotIcon;
            pictureBox2.Image = pictureBox2.InitialImage;
            //Bitmap radIcon = new Bitmap("C:/Users/Marilyn/Desktop/Engineering 5/4TB6/Icon/radioactive-48.png");
            //pictureBox3.Image = radIcon;
            pictureBox3.Image = pictureBox3.InitialImage;
            //simBitmap.SetResolution(500, 500);
            //pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

            simulationPerimeter();

        }

        private Bitmap DrawFilledRectangle(int x, int y)
        {
            Bitmap simBitmap = new Bitmap(x, y);
            using (Graphics graph = Graphics.FromImage(simBitmap))
            {
                Rectangle ImageSize = new Rectangle(0, 0, x, y);
                graph.FillRectangle(Brushes.White, ImageSize);
            }

            return simBitmap;
        }
        private void DrawRadInfo(int xPos, int yPos, int radLevel)
        {
            var radColour = Brushes.White;
            using (Graphics graph = Graphics.FromImage(simBitmap))
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

        private void simulationSweep()
        {

            for (int Xcount = 50; Xcount < 950; Xcount = Xcount + 25)
            {
                for (int Ycount = 50; Ycount < 950; Ycount = Ycount + 25)
                {
                    //robotLocation(Xcount, Ycount);
                    if (Xcount % 25 == 0 & Ycount % 25 == 0)
                    {
                        DrawRadInfo(Xcount, Ycount, RandomNumber(0, 11));
                    }
                    pictureBox1.Refresh();

                }
            }
        }
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        private void simulationPerimeter()
        {
            radLocation(500, 500);
            for (int Ycount = 50; Ycount < 950; Ycount++)
            {
                simBitmap.SetPixel(50, Ycount, Color.Black);
                robotLocation(50, Ycount);
                pictureBox1.Refresh();
            }

            for (int Xcount = 50; Xcount < 950; Xcount++)
            {
                simBitmap.SetPixel(Xcount, 950, Color.Black);
                robotLocation(Xcount, 950);
                pictureBox1.Refresh();
            }

            for (int Ycount = 950; Ycount > 50; Ycount--)
            {
                simBitmap.SetPixel(950, Ycount, Color.Black);
                robotLocation(950, Ycount);
                pictureBox1.Refresh();
            }

            for (int Xcount = 950; Xcount > 50; Xcount--)
            {
                simBitmap.SetPixel(Xcount, 50, Color.Black);
                robotLocation(Xcount, 50);
                pictureBox1.Refresh();
            }
            simulationSweep();
        }

        private void radLocation(int x, int y)
        {
            pictureBox3.Location = new Point(x, y);
            pictureBox3.Refresh();
        }
        private void robotLocation(int x, int y)
        {
            pictureBox2.Location = new Point(x, y);
            pictureBox2.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            startSim();
        }
    }
}
