using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CwiczenieRGB
{
    public partial class Form1 : Form
    {

        //do zadania 1

        private System.Drawing.Graphics g1;
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Blue, 3);

        private System.Drawing.Graphics g2;
        private System.Drawing.Pen pen2 = new System.Drawing.Pen(Color.Blue, 3);

        private System.Drawing.Graphics g3;
        private System.Drawing.Pen pen3 = new System.Drawing.Pen(Color.Blue, 3);

        private System.Drawing.Graphics g4;
        private System.Drawing.Pen pen4 = new System.Drawing.Pen(Color.Blue, 3);

        private System.Drawing.Graphics g5;
        private System.Drawing.Pen pen5 = new System.Drawing.Pen(Color.Blue, 3);

        private System.Drawing.Graphics g6;
        private System.Drawing.Pen pen6 = new System.Drawing.Pen(Color.Blue, 3);


        //do zadania 2
        private System.Drawing.Graphics h2;
        private System.Drawing.Pen penH = new System.Drawing.Pen(Color.Blue, 3);


        public Form1()
        {
            InitializeComponent();

            g1 = pictureBox1.CreateGraphics();
            g2 = pictureBox2.CreateGraphics();
            g3 = pictureBox3.CreateGraphics();
            g4 = pictureBox4.CreateGraphics();
            g5 = pictureBox5.CreateGraphics();
            g6 = pictureBox6.CreateGraphics();
            h2 = pictureBox7.CreateGraphics();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //1
            for (int i = 0; i < 101; i++)
            {
                for (int j = 0; j < 101; j++)
                {
                    int u1 = (int)(i * 255.0 / 100);
                    int v1 = (int)(j * 255.0 / 100);
                    pen1.Color = Color.FromArgb(255, 255 - u1, v1);
                    g1.DrawRectangle(pen1, 0 + i, 0 + j, 1, 1);
                }
            }

            //2
            for (int i = 0; i < 101; i++)
            {
                for (int j = 0; j < 101; j++)
                {
                    int u2 = (int)(i * 255.0 / 100);
                    int v2 = (int)(j * 255.0 / 100);
                    pen2.Color = Color.FromArgb(0, v2, 255 - u2);
                    g2.DrawRectangle(pen2, 0 + i, 0 + j, 1, 1);
                }
            }
            //3
            for (int i = 0; i < 101; i++)
            {
                for (int j = 0; j < 101; j++)
                {
                    int u3 = (int)(i * 255.0 / 100);
                    int v3 = (int)(j * 255.0 / 100);
                    pen3.Color = Color.FromArgb(255 - u3, 0, v3);
                    g3.DrawRectangle(pen3, 0 + i, 0 + j, 1, 1);
                }
            }            
            //4
            for (int i = 0; i < 101; i++)
            {
                for (int j = 0; j < 101; j++)
                {
                    int u4 = (int)(i * 255.0 / 100);
                    int v4 = (int)(j * 255.0 / 100);
                    pen4.Color = Color.FromArgb(255 - u4, v4, 255);
                    g4.DrawRectangle(pen4, 0 + i, 0 + j, 1, 1);
                }
            }            
            //5
            for (int i = 0; i < 101; i++)
            {
                for (int j = 0; j < 101; j++)
                {
                    int u5 = (int)(i * 255.0 / 100);
                    int v5 = (int)(j * 255.0 / 100);
                    pen5.Color = Color.FromArgb(v5, 255 - u5, 0);
                    g5.DrawRectangle(pen5, 0 + i, 0 + j, 1, 1);
                }
            }
            //6
            for (int i = 0; i < 101; i++)
            {
                for (int j = 0; j < 101; j++)
                {
                    int u6 = (int)(i * 255.0 / 100);
                    int v6 = (int)(j * 255.0 / 100);
                    pen6.Color = Color.FromArgb(v6 ,255 , 255 - u6);
                    g6.DrawRectangle(pen6, 0 + i, 0 + j, 1, 1);
                }
            }
        }





        // zadania 2 


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label4.Text = "Red : " + trackBar1.Value.ToString();            mySetterCMY();            mySetterHSV();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label5.Text = "Blue : " + trackBar2.Value.ToString();            mySetterCMY();
            mySetterHSV();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label6.Text = "Green : " + trackBar3.Value.ToString();            mySetterCMY();
            mySetterHSV();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 101; i++)
            {
                for (int j = 0; j < 101; j++)
                {
                    int u5 = (int)(i * 255.0 / 100);
                    int v5 = (int)(j * 255.0 / 100);
                    penH.Color = Color.FromArgb(trackBar1.Value, trackBar3.Value, trackBar2.Value);
                    h2.DrawRectangle(penH, u5, v5, 1, 1);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        void mySetterCMY()
        {
            label7.Text = "Cyjan : " + (255 - trackBar1.Value).ToString();
            label8.Text = "Yellow : " + (255 - trackBar2.Value).ToString();
            label9.Text = "Magenta : " + (255 - trackBar3.Value).ToString();
        }


        void mySetterHSV()
        {
            float R_proc, B_proc, G_proc, Delta = 0;

            R_proc = trackBar1.Value / 255;
            B_proc = trackBar2.Value / 255;
            G_proc = trackBar3.Value / 255;

            label7.Text = "Cyjan : " + (255 - trackBar1.Value).ToString();
            label8.Text = "Yellow : " + (255 - trackBar2.Value).ToString();
            label9.Text = "Magenta : " + (255 - trackBar3.Value).ToString();

            float Cmax = Math.Max(R_proc, Math.Max(B_proc, G_proc));
            label10.Text = "Value : " + Cmax.ToString();
            float Cmin = Math.Min(R_proc, Math.Min(B_proc, G_proc));
            Delta = Cmax - Cmin;

            if (Delta == 0)
            {
                label12.Text = "Hue : " + Cmax.ToString() + "  stopni";
            }
            else
            {
                if (Cmax == R_proc)
                {
                    label12.Text = "Hue : " + 60 * (((G_proc - B_proc) / Delta) % 6) + "  stopni";
                }
                else
                {
                    if (Cmax == G_proc)
                    {
                        label12.Text = "Hue : " + 60 * (((B_proc - R_proc) / Delta)+ 2) + "  stopni";
                    }
                    else
                    {
                        if (Cmax == B_proc)
                        {
                            label12.Text = "Hue : " + 60 * (((R_proc - G_proc) / Delta) + 4) + "  stopni";
                        }
                        else
                        {

                        }
                    }
                }
            }






            if (Cmax == 0)
            {
                label11.Text = "Saturation : 0";
            }
            else
            {
                label11.Text = "Saturation : " + (Delta / Cmax).ToString();
            }







            //Value label10
            //Saturation   label11
            //Hue   label12


        }
    }
}
