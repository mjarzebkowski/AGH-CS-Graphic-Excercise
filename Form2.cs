using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.M

namespace Cwiczenie3
{
    public partial class Form1 : Form
    {

        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Blue, 3);
        PointF Srodek = new PointF(200, 200);
        PointF P1 = new PointF(100, 100);
        PointF P2 = new PointF(300, 300);


        PointF P3 = new PointF(0, 0);
        PointF P4 = new PointF(0, 0);

        //BEZIER 
        PointF P5 = new PointF(10, 10);
        PointF P6 = new PointF(200, 10);
        PointF P7 = new PointF(10, 200);
        PointF P8 = new PointF(200, 200);
        // HERMITE
        PointF P9 = new PointF(100, 100);
        PointF P10 = new PointF(200, 100);
        PointF P11 = new PointF(-200, 0);
        PointF P12 = new PointF(0, 200);

        // Punkty pomocnicze
        PointF H1 = new PointF(0, 0);
        PointF H2 = new PointF(0, 0);
        PointF H3 = new PointF(0, 0);
        PointF H4 = new PointF(0, 0);




        public float wyznacznik1 = 0;
        public float wyznacznik2 = 0;

        float[][] array;

        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            g.DrawLine(pen1, this.P1, this.P2);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//p1x
        {
            this.P3.Y = float.Parse(textBox2.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//p1y
        {
            this.P3.X = float.Parse(textBox1.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            g.DrawLine(pen1, this.P1, this.P2);
            this.label5.Text = "Wynik:";
        }



        public bool czyMiesciSieMiedzyAiB(float A, float B, float X)
        {
            if (A >= B)
            {
                if (X <= A && X >= B)
                {
                    return true;
                }
            }
            else
            {
                if (X >= A && X <= B)
                {
                    return true;
                }
            }
            return false;
        }

        public void poKtorejStronieLezyPunkt(PointF A, PointF B, PointF R, float Wyz)
        {
            if (czyMiesciSieMiedzyAiB(A.X, B.X, R.X))
            {
                this.label5.Text = Text + "debug 1";
                if (czyMiesciSieMiedzyAiB(A.Y, B.Y, R.Y))
                {
                    this.label5.Text = Text + "Punkt mo¿na policzyæ";
                    //równanie prostej
                    PointF P3 = new PointF(0, 0);
                    PointF P4 = new PointF(0, 0);
                    //wyznacznik macierzy
                    Wyz = ((A.X * B.Y) + (A.Y * R.X) + (B.X * R.Y)) - ((R.X * B.Y) + (R.Y * A.X) + (B.X * A.Y));
                    if (Wyz == 0)
                    {
                        this.label5.Text = Text + " Na odcinku";
                    }
                    else
                    {
                        if (Wyz > 0)
                        {
                            this.label5.Text = Text + "Strona ujemna";
                        }

                        if (Wyz < 0)
                        {
                            this.label5.Text = Text + "Strona dodatnia";
                        }
                    }
                }
                else
                {
                    this.label5.Text = Text + "Punkt le¿y poza Y odcinka";
                }
            }
            else
            {
                this.label5.Text = Text + "Punkt le¿y poza X odcinka";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)//p2x
        {
            this.P4.X = float.Parse(textBox4.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)//p2y
        {
            this.P4.Y = float.Parse(textBox3.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //g.DrawLine(pen1, this.P3, this.P3);

            this.g.DrawEllipse(pen1, this.P3.X, this.P3.Y, 1, 1);

            poKtorejStronieLezyPunkt(this.P1, this.P2, this.P3, wyznacznik1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //g.DrawLine(pen1, this.P4, this.P4);
            this.g.DrawEllipse(pen1, this.P4.X, this.P4.Y, 1, 1);

            poKtorejStronieLezyPunkt(this.P1, this.P2, this.P4, wyznacznik2);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void rysunekBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            PointF A = this.P1;
            PointF B = this.P2;
            PointF R = this.P3;
            PointF D = this.P4;
            this.wyznacznik1 = ((A.X * B.Y) + (A.Y * R.X) + (B.X * R.Y)) - ((R.X * B.Y) + (R.Y * A.X) + (B.X * A.Y));
            this.wyznacznik2 = ((A.X * B.Y) + (A.Y * D.X) + (B.X * D.Y)) - ((D.X * B.Y) + (D.Y * A.X) + (B.X * A.Y));
            //this.label5.Text = "debug 3";
            if (this.wyznacznik1 > 0 && this.wyznacznik2 > 0)
            {
                this.label5.Text = "Punkty le¿y¹ po tej samej stronie";
            }
            if (this.wyznacznik1 > 0 && this.wyznacznik2 < 0)
            {
                this.label5.Text = "Punkty le¿y¹ po przeciwnej stronie";
            }
            if (this.wyznacznik1 < 0 && this.wyznacznik2 > 0)
            {
                this.label5.Text = "Punkty le¿y¹ po przeciwnej stronie";
            }
            if (this.wyznacznik1 < 0 && this.wyznacznik2 < 0)
            {
                this.label5.Text = "Punkty le¿y¹ po tej samej stronie";
            }
        }

        //void wartoscBeziera(float S)
        //{

        //}










        //        void Brezier(double Fstep)
        //        {

        //            //float Fstep;
        //            this.H1 = this.P5;
        //            // (/*2*/3 * i * Math.Pow(double.Parse( 1 - Fstep), 2.0) * P6.X) /*
        //            //this.H2.X = ( Math.Pow (1.0 - Fstep, (double)3 ) * (double)2.0 ) +





        ////(3 * i * Math.Pow(double.Parse( 1 - Fstep), 2.0) * P6.X) 
        ////(3 * Math.Pow(double.Parse( Fstep ), 2.0)*(1 - Fstep) * P7.X)
        ////(Math.Pow(double.Parse(Fstep), 3.0) * P8.X);

        //            //this.H1.X; 
        //            //this.P5.X; p1
        //            //this.P6.X; p2
        //            //this.P7.X; p3
        //            //this.P8.X; p4
        //   //* (double)(P5.X)) /*

        //            for (double i = 1; i >= 0 ; i = i - Fstep)
        //            {
        //                g.DrawLine(pen1, this.H1, this.H2);


        //                H2.X = (float)(  Math.Pow(1.0 - Fstep, 3.0 ) * 2.0) +                 (3.0 * i * Math.Pow((1.0 - Fstep), 2.0) * (double)P6.X) +                 (3.0 * Math.Pow((Fstep), 2.0) * (1.0 - Fstep) * (double)P7.X) +                 (Math.Pow((Fstep), 3.0) * (double)P8.X);




        //                //                this.H2.X = (/*1*/Math.Pow(double.Parse(1 - Fstep ), 3.0) * P5.X) /*
        //                //*/ (/*2*/3 * i * Math.Pow(double.Parse(1 -  Fstep ), 2.0) * P6.X) /*
        //                //*/ (/*3*/3 * Math.Pow(double.Parse(Fstep ), 2.0) * (1 - Fstep) * P7.X) /*
        //                //*/ (/*4*/Math.Pow(double.Parse(Fstep), 3.0) * P8.X);
        //            }
        //        }

        void krzywaHermitea(double Step)
        {
            for (double i = 1; i >= 0; i = i - Step)
            {
                g.DrawLine(pen1, this.H1, this.H2);

                this.H4.X = (float)(  /*1*/ (2*Math.Pow((i), 3) - 3 * Math.Pow((i), 2) + 1)*P9.X +    /*2*/ (- 2 * Math.Pow((i), 3) + 3 * Math.Pow((i), 2) ) * P9.X  /*3*/   (-2 * Math.Pow((i), 3) + 3 * Math.Pow((i), 2)) * P9.X /*4*/ (Math.Pow((i), 3) - Math.Pow((i), 2)) * P12.X);

                //// HERMITE
                //PointF P9 = new PointF(100, 100);
                //PointF P10 = new PointF(200, 100);
                //PointF P11 = new PointF(-200, 0);
                //PointF P12 = new PointF(0, 200);

                //// Punkty pomocnicze
                //PointF H1 = new PointF(0, 0);
                //PointF H2 = new PointF(0, 0);
                //PointF H3 = new PointF(0, 0);
                //PointF H4 = new PointF(0, 0);
            }
        }
    }
}
