using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coloring
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		MyGraphics graphics;
		Map test;
		private void Form1_Load(object sender, EventArgs e)
		{
			graphics = new MyGraphics(pictureBox1);
			test = new Map(3, graphics.resX, graphics.resY);
			test.Draw(graphics.grp);
			test.FillPonder(graphics.bmp);

			graphics.Refresh();
		}
	}
}
