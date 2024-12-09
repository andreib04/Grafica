﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arnold_Cat_Map
{
	public partial class Form1 : Form
	{
		ArnoldCatMap test;
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			test = new ArnoldCatMap(@"C:\Users\andre\Downloads\cat.jpg");
			timer1.Start();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			test.Iterate();
			pictureBox1.Image = test.source;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			button1_Click(sender, e);
		}
	}
}
