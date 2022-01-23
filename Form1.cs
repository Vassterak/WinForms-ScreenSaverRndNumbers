﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RndScreenSaver
{
    public partial class Form1 : Form
    {
        private Point mouseLocation;
        MyRandom random = new MyRandom();

        public Form1 (Rectangle Bounds)
        {
            InitializeComponent();
            this.Bounds = Bounds;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
            TopMost = true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseLocation.IsEmpty)
            {
                // Terminate if mouse is moved a significant distance
                if (Math.Abs(mouseLocation.X - e.X) > 5 ||
                    Math.Abs(mouseLocation.Y - e.Y) > 5)
                    Application.Exit();
            }

            // Update current mouse location
            mouseLocation = e.Location;

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = random.LCG_CLike().ToString();
            try
            {
                label1.Left = (int)(random.LCG_CLike() % this.Width);
                label1.Top = (int)(random.LCG_CLike() % this.Height);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex);
                throw;
            }
            //label1.Top = (int)(this.Height / (random.LCG_CLike() % 20));
        }
    }
}
