using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnowFall
{
    class Particles
    {
        static Random rnd = new Random();

        static int width = 800;
        static int height = 800;

        public double xPos;
        public double yPos;
        public int size;

        public double ySpeed;
        public double xSpeed;
        public double acc = 0.01;


        //Random xDir... 0 = left , 1 = right
        int index = rnd.Next(0, 2);

        public Particles()
        {
            this.xPos = rnd.Next(0, width);
            this.yPos = rnd.Next(0, height);
            this.size = rnd.Next(6, 15);
            this.ySpeed = 0.5;
            this.xSpeed = 0.25;
            
        }

        static System.Drawing.SolidBrush white = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        static Pen whitee = new Pen(Color.White);

        public static void UpdateSnow(Graphics g, Particles snow)
        { 
            //Bigger particles move faster
            snow.yPos += snow.ySpeed;
            if(snow.size < 9)
            {
                snow.ySpeed += 0.015;
            }
            else if(snow.size >=9 && snow.size <= 12)
            {
                snow.ySpeed += 0.02;
            }
            else if(snow.size > 12)
            {
                snow.ySpeed += 0.025;
            }


            //Random xDirection
            if (snow.index == 0)
            {
                snow.xPos -= snow.xSpeed;
            }
            else if (snow.index == 1)
            {
                snow.xPos += snow.xSpeed;
            }


            g.FillEllipse(white, (float)snow.xPos, (float)snow.yPos, snow.size, snow.size);

            //Restart particles above window, reset y speed, reset x position
            if(snow.yPos > height)
            {
                snow.yPos = -10;
                snow.ySpeed = 0.5;
                snow.xPos = rnd.Next(0, width);
            }
        }

    }

}
