using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowFall
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < numberOfParticles; i++)
            {
                Particles snow = new Particles();
                mySnow[i] = snow;
            }
        }
        System.Drawing.SolidBrush white = new System.Drawing.SolidBrush(System.Drawing.Color.White);

        Particles[] mySnow = new Particles[numberOfParticles];
        static int numberOfParticles = 200;


        private void Draw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (Particles item in mySnow)
            {
                Particles.UpdateSnow(g, item);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
