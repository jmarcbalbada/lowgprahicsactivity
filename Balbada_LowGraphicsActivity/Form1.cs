using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balbada_LowGraphicsActivity
{

    public partial class Form1 : Form
    {
        Rectangle r;
        Graphics gr;

        int formWidth;
        int formHeight;

        Timer t = new Timer();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            formWidth = this.Width;
            formHeight = this.Height;
            r = new Rectangle(50, 50, 50, 1);
            Pen newPen = new Pen(Color.White, 1);
            gr = this.CreateGraphics();

            gr.DrawEllipse(newPen, r);

            t.Interval = 1;
            t.Tick += T_Tick;
            t.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            try
            {
                gr.DrawRectangle(new Pen(Brushes.White, 6), r);
            }catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void clearRectangle()
        {
            //gr.Clear(Color.Gray);
            this.Invalidate();
        }

        private void checkBoundary()
        {

        }

        private void rightMove()
        {
            r.X += 5;
        }

        private void leftMove()
        {
            r.X -= 5;
        }

        private void upMove()
        {
            r.Y -= 5;
        }

        private void downMove()
        {
            r.Y += 5;
        }


        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char pressed = Char.ToLower(e.KeyChar);
            switch(pressed)
            {
                case 'a':
                    {
                        //move to left <- (-X)
                        int newLeft = r.Left - 10;

                        if (newLeft >= 0)
                        {
                            if (r.Height != 1)
                            {
                                int temp = r.Width;
                                r.Width = r.Height;
                                r.Height = temp;
                            }
                            this.BackColor = Color.Gray;
                            clearRectangle();
                            leftMove();
                            Console.WriteLine("left = " + r.Left);
                            errorMsg.Text = "";
                        }
                        else
                        {
                            this.BackColor = Color.Black;
                            errorMsg_Click(sender, e);
                        }
                    }
                    break;
                case 'w':
                    // positive y (+Y)
                    {
                        int newUp = r.Top - 6;

                        if (newUp >= 0)
                        {
                            if(r.Height == 1)
                            {
                                int temp = r.Width;
                                r.Width = r.Height;
                                r.Height = temp;
                            }
                            this.BackColor = Color.Gray;
                            clearRectangle();
                            upMove();
                            Console.WriteLine("up = " + r.Top);
                            errorMsg.Text = "";
                        }
                        else
                        {
                            this.BackColor = Color.Black;
                            errorMsg_Click(sender, e);
                        }
                    }
                    break;
                case 's':
                    // negative y (-Y)
                    {
                        int newDown = r.Bottom + 10;

                        if (newDown <= 460)
                        {
                            if (r.Height == 1)
                            {
                                int temp = r.Width;
                                r.Width = r.Height;
                                r.Height = temp;
                            }
                            this.BackColor = Color.Gray;
                            clearRectangle();
                            downMove();
                            Console.WriteLine("down = " + r.Top + " formHeight = " + formHeight);
                            errorMsg.Text = "";
                        }
                        else
                        {
                            this.BackColor = Color.Black;
                            errorMsg_Click(sender, e);
                        }
                    }

                    break;
                case 'd':
                    // positive X -> (+X)
                    {
                        int newRight = r.Right + 25;

                        if (newRight <= formWidth)
                        {
                            if (r.Height != 1)
                            {
                                int temp = r.Width;
                                r.Width = r.Height;
                                r.Height = temp;
                            }
                            this.BackColor = Color.Gray;
                            clearRectangle();
                            rightMove();
                            Console.WriteLine("right = " + r.Right);
                            errorMsg.Text = "";
                        }
                        else
                        {
                            this.BackColor = Color.Black;
                            errorMsg_Click(sender, e);
                        }
                    }
                    break;
            }
            
            
        }


        private void errorMsg_Click(object sender, EventArgs e)
        {
            errorMsg.Text = "Error: object is out of range";
        }


        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
